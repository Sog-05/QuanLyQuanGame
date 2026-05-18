/* RESET DB */
IF DB_ID('QuanLyQuanGame') IS NOT NULL
BEGIN
    ALTER DATABASE QuanLyQuanGame SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QuanLyQuanGame;
END
GO

CREATE DATABASE QuanLyQuanGame COLLATE Vietnamese_CI_AS;
GO
USE QuanLyQuanGame;
GO

/* ========== 1. DANH MỤC ========== */
CREATE TABLE KhuVuc (
    MaKhuVuc INT IDENTITY PRIMARY KEY,
    TenKhuVuc NVARCHAR(100) NOT NULL,
    GiaTheoGio MONEY NOT NULL
);

CREATE TABLE CPU (MaCPU INT IDENTITY PRIMARY KEY, TenCPU NVARCHAR(100) NOT NULL);
CREATE TABLE GPU (MaGPU INT IDENTITY PRIMARY KEY, TenGPU NVARCHAR(100) NOT NULL);
CREATE TABLE RAM (MaRAM INT IDENTITY PRIMARY KEY, TenRAM NVARCHAR(100) NOT NULL);
CREATE TABLE SSD (MaSSD INT IDENTITY PRIMARY KEY, TenSSD NVARCHAR(100) NOT NULL);
CREATE TABLE HDD (MaHDD INT IDENTITY PRIMARY KEY, TenHDD NVARCHAR(100) NOT NULL);
CREATE TABLE BanPhim (MaBanPhim INT IDENTITY PRIMARY KEY, TenBanPhim NVARCHAR(100) NOT NULL);
CREATE TABLE Chuot (MaChuot INT IDENTITY PRIMARY KEY, TenChuot NVARCHAR(100) NOT NULL);

CREATE TABLE ManHinh (
    MaManHinh INT IDENTITY PRIMARY KEY,
    TenManHinh NVARCHAR(100) NOT NULL,
    KichThuoc NVARCHAR(50),
    LoaiMan NVARCHAR(50),
    TanSo INT,
    DoPhanGiai NVARCHAR(50)
);

/* ========== 2. MÁY ========== */
CREATE TABLE MayTinh (
    MaMay INT IDENTITY PRIMARY KEY,
    MaKhuVuc INT NOT NULL,
    TenMay NVARCHAR(100) NOT NULL,
    TrangThaiMay NVARCHAR(50),
    MaCPU INT NOT NULL,
    MaGPU INT NOT NULL,
    MaRAM INT NOT NULL,
    MaSSD INT NOT NULL,
    MaHDD INT NOT NULL,
    MaManHinh INT NOT NULL,
    MaBanPhim INT NOT NULL,
    MaChuot INT NOT NULL,
    CONSTRAINT FK_MayTinh_KhuVuc FOREIGN KEY (MaKhuVuc) REFERENCES KhuVuc(MaKhuVuc),
    CONSTRAINT FK_MayTinh_CPU FOREIGN KEY (MaCPU) REFERENCES CPU(MaCPU),
    CONSTRAINT FK_MayTinh_GPU FOREIGN KEY (MaGPU) REFERENCES GPU(MaGPU),
    CONSTRAINT FK_MayTinh_RAM FOREIGN KEY (MaRAM) REFERENCES RAM(MaRAM),
    CONSTRAINT FK_MayTinh_SSD FOREIGN KEY (MaSSD) REFERENCES SSD(MaSSD),
    CONSTRAINT FK_MayTinh_HDD FOREIGN KEY (MaHDD) REFERENCES HDD(MaHDD),
    CONSTRAINT FK_MayTinh_ManHinh FOREIGN KEY (MaManHinh) REFERENCES ManHinh(MaManHinh),
    CONSTRAINT FK_MayTinh_BanPhim FOREIGN KEY (MaBanPhim) REFERENCES BanPhim(MaBanPhim),
    CONSTRAINT FK_MayTinh_Chuot FOREIGN KEY (MaChuot) REFERENCES Chuot(MaChuot)
);

/* ========== 3. USER ========== */
CREATE TABLE VaiTro (
    ma_role INT IDENTITY PRIMARY KEY,
    mo_ta NVARCHAR(255),
    ten_role NVARCHAR(100) NOT NULL
);

