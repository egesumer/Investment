using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InvestmentApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvestmentTools",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentTools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    TotalInvestment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Investments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvestmentToolId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvestmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Investments_InvestmentTools_InvestmentToolId",
                        column: x => x.InvestmentToolId,
                        principalTable: "InvestmentTools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Investments_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "InvestmentTools",
                columns: new[] { "Id", "CreationDate", "CurrentValue", "IsDeleted", "ModifiedDate", "Name", "Symbol" },
                values: new object[,]
                {
                    { new Guid("05e0d9a2-fac7-4e52-a26c-d357b5aa580e"), new DateTime(2024, 11, 10, 3, 39, 58, 456, DateTimeKind.Local).AddTicks(1684), 20000.00m, false, null, "Dow Jones Index", "DJI" },
                    { new Guid("062549c3-a85a-4c34-be4d-89455f7a49cf"), new DateTime(2024, 11, 10, 3, 39, 58, 456, DateTimeKind.Local).AddTicks(1674), 2000.00m, false, null, "Beyaz Eşya", "BEYAZE" },
                    { new Guid("08ce4272-c25c-46f6-bf9e-e391485c2f4f"), new DateTime(2024, 11, 10, 3, 39, 58, 456, DateTimeKind.Local).AddTicks(1689), 300000.00m, false, null, "Palladium", "PA" },
                    { new Guid("0f5fb133-c518-4106-a0d1-aefa2d944299"), new DateTime(2024, 11, 10, 3, 39, 58, 456, DateTimeKind.Local).AddTicks(1699), 6000.00m, false, null, "Bitcoin Cash", "BCH" },
                    { new Guid("15ce08d4-52b5-4bcf-beb8-280d8d90ef32"), new DateTime(2024, 11, 10, 3, 39, 58, 456, DateTimeKind.Local).AddTicks(1692), 300.00m, false, null, "Natural Gas", "NG" },
                    { new Guid("2cb52aa1-9aab-4e68-ac75-374f06651188"), new DateTime(2024, 11, 10, 3, 39, 58, 456, DateTimeKind.Local).AddTicks(1671), 1500.00m, false, null, "Litecoin", "LTC" },
                    { new Guid("401d118e-8bdd-4db7-98a6-d2e46d32606a"), new DateTime(2024, 11, 10, 3, 39, 58, 456, DateTimeKind.Local).AddTicks(1672), 2500.00m, false, null, "Tesla Stock", "TSLA" },
                    { new Guid("547a7f94-fb00-4d0f-86d9-2f75066dfe85"), new DateTime(2024, 11, 10, 3, 39, 58, 456, DateTimeKind.Local).AddTicks(1694), 750.00m, false, null, "Crude Oil", "CL" },
                    { new Guid("57a44fa2-0cac-40dd-8a2c-bd7cf388cf6e"), new DateTime(2024, 11, 10, 3, 39, 58, 456, DateTimeKind.Local).AddTicks(1677), 9000.00m, false, null, "Nasdaq-100 Index", "IXIC" },
                    { new Guid("766339f4-2e5e-4aa3-8099-aac77330ab2e"), new DateTime(2024, 11, 10, 3, 39, 58, 456, DateTimeKind.Local).AddTicks(1682), 3500.00m, false, null, "Amazon Stock", "AMZN" },
                    { new Guid("7f7372cf-ffac-4f07-83d3-e4296e91355c"), new DateTime(2024, 11, 10, 3, 39, 58, 456, DateTimeKind.Local).AddTicks(1669), 90000.00m, false, null, "Ethereum", "ETH" },
                    { new Guid("8e40f0ff-54d9-4a55-9ac9-2c7c78194aa3"), new DateTime(2024, 11, 10, 3, 39, 58, 456, DateTimeKind.Local).AddTicks(1654), 1250.00m, false, null, "Silver", "XAG" },
                    { new Guid("941110c2-34f9-4b92-ae8b-35ca94e835d4"), new DateTime(2024, 11, 10, 3, 39, 58, 456, DateTimeKind.Local).AddTicks(1676), 10.00m, false, null, "XRP (Ripple)", "XRP" },
                    { new Guid("9ebbf22c-71a1-41f5-8568-1721a04aabad"), new DateTime(2024, 11, 10, 3, 39, 58, 456, DateTimeKind.Local).AddTicks(1687), 200000.00m, false, null, "Platinum", "PLT" },
                    { new Guid("a4a96235-0ad8-4ab6-809a-ead9244d2e05"), new DateTime(2024, 11, 10, 3, 39, 58, 456, DateTimeKind.Local).AddTicks(1690), 1500.00m, false, null, "Borsa İstanbul 100 Endeksi", "BIST100" },
                    { new Guid("b1712de2-3a0b-4d69-a1b2-aa399f534e41"), new DateTime(2024, 11, 10, 3, 39, 58, 456, DateTimeKind.Local).AddTicks(1697), 2000.00m, false, null, "Silver ETF", "SLV" },
                    { new Guid("c18468ca-f9b3-4322-810c-bc0c624d8344"), new DateTime(2024, 11, 10, 3, 39, 58, 456, DateTimeKind.Local).AddTicks(1667), 1250000.00m, false, null, "Bitcoin", "BTC" },
                    { new Guid("cc79ded1-ff56-43e8-b260-aeff13af0ea1"), new DateTime(2024, 11, 10, 3, 39, 58, 456, DateTimeKind.Local).AddTicks(1665), 2200.00m, false, null, "Apple Stock", "AAPL" },
                    { new Guid("f4e60157-f7f3-4ee4-9df9-9c3dbe58421f"), new DateTime(2024, 11, 10, 3, 39, 58, 456, DateTimeKind.Local).AddTicks(1653), 101500.00m, false, null, "Gold", "XAU" },
                    { new Guid("f780692a-25cf-487b-afb0-cce388794c9b"), new DateTime(2024, 11, 10, 3, 39, 58, 456, DateTimeKind.Local).AddTicks(1685), 15000.00m, false, null, "SP500 Index", "SPX" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreationDate", "Email", "IsDeleted", "ModifiedDate", "PasswordHash", "TotalInvestment", "UserType", "Username" },
                values: new object[,]
                {
                    { new Guid("1ee7c0c5-0d96-4950-bb47-398a72f76366"), new DateTime(2024, 11, 10, 3, 39, 58, 456, DateTimeKind.Local).AddTicks(1556), null, false, null, "tsRYY4deNEh8o8FV7RRe/hKnRYHie+/sWqZhuO6Mpt0=", 0.0m, 3, "customer" },
                    { new Guid("49166a54-7d2c-451e-8190-abef57947d5a"), new DateTime(2024, 11, 10, 3, 39, 58, 456, DateTimeKind.Local).AddTicks(1542), null, false, null, "jGl25bVBBBW96Qi9Te4V37Fnqchz/Eu4qB9vKrRIqRg=", 0.0m, 2, "admin" },
                    { new Guid("a621c6c6-6cea-4ad9-bb50-44d35f66dca0"), new DateTime(2024, 11, 10, 3, 39, 58, 456, DateTimeKind.Local).AddTicks(1519), null, false, null, "GGz3dMl7YKHBBu9xjRCXCmoG4GvviVU9muZdk4qIbq4=", 0.0m, 1, "superadmin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Investments_InvestmentToolId",
                table: "Investments",
                column: "InvestmentToolId");

            migrationBuilder.CreateIndex(
                name: "IX_Investments_UserId",
                table: "Investments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Username",
                table: "User",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Investments");

            migrationBuilder.DropTable(
                name: "InvestmentTools");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
