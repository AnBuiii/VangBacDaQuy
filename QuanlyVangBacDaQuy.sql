create table LOAISANPHAM
(
	MALOAISP char(4) not null primary key,
	TENLOAISP	nvarchar(20)	not null,
	DONVITINH	char(20)	not null,
	PHANTRAMLOINHUAN	decimal(4,2)	not null
)


create table SANPHAM 
(
	MASP	char(4)	 not null primary key,
	MALOAISP	char(4)	 not null,
	TENSP	nvarchar(20)	not null,
	DONGIA	money	not null

)
create table PHIEUBANHANG
(
	SOPHIEU	char(4)	 not null primary key,
	MAKH	char(4)		not null,
	NGAYLAP	smalldatetime	not null,
	TONGTIEN	money	not null
)
create table CHITIETPHIEUBANHANG
(
	MASP	char(4) not null,
	SOPHIEU	char(4) not null,
	SOLUONG	int	not null,
	primary key (masp, sophieu)
)
create table PHIEUMUAHANG
(
	SOPHIEU	char(4)	 not null primary key,
	NGAYLAP	smalldatetime	not null,
	MANCC	char(4)	 not null,
	TONGTIEN	money	not null
)
create table CHITIETPHIEUMUAHANG
(
	MASP	char(4)	 not null,
	SOPHIEU	char(4)	 not null,
	SOLUONG	int	not null,
	primary key (masp, sophieu)
)
create table DICHVU
(
	MADV	char(4)	 not null primary key,
	TENDV	nvarchar(20)	not null,
	ĐONGIA	money	not null
)

create table PHIEUDICHVU
(
	SOPHIEU	char(4)	 not null primary key,
	NGAYLAP	smalldatetime	not null,
	MAKH	char(4)	 not null,
	TONGTIEN	money	not null,
	TIENTRATRUOC	money	not null,
	TIENCONLAI	money	not null
)
create table CHITIETPHIEUDICHVU
(
	MADV	char(4)	 not null,
	SOPHIEU	char(4)	 not null,
	SOLUONG	int	not null,
	TONGTIEN	money	not null,
	TIENTRATRUOC	money	not null,
	TIENCONLAI	money	not null,
	NGAYGIAO	smalldatetime	not null,
	TINHTRANG	char(10)	not null,
	primary key (madv,sophieu)
)
create table PHIEUBAOCAOTONKHO
(
	SOPHIEU	char(4)	 not null primary key,
	THANG	int	not null	
)
create table CHITIETPHIEUBAOCAOTONKHO
(
	SOPHIEU	char(4)	 not null,
	MASP	char(4)	 not null,
	TONDAU	int	not null,
	SLBAN	int	not null,
	SLMUA	int	not null,
	TONCUOI	int	not null,
	primary key (sophieu, masp)
)
create table NHACUNGCAP
(
	MANCC	char(4)	 not null primary key,
	DIACHI	nvarchar(50)	not null,
	SODT	varchar(10)	not null
)
create table KHACHHANG
(
	MAKH	char(4)	 not null primary key,
	TENKH	nvarchar(20)	not null
)
alter table sanpham add foreign key (maloaisp) references loaisanpham(maloaisp)
alter table chitietphieubanhang add foreign key (masp) references sanpham(masp)
alter table chitietphieubanhang add foreign key (sophieu) references phieubanhang(sophieu)
alter table phieubanhang add foreign key (makh) references khachhang(makh)
alter table phieudichvu add foreign key (makh) references khachhang(makh)
alter table chitietphieudichvu add foreign key (sophieu) references phieudichvu(sophieu)
alter table chitietphieudichvu add foreign key (madv) references dichvu(madv)
alter table chitietphieubaocaotonkho add foreign key (masp) references sanpham(masp)
alter table chitietphieubaocaotonkho add foreign key (sophieu) references phieubaocaotonkho(sophieu)
alter table chitietphieumuahang add foreign key (masp) references sanpham(masp)
alter table chitietphieumuahang add foreign key (sophieu) references phieumuahang(sophieu)
alter table phieumuahang add foreign key (mancc) references nhacungcap(mancc)

