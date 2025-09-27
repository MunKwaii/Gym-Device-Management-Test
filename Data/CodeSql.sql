--Tạo database QLGYM
CREATE DATABASE QLGYM
USE QLGYM

---Khu thiết bị 

--Bảng loại thiết bị
CREATE TABLE LoaiThietBi(
	MaLoai VARCHAR(10) PRIMARY KEY,
	TenLoai NVARCHAR(100) NOT NULL
);


--Bảng ThietBi
CREATE TABLE ThietBi (
    MaTB VARCHAR(10) PRIMARY KEY,
    TenTB NVARCHAR(100) NOT NULL,
    MaLoai VARCHAR(10),
    NgayNhap DATE NOT NULL,
    TinhTrang NVARCHAR(20) NOT NULL
        CHECK (TinhTrang IN (N'Đang sử dụng', N'Cần bảo trì', N'Hỏng', N'Thanh lý')),
    ViTri NVARCHAR(100),
    TinhTrangVeSinh NVARCHAR(20),   
    CONSTRAINT fk_ThietBi_Loai FOREIGN KEY (MaLoai) REFERENCES LoaiThietBi(MaLoai)
);



--Bảng BaoTri 
CREATE TABLE BaoTri (
    MaBT INT IDENTITY(1,1) PRIMARY KEY,
    MaTB VARCHAR(10) NOT NULL,
    MaNV VARCHAR(10),                -- để liên kết sang nhân viên
    NgayBaoTri DATE NOT NULL,
    MoTa NVARCHAR(200),
    ChiPhi FLOAT CHECK (ChiPhi >= 0),
    KetQua NVARCHAR(50),             -- ví dụ: 'Sửa xong', 'Không sửa được', 'Hỏng'

    -- Khóa ngoại tới ThietBi 
    CONSTRAINT fk_BaoTri_ThietBi FOREIGN KEY (MaTB) 
        REFERENCES ThietBi(MaTB),

    -- Khóa ngoại tới NhanVien 
    CONSTRAINT fk_BaoTri_NhanVien FOREIGN KEY (MaNV) 
        REFERENCES NhanVien(MaNV)
);
GO


--Bảng VeSinhLog
CREATE TABLE VeSinhLog (
    MaVS INT IDENTITY PRIMARY KEY,
    MaTB VARCHAR(10) REFERENCES ThietBi(MaTB),
    MaNV VARCHAR(10),
    NgayVeSinh DATE NOT NULL
);
GO

--Bảng NhanVien
CREATE TABLE NhanVien (
	MaNV VARCHAR(10) PRIMARY KEY,
	HoTen NVARCHAR(50) NOT NULL,
	NgaySinh DATE,
	SoDienThoai VARCHAR(20),
	Gmail NCHAR(50),
	DiaChi NVARCHAR(200),
	GioiTinh BIT,
	MaCV VARCHAR(10) NOT NULL,
	HinhAnh NCHAR(50),
	CONSTRAINT fk_NhanVien_CongViec FOREIGN KEY (MaCV) REFERENCES CongViec(MaCV)
)

--Bảng CongViec
CREATE TABLE CongViec (
	MaCV VARCHAR(10) PRIMARY KEY,
	TenCV NVARCHAR(50) NOT NULL,
	LuongCa FLOAT NOT NULL
)

--Bảng Acount
CREATE TABLE Account(
	Username VARCHAR(50) PRIMARY KEY,
	Password VARCHAR(50) NOT NULL,
	MaNV VARCHAR(10) UNIQUE NOT NULL,
	FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
)

------------------------------VIEW---------------------------------
CREATE VIEW v_ThietBi
AS
SELECT tb.MaTB,
       tb.TenTB,
       tb.MaLoai,
       lt.TenLoai,
       tb.NgayNhap,
       tb.TinhTrang,
       tb.ViTri
FROM ThietBi tb
LEFT JOIN LoaiThietBi lt ON tb.MaLoai = lt.MaLoai;
GO


CREATE VIEW v_GetCanBaoTri
AS
SELECT MaTB, TenTB, TinhTrang, ViTri
FROM ThietBi
WHERE TinhTrang = N'Cần bảo trì';
GO


