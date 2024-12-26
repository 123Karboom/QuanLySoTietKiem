using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLySoTietKiem.Migrations
{
    /// <inheritdoc />
    public partial class Nghia123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoTietKiems_HinhThucDenHan_MaHinhThucDenHan",
                table: "SoTietKiems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HinhThucDenHan",
                table: "HinhThucDenHan");

            migrationBuilder.RenameTable(
                name: "HinhThucDenHan",
                newName: "HinhThucDenHans");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HinhThucDenHans",
                table: "HinhThucDenHans",
                column: "MaHinhThucDenHan");

            migrationBuilder.AddForeignKey(
                name: "FK_SoTietKiems_HinhThucDenHans_MaHinhThucDenHan",
                table: "SoTietKiems",
                column: "MaHinhThucDenHan",
                principalTable: "HinhThucDenHans",
                principalColumn: "MaHinhThucDenHan",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoTietKiems_HinhThucDenHans_MaHinhThucDenHan",
                table: "SoTietKiems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HinhThucDenHans",
                table: "HinhThucDenHans");

            migrationBuilder.RenameTable(
                name: "HinhThucDenHans",
                newName: "HinhThucDenHan");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HinhThucDenHan",
                table: "HinhThucDenHan",
                column: "MaHinhThucDenHan");

            migrationBuilder.AddForeignKey(
                name: "FK_SoTietKiems_HinhThucDenHan_MaHinhThucDenHan",
                table: "SoTietKiems",
                column: "MaHinhThucDenHan",
                principalTable: "HinhThucDenHan",
                principalColumn: "MaHinhThucDenHan",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