CREATE TABLE NguoiDung (
    user_id INT IDENTITY PRIMARY KEY,
    username NVARCHAR(50) NOT NULL UNIQUE,
    password_hash NVARCHAR(255) NOT NULL,
    status NVARCHAR(50),
    ma_role INT NOT NULL,
    CONSTRAINT FK_NguoiDung_VaiTro FOREIGN KEY (ma_role) REFERENCES VaiTro(ma_role)
);

CREATE TABLE NhanVien (
    MaNhanVien INT IDENTITY PRIMARY KEY,
    TenNhanVien NVARCHAR(100) NOT NULL,
    GioiTinh NVARCHAR(10),
    NgaySinh DATE,
    SoDienThoai NVARCHAR(15),
    role NVARCHAR(50),
    ma_role INT NOT NULL,
    user_id INT NOT NULL,
    CONSTRAINT FK_NhanVien_VaiTro FOREIGN KEY (ma_role) REFERENCES VaiTro(ma_role),
    CONSTRAINT FK_NhanVien_NguoiDung FOREIGN KEY (user_id) REFERENCES NguoiDung(user_id)
);

CREATE TABLE KhachHang (
    MaKhachHang INT IDENTITY PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100),
    SoDienThoai NVARCHAR(15),
    DiemTichLuy INT DEFAULT 0,
    SoDu MONEY DEFAULT 0,
    GioChoiConLai INT DEFAULT 0,
    user_id INT NOT NULL,
    CONSTRAINT FK_KhachHang_NguoiDung FOREIGN KEY (user_id) REFERENCES NguoiDung(user_id)
);

/* ========== 4. PHIÊN + HÓA ĐƠN ========== */
CREATE TABLE PhienSuDung (
    MaPhien INT IDENTITY PRIMARY KEY,
    MaMay INT NOT NULL,
    ThoiGianBatDau DATETIME NOT NULL,
    ThoiGianKetThuc DATETIME,
    ChiPhi MONEY,
    MaKhachHang INT NOT NULL,
    ThoiLuong INT,
    CONSTRAINT FK_PhienSuDung_MayTinh FOREIGN KEY (MaMay) REFERENCES MayTinh(MaMay),
    CONSTRAINT FK_PhienSuDung_KhachHang FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang)
);

CREATE TABLE HoaDon (
    MaHoaDon INT IDENTITY PRIMARY KEY,
    LoaiHoaDon NVARCHAR(50),
    NgayLap DATETIME, -- The word document says DATE but code needs DATETIME for hours
    MaNhanVien INT, -- The word document says NOT NULL but for service invoices, it could be null initially
    TongTien MONEY,
    MaPhien INT,
    CONSTRAINT FK_HoaDon_NhanVien FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    CONSTRAINT FK_HoaDon_PhienSuDung FOREIGN KEY (MaPhien) REFERENCES PhienSuDung(MaPhien)
);

/* ========== 5. ĐỒ ĂN ========== */
CREATE TABLE LoaiMonAn (
    MaLoai INT IDENTITY PRIMARY KEY,
    TenLoai NVARCHAR(100) NOT NULL
);

CREATE TABLE MonAn (
    MaMon INT IDENTITY PRIMARY KEY,
    TenMon NVARCHAR(100) NOT NULL,
    GiaBan MONEY,
    GiaNhap MONEY,
    TonKho INT,
    MaLoai INT NOT NULL,
    HinhAnh NVARCHAR(255),
    CONSTRAINT FK_MonAn_LoaiMonAn FOREIGN KEY (MaLoai) REFERENCES LoaiMonAn(MaLoai)
);

CREATE TABLE ThucDon (
    id INT IDENTITY(1,1) PRIMARY KEY,
    MaMon INT NOT NULL,
    ngay_them DATE,
    trang_thai NVARCHAR(50),
    CONSTRAINT FK_ThucDon_MonAn FOREIGN KEY (MaMon) REFERENCES MonAn(MaMon)
);

CREATE TABLE ChiTietHoaDon (
    MaHoaDon INT NOT NULL,
    MaMon INT NOT NULL,
    SoLuong INT NOT NULL,
    DoanhThu MONEY,
    ID INT IDENTITY(1,1) PRIMARY KEY,
    CONSTRAINT FK_ChiTietHoaDon_HoaDon FOREIGN KEY (MaHoaDon) REFERENCES HoaDon(MaHoaDon),
    CONSTRAINT FK_ChiTietHoaDon_MonAn FOREIGN KEY (MaMon) REFERENCES MonAn(MaMon)
);

