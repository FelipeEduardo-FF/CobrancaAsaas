using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cobrancas.Migrations
{
    /// <inheritdoc />
    public partial class addidcustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdGatewayPayment",
                table: "Costumers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "95433ac4-2fe9-468f-b80d-b05ec3724d1d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "17acae90-b7fd-412a-bb2d-0c8afecd30d5", "AQAAAAIAAYagAAAAEFLMkqJ9PMHOMQyWx3Y33bHglOn6US+Zfsks4Ow+aL4Ivi5JFNeG6kWFwz1mq7KUkw==", "a972742a-f4e1-4880-a657-f918451828f6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdGatewayPayment",
                table: "Costumers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "95433ac4-2fe9-468f-b80d-b05ec3724d1d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eb5b10d9-857c-4bc6-b40f-ded5497a2bbf", "AQAAAAIAAYagAAAAEOTzAPHBOVKWwpNuEIBjgRBHAP+58suM37dS4Vg7GayMoinUErNjNwsNw1UOC7AUvA==", "96c85bd6-b147-4805-8ca3-5c58f8ad5f79" });
        }
    }
}
