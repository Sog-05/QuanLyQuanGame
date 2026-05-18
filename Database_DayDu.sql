/* Ch?y file này N?U ?ã có Database.sql c? (thi?u b?ng m? r?ng) */
USE QuanLyQuanGame;
GO

IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('MonAn') AND name = 'HienThucDon')
    ALTER TABLE MonAn ADD HienThucDon BIT NOT NULL DEFAULT 1;
GO

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'TinNhan')
BEGIN
    CREATE TABLE TinNhan (
        MaTin INT IDENTITY PRIMARY KEY,
        MaMay INT, MaKhachHang INT, MaNhanVien INT,
        NoiDung NVARCHAR(500) NOT NULL,
        ThoiGian DATETIME NOT NULL DEFAULT GETDATE(),
        LoaiNguoiGui NVARCHAR(20) NOT NULL,
        FOREIGN KEY (MaMay) REFERENCES MayTinh(MaMay),
        FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang),
        FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
    );
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'NhapHang')
BEGIN
    CREATE TABLE NhapHang (
        MaNhap INT IDENTITY PRIMARY KEY,
        MaMon INT NOT NULL, SoLuong INT NOT NULL, GiaNhap DECIMAL(10,2),
        NgayNhap DATETIME NOT NULL DEFAULT GETDATE(), MaNhanVien INT,
        FOREIGN KEY (MaMon) REFERENCES MonAn(MaMon),
        FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
    );
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'NapTien')
BEGIN
    CREATE TABLE NapTien (
        MaNap INT IDENTITY PRIMARY KEY,
        MaKhachHang INT NOT NULL, SoTien DECIMAL(10,2) NOT NULL,
        NgayNap DATETIME NOT NULL DEFAULT GETDATE(), MaNhanVien INT,
        GhiChu NVARCHAR(255),
        FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang),
        FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
    );
END
GO

UPDATE MonAn SET HienThucDon = 1 WHERE HienThucDon IS NULL;
GO

PRINT N'? Database_DayDu.sql — ?ã b? sung b?ng TinNhan, NhapHang, NapTien, c?t HienThucDon.';
