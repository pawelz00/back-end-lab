using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace todo_api.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Priorities",
                columns: table => new
                {
                    PriorityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priorities", x => x.PriorityId);
                });

            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PriorityId = table.Column<int>(type: "int", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Todos_Priorities_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "Priorities",
                        principalColumn: "PriorityId");
                });

            migrationBuilder.InsertData(
                table: "Priorities",
                columns: new[] { "PriorityId", "Name" },
                values: new object[] { 1, "Important" });

            migrationBuilder.InsertData(
                table: "Priorities",
                columns: new[] { "PriorityId", "Name" },
                values: new object[] { 2, "Medium important" });

            migrationBuilder.InsertData(
                table: "Priorities",
                columns: new[] { "PriorityId", "Name" },
                values: new object[] { 3, "Not very important" });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Created", "Description", "IsCompleted", "Name", "PriorityId" },
                values: new object[] { 1, new DateTime(2022, 6, 5, 23, 37, 20, 424, DateTimeKind.Utc).AddTicks(8166), "Łazienka, sypialnia, kuchnia, salon", false, "Odkurzyć", 2 });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Created", "Description", "IsCompleted", "Name", "PriorityId" },
                values: new object[] { 2, new DateTime(2022, 6, 5, 23, 37, 20, 424, DateTimeKind.Utc).AddTicks(8169), "Matematyka - planimetria", false, "Zrobić zadanie", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Todos_PriorityId",
                table: "Todos",
                column: "PriorityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todos");

            migrationBuilder.DropTable(
                name: "Priorities");
        }
    }
}
