using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace guitarapi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guitarists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guitarists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GuitarTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuitarTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Strings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guitars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    StringsId = table.Column<int>(type: "int", nullable: false),
                    ProducerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guitars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Guitars_GuitarTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "GuitarTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Guitars_Producers_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Producers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Guitars_Strings_StringsId",
                        column: x => x.StringsId,
                        principalTable: "Strings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuitaristsGuitars",
                columns: table => new
                {
                    GuitarId = table.Column<int>(type: "int", nullable: false),
                    GuitaristId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuitaristsGuitars", x => new { x.GuitarId, x.GuitaristId });
                    table.ForeignKey(
                        name: "FK_GuitaristsGuitars_Guitarists_GuitaristId",
                        column: x => x.GuitaristId,
                        principalTable: "Guitarists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuitaristsGuitars_Guitars_GuitarId",
                        column: x => x.GuitarId,
                        principalTable: "Guitars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "GuitarTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Electric" },
                    { 2, "Acoustic" },
                    { 3, "Classical" },
                    { 4, "Electro acoustic" },
                    { 5, "Classical Acoustic-Electric" }
                });

            migrationBuilder.InsertData(
                table: "Producers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fender" },
                    { 2, "Gibson" },
                    { 3, "Taylor" },
                    { 4, "Martin" },
                    { 5, "PRS" },
                    { 6, "Ibanez" },
                    { 7, "Yamaha" },
                    { 8, "Epiphone" },
                    { 9, "Suhr" },
                    { 10, "Rickenbacker" }
                });

            migrationBuilder.InsertData(
                table: "Strings",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Nylon" },
                    { 2, "Carbon" },
                    { 3, "Pro steel" },
                    { 4, "Pure nickel" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuitaristsGuitars_GuitaristId",
                table: "GuitaristsGuitars",
                column: "GuitaristId");

            migrationBuilder.CreateIndex(
                name: "IX_Guitars_ProducerId",
                table: "Guitars",
                column: "ProducerId");

            migrationBuilder.CreateIndex(
                name: "IX_Guitars_StringsId",
                table: "Guitars",
                column: "StringsId");

            migrationBuilder.CreateIndex(
                name: "IX_Guitars_TypeId",
                table: "Guitars",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuitaristsGuitars");

            migrationBuilder.DropTable(
                name: "Guitarists");

            migrationBuilder.DropTable(
                name: "Guitars");

            migrationBuilder.DropTable(
                name: "GuitarTypes");

            migrationBuilder.DropTable(
                name: "Producers");

            migrationBuilder.DropTable(
                name: "Strings");
        }
    }
}
