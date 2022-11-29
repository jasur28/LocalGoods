using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalGoods.DAL.Migrations
{
    public partial class createNewDB1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Farms_Farmers_FarmerId",
                table: "Farms");

            migrationBuilder.AlterColumn<int>(
                name: "FarmerId",
                table: "Farms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AlterColumn<int>(
                name: "FarmerId",
                table: "Farms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Farms_Farmers_FarmerId",
                table: "Farms",
                column: "FarmerId",
                principalTable: "Farmers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
