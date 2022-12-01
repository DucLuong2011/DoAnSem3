using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoAnSem3.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "About",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(maxLength: 200, nullable: false),
                    image = table.Column<string>(nullable: true),
                    content = table.Column<string>(maxLength: 1000, nullable: false),
                    craateAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_About", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    customerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    customerName = table.Column<string>(maxLength: 200, nullable: false),
                    email = table.Column<string>(nullable: false),
                    phone = table.Column<string>(nullable: false),
                    phoneNsp = table.Column<int>(nullable: false),
                    password = table.Column<string>(nullable: true),
                    totalPrice = table.Column<float>(nullable: true),
                    status = table.Column<bool>(nullable: false),
                    role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.customerId);
                });

            migrationBuilder.CreateTable(
                name: "Freeback",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 200, nullable: false),
                    email = table.Column<string>(nullable: false),
                    phone = table.Column<string>(nullable: false),
                    note = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Freeback", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NetworkServiceProvider",
                columns: table => new
                {
                    nspId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nspName = table.Column<string>(nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetworkServiceProvider", x => x.nspId);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    svId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    svName = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.svId);
                });

            migrationBuilder.CreateTable(
                name: "Banking",
                columns: table => new
                {
                    bankId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    bankName = table.Column<string>(maxLength: 200, nullable: false),
                    rechange = table.Column<float>(nullable: false),
                    status = table.Column<bool>(nullable: false),
                    createAt = table.Column<DateTime>(nullable: true),
                    cusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banking", x => x.bankId);
                    table.ForeignKey(
                        name: "FK_Banking_Customer_cusId",
                        column: x => x.cusId,
                        principalTable: "Customer",
                        principalColumn: "customerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    productId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    productName = table.Column<string>(maxLength: 200, nullable: true),
                    price = table.Column<float>(nullable: false),
                    description = table.Column<string>(maxLength: 1000, nullable: true),
                    nspId = table.Column<int>(nullable: false),
                    svId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.productId);
                    table.ForeignKey(
                        name: "FK_Product_NetworkServiceProvider_nspId",
                        column: x => x.nspId,
                        principalTable: "NetworkServiceProvider",
                        principalColumn: "nspId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Service_svId",
                        column: x => x.svId,
                        principalTable: "Service",
                        principalColumn: "svId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    orderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    numberPhone = table.Column<string>(nullable: true),
                    nameCustomer = table.Column<string>(nullable: true),
                    nameService = table.Column<string>(nullable: true),
                    transactionId = table.Column<int>(nullable: false),
                    createAt = table.Column<DateTime>(nullable: false),
                    status = table.Column<bool>(nullable: false),
                    productId = table.Column<int>(nullable: false),
                    customerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.orderId);
                    table.ForeignKey(
                        name: "FK_orders_Customer_customerId",
                        column: x => x.customerId,
                        principalTable: "Customer",
                        principalColumn: "customerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_Product_productId",
                        column: x => x.productId,
                        principalTable: "Product",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Banking_cusId",
                table: "Banking",
                column: "cusId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_customerId",
                table: "orders",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_productId",
                table: "orders",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_nspId",
                table: "Product",
                column: "nspId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_svId",
                table: "Product",
                column: "svId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "About");

            migrationBuilder.DropTable(
                name: "Banking");

            migrationBuilder.DropTable(
                name: "Freeback");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "NetworkServiceProvider");

            migrationBuilder.DropTable(
                name: "Service");
        }
    }
}
