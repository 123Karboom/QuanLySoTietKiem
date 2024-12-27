using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLySoTietKiem.Migrations
{
    /// <inheritdoc />
    public partial class RemovePhieuGuiTienAndPhieuRutTien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhieuGuiTiens_SoTietKiems_MaSoTietKiem",
                table: "PhieuGuiTiens");

            migrationBuilder.DropForeignKey(
                name: "FK_PhieuRutTiens_SoTietKiems_MaSoTietKiem",
                table: "PhieuRutTiens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhieuRutTiens",
                table: "PhieuRutTiens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhieuGuiTiens",
                table: "PhieuGuiTiens");

            migrationBuilder.RenameTable(
                name: "PhieuRutTiens",
                newName: "PhieuRutTien");

            migrationBuilder.RenameTable(
                name: "PhieuGuiTiens",
                newName: "PhieuGuiTien");

            migrationBuilder.RenameIndex(
                name: "IX_PhieuRutTiens_MaSoTietKiem",
                table: "PhieuRutTien",
                newName: "IX_PhieuRutTien_MaSoTietKiem");

            migrationBuilder.RenameIndex(
                name: "IX_PhieuGuiTiens_MaSoTietKiem",
                table: "PhieuGuiTien",
                newName: "IX_PhieuGuiTien_MaSoTietKiem");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhieuRutTien",
                table: "PhieuRutTien",
                column: "MaPhieuRut");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhieuGuiTien",
                table: "PhieuGuiTien",
                column: "MaPhieuGui");

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuGuiTien_SoTietKiems_MaSoTietKiem",
                table: "PhieuGuiTien",
                column: "MaSoTietKiem",
                principalTable: "SoTietKiems",
                principalColumn: "MaSoTietKiem",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuRutTien_SoTietKiems_MaSoTietKiem",
                table: "PhieuRutTien",
                column: "MaSoTietKiem",
                principalTable: "SoTietKiems",
                principalColumn: "MaSoTietKiem",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhieuGuiTien_SoTietKiems_MaSoTietKiem",
                table: "PhieuGuiTien");

            migrationBuilder.DropForeignKey(
                name: "FK_PhieuRutTien_SoTietKiems_MaSoTietKiem",
                table: "PhieuRutTien");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhieuRutTien",
                table: "PhieuRutTien");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhieuGuiTien",
                table: "PhieuGuiTien");

            migrationBuilder.RenameTable(
                name: "PhieuRutTien",
                newName: "PhieuRutTiens");

            migrationBuilder.RenameTable(
                name: "PhieuGuiTien",
                newName: "PhieuGuiTiens");

            migrationBuilder.RenameIndex(
                name: "IX_PhieuRutTien_MaSoTietKiem",
                table: "PhieuRutTiens",
                newName: "IX_PhieuRutTiens_MaSoTietKiem");

            migrationBuilder.RenameIndex(
                name: "IX_PhieuGuiTien_MaSoTietKiem",
                table: "PhieuGuiTiens",
                newName: "IX_PhieuGuiTiens_MaSoTietKiem");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhieuRutTiens",
                table: "PhieuRutTiens",
                column: "MaPhieuRut");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhieuGuiTiens",
                table: "PhieuGuiTiens",
                column: "MaPhieuGui");

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuGuiTiens_SoTietKiems_MaSoTietKiem",
                table: "PhieuGuiTiens",
                column: "MaSoTietKiem",
                principalTable: "SoTietKiems",
                principalColumn: "MaSoTietKiem",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuRutTiens_SoTietKiems_MaSoTietKiem",
                table: "PhieuRutTiens",
                column: "MaSoTietKiem",
                principalTable: "SoTietKiems",
                principalColumn: "MaSoTietKiem",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
