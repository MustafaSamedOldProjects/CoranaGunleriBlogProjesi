using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class kateg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kategoris_Kategoris_KategoriId",
                table: "Kategoris");

            migrationBuilder.DropIndex(
                name: "IX_Kategoris_KategoriId",
                table: "Kategoris");

            migrationBuilder.DropColumn(
                name: "KategoriId",
                table: "Kategoris");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KategoriId",
                table: "Kategoris",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kategoris_KategoriId",
                table: "Kategoris",
                column: "KategoriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kategoris_Kategoris_KategoriId",
                table: "Kategoris",
                column: "KategoriId",
                principalTable: "Kategoris",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
