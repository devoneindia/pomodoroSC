using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pomodoro.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedUsernamecolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "dev-name",
                table: "entry",
                newName: "user-name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "user-name",
                table: "entry",
                newName: "dev-name");
        }
    }
}
