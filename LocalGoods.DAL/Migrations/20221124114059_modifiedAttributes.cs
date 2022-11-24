using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalGoods.DAL.Migrations
{
    public partial class modifiedAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FarmName",
                table: "Farms",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "FarmAddress",
                table: "Farms",
                newName: "Address");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Farms",
                newName: "FarmName");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Farms",
                newName: "FarmAddress");
        }
    }
}
