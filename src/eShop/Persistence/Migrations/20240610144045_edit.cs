using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("6fcbd2b8-187b-4218-87e0-7f03e42de417"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fc2121fd-7161-4af0-958f-04dbab78fdf6"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 48,
                column: "Name",
                value: "Orders.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 49,
                column: "Name",
                value: "Orders.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 50,
                column: "Name",
                value: "Orders.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 51,
                column: "Name",
                value: "Orders.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 52,
                column: "Name",
                value: "Orders.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 53,
                column: "Name",
                value: "Orders.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 54,
                column: "Name",
                value: "Products.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 55,
                column: "Name",
                value: "Products.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 56,
                column: "Name",
                value: "Products.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 57,
                column: "Name",
                value: "Products.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 58,
                column: "Name",
                value: "Products.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 59,
                column: "Name",
                value: "Products.Delete");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("de40a203-d1af-455a-aebc-7767b3ea789f"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 19, 234, 10, 179, 70, 228, 113, 253, 172, 224, 149, 147, 56, 44, 38, 5, 60, 91, 225, 224, 121, 55, 221, 237, 116, 58, 56, 248, 148, 182, 242, 193, 21, 176, 245, 73, 77, 38, 38, 101, 179, 9, 79, 69, 40, 4, 167, 145, 138, 117, 92, 227, 151, 188, 15, 52, 53, 100, 155, 206, 72, 174, 205, 250 }, new byte[] { 162, 165, 9, 202, 190, 67, 225, 94, 133, 99, 105, 119, 236, 221, 49, 171, 253, 59, 64, 204, 23, 62, 22, 61, 5, 45, 158, 96, 153, 196, 224, 134, 162, 14, 62, 53, 144, 10, 235, 140, 203, 144, 236, 247, 144, 4, 182, 176, 28, 3, 164, 255, 148, 128, 242, 249, 5, 126, 2, 72, 75, 126, 137, 65, 165, 73, 160, 106, 45, 213, 193, 239, 230, 12, 253, 71, 187, 203, 226, 140, 201, 209, 158, 238, 145, 111, 81, 215, 193, 135, 27, 156, 253, 60, 204, 9, 100, 123, 72, 92, 148, 242, 186, 139, 14, 1, 248, 60, 194, 128, 17, 29, 189, 101, 149, 230, 130, 49, 135, 59, 10, 84, 66, 193, 120, 184, 206, 173 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("69e8345d-9a2e-4b4c-bd46-d6d21c787c2e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("de40a203-d1af-455a-aebc-7767b3ea789f") });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ProductId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("69e8345d-9a2e-4b4c-bd46-d6d21c787c2e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("de40a203-d1af-455a-aebc-7767b3ea789f"));

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Orders");

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 48,
                column: "Name",
                value: "OrderProducts.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 49,
                column: "Name",
                value: "OrderProducts.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 50,
                column: "Name",
                value: "OrderProducts.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 51,
                column: "Name",
                value: "OrderProducts.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 52,
                column: "Name",
                value: "OrderProducts.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 53,
                column: "Name",
                value: "OrderProducts.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 54,
                column: "Name",
                value: "Orders.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 55,
                column: "Name",
                value: "Orders.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 56,
                column: "Name",
                value: "Orders.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 57,
                column: "Name",
                value: "Orders.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 58,
                column: "Name",
                value: "Orders.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 59,
                column: "Name",
                value: "Orders.Delete");

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Products.Admin", null },
                    { 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Products.Read", null },
                    { 62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Products.Write", null },
                    { 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Products.Create", null },
                    { 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Products.Update", null },
                    { 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Products.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("fc2121fd-7161-4af0-958f-04dbab78fdf6"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 249, 53, 210, 236, 226, 246, 183, 79, 93, 21, 130, 164, 113, 63, 235, 188, 18, 238, 141, 18, 15, 47, 252, 204, 73, 197, 46, 39, 220, 6, 56, 51, 114, 128, 68, 43, 145, 250, 201, 120, 241, 183, 198, 245, 81, 164, 168, 178, 183, 211, 111, 81, 213, 49, 222, 154, 84, 108, 131, 227, 14, 98, 225, 144 }, new byte[] { 2, 65, 0, 201, 212, 242, 183, 236, 57, 248, 201, 104, 120, 248, 205, 21, 5, 163, 186, 18, 206, 213, 108, 79, 169, 134, 190, 2, 204, 89, 96, 206, 196, 5, 149, 10, 157, 70, 113, 12, 234, 138, 236, 117, 230, 85, 166, 201, 246, 232, 28, 228, 147, 4, 70, 163, 149, 113, 56, 24, 170, 2, 47, 149, 210, 232, 64, 229, 143, 235, 223, 227, 228, 126, 237, 176, 182, 161, 62, 251, 155, 60, 206, 245, 127, 175, 222, 13, 43, 129, 12, 213, 14, 75, 60, 116, 10, 218, 95, 228, 138, 166, 49, 77, 60, 214, 179, 52, 229, 7, 76, 168, 87, 14, 41, 58, 96, 110, 229, 132, 5, 123, 66, 231, 122, 240, 58, 103 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("6fcbd2b8-187b-4218-87e0-7f03e42de417"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("fc2121fd-7161-4af0-958f-04dbab78fdf6") });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderId",
                table: "OrderProducts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductId",
                table: "OrderProducts",
                column: "ProductId");
        }
    }
}