CREATE VIEW v_VeSinhTheoThang
AS
SELECT YEAR(NgayVeSinh) AS Nam, MONTH(NgayVeSinh) AS Thang, COUNT(*) AS SoLan
FROM VeSinhLog
GROUP BY YEAR(NgayVeSinh), MONTH(NgayVeSinh);
GO


CREATE VIEW v_ThietBi_VeSinh
AS
SELECT 
    tb.MaTB,
    tb.TenTB,
    tb.TinhTrangVeSinh,
    MAX(v.NgayVeSinh) AS NgayVeSinh
FROM ThietBi tb
LEFT JOIN VeSinhLog v ON v.MaTB = tb.MaTB
GROUP BY tb.MaTB, tb.TenTB, tb.TinhTrangVeSinh;
GO



------------------------------TRIGGER---------------------------------
CREATE TRIGGER trg_VeSinh_Update
ON ThietBi
AFTER UPDATE
AS
BEGIN

    -- Ngăn không cho Bẩn -> Sạch
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN deleted d ON i.MaTB = d.MaTB
        WHERE d.TinhTrangVeSinh = N'Bẩn'
          AND i.TinhTrangVeSinh = N'Sạch'
    )
    BEGIN
        RAISERROR (N'Không thể chuyển trực tiếp từ Bẩn sang Sạch. Hãy qua trạng thái Đang vệ sinh trước.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    -- Giữ nguyên logic cũ: log khi Đang vệ sinh -> Sạch
    IF UPDATE(TinhTrangVeSinh)
    BEGIN
        INSERT INTO VeSinhLog(MaTB, NgayVeSinh)
        SELECT i.MaTB, GETDATE()
        FROM inserted i
        JOIN deleted d ON i.MaTB = d.MaTB
        WHERE d.TinhTrangVeSinh = N'Đang vệ sinh'
          AND i.TinhTrangVeSinh = N'Sạch';
    END
END
GO


CREATE TRIGGER trg_UpdateVeSinh ON v_ThietBi_VeSinh
INSTEAD OF UPDATE
AS
BEGIN
    UPDATE ThietBi
    SET TinhTrangVeSinh = i.TinhTrangVeSinh
    FROM ThietBi tb
    INNER JOIN inserted i ON tb.MaTB = i.MaTB;
END
GO


CREATE TRIGGER trg_CheckChiPhi
ON BaoTri
AFTER INSERT
AS
BEGIN
    -- Nhánh 1: Nếu chi phí vượt quá 5 triệu → ép kết quả và tình trạng thành Hỏng
    UPDATE bt
    SET KetQua = N'Hỏng'
    FROM BaoTri bt
    INNER JOIN inserted i ON bt.MaBT = i.MaBT
    WHERE i.ChiPhi > 5000000;

    UPDATE tb
    SET tb.TinhTrang = N'Hỏng'
    FROM ThietBi tb
    INNER JOIN inserted i ON tb.MaTB = i.MaTB
    WHERE i.ChiPhi > 5000000;

    -- Nhánh 2: Nếu chi phí hợp lý và kết quả = 'Sửa xong' → chuyển thiết bị về 'Đang sử dụng'
    UPDATE tb
    SET tb.TinhTrang = N'Đang sử dụng'
    FROM ThietBi tb
    INNER JOIN inserted i ON tb.MaTB = i.MaTB
    INNER JOIN BaoTri bt ON bt.MaBT = i.MaBT
    WHERE i.ChiPhi <= 5000000 AND bt.KetQua = N'Sửa xong';

    -- Nhánh 3: Nếu chi phí hợp lý nhưng kết quả = 'Không sửa được' → tình trạng vẫn 'Cần bảo trì'
    UPDATE tb
    SET tb.TinhTrang = N'Cần bảo trì'
    FROM ThietBi tb
    INNER JOIN inserted i ON tb.MaTB = i.MaTB
    INNER JOIN BaoTri bt ON bt.MaBT = i.MaBT
    WHERE i.ChiPhi <= 5000000 AND bt.KetQua = N'Không sửa được';

    PRINT 'Trigger trg_CheckChiPhi: đã xử lý tình trạng thiết bị theo chi phí và kết quả bảo trì.';
END
GO


CREATE TRIGGER trg_TotalChiPhi
ON BaoTri
AFTER INSERT
AS
BEGIN
    DECLARE @TongChiPhi TABLE (MaTB VARCHAR(10));

    INSERT INTO @TongChiPhi(MaTB)
    SELECT MaTB
    FROM BaoTri
    GROUP BY MaTB
    HAVING SUM(ChiPhi) > 5000000;

    -- Update thiết bị
    UPDATE tb
    SET tb.TinhTrang = N'Hỏng'
    FROM ThietBi tb
    INNER JOIN @TongChiPhi t ON tb.MaTB = t.MaTB;

    -- Update log mới
    UPDATE bt
    SET bt.KetQua = N'Hỏng'
    FROM BaoTri bt
    INNER JOIN inserted i ON bt.MaBT = i.MaBT
    INNER JOIN @TongChiPhi t ON i.MaTB = t.MaTB;
END
GO


CREATE TRIGGER trg_CheckVeSinh_OnlyWhenUsable
ON ThietBi
AFTER UPDATE
AS
BEGIN

    -- Nếu thiết bị không ở trạng thái Đang sử dụng nhưng vẫn bị đổi vệ sinh → chặn
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN deleted d ON i.MaTB = d.MaTB
        JOIN ThietBi tb ON i.MaTB = tb.MaTB
        WHERE tb.TinhTrang <> N'Đang sử dụng'
          AND i.TinhTrangVeSinh IN (N'Đang vệ sinh', N'Sạch')
          AND i.TinhTrangVeSinh <> d.TinhTrangVeSinh  -- chỉ khi có thay đổi trạng thái vệ sinh
    )
    BEGIN
        RAISERROR (N'Thiết bị không ở trạng thái Đang sử dụng nên không thể cập nhật vệ sinh.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
END
GO

CREATE TRIGGER trg_CheckInsertBaoTri
ON BaoTri
INSTEAD OF INSERT
AS
BEGIN
    -- Chỉ lấy những dòng hợp lệ (Thiết bị đang Cần bảo trì)
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN ThietBi tb ON tb.MaTB = i.MaTB
        WHERE tb.TinhTrang <> N'Cần bảo trì'
    )
    BEGIN
        RAISERROR (N'Chỉ được ghi log bảo trì khi thiết bị đang ở trạng thái Cần bảo trì.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    -- Hợp lệ thì chèn vào BaoTri (sau đó các AFTER INSERT khác sẽ chạy)
    INSERT INTO BaoTri(MaTB, MaNV, NgayBaoTri, MoTa, ChiPhi, KetQua)
    SELECT MaTB, MaNV, NgayBaoTri, MoTa, ChiPhi, KetQua
    FROM inserted;
END
GO

------------------------------FUNCTION---------------------------------
CREATE FUNCTION fn_TongChiPhiThietBi(@MaTB VARCHAR(10))
RETURNS FLOAT
AS
BEGIN
    DECLARE @Tong FLOAT;
    SELECT @Tong = ISNULL(SUM(ChiPhi), 0)
    FROM BaoTri
    WHERE MaTB = @MaTB;
    RETURN @Tong;
END
GO


CREATE FUNCTION fn_AvgChiPhiBaoTri(@MaTB VARCHAR(10))
RETURNS FLOAT
AS
BEGIN
    DECLARE @Avg FLOAT;
    SELECT @Avg = AVG(ChiPhi)
    FROM BaoTri
    WHERE MaTB = @MaTB;
    RETURN ISNULL(@Avg,0);
END
GO


CREATE FUNCTION fn_CountCanBaoTri()  
RETURNS INT
AS
BEGIN
    DECLARE @Count INT;
    SELECT @Count = COUNT(*)
    FROM ThietBi
    WHERE TinhTrang = N'Cần bảo trì';
    RETURN @Count;
END
GO


CREATE FUNCTION fn_ReportTongChiPhi()
RETURNS TABLE
AS
RETURN
(
    SELECT 
        YEAR(NgayBaoTri) AS Nam,
        MONTH(NgayBaoTri) AS Thang,
        SUM(ChiPhi) AS TongChiPhi
    FROM BaoTri
    GROUP BY YEAR(NgayBaoTri), MONTH(NgayBaoTri)
);
GO

CREATE FUNCTION fn_ReportTopChiPhi_Multi()
RETURNS @Result TABLE
(
    MaTB VARCHAR(10),
    TenTB NVARCHAR(100),
    TopChiPhi FLOAT
)
AS
BEGIN
    -- Bước 1: tổng chi phí từng thiết bị
    INSERT INTO @Result (MaTB, TenTB, TopChiPhi)
    SELECT bt.MaTB, tb.TenTB, SUM(bt.ChiPhi)
    FROM BaoTri bt
    INNER JOIN ThietBi tb ON bt.MaTB = tb.MaTB
    GROUP BY bt.MaTB, tb.TenTB;

    -- Bước 2: giữ lại Top 5
    DELETE FROM @Result
    WHERE MaTB NOT IN (
        SELECT TOP 5 MaTB FROM @Result ORDER BY TopChiPhi DESC
    );

    RETURN;
END
GO



------------------------------PROCEDURE---------------------------------
CREATE PROCEDURE sp_CapNhatVeSinh
    @MaTB VARCHAR(10),
    @TinhTrang NVARCHAR(20),
    @NgayVeSinh DATE
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        -- chỉ update, KHÔNG chèn log nữa
        UPDATE ThietBi
        SET TinhTrangVeSinh = @TinhTrang
        WHERE MaTB = @MaTB;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO


CREATE PROCEDURE sp_ThemThietBi
    @MaTB VARCHAR(10),
    @TenTB NVARCHAR(100),
    @MaLoai VARCHAR(10),
    @NgayNhap DATE,
    @TinhTrang NVARCHAR(20),
    @ViTri NVARCHAR(100)
AS
BEGIN
    INSERT INTO ThietBi(MaTB, TenTB, MaLoai, NgayNhap, TinhTrang, ViTri)
    VALUES(@MaTB, @TenTB, @MaLoai, @NgayNhap, @TinhTrang, @ViTri);
END
GO


CREATE PROCEDURE sp_SuaThietBi
    @MaTB VARCHAR(10),
    @TenTB NVARCHAR(100),
    @MaLoai VARCHAR(10),
    @NgayNhap DATE,
    @TinhTrang NVARCHAR(20),
    @ViTri NVARCHAR(100)
AS
BEGIN
    UPDATE ThietBi
    SET TenTB=@TenTB, MaLoai=@MaLoai, NgayNhap=@NgayNhap,
        TinhTrang=@TinhTrang, ViTri=@ViTri
    WHERE MaTB=@MaTB;
END
GO


CREATE PROCEDURE sp_XoaThietBi
    @MaTB VARCHAR(10)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;   -- bắt đầu giao dịch

		DELETE FROM VeSinhLog WHERE MaTB = @MaTB;

        -- Xoá log bảo trì liên quan trước (nếu có ràng buộc khoá ngoại)
        DELETE FROM BaoTri WHERE MaTB = @MaTB;

        -- Xoá thiết bị
        DELETE FROM ThietBi WHERE MaTB = @MaTB;

        COMMIT TRANSACTION;  -- thành công thì lưu lại
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION; -- lỗi thì huỷ tất cả
        -- ném lỗi ra ngoài để biết nguyên nhân
        THROW;
    END CATCH
END
GO


CREATE PROCEDURE sp_UpdateTinhTrang
    @MaTB VARCHAR(10),
    @TinhTrang NVARCHAR(20)
AS
BEGIN
    UPDATE ThietBi
    SET TinhTrang = @TinhTrang
    WHERE MaTB = @MaTB;
END
GO

CREATE PROCEDURE sp_ThemBaoTri
    @MaTB VARCHAR(10),
    @MaNV VARCHAR(10) = NULL,
    @NgayBaoTri DATE,
    @MoTa NVARCHAR(200),
    @ChiPhi FLOAT,
    @KetQua NVARCHAR(50)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO BaoTri(MaTB, MaNV, NgayBaoTri, MoTa, ChiPhi, KetQua)
        VALUES(@MaTB, @MaNV, @NgayBaoTri, @MoTa, @ChiPhi, @KetQua);

        -- Trigger sẽ tự động update TinhTrang bên ThietBi
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW; -- trả lỗi ra ngoài
    END CATCH
END
GO


CREATE PROCEDURE sp_GetBaoTriByMaTB
    @MaTB VARCHAR(10)
AS
BEGIN
    SELECT MaBT, MaTB, NgayBaoTri, MoTa, ChiPhi, KetQua
    FROM BaoTri
    WHERE MaTB = @MaTB
    ORDER BY NgayBaoTri DESC;
END
GO

CREATE PROCEDURE sp_XoaBaoTri
    @MaBT INT
AS
BEGIN
    DELETE FROM BaoTri
    WHERE MaBT = @MaBT;
END
GO

CREATE PROCEDURE sp_TimKiemThietBi
    @TuKhoa NVARCHAR(100) = NULL
AS
BEGIN

    SELECT tb.MaTB,
           tb.TenTB,
           tb.MaLoai,
           lt.TenLoai,
           tb.NgayNhap,
           tb.TinhTrang,
           tb.ViTri
    FROM ThietBi tb
    LEFT JOIN LoaiThietBi lt ON tb.MaLoai = lt.MaLoai
    WHERE @TuKhoa IS NULL 
          OR tb.MaTB LIKE N'%' + @TuKhoa + N'%'
          OR tb.TenTB LIKE N'%' + @TuKhoa + N'%'
          OR lt.TenLoai LIKE N'%' + @TuKhoa + N'%'
    ORDER BY tb.NgayNhap DESC;
END
GO


CREATE OR ALTER PROCEDURE sp_TimKiemThietBiVeSinh
    @TuKhoa NVARCHAR(100) = NULL
AS
BEGIN
    SELECT MaTB,
           TenTB,
           TinhTrangVeSinh,
           NgayVeSinh
    FROM v_ThietBi_VeSinh
    WHERE @TuKhoa IS NULL
          OR MaTB LIKE N'%' + @TuKhoa + N'%'
          OR TenTB LIKE N'%' + @TuKhoa + N'%'
          OR TinhTrangVeSinh LIKE N'%' + @TuKhoa + N'%'
          OR CONVERT(NVARCHAR(10), NgayVeSinh, 120) LIKE N'%' + @TuKhoa + N'%'
    ORDER BY NgayVeSinh DESC;
END
GO


CREATE PROCEDURE sp_TimKiemCanBaoTri
    @TuKhoa NVARCHAR(100) = NULL
AS
BEGIN
    SELECT MaTB,
           TenTB,
           TinhTrang,
           ViTri
    FROM v_GetCanBaoTri
    WHERE @TuKhoa IS NULL
          OR MaTB LIKE N'%' + @TuKhoa + N'%'
          OR TenTB LIKE N'%' + @TuKhoa + N'%'
          OR TinhTrang LIKE N'%' + @TuKhoa + N'%'
          OR ViTri LIKE N'%' + @TuKhoa + N'%'
    ORDER BY TenTB;
END
GO

------------------------------Phân quyền---------------------------------
-- ========================
-- TẠO ROLE
-- ========================
CREATE ROLE rl_admin;
CREATE ROLE rl_pt;        -- Huấn luyện viên cá nhân
CREATE ROLE rl_le_tan;    -- Lễ tân
CREATE ROLE rl_bao_tri;   -- Bảo trì
CREATE ROLE rl_ve_sinh;   -- Vệ sinh
GO

-- ========================
-- TẠO LOGIN & USER
-- ========================

-- ADMIN
IF NOT EXISTS (SELECT 1 FROM sys.server_principals WHERE name = 'admin1')
    CREATE LOGIN admin1 WITH PASSWORD = '123';
IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'admin1')
    CREATE USER admin1 FOR LOGIN admin1;
