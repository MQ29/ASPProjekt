using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookData.Migrations
{
    /// <inheritdoc />
    public partial class nullabla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e59db1dd-4526-4514-9301-e82bae18cf59", "1b6a6a2c-2f62-4dd1-bc3a-e78b8d4d5211" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "89264d3d-c492-4547-8720-04ba07d8464d", "f86d15a9-4021-46de-8ded-db0271a1fc8a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89264d3d-c492-4547-8720-04ba07d8464d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e59db1dd-4526-4514-9301-e82bae18cf59");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b6a6a2c-2f62-4dd1-bc3a-e78b8d4d5211");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f86d15a9-4021-46de-8ded-db0271a1fc8a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "29b4a692-69bb-4aa6-a1c5-76679f50f009", "29b4a692-69bb-4aa6-a1c5-76679f50f009", "admin", "ADMIN" },
                    { "c5669c89-d0de-4745-9754-9b730f83ae31", "c5669c89-d0de-4745-9754-9b730f83ae31", "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "76b24d71-44a9-483c-aa24-3284c0d26e06", 0, "5b44e2ef-89f9-463f-8f64-bdee2d75b660", "krystian@books.pl", true, false, null, "KRYSTIAN@BOOKS.PL", "KRYSTIAN", "AQAAAAIAAYagAAAAEJIPQlYIQRjvPtJ98RJr2GbFKGVZd1ctrO2FtKyKzuK+RRfSybmNi5whPBIjKRid3g==", null, false, "d798240e-e4ee-4282-ad11-1d92f82db02f", false, "Krystian" },
                    { "7fcc4ba0-e6b3-453d-a4bc-9846a597cb6b", 0, "aeec4f80-f96f-480b-9f52-65011e445fb7", "mateusz@books.pl", true, false, null, "MATEUSZ@BOOKS.PL", "MATEUSZ", "AQAAAAIAAYagAAAAEPz+RXLp0/249vfsvrTjbnQAJs8wznk0Cue2HWeRM/RWQhSyDIqg+7Es2KL+4tBARw==", null, false, "1106e0bc-4421-4eae-ac64-7bf1c8920962", false, "Mateusz" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "c5669c89-d0de-4745-9754-9b730f83ae31", "76b24d71-44a9-483c-aa24-3284c0d26e06" },
                    { "29b4a692-69bb-4aa6-a1c5-76679f50f009", "7fcc4ba0-e6b3-453d-a4bc-9846a597cb6b" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c5669c89-d0de-4745-9754-9b730f83ae31", "76b24d71-44a9-483c-aa24-3284c0d26e06" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "29b4a692-69bb-4aa6-a1c5-76679f50f009", "7fcc4ba0-e6b3-453d-a4bc-9846a597cb6b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29b4a692-69bb-4aa6-a1c5-76679f50f009");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5669c89-d0de-4745-9754-9b730f83ae31");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "76b24d71-44a9-483c-aa24-3284c0d26e06");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7fcc4ba0-e6b3-453d-a4bc-9846a597cb6b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "89264d3d-c492-4547-8720-04ba07d8464d", "89264d3d-c492-4547-8720-04ba07d8464d", "user", "USER" },
                    { "e59db1dd-4526-4514-9301-e82bae18cf59", "e59db1dd-4526-4514-9301-e82bae18cf59", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1b6a6a2c-2f62-4dd1-bc3a-e78b8d4d5211", 0, "dc4a1060-5bf3-4015-8f4f-7c16fdf95954", "mateusz@books.pl", true, false, null, "MATEUSZ@BOOKS.PL", "MATEUSZ", "AQAAAAIAAYagAAAAEJbJtQCgyawai6tf+Ze4InzD9X8lw+LCDDObEVrLen5VV6SjVn/K9mb/NaPAB26BIQ==", null, false, "1407c1f1-b5fa-4861-873c-c553e9dedc6a", false, "Mateusz" },
                    { "f86d15a9-4021-46de-8ded-db0271a1fc8a", 0, "9a18c379-32c0-4bbf-a2a3-91033366b353", "krystian@books.pl", true, false, null, "KRYSTIAN@BOOKS.PL", "KRYSTIAN", "AQAAAAIAAYagAAAAEObYoIwJCoVxo7zI7KHXrFB5yj138l3u7ChOQh3IlRdwzNXXvafOKfWDkmSzpkx+bg==", null, false, "616d3d89-b893-4555-adce-5ff11a095e22", false, "Krystian" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "e59db1dd-4526-4514-9301-e82bae18cf59", "1b6a6a2c-2f62-4dd1-bc3a-e78b8d4d5211" },
                    { "89264d3d-c492-4547-8720-04ba07d8464d", "f86d15a9-4021-46de-8ded-db0271a1fc8a" }
                });
        }
    }
}
