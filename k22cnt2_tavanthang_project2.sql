CREATE DATABASE k22cnt3_tavanthang_project02;
GO
USE k22cnt3_tavanthang_project02;
GO

-- Bảng quản trị viên
CREATE TABLE QUAN_TRI_VIEN (
    QUAN_TRI_ID INT PRIMARY KEY IDENTITY(1,1),
    HO_TEN NVARCHAR(100) NOT NULL,
    EMAIL NVARCHAR(100) UNIQUE NOT NULL,
    MAT_KHAU NVARCHAR(255) NOT NULL,
    TRANG_THAI BIT DEFAULT 1 -- 1: Hoạt động, 0: Bị khóa
);

-- Bảng ghi log hoạt động của quản trị viên
CREATE TABLE LOG_HOAT_DONG (
    LOG_ID INT PRIMARY KEY IDENTITY(1,1),
    QUAN_TRI_ID INT,
    NOI_DUNG NVARCHAR(255),
    THOI_GIAN DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (QUAN_TRI_ID) REFERENCES QUAN_TRI_VIEN(QUAN_TRI_ID) ON DELETE SET NULL
);


CREATE TABLE KHACH_HANG (
    KHACH_HANG_ID INT PRIMARY KEY IDENTITY(1,1),
    HO_TEN NVARCHAR(100) NOT NULL,
    EMAIL NVARCHAR(100) UNIQUE NOT NULL,
    SODIENTHOAI NVARCHAR(15),
    DIACHI NVARCHAR(255),
    NGAY_DANG_KY DATETIME DEFAULT GETDATE(),
    MAT_KHAU NVARCHAR(255) NOT NULL,
    TRANG_THAI BIT DEFAULT 1 -- 1: Hoạt động, 0: Bị khóa
);

CREATE TABLE CHIEN_DICH (
    CHIEN_DICH_ID INT PRIMARY KEY IDENTITY(1,1),
    TEN_CHIEN_DICH NVARCHAR(100) NOT NULL,
    MO_TA NVARCHAR(255),
    THOI_GIAN_BAT_DAU DATETIME NOT NULL,
    THOI_GIAN_KET_THUC DATETIME NOT NULL,
    DIEN_TICH NVARCHAR(255),
    MAX_THAM_GIA INT,
    SO_NGUOI_DA_DANG_KY INT DEFAULT 0
);

CREATE TABLE SAN_PHAM (
    SAN_PHAM_ID INT PRIMARY KEY IDENTITY(1,1),
    TEN_SAN_PHAM NVARCHAR(100) NOT NULL,
    MO_TA NVARCHAR(255),
    GIA DECIMAL(10, 2) NOT NULL,
    SO_LUONG INT NOT NULL,
    TRANG_THAI BIT DEFAULT 1, -- 1: Còn hàng, 0: Hết hàng
    CHIEN_DICH_ID INT,
    FOREIGN KEY (CHIEN_DICH_ID) REFERENCES CHIEN_DICH(CHIEN_DICH_ID)
);

CREATE TABLE DAT_HANG (
    DAT_HANG_ID INT PRIMARY KEY IDENTITY(1,1),
    KHACH_HANG_ID INT,
    NGAY_DAT DATETIME DEFAULT GETDATE(),
    TONG_TIEN DECIMAL(10, 2) NOT NULL,
    TRANG_THAI NVARCHAR(50) DEFAULT 'Đang xử lý',
    FOREIGN KEY (KHACH_HANG_ID) REFERENCES KHACH_HANG(KHACH_HANG_ID)
);




select*from KHACH_HANG
select*from CHIEN_DICH
select*from SAN_PHAM
select*from DAT_HANG

INSERT INTO KHACH_HANG (HO_TEN, EMAIL, SODIENTHOAI, DIACHI, MAT_KHAU)
VALUES 
('Nguyễn Văn A', 'nguyenvana@gmail.com', '0123456789', '123 Đường ABC, Quận 1', 'MatKhau123'),
('Trần Thị B', 'tranthib@gmail.com', '0987654321', '456 Đường DEF, Quận 2', 'MatKhau456'),
('Lê Văn C', 'levanc@gmail.com', '0912345678', '789 Đường GHI, Quận 3', 'MatKhau789');

INSERT INTO CHIEN_DICH (TEN_CHIEN_DICH, MO_TA, THOI_GIAN_BAT_DAU, THOI_GIAN_KET_THUC, DIEN_TICH, MAX_THAM_GIA)
VALUES 
('Trồng cây xanh', 'Chiến dịch trồng cây để bảo vệ môi trường', '2024-10-01', '2024-10-31', 'Công viên TP.HCM', 100),
('Dọn rác bãi biển', 'Chiến dịch dọn rác tại bãi biển', '2024-11-01', '2024-11-15', 'Bãi biển Nha Trang', 50),
('Bảo vệ động vật', 'Chiến dịch bảo vệ động vật hoang dã', '2024-12-01', '2024-12-15', 'Khu bảo tồn thiên nhiên', 30);

INSERT INTO SAN_PHAM (TEN_SAN_PHAM, MO_TA, GIA, SO_LUONG, CHIEN_DICH_ID)
VALUES 
('Găng tay bảo vệ', 'Găng tay dùng trong các hoạt động bảo vệ môi trường', 50.00, 200, 1),
('Túi phân hủy sinh học', 'Túi phân hủy sinh học dùng để đựng rác', 25.00, 150, 2),
('Chậu cây nhỏ', 'Chậu cây nhỏ dùng để trồng cây tại nhà', 15.00, 300, 1);

INSERT INTO DAT_HANG (KHACH_HANG_ID, TONG_TIEN)
VALUES 
(1, 75.00),  -- Khách hàng 1 đặt hàng
(2, 50.00),  -- Khách hàng 2 đặt hàng
(3, 30.00);  -- Khách hàng 3 đặt hàng


-- Thêm quản trị viên
INSERT INTO QUAN_TRI_VIEN (HO_TEN, EMAIL, MAT_KHAU)
VALUES 
('Admin Nguyễn', 'admin1@gmail.com', 'AdminPass123'),
('Admin Trần', 'admin2@gmail.com', 'AdminPass456');

-- Thêm log hoạt động
INSERT INTO LOG_HOAT_DONG (QUAN_TRI_ID, NOI_DUNG)
VALUES 
(1, 'Đăng nhập vào hệ thống'),
(1, 'Thêm mới chiến dịch bảo vệ môi trường'),
(2, 'Cập nhật thông tin sản phẩm');
