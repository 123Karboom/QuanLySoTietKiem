using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuanLySoTietKiem.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataLoaiGiaoDich : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhieuGuiTien");

            migrationBuilder.DropTable(
                name: "PhieuRutTien");

            migrationBuilder.InsertData(
                table: "LoaiGiaoDichs",
                columns: new[] { "MaLoaiGiaoDich", "TenLoaiGiaoDich" },
                values: new object[,]
                {
                    { 1, "Rút tiền" },
                    { 2, "Gửi tiền" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LoaiGiaoDichs",
                keyColumn: "MaLoaiGiaoDich",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LoaiGiaoDichs",
                keyColumn: "MaLoaiGiaoDich",
                keyValue: 2);

            migrationBuilder.CreateTable(
                name: "PhieuGuiTien",
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
                    table.PrimaryKey("PK_PhieuGuiTien", x => x.MaPhieuGui);
                    table.ForeignKey(
                        name: "FK_PhieuGuiTien_SoTietKiems_MaSoTietKiem",
                        column: x => x.MaSoTietKiem,
                        principalTable: "SoTietKiems",
                        principalColumn: "MaSoTietKiem",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhieuRutTien",
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
                    table.PrimaryKey("PK_PhieuRutTien", x => x.MaPhieuRut);
                    table.ForeignKey(
                        name: "FK_PhieuRutTien_SoTietKiems_MaSoTietKiem",
                        column: x => x.MaSoTietKiem,
                        principalTable: "SoTietKiems",
                        principalColumn: "MaSoTietKiem",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhieuGuiTien_MaSoTietKiem",
                table: "PhieuGuiTien",
                column: "MaSoTietKiem");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuRutTien_MaSoTietKiem",
                table: "PhieuRutTien",
                column: "MaSoTietKiem");
        }
    }
}
