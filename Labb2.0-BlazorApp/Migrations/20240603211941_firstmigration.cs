using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb2._0_BlazorApp.Migrations
{
    /// <inheritdoc />
    public partial class firstmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    AuthorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Author__70DAFC142BA7F681", x => x.AuthorID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    StoreID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__A4AE64B82C3B084D", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    PublisherID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublisherName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Publishe__4C657E4B7223CCDB", x => x.PublisherID);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    StoreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreNamn = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Storedress = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Stores__3B82F0E11C07379A", x => x.StoreID);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ISBN13 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Category = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Languege = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "date", nullable: true),
                    PublisherID = table.Column<int>(type: "int", nullable: true),
                    AuthorID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Books__3BF79E038D206177", x => x.ISBN13);
                    table.ForeignKey(
                        name: "FK__Books__AuthorID__36B12243",
                        column: x => x.AuthorID,
                        principalTable: "Author",
                        principalColumn: "AuthorID");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "date", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Orders__C3905BAF39C14F24", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK__Orders__Customer__412EB0B6",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    EmployeeLastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    EmployeeEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    EmployeeStore = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__7AD04FF1573B60D0", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK__Employee__Employ__45F365D3",
                        column: x => x.EmployeeStore,
                        principalTable: "Stores",
                        principalColumn: "StoreID");
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    InventoryID = table.Column<int>(type: "int", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Inventor__51BA35BD57CD28AC", x => new { x.InventoryID, x.ISBN });
                    table.ForeignKey(
                        name: "FK__Inventory__ISBN__3C69FB99",
                        column: x => x.ISBN,
                        principalTable: "Books",
                        principalColumn: "ISBN13");
                    table.ForeignKey(
                        name: "FK__Inventory__Inven__3B75D760",
                        column: x => x.InventoryID,
                        principalTable: "Stores",
                        principalColumn: "StoreID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorID",
                table: "Books",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeStore",
                table: "Employee",
                column: "EmployeeStore");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ISBN",
                table: "Inventory",
                column: "ISBN");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Publisher");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Author");
        }
    }
}
