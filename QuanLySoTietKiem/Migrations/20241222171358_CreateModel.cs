using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLySoTietKiem.Migrations
{
    /// <inheritdoc />
    public partial class CreateModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoaiSoTietKiems",
                columns: table => new
                {
                    MaLoaiSo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiSo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LaiSuat = table.Column<float>(type: "real", nullable: false),
                    KyHan = table.Column<int>(type: "int", nullable: false),
                    ThoiGianGuiToiThieu = table.Column<int>(type: "int", nullable: false),
                    SoTienGuiToiThieu = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiSoTietKiems", x => x.MaLoaiSo);
                });

            migrationBuilder.CreateTable(
                name: "BaoCaoNgays",
                columns: table => new
                {
                    MaBaoCaoNgay = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaLoaiSo = table.Column<int>(type: "int", nullable: false),
                    NgayGhi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoTienGui = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaoCaoNgays", x => x.MaBaoCaoNgay);
                    table.ForeignKey(
                        name: "FK_BaoCaoNgays_LoaiSoTietKiems_MaLoaiSo",
                        column: x => x.MaLoaiSo,
                        principalTable: "LoaiSoTietKiems",
                        principalColumn: "MaLoaiSo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaoCaoThangs",
                columns: table => new
                {
                    MaBaoCaoThang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaLoaiSo = table.Column<int>(type: "int", nullable: false),
                    Thang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoLuongDong = table.Column<int>(type: "int", nullable: false),
                    SoTienGui = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ChenhLech = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaoCaoThangs", x => x.MaBaoCaoThang);
                    table.ForeignKey(
                        name: "FK_BaoCaoThangs_LoaiSoTietKiems_MaLoaiSo",
                        column: x => x.MaLoaiSo,
                        principalTable: "LoaiSoTietKiems",
                        principalColumn: "MaLoaiSo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoTietKiems",
                columns: table => new
                {
                    MaSoTietKiem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaLoaiSo = table.Column<int>(type: "int", nullable: false),
                    SoDuSoTietKiem = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LaiSuatApDung = table.Column<float>(type: "real", nullable: false),
                    NgayMoSo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayDongSo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoTietKiems", x => x.MaSoTietKiem);
                    table.ForeignKey(
                        name: "FK_SoTietKiems_LoaiSoTietKiems_MaLoaiSo",
                        column: x => x.MaLoaiSo,
                        principalTable: "LoaiSoTietKiems",
                        principalColumn: "MaLoaiSo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhieuGuiTiens",
                columns: table => new
                {
                    MaPhieuGui = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSoTietKiem = table.Column<int>(type: "int", nullable: false),
                    NgayGui = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoTienGui = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuGuiTiens", x => x.MaPhieuGui);
                    table.ForeignKey(
                        name: "FK_PhieuGuiTiens_SoTietKiems_MaSoTietKiem",
                        column: x => x.MaSoTietKiem,
                        principalTable: "SoTietKiems",
                        principalColumn: "MaSoTietKiem",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhieuRutTiens",
                columns: table => new
                {
                    MaPhieuRut = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSoTietKiem = table.Column<int>(type: "int", nullable: false),
                    NgayRut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoTienRut = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuRutTiens", x => x.MaPhieuRut);
                    table.ForeignKey(
                        name: "FK_PhieuRutTiens_SoTietKiems_MaSoTietKiem",
                        column: x => x.MaSoTietKiem,
                        principalTable: "SoTietKiems",
                        principalColumn: "MaSoTietKiem",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaoCaoNgays_MaLoaiSo",
                table: "BaoCaoNgays",
                column: "MaLoaiSo");

            migrationBuilder.CreateIndex(
                name: "IX_BaoCaoThangs_MaLoaiSo",
                table: "BaoCaoThangs",
                column: "MaLoaiSo");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuGuiTiens_MaSoTietKiem",
                table: "PhieuGuiTiens",
                column: "MaSoTietKiem");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuRutTiens_MaSoTietKiem",
                table: "PhieuRutTiens",
                column: "MaSoTietKiem");

            migrationBuilder.CreateIndex(
                name: "IX_SoTietKiems_MaLoaiSo",
                table: "SoTietKiems",
                column: "MaLoaiSo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaoCaoNgays");

            migrationBuilder.DropTable(
                name: "BaoCaoThangs");

            migrationBuilder.DropTable(
                name: "PhieuGuiTiens");

            migrationBuilder.DropTable(
                name: "PhieuRutTiens");

            migrationBuilder.DropTable(
                name: "SoTietKiems");

            migrationBuilder.DropTable(
                name: "LoaiSoTietKiems");
        }
    }
}
