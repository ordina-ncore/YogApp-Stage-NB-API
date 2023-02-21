using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YogApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TimeStampAdded",
                table: "sessions",
                type: "text",
                rowVersion: true,
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "bytea",
                oldRowVersion: true);

            migrationBuilder.AlterColumn<string>(
                name: "TimeStampSignUp",
                table: "sessionParticipants",
                type: "text",
                rowVersion: true,
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "bytea",
                oldRowVersion: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "TimeStampAdded",
                table: "sessions",
                type: "bytea",
                rowVersion: true,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldRowVersion: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "TimeStampSignUp",
                table: "sessionParticipants",
                type: "bytea",
                rowVersion: true,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldRowVersion: true);
        }
    }
}
