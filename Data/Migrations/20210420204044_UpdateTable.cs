using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class UpdateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Searches_SearchId",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Results_SearchId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "SearchId",
                table: "Results");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Results",
                newName: "UrlAnalyzed");

            migrationBuilder.AddColumn<int>(
                name: "ResultId",
                table: "Searches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "Results",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Searches_ResultId",
                table: "Searches",
                column: "ResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_Searches_Results_ResultId",
                table: "Searches",
                column: "ResultId",
                principalTable: "Results",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Searches_Results_ResultId",
                table: "Searches");

            migrationBuilder.DropIndex(
                name: "IX_Searches_ResultId",
                table: "Searches");

            migrationBuilder.DropColumn(
                name: "ResultId",
                table: "Searches");

            migrationBuilder.RenameColumn(
                name: "UrlAnalyzed",
                table: "Results",
                newName: "Url");

            migrationBuilder.AlterColumn<int>(
                name: "Position",
                table: "Results",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SearchId",
                table: "Results",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Results_SearchId",
                table: "Results",
                column: "SearchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Searches_SearchId",
                table: "Results",
                column: "SearchId",
                principalTable: "Searches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
