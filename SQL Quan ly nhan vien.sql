create database Quanlynhanvien
go

use Quanlynhanvien
go

--Nhanvien
-- Thongtinnhanvien
-- Account
-- Lichlamviec
-- Lich



create table AccountType
(
	ID int identity primary key,
	TypeName nvarchar(50) not null
)
go

create table Account
(
	UserName varchar(100) primary key,
	DisplayName nvarchar(100) not null default N'Name',
	Password varchar(500) not null default 0,
	TypeID int not null

	foreign key (TypeID) references AccountType(ID)
)
go

create table Nhanvien
(
	ID int identity primary key,
	Nhom char(6) not null default N'Chưa đặt tên'
)
go

create table ThongtinNhom
(
	ID int identity primary key,
	Nhom char(6) not null default N'Chưa đặt tên',
	NhomID int not null,
	Title char(6) not null default N'Chưa đặt tên'

	foreign key (NhomID) references Nhanvien(ID)
)
go

create table ThongtinNhanvien
(
	ID int identity primary key,
	Nhom char(6) not null default N'Chưa đặt tên',
	NhomID int not null,
	Title char(6) not null default N'Chưa đặt tên',
	ChungChiID int not null,
	NgayhethanCRS Date,
	NgayhethanCII Date,
	Name nvarchar(100) not null default N'Chưa đặt tên',
	Phone int not null,
	Email char(100) not null default N'Chưa đặt tên'

	foreign key (NhomID) references Nhanvien(ID),
	foreign key (ChungChiID) references ThongtinNhom(ID)
)
go

use Quanlynhanvien
go
alter table ThongtinNhanvien
alter column Phone char(12)
alter table ThongtinNhanvien
alter column Email char(50)

insert AccountType (TypeName) values (N'Quản lý')
insert AccountType (TypeName) values (N'Nhân viên')

insert into Account (UserName, DisplayName, Password, TypeID)
values ('adminroster', 'Quản lý', 'adminroster', 1)
go

insert into Account(UserName, DisplayName, Password, TypeID)
values ('staff', 'Nhân viên' ,'staff', 2)
go

insert into Account (UserName, DisplayName, Password, TypeID)
values ('adminmcc', 'Quản lý', 'adminmcc', 1)
go

use Quanlynhanvien select ID, Nhom, Title, NgayhethanCRS, NgayhethanCII, Name, Phone, Email from ThongtinNhanvien go




use Quanlynhanvien
go
create table Calamviec
(
	ID int identity primary key,
	CaLam nvarchar(100) not null default N'Chưa đặt tên',
	Status nvarchar(100) not null default N'Trống'
)

create table Danhsachnhom
(
	ID int identity primary key,
	Nhom char(6) not null default N'Chưa đặt tên'
)
go


create table Danhsachnhanvien
(
	ID int identity primary key,
	NhomID int not null,
	ChungChi char(6) not null default N'Chưa đặt tên',
	Ngayhethanchungchi Date,
	Name nvarchar(100) not null default N'Chưa đặt tên',
	Phone int not null,
	Email char(100) not null default N'Chưa đặt tên'

	

	foreign key (NhomID) references Danhsachnhom(ID)
)
go

create table Danhsachcalam
(
	ID int identity primary key,
	idCaLam int not null,
	idNhanVien int not null,
	count int not null default 0

	foreign key (idCaLam) references Calamviec(ID),
	foreign key (idNhanVien) references Danhsachnhanvien(ID)
)
go


create table SoHieuMayBay
(
	ID int identity primary key,
	AC char(10) not null default N'Chưa đặt tên'
)

create table WO 
(
	ID int identity primary key,
	manoidung char(10) not null default N'Chưa đặt tên',
	Noidung nvarchar(500) not null default N'Chưa đặt tên',
	ChungChi char(6) not null default N'Chưa đặt tên',
	Dungcu nvarchar(500) not null default N'Chưa đặt tên',
	AcID int not null

	foreign key (AcID) references SoHieuMayBay(ID)
)
go


create table DanhsachWO
(
	ID int identity primary key,
	idNoidung int not null,
	idAC int not null,

	foreign key (idNoidung) references WO(ID),
	foreign key (idAC) references SoHieuMayBay(ID)
)
go


