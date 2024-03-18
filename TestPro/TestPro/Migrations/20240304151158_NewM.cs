using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestPro.Migrations
{
    /// <inheritdoc />
    public partial class NewM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diseases",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    id_card = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseases", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    lastname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    midlename = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Proffecional = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Drug",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drug", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "EventType",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Oname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    number_passport = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: true),
                    seria_passport = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: true),
                    gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    adress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    number = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: true),
                    id_card = table.Column<int>(type: "int", nullable: true),
                    photo = table.Column<byte[]>(type: "binary(50)", fixedLength: true, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    cost = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    id_role = table.Column<int>(type: "int", nullable: true),
                    name_role = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                    table.ForeignKey(
                        name: "FK_Users_Doctor",
                        column: x => x.id_role,
                        principalTable: "Doctor",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Users_Patient",
                        column: x => x.id_role,
                        principalTable: "Patient",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    id_patient = table.Column<int>(type: "int", nullable: false),
                    id_doctor = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    date_p = table.Column<DateTime>(type: "datetime", nullable: true),
                    info_dop = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    directions = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    id_diseases = table.Column<int>(type: "int", nullable: false),
                    recipe = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.id);
                    table.ForeignKey(
                        name: "FK_Card_Diseases",
                        column: x => x.id_diseases,
                        principalTable: "Diseases",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Card_Drug",
                        column: x => x.recipe,
                        principalTable: "Drug",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Card_User",
                        column: x => x.id,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    id_card = table.Column<int>(type: "int", nullable: false),
                    id_service = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    result = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    date = table.Column<DateTime>(type: "datetime", nullable: true),
                    type = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.id);
                    table.ForeignKey(
                        name: "FK_Events_Card",
                        column: x => x.id_card,
                        principalTable: "Card",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Events_EventType",
                        column: x => x.type,
                        principalTable: "EventType",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Events_Services",
                        column: x => x.id_service,
                        principalTable: "Services",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Card_id_diseases",
                table: "Card",
                column: "id_diseases");

            migrationBuilder.CreateIndex(
                name: "IX_Card_recipe",
                table: "Card",
                column: "recipe");

            migrationBuilder.CreateIndex(
                name: "IX_Events_id_card",
                table: "Events",
                column: "id_card");

            migrationBuilder.CreateIndex(
                name: "IX_Events_id_service",
                table: "Events",
                column: "id_service");

            migrationBuilder.CreateIndex(
                name: "IX_Events_type",
                table: "Events",
                column: "type");

            migrationBuilder.CreateIndex(
                name: "IX_Users_id_role",
                table: "Users",
                column: "id_role");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "EventType");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Diseases");

            migrationBuilder.DropTable(
                name: "Drug");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Patient");
        }
    }
}
