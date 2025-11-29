CREATE DATABASE FashionShopDB;
GO

USE FashionShopDB;
GO

-- Bảng Loại sản phẩm
CREATE TABLE LoaiSanPham (
    MaLoai INT PRIMARY KEY IDENTITY(1,1),
    TenLoai NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(255)
);

-- Bảng Sản phẩm
CREATE TABLE SanPham (
    MaSP INT PRIMARY KEY IDENTITY(1,1),
    TenSP NVARCHAR(200) NOT NULL,
    MoTa NVARCHAR(MAX),
    GiaBan DECIMAL(18,2) NOT NULL,
    SoLuongTon INT NOT NULL DEFAULT 0,
    Size NVARCHAR(10),
    MauSac NVARCHAR(50),
    MaLoai INT,
    NgayNhap DATETIME DEFAULT GETDATE(),
    TrangThai BIT DEFAULT 1,
    FOREIGN KEY (MaLoai) REFERENCES LoaiSanPham(MaLoai)
);

-- Bảng Khách hàng
CREATE TABLE KhachHang (
    MaKH INT PRIMARY KEY IDENTITY(1,1),
    TenKH NVARCHAR(100) NOT NULL,
    SoDT VARCHAR(15),
    DiaChi NVARCHAR(255),
    Email VARCHAR(100),
    NgayDangKy DATETIME DEFAULT GETDATE(),
    DiemTichLuy DECIMAL(18,2) DEFAULT 0
);

-- Bảng Nhân viên
CREATE TABLE NhanVien (
    MaNV INT PRIMARY KEY IDENTITY(1,1),
    TenNV NVARCHAR(100) NOT NULL,
    SoDT VARCHAR(15),
    DiaChi NVARCHAR(255),
    ChucVu NVARCHAR(50),
    Luong DECIMAL(18,2),
    NgayVaoLam DATETIME DEFAULT GETDATE()
);

-- Bảng Tài khoản
CREATE TABLE TaiKhoan (
    Username VARCHAR(50) PRIMARY KEY,
    Password VARCHAR(255) NOT NULL,
    Quyen NVARCHAR(20) NOT NULL, -- Admin, NhanVien
    MaNV INT,
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);

-- Bảng Hóa đơn
CREATE TABLE HoaDon (
    MaHD INT PRIMARY KEY IDENTITY(1,1),
    NgayLap DATETIME DEFAULT GETDATE(),
    MaKH INT,
    MaNV INT,
    TongTien DECIMAL(18,2),
    GiamGia DECIMAL(18,2) DEFAULT 0,
    ThanhTien DECIMAL(18,2),
    FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);

-- Bảng Chi tiết hóa đơn
CREATE TABLE ChiTietHoaDon (
    MaCTHD INT PRIMARY KEY IDENTITY(1,1),
    MaHD INT,
    MaSP INT,
    SoLuong INT NOT NULL,
    DonGia DECIMAL(18,2) NOT NULL,
    ThanhTien DECIMAL(18,2),
    FOREIGN KEY (MaHD) REFERENCES HoaDon(MaHD),
    FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);

-- Insert dữ liệu mẫu
INSERT INTO LoaiSanPham (TenLoai, MoTa) VALUES
(N'Áo thun', N'Áo thun nam nữ các loại'),
(N'Quần jean', N'Quần jean thời trang'),
(N'Váy', N'Váy nữ các loại');

INSERT INTO SanPham (TenSP, MoTa, GiaBan, SoLuongTon, Size, MauSac, MaLoai) VALUES
(N'Áo thun basic', N'Áo thun cotton', 150000, 50, 'M', N'Trắng', 1),
(N'Quần jean skinny', N'Quần jean co giãn', 350000, 30, 'L', N'Xanh đen', 2),
(N'Váy hoa', N'Váy hoa nhí', 280000, 20, 'S', N'Hồng', 3);

INSERT INTO NhanVien (TenNV, SoDT, ChucVu, Luong) VALUES
(N'Nguyễn Văn A', '0901234567', N'Quản lý', 10000000),
(N'Trần Thị B', '0912345678', N'Nhân viên', 7000000);

INSERT INTO TaiKhoan (Username, Password, Quyen, MaNV) VALUES
('admin', '123456', 'Admin', 1),
('nhanvien1', '123456', 'NhanVien', 2);

GO