using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workshop.Infra.Migrations
{
    /// <inheritdoc />
    public partial class WorkAndWorkInOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Work_Orders_OrderId",
                table: "Work");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Work");

            migrationBuilder.DropColumn(
                name: "TimeToFinish",
                table: "Work");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Work",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Work_OrderId",
                table: "Work",
                newName: "IX_Work_OwnerId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Work",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Work",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "WorkInOrder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    DateInit = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateFinish = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    WorkId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkInOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkInOrder_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkInOrder_Work_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Work",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkInOrder_OrderId",
                table: "WorkInOrder",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkInOrder_WorkId",
                table: "WorkInOrder",
                column: "WorkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Work_Companies_OwnerId",
                table: "Work",
                column: "OwnerId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Work_Companies_OwnerId",
                table: "Work");

            migrationBuilder.DropTable(
                name: "WorkInOrder");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Work");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Work");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Work",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Work_OwnerId",
                table: "Work",
                newName: "IX_Work_OrderId");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Work",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "TimeToFinish",
                table: "Work",
                type: "time without time zone",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddForeignKey(
                name: "FK_Work_Orders_OrderId",
                table: "Work",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
