﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuanLySoTietKiem.Data;

#nullable disable

namespace QuanLySoTietKiem.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241226060525_Nghia123456")]
    partial class Nghia123456
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("QuanLySoTietKiem.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CCCD")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("SoDuTaiKhoan")
                        .HasColumnType("float");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("QuanLySoTietKiem.Models.BaoCaoNgay", b =>
                {
                    b.Property<int>("MaBaoCaoNgay")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaBaoCaoNgay"));

                    b.Property<int>("MaLoaiSo")
                        .HasColumnType("int");

                    b.Property<DateTime>("Ngay")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTaoBaoCao")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TongTienGui")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TongTienRut")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("MaBaoCaoNgay");

                    b.HasIndex("MaLoaiSo");

                    b.ToTable("BaoCaoNgays");
                });

            modelBuilder.Entity("QuanLySoTietKiem.Models.BaoCaoThang", b =>
                {
                    b.Property<int>("MaBaoCaoThang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaBaoCaoThang"));

                    b.Property<decimal>("ChenhLech")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MaLoaiSo")
                        .HasColumnType("int");

                    b.Property<int>("Nam")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayTaoBaoCao")
                        .HasColumnType("datetime2");

                    b.Property<int>("SoLuongDong")
                        .HasColumnType("int");

                    b.Property<int>("SoLuongMo")
                        .HasColumnType("int");

                    b.Property<int>("Thang")
                        .HasColumnType("int");

                    b.Property<decimal>("TongSoTienGui")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TongSoTienRut")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("MaBaoCaoThang");

                    b.HasIndex("MaLoaiSo");

                    b.ToTable("BaoCaoThangs");
                });

            modelBuilder.Entity("QuanLySoTietKiem.Models.HinhThucDenHan", b =>
                {
                    b.Property<int>("MaHinhThucDenHan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaHinhThucDenHan"));

                    b.Property<string>("TenHinhThucDenHan")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaHinhThucDenHan");

                    b.ToTable("HinhThucDenHans");

                    b.HasData(
                        new
                        {
                            MaHinhThucDenHan = 1,
                            TenHinhThucDenHan = "Rút hết"
                        },
                        new
                        {
                            MaHinhThucDenHan = 2,
                            TenHinhThucDenHan = "Quay vòng gốc"
                        },
                        new
                        {
                            MaHinhThucDenHan = 3,
                            TenHinhThucDenHan = "Quay vòng cả gốc và lãi"
                        });
                });

            modelBuilder.Entity("QuanLySoTietKiem.Models.LoaiSoTietKiem", b =>
                {
                    b.Property<int>("MaLoaiSo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaLoaiSo"));

                    b.Property<int>("KyHan")
                        .HasColumnType("int");

                    b.Property<double>("LaiSuat")
                        .HasColumnType("float");

                    b.Property<decimal>("SoTienGuiToiThieu")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TenLoaiSo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ThoiGianGuiToiThieu")
                        .HasColumnType("int");

                    b.HasKey("MaLoaiSo");

                    b.ToTable("LoaiSoTietKiems");
                });

            modelBuilder.Entity("QuanLySoTietKiem.Models.PhieuGuiTien", b =>
                {
                    b.Property<int>("MaPhieuGui")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaPhieuGui"));

                    b.Property<int>("MaSoTietKiem")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayGui")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("SoTienGui")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("MaPhieuGui");

                    b.HasIndex("MaSoTietKiem");

                    b.ToTable("PhieuGuiTiens");
                });

            modelBuilder.Entity("QuanLySoTietKiem.Models.PhieuRutTien", b =>
                {
                    b.Property<int>("MaPhieuRut")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaPhieuRut"));

                    b.Property<int>("MaSoTietKiem")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayRut")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("SoTienRut")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("MaPhieuRut");

                    b.HasIndex("MaSoTietKiem");

                    b.ToTable("PhieuRutTiens");
                });

            modelBuilder.Entity("QuanLySoTietKiem.Models.SoTietKiem", b =>
                {
                    b.Property<int>("MaSoTietKiem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaSoTietKiem"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("LaiSuatApDung")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("LaiSuatKyHan")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MaHinhThucDenHan")
                        .HasColumnType("int");

                    b.Property<int>("MaLoaiSo")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayDongSo")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayMoSo")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("SoDuSoTietKiem")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SoTienGui")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("MaSoTietKiem");

                    b.HasIndex("MaHinhThucDenHan");

                    b.HasIndex("MaLoaiSo");

                    b.HasIndex("UserId");

                    b.ToTable("SoTietKiems");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("QuanLySoTietKiem.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("QuanLySoTietKiem.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLySoTietKiem.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("QuanLySoTietKiem.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuanLySoTietKiem.Models.BaoCaoNgay", b =>
                {
                    b.HasOne("QuanLySoTietKiem.Models.LoaiSoTietKiem", "LoaiSoTietKiem")
                        .WithMany("BaoCaoNgays")
                        .HasForeignKey("MaLoaiSo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoaiSoTietKiem");
                });

            modelBuilder.Entity("QuanLySoTietKiem.Models.BaoCaoThang", b =>
                {
                    b.HasOne("QuanLySoTietKiem.Models.LoaiSoTietKiem", "LoaiSoTietKiem")
                        .WithMany("BaoCaoThangs")
                        .HasForeignKey("MaLoaiSo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoaiSoTietKiem");
                });

            modelBuilder.Entity("QuanLySoTietKiem.Models.PhieuGuiTien", b =>
                {
                    b.HasOne("QuanLySoTietKiem.Models.SoTietKiem", "SoTietKiem")
                        .WithMany("PhieuGuiTiens")
                        .HasForeignKey("MaSoTietKiem")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SoTietKiem");
                });

            modelBuilder.Entity("QuanLySoTietKiem.Models.PhieuRutTien", b =>
                {
                    b.HasOne("QuanLySoTietKiem.Models.SoTietKiem", "SoTietKiem")
                        .WithMany("PhieuRutTiens")
                        .HasForeignKey("MaSoTietKiem")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SoTietKiem");
                });

            modelBuilder.Entity("QuanLySoTietKiem.Models.SoTietKiem", b =>
                {
                    b.HasOne("QuanLySoTietKiem.Models.HinhThucDenHan", "HinhThucDenHan")
                        .WithMany("SoTietKiems")
                        .HasForeignKey("MaHinhThucDenHan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLySoTietKiem.Models.LoaiSoTietKiem", "LoaiSoTietKiem")
                        .WithMany("SoTietKiems")
                        .HasForeignKey("MaLoaiSo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLySoTietKiem.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HinhThucDenHan");

                    b.Navigation("LoaiSoTietKiem");

                    b.Navigation("User");
                });

            modelBuilder.Entity("QuanLySoTietKiem.Models.HinhThucDenHan", b =>
                {
                    b.Navigation("SoTietKiems");
                });

            modelBuilder.Entity("QuanLySoTietKiem.Models.LoaiSoTietKiem", b =>
                {
                    b.Navigation("BaoCaoNgays");

                    b.Navigation("BaoCaoThangs");

                    b.Navigation("SoTietKiems");
                });

            modelBuilder.Entity("QuanLySoTietKiem.Models.SoTietKiem", b =>
                {
                    b.Navigation("PhieuGuiTiens");

                    b.Navigation("PhieuRutTiens");
                });
#pragma warning restore 612, 618
        }
    }
}