using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyBasket.Api.Presistence.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDisabledColumnToUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "019d914e-f324-7a2c-9459-d1c6af7d44e9",
                columns: new[] { "IsDisabled", "PasswordHash" },
                values: new object[] { false, "AQAAAAIAAYagAAAAEEnJIU3S8VQCHHYLJ8y0bTC+fLKqpWW2peCurfCTn92eJldRD8DoJWoUlyrrT7VOKA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "019d914e-f324-7a2c-9459-d1c6af7d44e9",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEEb/gEH0giDmiEYTrQQEEqsH4IvYvJLFNCwVn+zhyB1JlJq5OWph6z76B6B93tzQkw==");
        }
    }
}
