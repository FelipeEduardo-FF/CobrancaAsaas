using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cobrancas.Migrations
{
    /// <inheritdoc />
    public partial class idsubscription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Costumers_CostumerId",
                table: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Costumers");

            migrationBuilder.RenameColumn(
                name: "CostumerId",
                table: "Subscriptions",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Subscriptions_CostumerId",
                table: "Subscriptions",
                newName: "IX_Subscriptions_CustomerId");

            migrationBuilder.AddColumn<string>(
                name: "IdSubscription",
                table: "Subscriptions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdGatewayPayment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "95433ac4-2fe9-468f-b80d-b05ec3724d1d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af386942-0d22-4932-97ea-ed66d9b840e7", "AQAAAAIAAYagAAAAEBJwMQ7XNVfduy64DmOe4tZi7GJX82ce4jqRozPKjzLyKIIzV4nZT6oXRBpv6tPY8A==", "13cf2380-0d1a-4448-ae9d-b5e436e15989" });

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Customers_CustomerId",
                table: "Subscriptions",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Customers_CustomerId",
                table: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropColumn(
                name: "IdSubscription",
                table: "Subscriptions");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Subscriptions",
                newName: "CostumerId");

            migrationBuilder.RenameIndex(
                name: "IX_Subscriptions_CustomerId",
                table: "Subscriptions",
                newName: "IX_Subscriptions_CostumerId");

            migrationBuilder.CreateTable(
                name: "Costumers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdGatewayPayment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costumers", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "95433ac4-2fe9-468f-b80d-b05ec3724d1d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "17acae90-b7fd-412a-bb2d-0c8afecd30d5", "AQAAAAIAAYagAAAAEFLMkqJ9PMHOMQyWx3Y33bHglOn6US+Zfsks4Ow+aL4Ivi5JFNeG6kWFwz1mq7KUkw==", "a972742a-f4e1-4880-a657-f918451828f6" });

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Costumers_CostumerId",
                table: "Subscriptions",
                column: "CostumerId",
                principalTable: "Costumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
