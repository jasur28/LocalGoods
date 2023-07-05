using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalGoods.DAL.Migrations
{
    /// <inheritdoc />
    public partial class New4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UpdatedUser",
                table: "Categories",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UpdatedUser",
                table: "Categories",
                column: "UpdatedUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_AspNetUsers_UpdatedUser",
                table: "Categories",
                column: "UpdatedUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_AspNetUsers_UpdatedUser",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_UpdatedUser",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UpdatedUser",
                table: "Categories");
        }
    }
}
