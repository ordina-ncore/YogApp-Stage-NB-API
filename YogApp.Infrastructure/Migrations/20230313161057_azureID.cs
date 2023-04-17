using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YogApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class azureID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sessionParticipants_users_UserId",
                table: "sessionParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_sessions_users_TeacherId",
                table: "sessions");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropIndex(
                name: "IX_sessions_TeacherId",
                table: "sessions");

            migrationBuilder.DropIndex(
                name: "IX_sessionParticipants_UserId",
                table: "sessionParticipants");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "sessions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "sessionParticipants");

            migrationBuilder.AddColumn<string>(
                name: "TeacherAzureId",
                table: "sessions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserAzureId",
                table: "sessionParticipants",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeacherAzureId",
                table: "sessions");

            migrationBuilder.DropColumn(
                name: "UserAzureId",
                table: "sessionParticipants");

            migrationBuilder.AddColumn<Guid>(
                name: "TeacherId",
                table: "sessions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "sessionParticipants",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AzureId = table.Column<string>(type: "text", nullable: true),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    IsAdmin = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    ProfilePicture = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sessions_TeacherId",
                table: "sessions",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_sessionParticipants_UserId",
                table: "sessionParticipants",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_sessionParticipants_users_UserId",
                table: "sessionParticipants",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sessions_users_TeacherId",
                table: "sessions",
                column: "TeacherId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
