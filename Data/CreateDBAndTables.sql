--1. Tạo database QLGYM
CREATE DATABASE QLGYM
USE GLGYM

--2. Tạo bảng CongViec
CREATE TABLE CongViec (
	MaCV VARCHAR(10) PRIMARY KEY,
	TenCV NVARCHAR(50),
	LuongCa FLOAT
)

--3. Tạo bảng NhanVien
CREATE TABLE NhanVien (
	MaNV VARCHAR(10) PRIMARY KEY,
	HoTen NVARCHAR(50),
	NgaySinh DATE,
	SoDienThoai VARCHAR(20),
	DiaChi NVARCHAR(200),
	GioiTinh NVARCHAR(10),
	MaCV VARCHAR(10),
	CONSTRAINT fk_NhanVien_CongViec FOREIGN KEY (MaCV) REFERENCES CongViec(MaCV)
)

--4. Tạo bảng CaLam
CREATE TABLE CaLamViec (
	MaCa VARCHAR(10) PRIMARY KEY,
	TenCa NVARCHAR(50)
)

--5. Tạo bảng LichLamViec
CREATE TABLE LichLamViec (
	MaNV VARCHAR(10),
	MaCa VARCHAR(10),
	Ngay NVARCHAR(20)
	PRIMARY KEY (MaNV, MaCa),
	CONSTRAINT fk_LichLamViec_NhanVien FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
	CONSTRAINT fk_LichLamViec_CaLamViec FOREIGN KEY (MaCa) REFERENCES CaLamViec(MaCa)
)

--6. Tạo bảng NghiPhep
CREATE TABLE NghiPhep (
	MaNVNghi VARCHAR(10),
	MaNVBu VARCHAR(10),
	MaCa VARCHAR(10),
	NgayNghi DATETIME,
	PRIMARY KEY (MaNVNghi, MaNVBu, MaCa),
	CONSTRAINT fk_NghiPhepNVNghi_NhanVien FOREIGN KEY (MaNVNghi) REFERENCES NhanVien(MaNV),
	CONSTRAINT fk_NghiPhepNVBu_NhanVien FOREIGN KEY (MaNVBu) REFERENCES NhanVien(MaNV),
	CONSTRAINT fk_NghiPhep_CaLamViec FOREIGN KEY (MaCa) REFERENCES CaLamViec(MaCa)
)

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
--9. Tạo bảng KhachHang
CREATE TABLE KhachHang (
	MaKH VARCHAR(10) PRIMARY KEY,
	HoTen NVARCHAR(50),
	SoDienThoai VARCHAR(20)
)

--10. Tạo bảng HoiVien
CREATE TABLE HoiVien (
	MaHV VARCHAR(10) PRIMARY KEY,
	MaKH VARCHAR(10),
	NgayBatDau DATE,
	NgayKetThuc DATE,
	CONSTRAINT fk_HoiVien_KhachHang FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)
)

--11. Tạo bảng DichVuPT
CREATE TABLE DichVuPT (
	MaDV VARCHAR(10) PRIMARY KEY,
	TenDV NVARCHAR(100), 
	MaNV VARCHAR(10),
	DonGia FLOAT,
	SoBuoi INT,
	CONSTRAINT fk_DichVuPT_NhanVien FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
)

--12. Tạo bảng LichTap
CREATE TABLE LichTap (
	MaKH VARCHAR(10) PRIMARY KEY,
	MaDV VARCHAR(10),
	NgayTap DATE,
	GioBatDau TIME,
	GioKetThuc TIME,
	CONSTRAINT fk_LichTap_KhachHang FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH),
	CONSTRAINT fk_LichTap_MaDV FOREIGN KEY (MaDV) REFERENCES DichVuPT(MaDV)
)

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

-- Xóa thiết bị
CREATE PROCEDURE sp_XoaThietBi
    @MaTB VARCHAR(10)
AS
BEGIN
    DELETE FROM ThietBi WHERE MaTB=@MaTB;
END
GO

-- Lấy danh sách thiết bị
CREATE PROCEDURE sp_GetThietBi
AS
BEGIN
    SELECT * FROM ThietBi;
END
GO

INSERT INTO LoaiThietBi (MaLoai, TenLoai) VALUES
('ML01', N'Máy chạy bộ'),
('ML02', N'Xe đạp tập'),
('ML03', N'Dàn tạ đa năng');

SELECT * FROM dbo.LoaiThietBi;

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
    @MaNV VARCHAR(10) = NULL,                -- Nếu cần liên kết nhân viên thực hiện
    @NgayBaoTri DATE,
    @MoTa NVARCHAR(200),
    @ChiPhi FLOAT,
    @KetQua NVARCHAR(50)
AS
BEGIN
    -- Thêm log bảo trì vào bảng BaoTri
    INSERT INTO BaoTri(MaTB, MaNV, NgayBaoTri, MoTa, ChiPhi, KetQua)
    VALUES(@MaTB, @MaNV, @NgayBaoTri, @MoTa, @ChiPhi, @KetQua);
END
GO

CREATE TRIGGER trg_UpdateTinhTrang
ON BaoTri
AFTER INSERT
AS
BEGIN
    DECLARE @MaTB VARCHAR(10), @KetQua NVARCHAR(50);

    -- Lấy dữ liệu từ bảng inserted (dòng mới thêm vào)
    SELECT @MaTB = MaTB, @KetQua = KetQua FROM inserted;

    -- Kiểm tra kết quả bảo trì và cập nhật trạng thái thiết bị
    IF @KetQua = N'Sửa xong'
        UPDATE ThietBi SET TinhTrang = N'Đang sử dụng' WHERE MaTB = @MaTB;
    ELSE IF @KetQua = N'Hỏng' OR @KetQua = N'Không sửa được'
        UPDATE ThietBi SET TinhTrang = N'Hỏng' WHERE MaTB = @MaTB;
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

-- Thiết bị cần bảo trì
CREATE PROCEDURE sp_ReportCanBaoTri
AS
BEGIN
    SELECT MaTB, TenTB, TinhTrang, ViTri
    FROM ThietBi
    WHERE TinhTrang = N'Cần bảo trì';
END
GO

-- Tổng chi phí bảo trì theo tháng
CREATE PROCEDURE sp_ReportTongChiPhi
AS
BEGIN
    SELECT YEAR(NgayBaoTri) AS Nam,
           MONTH(NgayBaoTri) AS Thang,
           SUM(ChiPhi) AS TongChiPhi
    FROM BaoTri
    GROUP BY YEAR(NgayBaoTri), MONTH(NgayBaoTri)
    ORDER BY Nam DESC, Thang DESC;
END
GO

-- Top thiết bị tốn nhiều chi phí nhất
CREATE PROCEDURE sp_ReportTopChiPhi
AS
BEGIN
    SELECT TOP 5 bt.MaTB, tb.TenTB, SUM(bt.ChiPhi) AS TongChiPhi
    FROM BaoTri bt
    INNER JOIN ThietBi tb ON bt.MaTB = tb.MaTB
    GROUP BY bt.MaTB, tb.TenTB
    ORDER BY TongChiPhi DESC;
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