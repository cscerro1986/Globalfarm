using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Disval.Migrations
{
    public partial class global : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CCVs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PuntoDeVenta = table.Column<int>(type: "int", nullable: false),
                    Comprobante = table.Column<int>(type: "int", nullable: false),
                    FechaDeEmision = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCVs", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TFCs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigoLaboratorio = table.Column<int>(type: "int", nullable: false),
                    serie = table.Column<int>(type: "int", nullable: false),
                    numeroDeDocumento = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TFCs", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DCVs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IDCCV = table.Column<int>(type: "int", nullable: false),
                    transaccionCCVID = table.Column<int>(type: "int", nullable: false),
                    CodigoLaboratorio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DCVs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DCVs_CCVs_transaccionCCVID",
                        column: x => x.transaccionCCVID,
                        principalTable: "CCVs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DCVs_transaccionCCVID",
                table: "DCVs",
                column: "transaccionCCVID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DCVs");

            migrationBuilder.DropTable(
                name: "TFCs");

            migrationBuilder.DropTable(
                name: "CCVs");
        }
    }
}
