using Microsoft.EntityFrameworkCore.Migrations;

namespace Hostelsystem.Migrations
{
    public partial class AddPhoneAddressCityToGuest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ReservationCode",
                table: "Reservations",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Guests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Guests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Guests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Guests");

            migrationBuilder.AlterColumn<string>(
                name: "ReservationCode",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10);
        }
    }
}