/* ========== 6. BẢO TRÌ ========== */
CREATE TABLE BaoTri (
    MaBaoTri INT IDENTITY PRIMARY KEY,
    TrangThaiBaoTri NVARCHAR(50),
    MaMay INT NOT NULL,
    MaHoaDon INT,
    ChiPhi MONEY,
    CONSTRAINT FK_BaoTri_MayTinh FOREIGN KEY (MaMay) REFERENCES MayTinh(MaMay),
    CONSTRAINT FK_BaoTri_HoaDon FOREIGN KEY (MaHoaDon) REFERENCES HoaDon(MaHoaDon)
);

CREATE TABLE ChiTietBaoTri (
    MaBaoTri INT NOT NULL,
    TenLinhKien NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(255),
    PRIMARY KEY (MaBaoTri, TenLinhKien),
    CONSTRAINT FK_ChiTietBaoTri_BaoTri FOREIGN KEY (MaBaoTri) REFERENCES BaoTri(MaBaoTri)
);

/* ========== 7. CHAT, NHẬP HÀNG, NẠP TIỀN (KEEPING EXISTING AS WELL) ========== */
CREATE TABLE TinNhan (
    MaTin INT IDENTITY PRIMARY KEY,
    MaMay INT,
    MaKhachHang INT,
    MaNhanVien INT,
    NoiDung NVARCHAR(500) NOT NULL,
    ThoiGian DATETIME NOT NULL DEFAULT GETDATE(),
    LoaiNguoiGui NVARCHAR(20) NOT NULL,
    FOREIGN KEY (MaMay) REFERENCES MayTinh(MaMay),
    FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);

CREATE TABLE NhapHang (
    MaNhap INT IDENTITY PRIMARY KEY,
    MaMon INT NOT NULL,
    SoLuong INT NOT NULL,
    GiaNhap MONEY,
    NgayNhap DATETIME NOT NULL DEFAULT GETDATE(),
    MaNhanVien INT,
    FOREIGN KEY (MaMon) REFERENCES MonAn(MaMon),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);

CREATE TABLE NapTien (
    MaNap INT IDENTITY PRIMARY KEY,
    MaKhachHang INT NOT NULL,
    SoTien MONEY NOT NULL,
    NgayNap DATETIME NOT NULL DEFAULT GETDATE(),
    MaNhanVien INT,
    GhiChu NVARCHAR(255),
    FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);
GO

/* PROCEDURES (Based on Section 2.4 in Word Document) */

CREATE PROCEDURE [dbo].[GetBillByDate]
    @ngaybd DATETIME,
    @ngaykt DATETIME
AS
BEGIN
    SELECT 
        h.NgayLap AS BillingDate,
        nv.TenNhanVien AS EmployeeName,
        h.LoaiHoaDon AS BillingType,
        ISNULL(sd.ChiPhi, 0) AS SessionCost,
        ISNULL(mt.MaintainanceCost, 0) AS MaintainanceCost,
        ISNULL(fd.FoodCost, 0) AS FoodCost,
        h.TongTien AS Amount
    FROM HoaDon h
    LEFT JOIN NhanVien nv ON h.MaNhanVien = nv.MaNhanVien
    LEFT JOIN PhienSuDung sd ON h.MaPhien = sd.MaPhien
    LEFT JOIN (
        SELECT MaHoaDon, SUM(ChiPhi) AS MaintainanceCost
        FROM BaoTri
        GROUP BY MaHoaDon
    ) mt ON h.MaHoaDon = mt.MaHoaDon
    LEFT JOIN (
        SELECT cthd.MaHoaDon, SUM(ma.GiaBan * cthd.SoLuong) AS FoodCost
        FROM ChiTietHoaDon cthd
        INNER JOIN MonAn ma ON cthd.MaMon = ma.MaMon
        GROUP BY cthd.MaHoaDon
    ) fd ON h.MaHoaDon = fd.MaHoaDon
    WHERE h.NgayLap BETWEEN @ngaybd AND @ngaykt;
END;
GO

CREATE PROCEDURE [dbo].[LayPhienSuDungChuaThanhToan]
    @comid NVARCHAR(50)
AS
BEGIN
    DECLARE @Ma INT = TRY_CAST(@comid AS INT);
    SELECT hd.MaHoaDon, mt.TenMay AS ComputerName, mt.TrangThaiMay, us.ThoiGianBatDau
    FROM PhienSuDung us
    INNER JOIN MayTinh mt ON us.MaMay = mt.MaMay
    LEFT JOIN HoaDon hd ON us.MaPhien = hd.MaPhien
    WHERE us.MaMay = @Ma AND hd.NgayLap IS NULL;
