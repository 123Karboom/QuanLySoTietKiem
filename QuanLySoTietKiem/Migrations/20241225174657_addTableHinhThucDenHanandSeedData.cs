using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuanLySoTietKiem.Migrations
{
    /// <inheritdoc />
    public partial class addTableHinhThucDenHanandSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaHinhThucDenHan",
                table: "SoTietKiems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "HinhThucDenHan",
                columns: table => new
                {
                    MaHinhThucDenHan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenHinhThucDenHan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HinhThucDenHan", x => x.MaHinhThucDenHan);
                });

            migrationBuilder.InsertData(
                table: "HinhThucDenHan",
                columns: new[] { "MaHinhThucDenHan", "TenHinhThucDenHan" },
                values: new object[,]
                {
                    { 1, "Rút hết" },
                    { 2, "Quay vòng gốc" },
                    { 3, "Quay vòng cả gốc và lãi" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SoTietKiems_MaHinhThucDenHan",
                table: "SoTietKiems",
                column: "MaHinhThucDenHan");

            migrationBuilder.AddForeignKey(
                name: "FK_SoTietKiems_HinhThucDenHan_MaHinhThucDenHan",
                table: "SoTietKiems",
                column: "MaHinhThucDenHan",
                principalTable: "HinhThucDenHan",
                principalColumn: "MaHinhThucDenHan",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoTietKiems_HinhThucDenHan_MaHinhThucDenHan",
                table: "SoTietKiems");

            migrationBuilder.DropTable(
                name: "HinhThucDenHan");

            migrationBuilder.DropIndex(
                name: "IX_SoTietKiems_MaHinhThucDenHan",
                table: "SoTietKiems");

            migrationBuilder.DropColumn(
                name: "MaHinhThucDenHan",
                table: "SoTietKiems");
        }
    }
}