ALTER ROLE rl_admin ADD MEMBER admin1;

-- NV01: Lễ tân
IF NOT EXISTS (SELECT 1 FROM sys.server_principals WHERE name = 'letan1')
    CREATE LOGIN letan1 WITH PASSWORD = '123';
IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'letan1')
    CREATE USER letan1 FOR LOGIN letan1;
ALTER ROLE rl_le_tan ADD MEMBER letan1;

-- NV02: Vệ sinh
IF NOT EXISTS (SELECT 1 FROM sys.server_principals WHERE name = 'vesinh1')
    CREATE LOGIN vesinh1 WITH PASSWORD = '123';
IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'vesinh1')
    CREATE USER vesinh1 FOR LOGIN vesinh1;
ALTER ROLE rl_ve_sinh ADD MEMBER vesinh1;

-- NV03: Vệ sinh
IF NOT EXISTS (SELECT 1 FROM sys.server_principals WHERE name = 'vesinh2')
    CREATE LOGIN vesinh2 WITH PASSWORD = '123';
IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'vesinh2')
    CREATE USER vesinh2 FOR LOGIN vesinh2;
ALTER ROLE rl_ve_sinh ADD MEMBER vesinh2;

-- NV04: Bảo trì
IF NOT EXISTS (SELECT 1 FROM sys.server_principals WHERE name = 'baotri1')
    CREATE LOGIN baotri1 WITH PASSWORD = '123';
IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'baotri1')
    CREATE USER baotri1 FOR LOGIN baotri1;
ALTER ROLE rl_bao_tri ADD MEMBER baotri1;

-- NV05: PT
IF NOT EXISTS (SELECT 1 FROM sys.server_principals WHERE name = 'pt1')
    CREATE LOGIN pt1 WITH PASSWORD = '123';
IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'pt1')
    CREATE USER pt1 FOR LOGIN pt1;
ALTER ROLE rl_pt ADD MEMBER pt1;

-- NV06: Lễ tân
IF NOT EXISTS (SELECT 1 FROM sys.server_principals WHERE name = 'letan2')
    CREATE LOGIN letan2 WITH PASSWORD = '123';
IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'letan2')
    CREATE USER letan2 FOR LOGIN letan2;
ALTER ROLE rl_le_tan ADD MEMBER letan2;

-- NV07: PT
IF NOT EXISTS (SELECT 1 FROM sys.server_principals WHERE name = 'pt2')
    CREATE LOGIN pt2 WITH PASSWORD = '123';
IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'pt2')
    CREATE USER pt2 FOR LOGIN pt2;
ALTER ROLE rl_pt ADD MEMBER pt2;
GO

-- ========================
-- PHÂN QUYỀN
-- ========================

-- Admin: cấp toàn quyền bằng db_owner
ALTER ROLE db_owner ADD MEMBER rl_admin;
GO


