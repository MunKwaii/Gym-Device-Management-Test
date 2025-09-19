--1. Tạo database QLGYM
CREATE DATABASE QLGYM
USE QLGYM

---Khu thiết bị 

CREATE TABLE LoaiThietBi(
	MaLoai VARCHAR(10) PRIMARY KEY,
	TenLoai NVARCHAR(100) NOT NULL
);

--7. Tạo bảng ThietBi
CREATE TABLE ThietBi (
    MaTB VARCHAR(10) PRIMARY KEY,
    TenTB NVARCHAR(100) NOT NULL,
    MaLoai VARCHAR(10) NULL,
    NgayNhap DATE NOT NULL,
    TinhTrang NVARCHAR(20) NOT NULL
        CHECK (TinhTrang IN (N'Đang sử dụng', N'Cần bảo trì', N'Hỏng', N'Thanh lý')),
    ViTri NVARCHAR(100) NULL,
    TinhTrangVeSinh NVARCHAR(20) NULL,   
    CONSTRAINT fk_ThietBi_Loai FOREIGN KEY (MaLoai) REFERENCES LoaiThietBi(MaLoai)
);



--8. Tạo bảng BaoTri (không có ON DELETE CASCADE)
CREATE TABLE BaoTri (
    MaBT INT IDENTITY(1,1) PRIMARY KEY,
    MaTB VARCHAR(10) NOT NULL,
    MaNV VARCHAR(10) NULL,                -- để liên kết sang nhân viên
    NgayBaoTri DATE NOT NULL,
    MoTa NVARCHAR(200) NULL,
    ChiPhi FLOAT CHECK (ChiPhi >= 0),
    KetQua NVARCHAR(50) NULL,             -- ví dụ: 'Sửa xong', 'Không sửa được', 'Hỏng'

    -- Khóa ngoại tới ThietBi (KHÔNG CASCADE)
    CONSTRAINT fk_BaoTri_ThietBi FOREIGN KEY (MaTB) 
        REFERENCES ThietBi(MaTB),

    -- Khóa ngoại tới NhanVien (nếu bảng NhanVien tồn tại)
    CONSTRAINT fk_BaoTri_NhanVien FOREIGN KEY (MaNV) 
        REFERENCES NhanVien(MaNV)
);
GO



CREATE TABLE VeSinhLog (
    MaVS INT IDENTITY PRIMARY KEY,
    MaTB VARCHAR(10) REFERENCES ThietBi(MaTB),
    MaNV VARCHAR(10) NULL,
    NgayVeSinh DATE NOT NULL
);
GO

CREATE VIEW v_VeSinhTheoThang
AS
SELECT YEAR(NgayVeSinh) AS Nam, MONTH(NgayVeSinh) AS Thang, COUNT(*) AS SoLan
FROM VeSinhLog
GROUP BY YEAR(NgayVeSinh), MONTH(NgayVeSinh);
GO


CREATE OR ALTER VIEW v_ThietBi_VeSinh
AS
SELECT 
    tb.MaTB,
    tb.TenTB,
    tb.TinhTrangVeSinh,
    vs.NgayVeSinh
FROM ThietBi tb
OUTER APPLY
(
    SELECT TOP 1 v.NgayVeSinh
    FROM VeSinhLog v
    WHERE v.MaTB = tb.MaTB
    ORDER BY v.NgayVeSinh DESC
) vs;
GO

CREATE OR ALTER PROCEDURE sp_CapNhatVeSinh
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

CREATE OR ALTER TRIGGER trg_VeSinh_Update
ON ThietBi
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

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

-- Thêm thiết bị
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

-- Sửa thiết bị
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

-- Xóa thiết bị có transaction
CREATE OR ALTER PROCEDURE sp_XoaThietBi
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

-- Lấy danh sách thiết bị
CREATE PROCEDURE sp_GetThietBi
AS
BEGIN
    SELECT tb.MaTB,
           tb.TenTB,
           tb.MaLoai,
           lt.TenLoai,  -- cột tên loại
           tb.NgayNhap,
           tb.TinhTrang,
           tb.ViTri
    FROM dbo.ThietBi tb
    LEFT JOIN dbo.LoaiThietBi lt ON tb.MaLoai = lt.MaLoai;
END
GO

--View
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

CREATE OR ALTER PROCEDURE sp_ThemBaoTri
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

CREATE OR ALTER TRIGGER trg_CheckChiPhi
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


CREATE OR ALTER TRIGGER trg_TotalChiPhi
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