END;
GO

CREATE PROCEDURE [dbo].[LayThongTinHoaDon]
    @mahoadon NVARCHAR(50)
AS
BEGIN
    DECLARE @Ma INT = TRY_CAST(@mahoadon AS INT);
    SELECT 
        b.NgayLap, 
        e.TenNhanVien, 
        b.LoaiHoaDon,
        ISNULL(us.ChiPhi, 0) AS SessionCost,
        ISNULL(SUM(m.ChiPhi), 0) AS MaintainanceCost,
        ISNULL(SUM(f.GiaBan * fd.SoLuong), 0) AS FoodCost,
        b.TongTien AS Amount
    FROM HoaDon b
    LEFT JOIN NhanVien e ON b.MaNhanVien = e.MaNhanVien
    LEFT JOIN PhienSuDung us ON b.MaPhien = us.MaPhien
    LEFT JOIN BaoTri m ON b.MaHoaDon = m.MaHoaDon
    LEFT JOIN ChiTietHoaDon fd ON b.MaHoaDon = fd.MaHoaDon
    LEFT JOIN MonAn f ON f.MaMon = fd.MaMon
    WHERE b.MaHoaDon = @Ma
    GROUP BY b.NgayLap, e.TenNhanVien, b.LoaiHoaDon, us.ChiPhi, b.TongTien;
END;
GO

CREATE PROCEDURE [dbo].[LayThongTinMaintainanceChuaThanhToan]
    @mamay TINYINT
AS
BEGIN
    SELECT m.MaBaoTri, m.MaHoaDon, md.TenLinhKien, md.MoTa
    FROM BaoTri m
    INNER JOIN ChiTietBaoTri md ON m.MaBaoTri = md.MaBaoTri
    WHERE m.MaMay = @mamay AND m.ChiPhi IS NULL;
END;
GO

CREATE PROCEDURE [dbo].[LayThongTinMayTinhTheoKhuVuc]
    @ZoneID NVARCHAR(50)
AS
BEGIN
    DECLARE @Ma INT = TRY_CAST(@ZoneID AS INT);
    SELECT c.MaMay, c.TenMay, z.TenKhuVuc, c.TrangThaiMay, z.GiaTheoGio, 
           cpu.TenCPU, gpu.TenGPU, hdd.TenHDD, ssd.TenSSD, 
           m.TenChuot, k.TenBanPhim, mn.TenManHinh
    FROM MayTinh c
    INNER JOIN KhuVuc z ON c.MaKhuVuc = z.MaKhuVuc
    LEFT JOIN CPU cpu ON c.MaCPU = cpu.MaCPU
    LEFT JOIN GPU gpu ON c.MaGPU = gpu.MaGPU
    LEFT JOIN HDD hdd ON c.MaHDD = hdd.MaHDD
    LEFT JOIN SSD ssd ON c.MaSSD = ssd.MaSSD
    LEFT JOIN Chuot m ON c.MaChuot = m.MaChuot
    LEFT JOIN BanPhim k ON c.MaBanPhim = k.MaBanPhim
    LEFT JOIN ManHinh mn ON c.MaManHinh = mn.MaManHinh
    WHERE c.MaKhuVuc = @Ma;
END;
GO

CREATE PROCEDURE [dbo].[LayThongTinMonAnChuaThanhToan]
    @mamay NVARCHAR(50)
AS
BEGIN
    DECLARE @Ma INT = TRY_CAST(@mamay AS INT);
    SELECT fd.MaMon, f.TenMon, f.MaLoai, fd.SoLuong, f.GiaBan, f.GiaNhap, f.HinhAnh
    FROM PhienSuDung us
    INNER JOIN HoaDon b ON us.MaPhien = b.MaPhien
    INNER JOIN ChiTietHoaDon fd ON b.MaHoaDon = fd.MaHoaDon
    INNER JOIN MonAn f ON fd.MaMon = f.MaMon
    WHERE us.MaMay = @Ma AND b.LoaiHoaDon = N'Hóa đơn dịch vụ' AND b.NgayLap IS NULL;
END;
GO

CREATE PROCEDURE [dbo].[Pro_Dodulieuvaochitiethoadon]
    @HoadonID INT,
    @MonanID INT,
    @sl INT