--Phân quyền cho Bảo trì (rl_bao_tri)
-- Chỉ xem thiết bị
GRANT SELECT ON ThietBi TO rl_bao_tri;
GRANT SELECT ON LoaiThietBi TO rl_bao_tri;
-- Chỉ thao tác với bảng BaoTri (thêm, xem, không xóa thiết bị)
GRANT SELECT, INSERT, UPDATE ON BaoTri TO rl_bao_tri;
-- Xem view liên quan đến thiết bị
GRANT SELECT ON OBJECT::dbo.v_ThietBi TO rl_bao_tri;
-- Cho phép gọi procedure liên quan bảo trì
GRANT EXECUTE ON OBJECT::dbo.sp_ThemBaoTri TO rl_bao_tri;
GRANT EXECUTE ON OBJECT::dbo.sp_GetBaoTriByMaTB TO rl_bao_tri;
GRANT EXECUTE ON OBJECT::dbo.sp_TimKiemThietBi TO rl_bao_tri;


--Phân quyền cho Vệ sinh (rl_ve_sinh)
-- Chỉ xem thiết bị
GRANT SELECT ON ThietBi TO rl_ve_sinh;
GRANT SELECT ON LoaiThietBi TO rl_ve_sinh;
-- Chỉ thao tác với bảng vệ sinh
GRANT SELECT, INSERT, UPDATE ON VeSinhLog TO rl_ve_sinh;
-- Cho phép xem các view thống kê vệ sinh
GRANT SELECT ON OBJECT::dbo.v_ThietBi_VeSinh TO rl_ve_sinh;
GRANT SELECT ON OBJECT::dbo.v_ThietBi TO rl_ve_sinh;
GRANT EXECUTE ON OBJECT::dbo.sp_TimKiemThietBi TO rl_ve_sinh;
GRANT EXECUTE ON OBJECT::dbo.sp_TimKiemThietBiVeSinh TO rl_ve_sinh;
-- Cho phép gọi procedure cập nhật vệ sinh
GRANT EXECUTE ON OBJECT::dbo.sp_CapNhatVeSinh TO rl_ve_sinh;



