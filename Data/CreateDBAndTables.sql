--1. Tạo database QLGYM
CREATE DATABASE QLGYM
USE GLGYM


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
    CONSTRAINT fk_ThietBi_Loai FOREIGN KEY (MaLoai) REFERENCES LoaiThietBi(MaLoai)
);
--8. Tạo bảng BaoTri
CREATE TABLE BaoTri (
    MaBT INT IDENTITY(1,1) PRIMARY KEY,
    MaTB VARCHAR(10) NOT NULL,
    MaNV VARCHAR(10) NULL,                -- để liên kết sang nhân viên (
    NgayBaoTri DATE NOT NULL,
    MoTa NVARCHAR(200) NULL,
    ChiPhi FLOAT CHECK (ChiPhi >= 0),
    KetQua NVARCHAR(50) NULL,             -- ví dụ: 'Sửa xong', 'Không sửa được', 'Hỏng'
    CONSTRAINT fk_BaoTri_ThietBi FOREIGN KEY (MaTB) REFERENCES ThietBi(MaTB)
    -- Nếu muốn liên kết nhân viên thì giữ dòng này:
    ,CONSTRAINT fk_BaoTri_NhanVien FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);


CREATE TABLE VeSinhLog (
    MaVS INT IDENTITY PRIMARY KEY,
    MaTB VARCHAR(10) REFERENCES ThietBi(MaTB),
    MaNV VARCHAR(10) NULL,
    NgayVeSinh DATE NOT NULL,
    GhiChu NVARCHAR(200)
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
    BEGIN TRANSACTION;
    BEGIN TRY
        -- Cập nhật tình trạng trong ThietBi
        UPDATE ThietBi
        SET TinhTrangVeSinh = @TinhTrang
        WHERE MaTB = @MaTB;

        -- Ghi log vào VeSinhLog
        INSERT INTO VeSinhLog(MaTB, NgayVeSinh)
        VALUES(@MaTB, @NgayVeSinh);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END

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





--13. Thêm công việc
INSERT INTO CongViec (MaCV, TenCV, LuongCa)
VALUES
('CV01', N'Lễ tân', 200000),
('CV02', N'Vệ sinh', 180000),
('CV03', N'Bảo trì', 220000),
('CV04', N'PT', 500000);

--14. Thêm nhân viên
INSERT INTO NhanVien (MaNV, HoTen, NgaySinh, SoDienThoai, DiaChi, GioiTinh, MaCV)
VALUES
('NV01', N'Nguyễn Thị Lan', '1998-05-12', '0905123456', N'123 Lê Lợi, Hà Nội', N'Nữ', 'CV01'),
('NV02', N'Trần Văn Hùng', '1985-03-20', '0912345678', N'45 Nguyễn Huệ, TP.HCM', N'Nam', 'CV02'),
('NV03', N'Phạm Thị Hoa', '1990-11-02', '0987654321', N'78 Hai Bà Trưng, Đà Nẵng', N'Nữ', 'CV02'),
('NV04', N'Ngô Văn Bình', '1988-07-15', '0978123456', N'56 Lý Thường Kiệt, Hà Nội', N'Nam', 'CV03'),
('NV05', N'Đặng Quang Minh', '1995-01-10', '0934567890', N'89 Điện Biên Phủ, TP.HCM', N'Nam', 'CV04'),
('NV06', N'Lê Thị Hương', '1997-08-25', '0945678901', N'12 Võ Thị Sáu, Huế', N'Nữ', 'CV01'),
('NV07', N'Hoàng Văn Tuấn', '1992-09-05', '0956789012', N'34 Cách Mạng Tháng 8, Cần Thơ', N'Nam', 'CV04');


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
    SELECT * FROM ThietBi;
END
GO
ALTER PROCEDURE sp_GetThietBi
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


INSERT INTO LoaiThietBi (MaLoai, TenLoai) VALUES
('ML01', N'Máy chạy bộ'),
('ML02', N'Xe đạp tập'),
('ML03', N'Dàn tạ đa năng');

SELECT * FROM dbo.LoaiThietBi;



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

DROP TRIGGER dbo.trg_TotalChiPhi;
CREATE TRIGGER trg_TotalChiPhi
ON BaoTri
AFTER INSERT
AS
BEGIN
    DECLARE @MaTB VARCHAR(10);

    -- Duyệt qua tất cả thiết bị vừa insert log bảo trì
    DECLARE cur CURSOR FOR
        SELECT DISTINCT MaTB FROM inserted;

    OPEN cur;
    FETCH NEXT FROM cur INTO @MaTB;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        DECLARE @Tong FLOAT;
        SELECT @Tong = SUM(ChiPhi) FROM BaoTri WHERE MaTB = @MaTB;

        IF @Tong > 5000000
        BEGIN
            UPDATE ThietBi SET TinhTrang = N'Hỏng'
            WHERE MaTB = @MaTB;

            UPDATE BaoTri SET KetQua = N'Hỏng'
            WHERE MaTB = @MaTB AND MaBT IN (SELECT MaBT FROM inserted);
        END

        FETCH NEXT FROM cur INTO @MaTB;
    END

    CLOSE cur;
    DEALLOCATE cur;
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


ALTER TABLE BaoTri
DROP CONSTRAINT fk_BaoTri_ThietBi;

ALTER TABLE BaoTri
ADD CONSTRAINT fk_BaoTri_ThietBi
FOREIGN KEY (MaTB) REFERENCES ThietBi(MaTB)
ON DELETE CASCADE;



-- Thêm vài thiết bị
INSERT INTO ThietBi (MaTB, TenTB, MaLoai, NgayNhap, TinhTrang, ViTri)
VALUES
('TB01', N'Máy chạy bộ LifeFitness', 'ML01', '2023-01-10', N'Đang sử dụng', N'Khu Cardio A1'),
('TB02', N'Xe đạp tập Technogym', 'ML02', '2023-02-15', N'Đang sử dụng', N'Khu Cardio A2'),
('TB03', N'Dàn tạ đa năng Bowflex', 'ML03', '2023-03-20', N'Cần bảo trì', N'Khu Tạ B1'),
('TB04', N'Máy chạy bộ StarTrac', 'ML01', '2022-10-05', N'Đang sử dụng', N'Khu Cardio A3'),
('TB05', N'Xe đạp tập Reebok', 'ML02', '2023-04-25', N'Hỏng', N'Khu Cardio A4');

-- Log bảo trì cho thiết bị
INSERT INTO BaoTri (MaTB, MaNV, NgayBaoTri, MoTa, ChiPhi, KetQua)
VALUES
('TB01', 'NV04', '2023-08-10', N'Bảo dưỡng định kỳ', 1500000, N'Sửa xong'),
('TB01', 'NV04', '2024-02-12', N'Thay băng tải máy chạy', 2200000, N'Sửa xong'),

('TB02', 'NV04', '2023-09-05', N'Thay bàn đạp bị gãy', 800000, N'Sửa xong'),

('TB03', 'NV04', '2024-03-18', N'Thay cáp tạ bị đứt', 5500000, N'Hỏng'),
('TB03', 'NV04', '2024-05-22', N'Thử thay phụ kiện nhưng không sửa được', 3000000, N'Không sửa được'),

('TB04', 'NV04', '2024-01-15', N'Bảo dưỡng motor', 1800000, N'Sửa xong'),

('TB05', 'NV04', '2023-11-11', N'Bảo trì bàn đạp', 6000000, N'Hỏng'); -- > 5tr trigger ép Hỏng


INSERT INTO ThietBi (MaTB, TenTB, MaLoai, NgayNhap, TinhTrang, ViTri)
VALUES
('TB06', N'Máy tập cơ bụng ABC', 'ML03', '2023-07-01', N'Cần bảo trì', N'Khu Tạ B2'),
('TB07', N'Xe đạp tập Impulse', 'ML02', '2023-09-15', N'Cần bảo trì', N'Khu Cardio A5');


-- TB06: thêm 2 lần bảo trì nữa
INSERT INTO BaoTri (MaTB, MaNV, NgayBaoTri, MoTa, ChiPhi, KetQua)
VALUES
('TB06', 'NV04', '2024-08-15', N'Thay dây cáp phụ', 2000000, N'Không sửa được'),
('TB06', 'NV04', '2024-09-10', N'Bảo dưỡng motor nhỏ', 500000, N'Không sửa được');

-- TB07: thêm 2 lần bảo trì nữa
INSERT INTO BaoTri (MaTB, MaNV, NgayBaoTri, MoTa, ChiPhi, KetQua)
VALUES
('TB07', 'NV04', '2024-08-20', N'Thay bàn đạp mới', 2200000, N'Sửa xong'),
('TB07', 'NV04', '2024-09-05', N'Bảo trì định kỳ', 1000000, N'Sửa xong');


-- TB06: có vài lần bảo trì nhưng chưa ổn → vẫn cần bảo trì
INSERT INTO BaoTri (MaTB, MaNV, NgayBaoTri, MoTa, ChiPhi, KetQua)
VALUES
('TB06', 'NV04', '2024-06-10', N'Thay cáp tập cơ bụng', 2500000, N'Không sửa được'),
('TB06', 'NV04', '2024-07-05', N'Thay phụ kiện nhỏ nhưng không khắc phục được', 1200000, N'Không sửa được');

-- TB07: bảo trì nhiều lần, có chi phí nhỏ và vừa, nhưng kết quả không khả quan → vẫn cần bảo trì
INSERT INTO BaoTri (MaTB, MaNV, NgayBaoTri, MoTa, ChiPhi, KetQua)
VALUES
('TB07', 'NV04', '2024-05-20', N'Bảo dưỡng hệ thống bàn đạp', 1800000, N'Không sửa được'),
('TB07', 'NV04', '2024-07-28', N'Thay ốc vít, căn chỉnh nhưng chưa hoạt động ổn định', 800000, N'Không sửa được');
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

--9. Tạo bảng Account
CREATE TABLE Account(
	MaNV VARCHAR(10) PRIMARY KEY REFERENCES dbo.NhanVien(MaNV),
	Password VARCHAR(Max) NOT NULL
)
--Thêm tài khoản
INSERT INTO Account(MaNV, Password)
VALUES
('NV01', '123'),
('NV02', '123'),
('NV03', '123'),
('NV04', '123'),
('NV05', '123'),
('NV06', '123'),
('NV07', '123');

-- Tạo login (cấp server-level login)
CREATE LOGIN adminUser WITH PASSWORD = '123';
CREATE LOGIN baotriUser WITH PASSWORD = '123';
CREATE LOGIN vesinhUser WITH PASSWORD = '123';

-- Gắn login này vào database QLGYM
USE QLGYM;
CREATE USER adminUser FOR LOGIN adminUser;
CREATE USER baotriUser FOR LOGIN baotriUser;
CREATE USER vesinhUser FOR LOGIN vesinhUser;


-- Tạo role
CREATE ROLE Role_Admin;
CREATE ROLE Role_BaoTri;
CREATE ROLE Role_VeSinh;

-- Cấp quyền cho role
-- Admin full quyền
GRANT SELECT, INSERT, UPDATE, DELETE ON ThietBi TO Role_Admin;
GRANT SELECT, INSERT, UPDATE, DELETE ON BaoTri TO Role_Admin;

-- Bảo trì: chỉ xem thiết bị + thêm log bảo trì
GRANT SELECT ON ThietBi TO Role_BaoTri;
GRANT SELECT, INSERT ON BaoTri TO Role_BaoTri;

-- Vệ sinh: chỉ được xem thiết bị
GRANT SELECT ON ThietBi TO Role_VeSinh;

-- Gán user vào role
EXEC sp_addrolemember 'Role_Admin', 'adminUser';
EXEC sp_addrolemember 'Role_BaoTri', 'baotriUser';
EXEC sp_addrolemember 'Role_VeSinh', 'vesinhUser';

-- Admin full
GRANT SELECT, INSERT, UPDATE, DELETE ON LoaiThietBi TO Role_Admin;

-- Bảo trì: chỉ cần SELECT loại thiết bị (để hiển thị combobox)
GRANT SELECT ON LoaiThietBi TO Role_BaoTri;

-- Vệ sinh: cũng chỉ cần SELECT để hiển thị
GRANT SELECT ON LoaiThietBi TO Role_VeSinh;

-- Nếu có view v_ThietBi thì cũng cần cấp
GRANT SELECT ON v_ThietBi TO Role_BaoTri;
GRANT SELECT ON v_ThietBi TO Role_VeSinh; 

-- ========== PROCEDURE ==========
GRANT EXECUTE ON OBJECT::dbo.sp_ThemThietBi TO Role_Admin;
GRANT EXECUTE ON OBJECT::dbo.sp_SuaThietBi TO Role_Admin;
GRANT EXECUTE ON OBJECT::dbo.sp_XoaThietBi TO Role_Admin;
GRANT EXECUTE ON OBJECT::dbo.sp_GetThietBi TO Role_Admin;
GRANT EXECUTE ON OBJECT::dbo.sp_UpdateTinhTrang TO Role_Admin;
GRANT EXECUTE ON OBJECT::dbo.sp_ThemBaoTri TO Role_Admin;
GRANT EXECUTE ON OBJECT::dbo.sp_GetBaoTriByMaTB TO Role_Admin;

-- ========== VIEW ==========
GRANT SELECT ON OBJECT::dbo.v_ThietBi TO Role_Admin;
GRANT SELECT ON OBJECT::dbo.v_GetCanBaoTri TO Role_Admin;

-- ========== FUNCTION ==========
-- Table-valued function (SELECT)
GRANT SELECT ON OBJECT::dbo.fn_GetCanBaoTri TO Role_Admin;
GRANT SELECT ON OBJECT::dbo.fn_ReportTongChiPhi TO Role_Admin;
GRANT SELECT ON OBJECT::dbo.fn_ReportTopChiPhi_Multi TO Role_Admin;

-- Scalar function (EXECUTE)
GRANT EXECUTE ON OBJECT::dbo.fn_TongChiPhiThietBi TO Role_Admin;
GRANT EXECUTE ON OBJECT::dbo.fn_AvgChiPhiBaoTri TO Role_Admin;
GRANT EXECUTE ON OBJECT::dbo.fn_CountCanBaoTri TO Role_Admin;