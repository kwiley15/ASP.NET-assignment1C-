using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace assignment1C_.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

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
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_Contacts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Assistant" },
                    { 2, "Employee" },
                    { 3, "Manager" },
                    { 4, "Friend" },
                    { 5, "Family" },
                    { 6, "Other" }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "CategoryId", "DateAdded", "Email", "FirstName", "LastName", "Organization", "PhoneNumber", "Slug" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "juangg@gmail.com", "Juan", "Guerro", "RDP", "1234567890", "1/juan-guerro/" },
                    { 2, 2, new DateTime(2023, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "elara.starseeker@stellarnet.com", "Elara", "Starseeker", "Stellar Explorations", "1234567890", "2/elara-starseeker/" },
                    { 3, 5, new DateTime(2023, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "cassia.moonshade@lunarchive.us", "Cassia", "Moonshade", "Celestial Archives", "7788990011", "3/cassia-moonshade/" },
                    { 4, 4, new DateTime(2023, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "thorne.blackthorn@shadowcraft.io", "Thorne", "Blackthorn", "Shadowbound Guild", "9988776655", "4/thorne-blackthorn/" },
                    { 5, 3, new DateTime(2023, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "mira.luminaris@lightweave.org", "Mira", "Luminaris", "Weavers of Dawn", "1122334455", "5/mira-luminaris/" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CategoryId",
                table: "Contacts",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
