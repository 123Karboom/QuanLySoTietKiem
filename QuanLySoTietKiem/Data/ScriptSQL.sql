

create table LOAI_SO_TIET_KIEM
(
    MaLoaiSo            int         not null
        primary key,
    TenLoaiSo           varchar(50) not null,
    LaiSuat             float       not null,
    KyHan               int         not null,
    ThoiGianGuiToiThieu int         not null,
    SoTienGuiToiThieu   money       not null
)
go

create table BAO_CAO_NGAY
(
    MaBaoCaoNgay varchar(20) not null
        primary key,
    MaLoaiSo     int
        references LOAI_SO_TIET_KIEM,
    NgayGhi      datetime    not null,
    SoTienGui    money       not null
)
go

create table BAO_CAO_THANG
(
    MaBaoCaoThang varchar(20) not null
        primary key,
    MaLoaiSo      int
        references LOAI_SO_TIET_KIEM,
    Thang         int         not null,
    SoLuongDong   int         not null,
    SoTienGui     money       not null,
    ChenhLech     float       not null
)
go

create table SO_TIET_KIEM
(
    MaSoTietKiem   varchar(20) not null
        primary key,
    MaLoaiSo       int
        references LOAI_SO_TIET_KIEM,
    SoDuSoTietKiem money       not null,
    NgayMoSo       datetime    not null,
    TrangThai      bit         not null,
    LaiSuatApDung  float       not null,
    NgayDongSo     smalldatetime
)
go

create table PHIEU_GUI_TIEN
(
    MaPhieuGui   varchar(20) not null
        primary key,
    MaSoTietKiem varchar(20)
        references SO_TIET_KIEM,
    NgayGui      datetime    not null,
    SoTienGui    money       not null
)
go

create table PHIEU_RUT_TIEN
(
    MaPhieuRut   varchar(20) not null
        primary key,
    MaSoTietKiem varchar(20)
        references SO_TIET_KIEM,
    NgayRut      datetime    not null,
    SoTienRut    money       not null
)
go

create table THAM_SO
(
    MaThamSo varchar(20) not null
        primary key,
    MoTa     varchar(100),
    GiaTri   int         not null
)
go

