using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace assignment1C_.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Organization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "Category", "CategoryId", "Email", "FirstName", "LastName", "Organization", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 0, 1, "juangg@gmail.com", "Juan", "Guerro", "RDP", "1234567890" },
                    { 2, 0, 2, "elara.starseeker@stellarnet.com ", "Elara", "Starseeker", "Stellar Explorations", "1234567890" },
                    { 3, 0, 5, "cassia.moonshade@lunarchive.us ", "Cassia", "Moonshade", "Celestial Archives", "7788990011" },
                    { 4, 0, 4, "thorne.blackthorn@shadowcraft.io ", "Thorne", "Blackthorn", "Shadowbound Guild", "9988776655" },
                    { 5, 0, 3, "mira.luminaris@lightweave.org ", "Mira", "Luminaris", "Weavers of Dawn", "1122334455" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