AS
BEGIN
    INSERT INTO ChiTietHoaDon(MaHoaDon, MaMon, SoLuong)
    VALUES (@HoadonID, @MonanID, @sl)
END;
GO

CREATE PROCEDURE [dbo].[Proc_CapNhatTrangThaiMay]
    @mamay INT,
    @status NVARCHAR(50)
AS
BEGIN
    UPDATE MayTinh
    SET TrangThaiMay = @status
    WHERE MaMay = @mamay
END;
GO

CREATE PROCEDURE [dbo].[Proc_LayChiTietPhienSuDung]
    @mamay INT
AS
BEGIN
    SELECT 
        mt.TenMay AS ComputerName,
        CASE WHEN mt.TrangThaiMay = N'Offline' OR mt.TrangThaiMay = N'Bảo trì' THEN NULL
             WHEN mt.TrangThaiMay = N'Online' AND hd.NgayLap IS NULL THEN ps.MaPhien 
             ELSE ps.MaPhien END AS MaPhien,
        CASE WHEN mt.TrangThaiMay = N'Offline' OR mt.TrangThaiMay = N'Bảo trì' THEN NULL
             WHEN mt.TrangThaiMay = N'Online' AND hd.NgayLap IS NULL THEN ps.ThoiGianBatDau 
             ELSE ps.ThoiGianBatDau END AS StartTime,
        mt.TrangThaiMay AS ComputerStatus
    FROM MayTinh mt
    LEFT JOIN PhienSuDung ps ON mt.MaMay = ps.MaMay
    LEFT JOIN HoaDon hd ON hd.MaPhien = ps.MaPhien
    WHERE mt.MaMay = @mamay
    ORDER BY ps.ThoiGianBatDau DESC
END;
GO


/* ================= SEED DATA ================= */

INSERT INTO VaiTro (mo_ta, ten_role) VALUES (N'Quản trị viên', N'Admin'), (N'Nhân viên phục vụ', N'NhanVien'), (N'Khách hàng', N'KhachHang');

INSERT INTO KhuVuc (TenKhuVuc, GiaTheoGio) VALUES (N'Phòng Thường', 8000), (N'Phòng VIP', 15000), (N'Khu Thi Đấu', 25000), (N'Khu Stream', 30000), (N'Phòng Couple', 20000);
INSERT INTO CPU (TenCPU) VALUES ('Core i3-12100F'), ('Core i5-13400F'), ('Core i7-14700K'), ('Ryzen 5 7600'), ('Ryzen 7 7800X3D');
INSERT INTO GPU (TenGPU) VALUES ('GTX 1650'), ('RTX 3060'), ('RTX 4060 Ti'), ('RTX 4070'), ('RTX 4090');
INSERT INTO RAM (TenRAM) VALUES ('8GB'), ('16GB'), ('32GB'), ('64GB'), ('128GB');
INSERT INTO SSD (TenSSD) VALUES ('256GB'), ('512GB'), ('1TB'), ('2TB'), ('4TB');
INSERT INTO HDD (TenHDD) VALUES ('1TB'), ('2TB'), ('4TB'), ('None'), ('None');
INSERT INTO ManHinh (TenManHinh, KichThuoc, LoaiMan, TanSo, DoPhanGiai) VALUES (N'Samsung', '24"', 'VA', 144, 'FHD'), (N'LG', '27"', 'IPS', 165, '2K'), (N'Asus', '25"', 'IPS', 240, 'FHD'), (N'BenQ', '24.5"', 'TN', 360, 'FHD'), (N'Dell', '27"', 'IPS', 60, '4K');
INSERT INTO BanPhim (TenBanPhim) VALUES (N'Logitech G213'), (N'Razer BlackWidow'), (N'Akko 3087'), (N'Corsair K70'), (N'DareU EK87');
INSERT INTO Chuot (TenChuot) VALUES (N'Logitech G102'), (N'Razer DeathAdder'), (N'Zowie EC2'), (N'G-Pro Wireless'), (N'SteelSeries Rival');
INSERT INTO LoaiMonAn (TenLoai) VALUES (N'Nước giải khát'), (N'Mì gói'), (N'Cơm'), (N'Ăn vặt'), (N'Thẻ nạp');