use Quanlynhanvien select * from Calamviec go
use Quanlynhanvien select * from Danhsachnhom go
select Danhsachnhom.Nhom,Danhsachnhanvien.ChungChi,Danhsachnhanvien.Ngayhethanchungchi,Danhsachnhanvien.Name,Danhsachnhanvien.Phone,Danhsachnhanvien.Email from Danhsachnhanvien INNER JOIN Danhsachnhom ON Danhsachnhanvien.NhomID = Danhsachnhom.ID  
select WO.ID,SoHieuMayBay.AC,WO.manoidung,WO.Noidung,WO.ChungChi,WO.Dungcu from WO inner join SoHieuMayBay on WO.AcID = SoHieuMayBay.ID
use Quanlynhanvien select * from Danhsachcalm go
use Quanlynhanvien select UserName,Password from Account go

--Tạo dữ liệu cho bảng Ca làm việc
insert dbo.Calamviec (CaLam) values (N'Ca ngày')

insert dbo.Calamviec (CaLam) values (N'Ca đêm')

insert dbo.Calamviec (CaLam) values (N'Training')

--Tạo dữ liệu cho Nhóm

insert dbo.Danhsachnhom (Nhom) values (N'Crew 1')

insert dbo.Danhsachnhom (Nhom) values (N'Crew 2')

insert dbo.Danhsachnhom (Nhom) values (N'Crew 3')

insert dbo.Danhsachnhom (Nhom) values (N'Crew 4')

insert dbo.Danhsachnhom (Nhom) values (N'...')

--Tạo dữ liệu cho Nhân viên

insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (1,N'B1',N'Nguyễn Hữu Nam','0988480945','nam.nguyenhuu@jetstarpacific.com.vn')
insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (1,N'B2',N'Đinh Hưng Đạo','0988611160','dao.dinh@jetstarpacific.com.vn')
insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (1,N'B2',N'Nguyễn Thái Hoàng','0902843948','hoang.nguyenthai@jetstarpacific.com.vn')
insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (1,N'A',N'Lê Trung Hưng','0908878083','hung.letrung@jetstarpacific.com.vn')
insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (1,N'A',N'Nguyễn Thành Danh','0908981256','danh.nguyenthanh@jetstarpacific.com.vn')
insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (1,N'Mech',N'Dương Thanh Sơn','01662552155','son.duongthanh@jetstarpacific.com.vn')
insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (1,N'Mech',N'Nguyễn Khánh Toàn','0905221191','toan.nguyenkhanh@jetstarpacific.com.vn')
insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (1,N'Mech',N'Nguyễn Thương Hải','0974895391','tuan.phanngoc@jetstarpacific.com.vn')
insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (2,N'B1',N'Biên Công Tín','0985423245','duy.le@jetstarpacific.com.vn')
insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (2,N'B1',N'Lê Đức Duy','0907936564','tin.biencong@jetstarpacific.com.vn')
insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (2,N'A',N'Đỗ Quang Hưng','0909269699','hung.quangdo@jetstarpacific.com.vn')
insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (2,N'A',N'Huỳnh Nguyễn Thái Hoà','0905922229','hoa.huynhnguyenthai@jetstarpacific.com.vn')
insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (2,N'A',N'Nguyễn Văn Ngọc','01687774408','ngoc.nguyenvan@jetstarpacific.com.vn')
insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (2,N'Mech',N'Dương Tuấn Hoàng','01214573852','hoang.duongtuan@jetstarpacific.com.vn')
insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (2,N'Mech',N'Nguyễn Duy Minh','0987362964','minh.nguyenduy@jetstarpacific.com.vn')
insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (2,N'Mech',N'Trần Tuấn Anh','0388648558','anh.trantuan@jetstarpacific.com.vn')
insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (3,N'B2',N'Vũ Mạnh Cường','0936399049','cuong.manhvu@jetstarpacific.com.vn')
insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (3,N'B1',N'Thái Nhật Phú','0974099626','phu.nhatthai@jetstarpacific.com.vn')
insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (3,N'A',N'Nguyễn Văn Đăng','0988480945','dang.nguyen@jetstarpacific.com.vn')
insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (3,N'A',N'Phan Tiến Tài','0988231640','tai.phantien@jetstarpacific.com.vn')
insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (3,N'A',N'Trần Xuân Phong','0938212221','phong.tranxuan@jetstarpacific.com.vn')
insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (3,N'A',N'Nguyễn Văn Khải','0983238461','khai.nguyenvan@jetstarpacific.com.vn')
insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (3,N'Mech',N'Trần Đình Quân','0916295530','quan.trandinh@jetstarpacific.com.vn')
insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (3,N'Mech',N'Lê Kim Quốc','01215755594','quoc.lekim@jetstarpacific.com.vn')
insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (3,N'Mech',N'Đoàn Quốc Bảo','0929620489','bao.doanquoc@jetstarpacific.com.vn')
insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (4,N'B2',N'Nguyễn Việt Trung','0944052882','trung.nguyenviet@jetstarpacific.com.vn')
insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (4,N'B1',N'Lê Việt Hải','0937693877','hai.vietle@jetstarpacific.com.vn')
insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (4,N'A',N'Đào Duy Thiện','0902644233','thien.daoduy@jetstarpacific.com.vn')
insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (4,N'A',N'Bùi Hữu Đức','0938801480','duc.buihuu@jetstarpacific.com.vn')
insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (4,N'A',N'Nguyễn Minh Trí','01268682946','tri.nguyenminh@jetstarpacific.com.vn')
insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (4,N'Mech',N'Nguyễn Văn Thiên','0974341822','thien.nguyen@jetstarpacific.com.vn')
insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (4,N'Mech',N'Nguyễn Hà Minh Hoàng','0902101005','hoang.nguyenhaminh@jetstarpacific.com.vn')
insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (4,N'Mech',N'Trương Văn Thuận','01659121354','thuan.truongvan@jetstarpacific.com.vn')
insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (4,N'Mech',N'Nguyễn Văn Tiến','0987437473','tien.nguyenvan@jetstarpacific.com.vn')
insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (5,N'DMMB',N'Nguyễn Công Phượng','0907840641','phuoc.nguyen@jetstarpacific.com.vn')
insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (5,N'DMMB',N'Nguyễn Minh Đức','0909608286','duc1.nguyenminh@jetstarpacific.com.vn')
insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (5,N'DMMB',N'Huỳnh Tiến Đăng','0903701085','dang.huynh@jetstarpacific.com.vn')
insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (5,N'A2',N'Nguyễn Raman Minh Huy','0909336856','huy.nguyenramanminh@jetstarpacific.com.vn')
insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (5,N'A2',N'Võ Minh Phúc Tài','0374226709','tai.vominhphuc@jetstarpacific.com.vn')
insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (5,N'A2',N'Lê Minh Dũng','0903371986','dung.minhle@jetstarpacific.com.vn')
insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (5,N'Mech',N'Tô Văn Duy','0988480945','duy.tovan@jetstarpacific.com.vn                   ')
insert dbo.Danhsachnhanvien (NhomID,ChungChi,Name,Phone,Email) values (5,N'Mech',N'Bùi Thanh Duy','0789090882','duy.buithanh@jetstarpacific.com.vn')