CREATE OR ALTER TRIGGER trg_CheckVeSinh_OnlyWhenUsable
ON ThietBi
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

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
    RETURN ISNULL(@Avg,0);CREATE OR ALTER TRIGGER trg_CheckChiPhi
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


CREATE FUNCTION fn_GetCanBaoTri()
RETURNS TABLE
AS
RETURN
(
    SELECT MaTB, TenTB, TinhTrang, ViTri
    FROM ThietBi
    WHERE TinhTrang = N'Cần bảo trì'
);
GO
--view
CREATE VIEW v_GetCanBaoTri
AS
SELECT MaTB, TenTB, TinhTrang, ViTri
FROM ThietBi
WHERE TinhTrang = N'Cần bảo trì';
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
    TongChiPhi FLOAT
)
AS
BEGIN
    -- Bước 1: tổng chi phí từng thiết bị
    INSERT INTO @Result (MaTB, TenTB, TongChiPhi)
    SELECT bt.MaTB, tb.TenTB, SUM(bt.ChiPhi)
    FROM BaoTri bt
    INNER JOIN ThietBi tb ON bt.MaTB = tb.MaTB
    GROUP BY bt.MaTB, tb.TenTB;

    -- Bước 2: giữ lại Top 5
    DELETE FROM @Result
    WHERE MaTB NOT IN (
        SELECT TOP 5 MaTB FROM @Result ORDER BY TongChiPhi DESC
    );

    RETURN;
END
GO

-- Tạo role
CREATE ROLE rl_admin;
CREATE ROLE rl_pt;        -- PT (huấn luyện viên cá nhân)
CREATE ROLE rl_le_tan;    -- lễ tân
CREATE ROLE rl_bao_tri;   -- bảo trì
CREATE ROLE rl_ve_sinh;   -- vệ sinh
GO

-- Tạo login & user cho admin
CREATE LOGIN Admin_Login WITH PASSWORD = 'Admin@123';
CREATE USER Admin_User FOR LOGIN Admin_Login WITH DEFAULT_SCHEMA = [QLGYM];

-- NV01
CREATE LOGIN NV01_Login WITH PASSWORD = 'NV01@123';
CREATE USER NV01_User FOR LOGIN NV01_Login WITH DEFAULT_SCHEMA = [QLGYM];

-- NV02
CREATE LOGIN NV02_Login WITH PASSWORD = 'NV02@123';
CREATE USER NV02_User FOR LOGIN NV02_Login WITH DEFAULT_SCHEMA = [QLGYM];

-- NV03
CREATE LOGIN NV03_Login WITH PASSWORD = 'NV03@123';
CREATE USER NV03_User FOR LOGIN NV03_Login WITH DEFAULT_SCHEMA = [QLGYM];

-- NV04
CREATE LOGIN NV04_Login WITH PASSWORD = 'NV04@123';
CREATE USER NV04_User FOR LOGIN NV04_Login WITH DEFAULT_SCHEMA = [QLGYM];

-- NV05
CREATE LOGIN NV05_Login WITH PASSWORD = 'NV05@123';
CREATE USER NV05_User FOR LOGIN NV05_Login WITH DEFAULT_SCHEMA = [QLGYM];

-- NV06
CREATE LOGIN NV06_Login WITH PASSWORD = 'NV06@123';
CREATE USER NV06_User FOR LOGIN NV06_Login WITH DEFAULT_SCHEMA = [QLGYM];

-- NV07
CREATE LOGIN NV07_Login WITH PASSWORD = 'NV07@123';
CREATE USER NV07_User FOR LOGIN NV07_Login WITH DEFAULT_SCHEMA = [QLGYM];
GO

-- Gán role
ALTER ROLE rl_admin   ADD MEMBER Admin_User;
ALTER ROLE rl_pt      ADD MEMBER NV05_User;   -- NV05 = PT
ALTER ROLE rl_pt      ADD MEMBER NV07_User;   -- NV07 = PT
ALTER ROLE rl_le_tan  ADD MEMBER NV01_User;   -- NV01 = lễ tân
ALTER ROLE rl_le_tan  ADD MEMBER NV06_User;   -- NV06 = lễ tân
ALTER ROLE rl_bao_tri ADD MEMBER NV04_User;   -- NV04 = bảo trì
ALTER ROLE rl_ve_sinh ADD MEMBER NV02_User;   -- NV02 = vệ sinh
ALTER ROLE rl_ve_sinh ADD MEMBER NV03_User;   -- NV03 = vệ sinh
GO


