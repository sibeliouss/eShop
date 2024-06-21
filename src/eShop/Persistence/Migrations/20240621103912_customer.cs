using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class customer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("a2c5202f-d1a9-4da3-98c7-61bc4b0584fb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("86b1d63c-f611-4982-9811-ede261def1c8"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("0f50d939-eceb-4335-9534-c4d39aadb3e9"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 181, 196, 2, 225, 120, 101, 202, 159, 197, 133, 39, 157, 167, 116, 151, 206, 118, 200, 128, 111, 142, 98, 153, 142, 19, 88, 218, 169, 177, 174, 53, 116, 18, 73, 223, 53, 130, 118, 21, 107, 37, 165, 113, 217, 41, 95, 142, 189, 192, 253, 242, 192, 18, 104, 125, 23, 55, 108, 33, 219, 17, 213, 251, 157 }, new byte[] { 151, 181, 140, 212, 103, 253, 125, 107, 162, 10, 53, 42, 231, 70, 121, 176, 47, 45, 73, 86, 151, 153, 180, 205, 241, 193, 112, 96, 145, 81, 78, 77, 222, 208, 205, 1, 77, 104, 16, 199, 49, 174, 252, 80, 111, 64, 161, 239, 57, 249, 133, 249, 232, 208, 49, 9, 242, 166, 78, 83, 55, 113, 136, 239, 232, 142, 0, 171, 149, 37, 231, 13, 91, 150, 28, 192, 242, 220, 82, 148, 33, 94, 17, 10, 181, 223, 54, 19, 66, 56, 121, 112, 3, 1, 123, 85, 130, 48, 237, 50, 214, 69, 203, 20, 161, 124, 131, 212, 49, 52, 131, 200, 193, 59, 216, 84, 55, 55, 12, 104, 81, 255, 217, 213, 161, 200, 83, 208 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("a1c608e3-ac57-43d6-9b2f-183e7e50734f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("0f50d939-eceb-4335-9534-c4d39aadb3e9") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("a1c608e3-ac57-43d6-9b2f-183e7e50734f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0f50d939-eceb-4335-9534-c4d39aadb3e9"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("86b1d63c-f611-4982-9811-ede261def1c8"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 34, 15, 47, 177, 42, 32, 107, 63, 224, 194, 165, 206, 38, 246, 86, 168, 50, 63, 151, 190, 84, 91, 220, 65, 39, 169, 85, 210, 75, 110, 48, 168, 221, 67, 227, 110, 177, 216, 230, 24, 113, 87, 115, 73, 245, 90, 25, 110, 211, 173, 156, 249, 47, 219, 31, 68, 8, 100, 86, 153, 48, 144, 31, 186 }, new byte[] { 220, 161, 175, 92, 147, 26, 19, 0, 169, 97, 234, 107, 77, 2, 21, 168, 1, 145, 153, 85, 183, 73, 135, 33, 14, 104, 139, 190, 160, 229, 62, 196, 150, 223, 97, 44, 218, 152, 236, 138, 202, 82, 114, 174, 106, 174, 169, 175, 83, 84, 69, 204, 193, 82, 175, 253, 17, 176, 67, 34, 126, 223, 146, 80, 9, 39, 224, 89, 34, 35, 74, 159, 93, 234, 253, 159, 58, 178, 31, 12, 200, 82, 132, 167, 78, 237, 100, 110, 200, 139, 142, 78, 81, 101, 10, 187, 253, 142, 34, 108, 22, 182, 181, 74, 226, 146, 247, 67, 237, 233, 255, 152, 167, 198, 223, 201, 231, 181, 244, 141, 137, 139, 136, 181, 238, 229, 237, 220 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("a2c5202f-d1a9-4da3-98c7-61bc4b0584fb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("86b1d63c-f611-4982-9811-ede261def1c8") });
        }
    }
}
