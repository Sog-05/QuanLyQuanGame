/* S?a d? li?u ti?ng Vi?t b? l?i trong CSDL (ch?y sau khi ?ã có d? li?u) */
USE QuanLyQuanGame;
GO

UPDATE KhuVuc SET TenKhuVuc = N'Phòng Th??ng' WHERE TenKhuVuc LIKE N'%Th??ng%' OR TenKhuVuc LIKE N'%Thuong%';
UPDATE KhuVuc SET TenKhuVuc = N'Phòng VIP' WHERE TenKhuVuc LIKE N'%VIP%';
UPDATE KhuVuc SET TenKhuVuc = N'Khu Thi ??u' WHERE TenKhuVuc LIKE N'%Thi%' OR TenKhuVuc LIKE N'%??u%';
UPDATE KhuVuc SET TenKhuVuc = N'Khu Stream' WHERE TenKhuVuc LIKE N'%Stream%';
UPDATE KhuVuc SET TenKhuVuc = N'Phòng Couple' WHERE TenKhuVuc LIKE N'%Couple%';

UPDATE LoaiMon SET TenLoai = N'N??c gi?i khát' WHERE MaLoai = 1;
UPDATE LoaiMon SET TenLoai = N'Mì gói' WHERE MaLoai = 2;
UPDATE LoaiMon SET TenLoai = N'C?m' WHERE MaLoai = 3;
UPDATE LoaiMon SET TenLoai = N'?n v?t' WHERE MaLoai = 4;
UPDATE LoaiMon SET TenLoai = N'Th? n?p' WHERE MaLoai = 5;

UPDATE NhanVien SET TenNhanVien = N'Qu?n tr? viên' WHERE MaNguoiDung IN (SELECT MaNguoiDung FROM TaiKhoan WHERE TenDangNhap = 'admin');

UPDATE HoaDon SET LoaiHoaDon = N'Hóa ??n d?ch v?' WHERE LoaiHoaDon LIKE N'%d?ch%' OR LoaiHoaDon LIKE N'%dich%';
UPDATE HoaDon SET LoaiHoaDon = N'Hóa ??n b?o trì' WHERE LoaiHoaDon LIKE N'%b?o%' OR LoaiHoaDon LIKE N'%bao%';

UPDATE BaoTri SET TrangThaiBaoTri = N'Hoàn thành' WHERE TrangThaiBaoTri LIKE N'%Hoàn%' OR TrangThaiBaoTri LIKE N'%Hoan%';

PRINT N'? ?ã c?p nh?t d? li?u ti?ng Vi?t.';
