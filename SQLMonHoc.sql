create database DuLieu;
go
use DuLieu;
create table MonHoc(
     MaMonHoc nvarchar(10) primary key,
     TenMonHoc ntext not null,
     SoTinChi nvarchar(5) not null,
);
go
insert into MonHoc(MaMonHoc, TenMonHoc, SoTinChi) values
('MH001', N'Lập trình C# cơ bản', '3'),
('MH002',N'Cơ Sở dữ liệu', '4'),
('MH003',N'Phan tích thiết kế yêu cầu','3'),
('MH004',N'Mạng Máy tính','3'),
('MH005',N'Trí tuệ nhân tạo cơ bản ','3');
Go