--Insert dữ liệu
INSERT INTO CongViec (MaCV, TenCV, LuongCa)
VALUES
('CV01', N'Lễ tân', 200000),
('CV02', N'Vệ sinh', 180000),
('CV03', N'Bảo trì', 220000),
('CV04', N'PT', 500000),
('CV05', N'Quản trị viên', 500000);


INSERT INTO NhanVien (MaNV, HoTen, NgaySinh, SoDienThoai, Gmail, DiaChi, GioiTinh, MaCV, HinhAnh)
VALUES
('NV01', N'Nguyễn Thị Lan', '1998-05-12', '0905123456', 'lan.nguyen@gmail.com', N'123 Lê Lợi, Hà Nội', 0, 'CV01', NULL),
('NV02', N'Trần Văn Hùng', '1985-03-20', '0912345678', 'hung.tran@gmail.com', N'45 Nguyễn Huệ, TP.HCM', 1, 'CV02', NULL),
('NV03', N'Phạm Thị Hoa', '1990-11-02', '0987654321', 'hoa.pham@gmail.com', N'78 Hai Bà Trưng, Đà Nẵng', 0, 'CV02', NULL),
('NV04', N'Ngô Văn Bình', '1988-07-15', '0978123456', 'binh.ngo@gmail.com', N'56 Lý Thường Kiệt, Hà Nội', 1, 'CV03', NULL),
('NV05', N'Đặng Quang Minh', '1995-01-10', '0934567890', 'minh.dang@gmail.com', N'89 Điện Biên Phủ, TP.HCM', 1, 'CV04', NULL),
('NV06', N'Lê Thị Hương', '1997-08-25', '0945678901', 'huong.le@gmail.com', N'12 Võ Thị Sáu, Huế', 0, 'CV01', NULL),
('NV07', N'Hoàng Văn Tuấn', '1992-09-05', '0956789012', 'tuan.hoang@gmail.com', N'34 Cách Mạng Tháng 8, Cần Thơ', 1, 'CV04', NULL),
('NV08', N'Trần Hồng Quang Lê','2005-12-14','0911700973','le@gmail.com', N'34 Cách Mạng Tháng 8, TPHCM',1,'CV05',NULL);

