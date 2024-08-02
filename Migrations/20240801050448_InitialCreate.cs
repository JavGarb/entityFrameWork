using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace app_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategoriaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Peso = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Tarea",
                columns: table => new
                {
                    TareaId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoriaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Titulo = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: true),
                    PrioridadTarea = table.Column<int>(type: "integer", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarea", x => x.TareaId);
                    table.ForeignKey(
                        name: "FK_Tarea_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Description", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("b0e000d3-f29c-4fed-8747-3bd0734f8711"), null, "Personal", 50 },
                    { new Guid("b0e000d3-f29c-4fed-8747-3bd0734f871e"), null, "Pending", 20 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("b0e000d3-f29c-4fed-8747-3bd0734f8721"), new Guid("b0e000d3-f29c-4fed-8747-3bd0734f8711"), null, new DateTime(2024, 8, 1, 5, 4, 47, 522, DateTimeKind.Utc).AddTicks(2670), 0, "Netflix movie end" },
                    { new Guid("b0e000d3-f29c-4fed-8747-3bd0734f8730"), new Guid("b0e000d3-f29c-4fed-8747-3bd0734f871e"), null, new DateTime(2024, 8, 1, 5, 4, 47, 522, DateTimeKind.Utc).AddTicks(2665), 1, "Review public services pays" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarea_CategoriaId",
                table: "Tarea",
                column: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarea");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
