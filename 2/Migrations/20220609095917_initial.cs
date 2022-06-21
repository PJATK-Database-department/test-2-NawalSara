using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APBD_Test2.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Confectionery",
                columns: table => new
                {
                    IdConectionery = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    PricePerItem = table.Column<double>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confectionery", x => x.IdConectionery);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    IdClient = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.IdClient);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    IdEmpl = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.IdEmpl);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    IdOrder = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAccepted = table.Column<DateTime>(nullable: false),
                    DateFinished = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    IdClient = table.Column<int>(nullable: false),
                    IdEmpl = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.IdOrder);
                    table.ForeignKey(
                        name: "FK_Order_Customer_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Customer",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Employee_IdEmpl",
                        column: x => x.IdEmpl,
                        principalTable: "Employee",
                        principalColumn: "IdEmpl",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Confectionery_Order",
                columns: table => new
                {
                    IdConfection = table.Column<int>(nullable: false),
                    IdOrder = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confectionery_Order", x => new { x.IdOrder, x.IdConfection });
                    table.ForeignKey(
                        name: "FK_Confectionery_Order_Confectionery_IdConfection",
                        column: x => x.IdConfection,
                        principalTable: "Confectionery",
                        principalColumn: "IdConectionery",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Confectionery_Order_Order_IdOrder",
                        column: x => x.IdOrder,
                        principalTable: "Order",
                        principalColumn: "IdOrder",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Confectionery",
                columns: new[] { "IdConectionery", "Name", "PricePerItem", "Type" },
                values: new object[,]
                {
                    { 1, "whatever", 2.3399999999999999, "gud" },
                    { 2, "nme", 2.5600000000000001, "okei" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "IdClient", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, "John", "Doe" },
                    { 2, "Steve", "Do" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "IdEmpl", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, "Jonny", "Dough" },
                    { 2, "Steven", "Dou" }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "IdOrder", "DateAccepted", "DateFinished", "IdClient", "IdEmpl", "Notes" },
                values: new object[] { 1, new DateTime(2020, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "gibberish" });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "IdOrder", "DateAccepted", "DateFinished", "IdClient", "IdEmpl", "Notes" },
                values: new object[] { 2, new DateTime(2020, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "NotesHere" });

            migrationBuilder.InsertData(
                table: "Confectionery_Order",
                columns: new[] { "IdOrder", "IdConfection", "Notes", "Quantity" },
                values: new object[] { 1, 1, "noted", 3 });

            migrationBuilder.InsertData(
                table: "Confectionery_Order",
                columns: new[] { "IdOrder", "IdConfection", "Notes", "Quantity" },
                values: new object[] { 2, 2, "NOTED", 4 });

            migrationBuilder.CreateIndex(
                name: "IX_Confectionery_Order_IdConfection",
                table: "Confectionery_Order",
                column: "IdConfection");

            migrationBuilder.CreateIndex(
                name: "IX_Order_IdClient",
                table: "Order",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Order_IdEmpl",
                table: "Order",
                column: "IdEmpl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Confectionery_Order");

            migrationBuilder.DropTable(
                name: "Confectionery");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