-- Tài khoản
INSERT INTO Account (Username, Password, MaNV) VALUES
('letan1', '123', 'NV01'),       
('vesinh1', '123', 'NV02'),      
('vesinh2', '123', 'NV03'),      
('baotri1', '123', 'NV04'),      
('pt1', '123', 'NV05'),      
('letan2', '123', 'NV06'),     
('pt2', '123', 'NV07'),
('admin1','123', 'NV08');


-- Loại thiết bị
INSERT INTO LoaiThietBi (MaLoai, TenLoai) VALUES
('L01', N'Máy chạy bộ'),
('L02', N'Xe đạp tập'),
('L03', N'Tạ đơn'),
('L04', N'Máy kéo xô'),
('L05', N'Máy tập toàn thân');

-- Thiết bị
INSERT INTO ThietBi (MaTB, TenTB, MaLoai, NgayNhap, TinhTrang, ViTri, TinhTrangVeSinh) VALUES
('TB01', N'Máy chạy LifeFitness 01', 'L01', '2022-01-15', N'Đang sử dụng', N'Khu Cardio', N'Sạch'),
('TB02', N'Máy chạy LifeFitness 02', 'L01', '2021-10-05', N'Cần bảo trì', N'Khu Cardio', N'Bẩn'),
('TB03', N'Xe đạp tập Technogym 01', 'L02', '2020-07-20', N'Đang sử dụng', N'Khu Cardio', N'Sạch'),
('TB04', N'Xe đạp tập Technogym 02', 'L02', '2022-03-12', N'Hỏng', N'Khu Cardio', N'Đang vệ sinh'),
('TB05', N'Tạ đơn 10kg', 'L03', '2023-05-01', N'Đang sử dụng', N'Khu Tạ', N'Sạch'),
('TB06', N'Tạ đơn 20kg', 'L03', '2023-05-01', N'Cần bảo trì', N'Khu Tạ', N'Bẩn'),
('TB07', N'Máy kéo xô ABC 01', 'L04', '2021-12-25', N'Đang sử dụng', N'Khu Máy tập', N'Sạch'),
('TB08', N'Máy kéo xô ABC 02', 'L04', '2020-09-15', N'Thanh lý', N'Kho', N'Bẩn'),
('TB09', N'Máy tập toàn thân Matrix 01', 'L05', '2022-08-30', N'Đang sử dụng', N'Khu Tổng hợp', N'Sạch'),
('TB10', N'Máy tập toàn thân Matrix 02', 'L05', '2021-01-01', N'Cần bảo trì', N'Khu Tổng hợp', N'Đang vệ sinh'),
('TB11', N'Máy chạy LifeFitness 03', 'L01', '2023-01-20', N'Đang sử dụng', N'Khu Cardio', N'Sạch'),
('TB12', N'Tạ đơn 15kg', 'L03', '2022-11-01', N'Đang sử dụng', N'Khu Tạ', N'Bẩn'),
('TB13', N'Máy kéo xô ABC 03', 'L04', '2022-05-18', N'Cần bảo trì', N'Khu Máy tập', N'Đang vệ sinh'),
('TB14', N'Xe đạp tập Technogym 03', 'L02', '2023-02-10', N'Đang sử dụng', N'Khu Cardio', N'Sạch'),
('TB15', N'Máy tập toàn thân Matrix 03', 'L05', '2021-04-25', N'Hỏng', N'Khu Tổng hợp', N'Bẩn');

