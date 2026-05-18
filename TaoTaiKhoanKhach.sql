/* Ch?y file này n?u ?ã có DB c? - t?o tài kho?n khách c? ??nh ?? ??ng nh?p */
USE QuanLyQuanGame;
GO

DECLARE @i INT = 1;
WHILE @i <= 25
BEGIN
    DECLARE @User VARCHAR(50) = 'khach' + CAST(@i AS VARCHAR);

    IF NOT EXISTS (SELECT 1 FROM TaiKhoan WHERE TenDangNhap = @User)
    BEGIN
        INSERT INTO TaiKhoan (TenDangNhap, MatKhau, TrangThai, LoaiTaiKhoan)
        VALUES (@User, 'Pass123!', N'HoatDong', N'KhachHang');

        DECLARE @uid INT = SCOPE_IDENTITY();
        INSERT INTO KhachHang (HoTen, Email, SoDienThoai, DiemTichLuy, SoDu, GioChoiConLai, MaNguoiDung)
        VALUES (N'Khách hàng ' + CAST(@i AS NVARCHAR), @User + '@gmail.com', '090000000' + RIGHT('0' + CAST(@i AS VARCHAR), 2),
                100, 100000, 5, @uid);
    END
    SET @i += 1;
END

/* Tài kho?n khách th? nhanh */
IF NOT EXISTS (SELECT 1 FROM TaiKhoan WHERE TenDangNhap = 'khach')
BEGIN
    INSERT INTO TaiKhoan (TenDangNhap, MatKhau, TrangThai, LoaiTaiKhoan)
    VALUES ('khach', 'Pass123!', N'HoatDong', N'KhachHang');
    DECLARE @k INT = SCOPE_IDENTITY();
    INSERT INTO KhachHang VALUES (N'Khách th?', 'khach@gmail.com', '0909123456', 0, 500000, 10, @k);
END

PRINT N'? ?ã t?o tài kho?n khách: khach1..khach25 và khach — m?t kh?u Pass123!';
