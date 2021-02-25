using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ADDEDSelfRefereYorumDeltedSelfRefereTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Tags_ParentTagId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_ParentTagId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "ParentTagId",
                table: "Tags");

            migrationBuilder.AddColumn<int>(
                name: "ParentYorumId",
                table: "Yorums",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Yorums_ParentYorumId",
                table: "Yorums",
                column: "ParentYorumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Yorums_Yorums_ParentYorumId",
                table: "Yorums",
                column: "ParentYorumId",
                principalTable: "Yorums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yorums_Yorums_ParentYorumId",
                table: "Yorums");

            migrationBuilder.DropIndex(
                name: "IX_Yorums_ParentYorumId",
                table: "Yorums");

            migrationBuilder.DropColumn(
                name: "ParentYorumId",
                table: "Yorums");

            migrationBuilder.AddColumn<int>(
                name: "ParentTagId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ParentTagId",
                table: "Tags",
                column: "ParentTagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Tags_ParentTagId",
                table: "Tags",
                column: "ParentTagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
