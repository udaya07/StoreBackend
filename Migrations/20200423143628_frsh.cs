using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreBackEnd.Migrations
{
    public partial class frsh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<int>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserDefn",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 100, nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: false),
                    EmailId = table.Column<string>(maxLength: 100, nullable: false),
                    MobileNumber = table.Column<string>(maxLength: 100, nullable: false),
                    RoleName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDefn", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(nullable: false),
                    ProdType = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductType_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    DeliverTo = table.Column<string>(nullable: true),
                    ContactNo = table.Column<string>(maxLength: 30, nullable: false),
                    DeliveryAddress = table.Column<string>(maxLength: 100, nullable: false),
                    Pincode = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_UserDefn_UserId",
                        column: x => x.UserId,
                        principalTable: "UserDefn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductTypeId = table.Column<int>(nullable: false),
                    ProductName = table.Column<string>(maxLength: 100, nullable: false),
                    Specification = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: false),
                    Picture = table.Column<string>(maxLength: 200, nullable: false),
                    Price = table.Column<string>(maxLength: 100, nullable: false),
                    AddQuantity = table.Column<string>(maxLength: 100, nullable: false),
                    InStock = table.Column<string>(maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AddToCart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    OrderDetailsId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<string>(maxLength: 30, nullable: true),
                    UserDefnId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddToCart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddToCart_OrderDetails_OrderDetailsId",
                        column: x => x.OrderDetailsId,
                        principalTable: "OrderDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddToCart_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddToCart_UserDefn_UserDefnId",
                        column: x => x.UserDefnId,
                        principalTable: "UserDefn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WishList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WishList_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishList_UserDefn_UserId",
                        column: x => x.UserId,
                        principalTable: "UserDefn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(nullable: false),
                    OrderDate = table.Column<DateTime>(maxLength: 30, nullable: false),
                    OrderTime = table.Column<DateTime>(maxLength: 30, nullable: false),
                    StatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AddToCart_CartId",
                        column: x => x.CartId,
                        principalTable: "AddToCart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddToCart_OrderDetailsId",
                table: "AddToCart",
                column: "OrderDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_AddToCart_ProductId",
                table: "AddToCart",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AddToCart_UserDefnId",
                table: "AddToCart",
                column: "UserDefnId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_UserId",
                table: "OrderDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartId",
                table: "Orders",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StatusId",
                table: "Orders",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductTypeId",
                table: "Product",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductType_CategoryId",
                table: "ProductType",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WishList_ProductId",
                table: "WishList",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_WishList_UserId",
                table: "WishList",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "WishList");

            migrationBuilder.DropTable(
                name: "AddToCart");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "UserDefn");

            migrationBuilder.DropTable(
                name: "ProductType");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