-- Admin full quyền trên bảng
GRANT SELECT, INSERT, UPDATE, DELETE ON ThietBi TO rl_admin;
GRANT SELECT, INSERT, UPDATE, DELETE ON BaoTri TO rl_admin;
GRANT SELECT, INSERT, UPDATE, DELETE ON VeSinhLog TO rl_admin;
GRANT SELECT, INSERT, UPDATE, DELETE ON LoaiThietBi TO rl_admin;


-- Admin full quyền trên view
GRANT SELECT ON OBJECT::dbo.v_ThietBi TO rl_admin;
GRANT SELECT ON OBJECT::dbo.v_GetCanBaoTri TO rl_admin;
GRANT SELECT ON OBJECT::dbo.v_VeSinhTheoThang TO rl_admin;
GRANT SELECT ON OBJECT::dbo.v_ThietBi_VeSinh TO rl_admin;

-- Admin full quyền với procedure
GRANT EXECUTE ON OBJECT::dbo.sp_ThemThietBi TO rl_admin;
GRANT EXECUTE ON OBJECT::dbo.sp_SuaThietBi TO rl_admin;
GRANT EXECUTE ON OBJECT::dbo.sp_XoaThietBi TO rl_admin;
GRANT EXECUTE ON OBJECT::dbo.sp_GetThietBi TO rl_admin;
GRANT EXECUTE ON OBJECT::dbo.sp_UpdateTinhTrang TO rl_admin;
GRANT EXECUTE ON OBJECT::dbo.sp_ThemBaoTri TO rl_admin;
GRANT EXECUTE ON OBJECT::dbo.sp_GetBaoTriByMaTB TO rl_admin;
GRANT EXECUTE ON OBJECT::dbo.sp_CapNhatVeSinh TO rl_admin;


-- Admin full quyền với function (table-valued: SELECT, scalar: EXECUTE)
GRANT SELECT ON OBJECT::dbo.fn_GetCanBaoTri TO rl_admin;
GRANT SELECT ON OBJECT::dbo.fn_ReportTongChiPhi TO rl_admin;
GRANT SELECT ON OBJECT::dbo.fn_ReportTopChiPhi_Multi TO rl_admin;

GRANT EXECUTE ON OBJECT::dbo.fn_TongChiPhiThietBi TO rl_admin;
GRANT EXECUTE ON OBJECT::dbo.fn_AvgChiPhiBaoTri TO rl_admin;
GRANT EXECUTE ON OBJECT::dbo.fn_CountCanBaoTri TO rl_admin;


--Phân quyền cho Bảo trì (rl_bao_tri)
-- Chỉ xem thiết bị
GRANT SELECT ON ThietBi TO rl_bao_tri;
GRANT SELECT ON LoaiThietBi TO rl_bao_tri;

-- Chỉ thao tác với bảng BaoTri (thêm, xem, không xóa thiết bị)
GRANT SELECT, INSERT, UPDATE ON BaoTri TO rl_bao_tri;

-- Xem view liên quan đến thiết bị
GRANT SELECT ON OBJECT::dbo.v_ThietBi TO rl_bao_tri;
GRANT SELECT ON OBJECT::dbo.v_GetCanBaoTri TO rl_bao_tri;

-- Cho phép gọi procedure liên quan bảo trì
GRANT EXECUTE ON OBJECT::dbo.sp_ThemBaoTri TO rl_bao_tri;
GRANT EXECUTE ON OBJECT::dbo.sp_GetBaoTriByMaTB TO rl_bao_tri;

-- Cho phép xem báo cáo (function bảo trì)
GRANT SELECT ON OBJECT::dbo.fn_GetCanBaoTri TO rl_bao_tri;



--Phân quyền cho Vệ sinh (rl_ve_sinh)
-- Chỉ xem thiết bị
GRANT SELECT ON ThietBi TO rl_ve_sinh;
GRANT SELECT ON LoaiThietBi TO rl_ve_sinh;

-- Chỉ thao tác với bảng vệ sinh
GRANT SELECT, INSERT ON VeSinhLog TO rl_ve_sinh;

-- Cho phép xem các view thống kê vệ sinh
GRANT SELECT ON OBJECT::dbo.v_VeSinhTheoThang TO rl_ve_sinh;
GRANT SELECT ON OBJECT::dbo.v_ThietBi_VeSinh TO rl_ve_sinh;
GRANT SELECT ON OBJECT::dbo.v_ThietBi TO rl_ve_sinh;

-- Cho phép gọi procedure cập nhật vệ sinh
GRANT EXECUTE ON OBJECT::dbo.sp_CapNhatVeSinh TO rl_ve_sinh;



