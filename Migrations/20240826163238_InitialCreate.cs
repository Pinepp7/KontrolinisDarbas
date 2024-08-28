using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KontrolinisDarbas.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pirkejas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vardas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pavarde = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ElPastas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numeris = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pirkejas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produktas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pavadinimas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kaina = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Kategorija = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kiekis = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produktas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uzsakymas",
                columns: table => new
                {
                    PirkejoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProduktoId = table.Column<int>(type: "int", nullable: false),
                    UzsakymoId = table.Column<int>(type: "int", nullable: false),
                    UzsakymoDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UzsakymoKiekis = table.Column<int>(type: "int", nullable: false),
                    PirkejasId = table.Column<int>(type: "int", nullable: false),
                    ProduktasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzsakymas", x => x.PirkejoId);
                    table.ForeignKey(
                        name: "FK_Uzsakymas_Pirkejas_PirkejasId",
                        column: x => x.PirkejasId,
                        principalTable: "Pirkejas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Uzsakymas_Produktas_ProduktasId",
                        column: x => x.ProduktasId,
                        principalTable: "Produktas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Uzsakymas_PirkejasId",
                table: "Uzsakymas",
                column: "PirkejasId");

            migrationBuilder.CreateIndex(
                name: "IX_Uzsakymas_ProduktasId",
                table: "Uzsakymas",
                column: "ProduktasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Uzsakymas");

            migrationBuilder.DropTable(
                name: "Pirkejas");

            migrationBuilder.DropTable(
                name: "Produktas");
        }
    }
}