INSERT INTO MonAn (TenMon, GiaBan, GiaNhap, TonKho, MaLoai)
SELECT T.Ten, T.GiaB, T.GiaN, 100, L.MaLoai
FROM (VALUES 
    (N'Sting Dâu', 12000, 8000, N'Nước'), (N'Coca Cola', 12000, 8000, N'Nước'), (N'Pepsi', 12000, 8000, N'Nước'),
    (N'Mì Hảo Hảo', 15000, 5000, N'Mì'), (N'Mì Trứng', 20000, 8000, N'Mì'), (N'Mì Xào Bò', 35000, 15000, N'Mì'),
    (N'Cơm Đùi Gà', 45000, 25000, N'Cơm'), (N'Cơm Sườn', 45000, 25000, N'Cơm'), (N'Bánh Mì Que', 15000, 7000, N'vặt'),
    (N'Xúc Xích', 15000, 7000, N'vặt'), (N'Khô Gà', 25000, 15000, N'vặt'), (N'Thẻ Garena 20k', 20000, 19000, N'nạp')
) AS T(Ten, GiaB, GiaN, LoaiKey)
JOIN LoaiMonAn L ON L.TenLoai LIKE '%' + T.LoaiKey + '%';

INSERT INTO ThucDon (MaMon, ngay_them, trang_thai)
SELECT MaMon, GETDATE(), N'Đang bán' FROM MonAn;

DECLARE @i INT = 1;
WHILE @i <= 25
BEGIN
    INSERT INTO MayTinh (TenMay, MaKhuVuc, MaCPU, MaGPU, MaRAM, MaSSD, MaHDD, MaManHinh, MaBanPhim, MaChuot, TrangThaiMay)
    SELECT TOP 1 CONCAT('PC-', FORMAT(@i, '00')), MaKhuVuc, 
    (SELECT TOP 1 MaCPU FROM CPU ORDER BY NEWID()), (SELECT TOP 1 MaGPU FROM GPU ORDER BY NEWID()),
    (SELECT TOP 1 MaRAM FROM RAM ORDER BY NEWID()), (SELECT TOP 1 MaSSD FROM SSD ORDER BY NEWID()),
    (SELECT TOP 1 MaHDD FROM HDD ORDER BY NEWID()), (SELECT TOP 1 MaManHinh FROM ManHinh ORDER BY NEWID()),
    (SELECT TOP 1 MaBanPhim FROM BanPhim ORDER BY NEWID()), (SELECT TOP 1 MaChuot FROM Chuot ORDER BY NEWID()),
    N'Offline'
    FROM KhuVuc ORDER BY NEWID();
    SET @i += 1;
END

INSERT INTO NguoiDung (username, password_hash, status, ma_role) VALUES ('admin', '46708f23d682fef9aa996ecbb139bfb6c9ffdc039905ad6ad5c85a88b9411d97', N'HoatDong', 1);
DECLARE @adminUID INT = SCOPE_IDENTITY();
INSERT INTO NhanVien (TenNhanVien, GioiTinh, NgaySinh, SoDienThoai, role, ma_role, user_id)
VALUES (N'Quản trị viên', N'Nam', '1990-01-01', '0900000000', N'Admin', 1, @adminUID);

INSERT INTO NguoiDung (username, password_hash, status, ma_role) VALUES ('nhanvien', '46708f23d682fef9aa996ecbb139bfb6c9ffdc039905ad6ad5c85a88b9411d97', N'HoatDong', 2);
DECLARE @nvUID INT = SCOPE_IDENTITY();
INSERT INTO NhanVien (TenNhanVien, GioiTinh, NgaySinh, SoDienThoai, role, ma_role, user_id)
VALUES (N'Nhân viên phòng máy', N'Nữ', '2000-01-01', '0988888888', N'Staff', 2, @nvUID);

INSERT INTO NguoiDung (username, password_hash, status, ma_role) VALUES ('khach', '46708f23d682fef9aa996ecbb139bfb6c9ffdc039905ad6ad5c85a88b9411d97', N'HoatDong', 3);
DECLARE @khachUID INT = SCOPE_IDENTITY();
INSERT INTO KhachHang (HoTen, Email, SoDienThoai, DiemTichLuy, SoDu, GioChoiConLai, user_id)
VALUES (N'Khách Lẻ', N'khach@gmail.com', '0123456789', 0, 50000, 2, @khachUID);

PRINT N'✅ ĐÃ TẠO DATABASE QUANLYQUANGAME THEO ĐÚNG REPORT WORD!';
