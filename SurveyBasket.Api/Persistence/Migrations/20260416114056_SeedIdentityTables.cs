using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SurveyBasket.Api.Presistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedIdentityTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDefault", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "019d91a5-ed7b-7704-8166-f6234ddd7fb5", "019d91a7-b691-7a1a-9c7f-dcbcb78d5caa", false, false, "Admin", "ADMIN" },
                    { "019d91a6-82df-7496-ad26-ceccbbc9363e", "019d91a7-cd12-7e4e-bed8-f5b8e041e969", true, false, "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "019d914e-f324-7a2c-9459-d1c6af7d44e9", 0, "019d9153-3d6e-7454-9765-f23bd6200d25", "admin@survey-basket.com", true, "Survey Basket", "Admin", false, null, "ADMIN@SURVEY-BASKET.COM", "ADMIN@SURVEY-BASKET.COM", "AQAAAAIAAYagAAAAEEb/gEH0giDmiEYTrQQEEqsH4IvYvJLFNCwVn+zhyB1JlJq5OWph6z76B6B93tzQkw==", null, false, "019d91531b707ffe926b2bed4382cddf", false, "admin@survey-basket.com" });

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "permissions", "polls:read", "019d91a5-ed7b-7704-8166-f6234ddd7fb5" },
                    { 2, "permissions", "polls:add", "019d91a5-ed7b-7704-8166-f6234ddd7fb5" },
                    { 3, "permissions", "polls:update", "019d91a5-ed7b-7704-8166-f6234ddd7fb5" },
                    { 4, "permissions", "polls:delete", "019d91a5-ed7b-7704-8166-f6234ddd7fb5" },
                    { 5, "permissions", "questions:read", "019d91a5-ed7b-7704-8166-f6234ddd7fb5" },
                    { 6, "permissions", "questions:add", "019d91a5-ed7b-7704-8166-f6234ddd7fb5" },
                    { 7, "permissions", "questions:update", "019d91a5-ed7b-7704-8166-f6234ddd7fb5" },
                    { 8, "permissions", "users:read", "019d91a5-ed7b-7704-8166-f6234ddd7fb5" },
                    { 9, "permissions", "users:add", "019d91a5-ed7b-7704-8166-f6234ddd7fb5" },
                    { 10, "permissions", "users:update", "019d91a5-ed7b-7704-8166-f6234ddd7fb5" },
                    { 11, "permissions", "roles:read", "019d91a5-ed7b-7704-8166-f6234ddd7fb5" },
                    { 12, "permissions", "roles:add", "019d91a5-ed7b-7704-8166-f6234ddd7fb5" },
                    { 13, "permissions", "roles:update", "019d91a5-ed7b-7704-8166-f6234ddd7fb5" },
                    { 14, "permissions", "results:read", "019d91a5-ed7b-7704-8166-f6234ddd7fb5" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "019d91a5-ed7b-7704-8166-f6234ddd7fb5", "019d914e-f324-7a2c-9459-d1c6af7d44e9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "019d91a6-82df-7496-ad26-ceccbbc9363e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "019d91a5-ed7b-7704-8166-f6234ddd7fb5", "019d914e-f324-7a2c-9459-d1c6af7d44e9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "019d91a5-ed7b-7704-8166-f6234ddd7fb5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "019d914e-f324-7a2c-9459-d1c6af7d44e9");
        }
    }
}
