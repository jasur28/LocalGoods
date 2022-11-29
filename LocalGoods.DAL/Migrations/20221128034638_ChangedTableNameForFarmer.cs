using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalGoods.DAL.Migrations
{
    public partial class ChangedTableNameForFarmer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FarmerId",
                table: "Farms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Farms_FarmerId",
                table: "Farms",
                column: "FarmerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Farms_Farmers_FarmerId",
                table: "Farms",
                column: "FarmerId",
                principalTable: "Farmers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Farms_Farmers_FarmerId",
                table: "Farms");

            migrationBuilder.DropIndex(
                name: "IX_Farms_FarmerId",
                table: "Farms");

            migrationBuilder.DropColumn(
                name: "FarmerId",
                table: "Farms");
        }
    }
}
