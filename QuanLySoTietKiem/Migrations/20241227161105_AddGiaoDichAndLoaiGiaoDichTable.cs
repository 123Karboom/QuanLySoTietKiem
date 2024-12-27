using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLySoTietKiem.Migrations
{
    /// <inheritdoc />
    public partial class AddGiaoDichAndLoaiGiaoDichTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoaiGiaoDichs",
                columns: table => new
                {
                    MaLoaiGiaoDich = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiGiaoDich = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiGiaoDichs", x => x.MaLoaiGiaoDich);
                });

            migrationBuilder.CreateTable(
                name: "GiaoDichs",
                columns: table => new
                {
                    MaGiaoDich = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSoTietKiem = table.Column<int>(type: "int", nullable: false),
                    MaLoaiGiaoDich = table.Column<int>(type: "int", nullable: false),
                    NgayGiaoDich = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoTien = table.Column<double>(type: "float(18)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiaoDichs", x => x.MaGiaoDich);
                    table.ForeignKey(
                        name: "FK_GiaoDichs_LoaiGiaoDichs_MaLoaiGiaoDich",
                        column: x => x.MaLoaiGiaoDich,
                        principalTable: "LoaiGiaoDichs",
                        principalColumn: "MaLoaiGiaoDich",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GiaoDichs_SoTietKiems_MaSoTietKiem",
                        column: x => x.MaSoTietKiem,
                        principalTable: "SoTietKiems",
                        principalColumn: "MaSoTietKiem",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GiaoDichs_MaLoaiGiaoDich",
                table: "GiaoDichs",
                column: "MaLoaiGiaoDich");

            migrationBuilder.CreateIndex(
                name: "IX_GiaoDichs_MaSoTietKiem",
                table: "GiaoDichs",
                column: "MaSoTietKiem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GiaoDichs");

            migrationBuilder.DropTable(
                name: "LoaiGiaoDichs");
        }
    }
}
