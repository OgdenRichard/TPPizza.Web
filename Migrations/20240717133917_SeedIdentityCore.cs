using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPPizza.Web.Migrations
{
    /// <inheritdoc />
    public partial class SeedIdentityCore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "341743f0-asd2-42de-afbf-59kmkkmk72cf6", null, "SuperAdmin", "SUPERADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "02174cf0-9412-4cfe-afbf-59f706d72cf6", 0, "368d46d6-b1ff-4273-83ad-40869de1335a", "mael@3bs.fr", true, false, null, "MAEL@3BS.FR", "ADMIN", "AQAAAAIAAYagAAAAEOXBEZPdVNBrWb7MV3t6dkaNho+xrxKAskXqVV2Okpqe68RUeInOlGL3L6mP+WybVA==", null, false, "eb07b622-00d2-4809-9572-c09c350bfbf8", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "341743f0-asd2-42de-afbf-59kmkkmk72cf6", "02174cf0-9412-4cfe-afbf-59f706d72cf6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "341743f0-asd2-42de-afbf-59kmkkmk72cf6", "02174cf0-9412-4cfe-afbf-59f706d72cf6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "341743f0-asd2-42de-afbf-59kmkkmk72cf6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6");

           
        }
    }
}
