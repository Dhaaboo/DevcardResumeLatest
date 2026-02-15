using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DevcardResume.Data.Migrations
{
    /// <inheritdoc />
    public partial class _tblPeople : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_Peoples",
                columns: table => new
                {
                    PID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Peoples", x => x.PID);
                });

            migrationBuilder.InsertData(
                table: "_Peoples",
                columns: new[] { "PID", "City", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Burao", "Abdinoor", "Suleman" },
                    { 2, "Boorama", "Abdirahman", "Suleman" },
                    { 3, "BerBera", "Abdiqani", "Suleman" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_Peoples");
        }
    }
}