--Tạo csdl cho số hiệu máy bay
insert dbo.Danhsachcalam(idCaLam,idNhanVien,count) values (1,6,1)
insert dbo.Danhsachcalam(idCaLam,idNhanVien,count) values (1,9,1)
insert dbo.Danhsachcalam(idCaLam,idNhanVien,count) values (2,10,1)
insert dbo.Danhsachcalam(idCaLam,idNhanVien,count) values (2,24,1)
insert dbo.Danhsachcalam(idCaLam,idNhanVien,count) values (3,46,1)

--Tạo csdl cho số hiệu máy bay

insert dbo.SoHieuMayBay(AC) values (N'VN-A278')
insert dbo.SoHieuMayBay(AC) values (N'VN-A289')
insert dbo.SoHieuMayBay(AC) values (N'VN-A288')


--Tạo csdl cho nội dung wo

insert dbo.WO(manoidung,Noidung,ChungChi,Dungcu,AcID) values (69278,N'INSTALL TEMPORARY DECAL',N'B',N'1-PULLER(IAE1P17038),1-TUBE(2A1212),3-PACKING(ST1946-107),1-TUBE(2A1211),1-PACKING(1-ST1946-110),1-SEAL(AS42714),1-WIRE(ST1003-06)',1)
insert dbo.WO(manoidung,Noidung,ChungChi,Dungcu,AcID) values (69280,N'REPLACE SLIDE RAFTS',N'A',N'2-PULLER(IAE1P17038),1-TUBE(2A1212),1-PACKING(ST1946-107),1-TUBE(2A1211),3-PACKING(1-ST1946-110),1-SEAL(AS42714),1-WIRE(ST1003-06)',1)
insert dbo.WO(manoidung,Noidung,ChungChi,Dungcu,AcID) values (69281,N'PERFORM WEEKLY CHECK',N'B',N'1-PULLER(IAE1P17038),1-TUBE(2A1212),1-PACKING(ST1946-107),1-TUBE(2A1211),1-PACKING(1-ST1946-110),1-SEAL(AS42714),1-WIRE(ST1003-06)',1)
insert dbo.WO(manoidung,Noidung,ChungChi,Dungcu,AcID) values (69288,N'REMOVE OXYGEN PRESS BOTTLE AT D4R',N'A',N'3-PULLER(IAE1P17038),2-TUBE(2A1212),3-PACKING(ST1946-107),1-TUBE(2A1211),1-PACKING(1-ST1946-110),1-SEAL(AS42714),1-WIRE(ST1003-06)',1)
insert dbo.WO(manoidung,Noidung,ChungChi,Dungcu,AcID) values (69294,N'STORAGE PERIODIC GROUND CHECKS AT 7-DAY INTERVALS',N'B',N'1-PULLER(IAE1P17038),1-TUBE(2A1212),3-PACKING(ST1946-107),1-TUBE(2A1211),1-PACKING(1-ST1946-110),1-SEAL(AS42714),1-WIRE(ST1003-06)',1)
insert dbo.WO(manoidung,Noidung,ChungChi,Dungcu,AcID) values (69295,N'REMOVE BATTERY #1 FOR OVERHAUL',N'A',N'1-PULLER(IAE1P17038),1-TUBE(2A1212),3-PACKING(ST1946-107),1-TUBE(2A1211),1-PACKING(1-ST1946-110),1-SEAL(AS42714),1-WIRE(ST1003-06)',1)
insert dbo.WO(manoidung,Noidung,ChungChi,Dungcu,AcID) values (69296,N'REMOVE BATTERY #2 FOR OVERHAUL',N'A',N'1-PULLER(IAE1P17038),1-TUBE(2A1212),3-PACKING(ST1946-107),1-TUBE(2A1211),1-PACKING(1-ST1946-110),1-SEAL(AS42714),1-WIRE(ST1003-06)',1)
insert dbo.WO(manoidung,Noidung,ChungChi,Dungcu,AcID) values (69284,N'FIRE PROTECTION – CARGO DOOR SEALS – CLEANING / GREASING',N'B',N'1-PULLER(IAE1P17038),1-TUBE(2A1212),3-PACKING(ST1946-107),1-TUBE(2A1211),1-PACKING(1-ST1946-110),1-SEAL(AS42714),1-WIRE(ST1003-06)',2)
insert dbo.WO(manoidung,Noidung,ChungChi,Dungcu,AcID) values (69303,N'PERFORM AIRCRAFT REGISTRATION CHANGE REF EO A321/001.21',N'B',N'1-PULLER(IAE1P17038),1-TUBE(2A1212),3-PACKING(ST1946-107),1-TUBE(2A1211),1-PACKING(1-ST1946-110),1-SEAL(AS42714),1-WIRE(ST1003-06)',2)
insert dbo.WO(manoidung,Noidung,ChungChi,Dungcu,AcID) values (69330,N'INSTALL EXIT SIGN LENS IN ALL DOORS (D1LR-D4LR; D2-3LR)',N'A',N'1-PULLER(IAE1P17038),1-TUBE(2A1212),3-PACKING(ST1946-107),1-TUBE(2A1211),1-PACKING(1-ST1946-110),1-SEAL(AS42714),1-WIRE(ST1003-06)',2)
insert dbo.WO(manoidung,Noidung,ChungChi,Dungcu,AcID) values (69325,N'PERFORM WEEKLY CHECK',N'B',N'1-PULLER(IAE1P17038),1-TUBE(2A1212),3-PACKING(ST1946-107),1-TUBE(2A1211),1-PACKING(1-ST1946-110),1-SEAL(AS42714),1-WIRE(ST1003-06)',2)
insert dbo.WO(manoidung,Noidung,ChungChi,Dungcu,AcID) values (69332,N'REPLACE 06 EA OVER AISLE CEILING',N'A',N'1-PULLER(IAE1P17038),1-TUBE(2A1212),3-PACKING(ST1946-107),1-TUBE(2A1211),1-PACKING(1-ST1946-110),1-SEAL(AS42714),1-WIRE(ST1003-06)',2)
insert dbo.WO(manoidung,Noidung,ChungChi,Dungcu,AcID) values (69333,N'EXTERNAL CLEANING',N'A',N'1-PULLER(IAE1P17038),1-TUBE(2A1212),3-PACKING(ST1946-107),1-TUBE(2A1211),1-PACKING(1-ST1946-110),1-SEAL(AS42714),1-WIRE(ST1003-06)',2)
insert dbo.WO(manoidung,Noidung,ChungChi,Dungcu,AcID) values (69353,N'DOWNLOAD DATA OF THE THE PERSONAL COMPUTER MEMORY CARD (PCMCIA) CARD OF THE WGL-QAR',N'B',N'1-PULLER(IAE1P17038),1-TUBE(2A1212),3-PACKING(ST1946-107),1-TUBE(2A1211),1-PACKING(1-ST1946-110),1-SEAL(AS42714),1-WIRE(ST1003-06)',2)
insert dbo.WO(manoidung,Noidung,ChungChi,Dungcu,AcID) values (69347,N'WO 69347 UPLOAD IPRAM VN-A288',N'B',N'1-PULLER(IAE1P17038),1-TUBE(2A1212),3-PACKING(ST1946-107),1-TUBE(2A1211),1-PACKING(1-ST1946-110),1-SEAL(AS42714),1-WIRE(ST1003-06)',3)
insert dbo.WO(manoidung,Noidung,ChungChi,Dungcu,AcID) values (69355,N'DOWNLOAD DATA OF THE COMPACT FLASH (CF) CARD OF THE WGL-QAR',N'B',N'1-PULLER(IAE1P17038),1-TUBE(2A1212),3-PACKING(ST1946-107),1-TUBE(2A1211),1-PACKING(1-ST1946-110),1-SEAL(AS42714),1-WIRE(ST1003-06)',3)
insert dbo.WO(manoidung,Noidung,ChungChi,Dungcu,AcID) values (69386,N'CENTERBODY DETAILED INSPECTION OF THE EXHAUST CENTERBODY REF AMM TASK 781112-210-041-B ENG #1',N'B',N'1-PULLER(IAE1P17038),1-TUBE(2A1212),3-PACKING(ST1946-107),1-TUBE(2A1211),1-PACKING(1-ST1946-110),1-SEAL(AS42714),1-WIRE(ST1003-06)',3)
insert dbo.WO(manoidung,Noidung,ChungChi,Dungcu,AcID) values (69411,N'"PROTECT. BREATHING EQPT (CKPT & CABIN) VISUAL CHECK OF THE TAMPER SEAL/SERVICEABILITY INDICATION OF THE PROTECTIVE BREATHING EQUIPMENT"',N'A',N'1-PULLER(IAE1P17038),1-TUBE(2A1212),3-PACKING(ST1946-107),1-TUBE(2A1211),1-PACKING(1-ST1946-110),1-SEAL(AS42714),1-WIRE(ST1003-06)',3)
insert dbo.WO(manoidung,Noidung,ChungChi,Dungcu,AcID) values (69449,N'FIRE PROTECTION – CARGO DOOR SEALS – CLEANING / GREASING',N'A',N'1-PULLER(IAE1P17038),1-TUBE(2A1212),3-PACKING(ST1946-107),1-TUBE(2A1211),1-PACKING(1-ST1946-110),1-SEAL(AS42714),1-WIRE(ST1003-06)',3)
insert dbo.WO(manoidung,Noidung,ChungChi,Dungcu,AcID) values (69495,N'ELECTRICAL FLIGHT CONTROL SYSTEM (EFCS)',N'A',N'1-PULLER(IAE1P17038),1-TUBE(2A1212),3-PACKING(ST1946-107),1-TUBE(2A1211),1-PACKING(1-ST1946-110),1-SEAL(AS42714),1-WIRE(ST1003-06)',3)



--Tạo csdl cho bảng danh sách wo
insert dbo.DanhsachWO(idAC,idNoidung) values (1,1)
insert dbo.DanhsachWO(idAC,idNoidung) values (1,2)
insert dbo.DanhsachWO(idAC,idNoidung) values (1,3)
insert dbo.DanhsachWO(idAC,idNoidung) values (1,4)
insert dbo.DanhsachWO(idAC,idNoidung) values (2,8)
insert dbo.DanhsachWO(idAC,idNoidung) values (3,15)



select * from Danhsachcalam WHERE idCaLam = 1

CREATE PROC USP_ThemNhanVien
@Name nvarchar(100)
AS
BEGIN
	SELECT * FROM ThongtinNhanvien WHERE Name = @Name
END
GO




EXEC dbo.USP_ThemNhanVien @Name = N'Hùynh Tiến Đăng'




