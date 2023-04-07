using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MigratonName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Адрес",
                schema: "dbo",
                columns: table => new
                {
                    Login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    House = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Appartments = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Адрес", x => x.Login)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Категории",
                schema: "dbo",
                columns: table => new
                {
                    Category_ID = table.Column<int>(type: "int", nullable: false),
                    Category_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Is_Deleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Категории", x => x.Category_ID)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Пользователи",
                schema: "dbo",
                columns: table => new
                {
                    Login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Birthday = table.Column<DateTime>(type: "date", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Пользователи", x => x.Login)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Пользователи_Адрес",
                        column: x => x.Login,
                        principalSchema: "dbo",
                        principalTable: "Адрес",
                        principalColumn: "Login");
                });

            migrationBuilder.CreateTable(
                name: "Товар",
                schema: "dbo",
                columns: table => new
                {
                    Product_ID = table.Column<int>(type: "int", nullable: false),
                    Product_Price = table.Column<double>(type: "float(53)", precision: 53, nullable: true),
                    Product_weight = table.Column<double>(type: "float(53)", precision: 53, nullable: true),
                    Product_Lenght = table.Column<double>(type: "float(53)", precision: 53, nullable: true),
                    Product_width = table.Column<double>(type: "float(53)", precision: 53, nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Sum_product = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Товар", x => x.Product_ID)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Товар_Категории",
                        column: x => x.Product_ID,
                        principalSchema: "dbo",
                        principalTable: "Категории",
                        principalColumn: "Category_ID");
                });

            migrationBuilder.CreateTable(
                name: "Заказ",
                schema: "dbo",
                columns: table => new
                {
                    Order_number = table.Column<int>(type: "int", nullable: false),
                    Order_date = table.Column<DateTime>(type: "date", nullable: true),
                    Login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Price = table.Column<double>(type: "float(53)", precision: 53, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Delivery_Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Заказ", x => x.Order_number)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Заказ_Пользователи",
                        column: x => x.Login,
                        principalSchema: "dbo",
                        principalTable: "Пользователи",
                        principalColumn: "Login");
                });

            migrationBuilder.CreateTable(
                name: "Оценка_товара",
                schema: "dbo",
                columns: table => new
                {
                    Product_ID = table.Column<int>(type: "int", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Оценка_товара", x => new { x.Product_ID, x.Login })
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Оценка_товара_Пользователи",
                        column: x => x.Login,
                        principalSchema: "dbo",
                        principalTable: "Пользователи",
                        principalColumn: "Login");
                    table.ForeignKey(
                        name: "FK_Оценка_товара_Товар",
                        column: x => x.Product_ID,
                        principalSchema: "dbo",
                        principalTable: "Товар",
                        principalColumn: "Product_ID");
                });

            migrationBuilder.CreateTable(
                name: "Заказ_товара",
                schema: "dbo",
                columns: table => new
                {
                    Order_number = table.Column<int>(type: "int", nullable: false),
                    Product_ID = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Заказ_товара", x => new { x.Order_number, x.Product_ID })
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Заказ_товара_Заказ",
                        column: x => x.Order_number,
                        principalSchema: "dbo",
                        principalTable: "Заказ",
                        principalColumn: "Order_number");
                    table.ForeignKey(
                        name: "FK_Заказ_товара_Товар",
                        column: x => x.Product_ID,
                        principalSchema: "dbo",
                        principalTable: "Товар",
                        principalColumn: "Product_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Заказ_Login",
                schema: "dbo",
                table: "Заказ",
                column: "Login");

            migrationBuilder.CreateIndex(
                name: "IX_Заказ_товара_Product_ID",
                schema: "dbo",
                table: "Заказ_товара",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Оценка_товара_Login",
                schema: "dbo",
                table: "Оценка_товара",
                column: "Login");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Заказ_товара",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Оценка_товара",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Заказ",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Товар",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Пользователи",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Категории",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Адрес",
                schema: "dbo");
        }
    }
}