-- Bảo trì
INSERT INTO BaoTri (MaTB, MaNV, NgayBaoTri, MoTa, ChiPhi, KetQua) VALUES
('TB02', 'NV04', '2023-06-10', N'Thay băng tải', 2000000, N'Sửa xong'),
('TB04', 'NV04', '2023-07-05', N'Thay vòng bi', 6000000, N'Hỏng'),
('TB06', 'NV04', '2023-08-01', N'Hàn khung bị nứt', 3000000, N'Không sửa được'),
('TB10', 'NV04', '2023-09-15', N'Bảo dưỡng định kỳ', 1500000, N'Sửa xong'),
('TB08', 'NV04', '2023-04-20', N'Khung gỉ sét', 5500000, N'Hỏng'),
('TB13', 'NV04', '2023-09-25', N'Kiểm tra dây cáp', 1200000, N'Sửa xong'),
('TB15', 'NV04', '2023-10-05', N'Thay bo mạch', 7000000, N'Hỏng'),
('TB06', 'NV04', '2023-10-10', N'Bảo trì lần 2', 1800000, N'Sửa xong');

-- Vệ sinh log
INSERT INTO VeSinhLog (MaTB, MaNV, NgayVeSinh) VALUES
('TB01', 'NV02', '2023-06-01'),
('TB01', 'NV03', '2023-06-15'),
('TB02', 'NV02', '2023-07-01'),
('TB03', 'NV03', '2023-07-05'),
('TB04', 'NV02', '2023-07-20'),
('TB05', 'NV02', '2023-08-01'),
('TB06', 'NV03', '2023-08-10'),
('TB07', 'NV02', '2023-09-01'),
('TB09', 'NV03', '2023-09-05'),
('TB10', 'NV02', '2023-09-15'),
('TB11', 'NV02', '2023-09-18'),
('TB12', 'NV03', '2023-09-20'),
('TB13', 'NV02', '2023-09-22'),
('TB14', 'NV03', '2023-09-25'),
('TB15', 'NV02', '2023-09-28');

