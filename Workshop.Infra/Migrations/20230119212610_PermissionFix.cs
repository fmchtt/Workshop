using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Workshop.Infra.Migrations
{
    /// <inheritdoc />
    public partial class PermissionFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Employees_EmployeeId",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_EmployeeId",
                table: "Permissions");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("1bd44bc9-da35-4c89-8ce0-4d566f2ef82a"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("2682564c-6c2f-41c3-b4f7-d0242561a168"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("3d46e73d-1fab-4673-9b18-b463a94b9e50"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("3faebefa-ebbf-4afd-8475-9eee3e78a6b8"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("7fa60b41-7b3b-40e9-b6ae-82d3013f9929"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("aab81c93-32c1-442d-bb8d-b7a857099570"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("b272eced-116a-46cd-a989-48ac007644f3"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("e54f45a3-57b6-46ba-a5ba-6b4b95825a4f"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("f68fa854-4c7d-4094-bdb8-5215f02a6360"));

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Permissions");

            migrationBuilder.CreateTable(
                name: "EmployeePermission",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: false),
                    PermissionsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePermission", x => new { x.EmployeeId, x.PermissionsId });
                    table.ForeignKey(
                        name: "FK_EmployeePermission_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeePermission_Permissions_PermissionsId",
                        column: x => x.PermissionsId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Name", "ResourceCode" },
                values: new object[,]
                {
                    { new Guid("1c65167c-3e1f-433c-b8a3-2494a1715eae"), "Remover Empregado", "employee:delete" },
                    { new Guid("1d7ef335-ef8e-404f-9b85-240b12b80b86"), "Criar e Gerenciar Cargos", "role:create" },
                    { new Guid("48b17bd9-e3f4-4e7a-b966-df96b8a39f2c"), "Deletar Cargos", "role:delete" },
                    { new Guid("656b8766-7368-4535-855d-67922cc580b0"), "Deletar Produto", "product:delete" },
                    { new Guid("66be2efc-4d62-4cc1-8349-560882e0e7d8"), "Criar e Gerenciar Produto", "product:create" },
                    { new Guid("a9de09ec-5742-4c03-912c-f2f5e7bdea4a"), "ALL", "resource:owner" },
                    { new Guid("af8105de-33ab-4b04-be00-e3d3100c10b8"), "Remover Pedidos", "order:delete" },
                    { new Guid("facf7196-a1c5-497d-86bf-bf0bc8a98653"), "Criar e Gerenciar Pedidos", "order:create" },
                    { new Guid("fd43166a-3f83-40a4-b515-940ffb7f43ce"), "Criar e Gerenciar Empregado", "employee:create" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePermission_PermissionsId",
                table: "EmployeePermission",
                column: "PermissionsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeePermission");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("1c65167c-3e1f-433c-b8a3-2494a1715eae"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("1d7ef335-ef8e-404f-9b85-240b12b80b86"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("48b17bd9-e3f4-4e7a-b966-df96b8a39f2c"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("656b8766-7368-4535-855d-67922cc580b0"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("66be2efc-4d62-4cc1-8349-560882e0e7d8"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("a9de09ec-5742-4c03-912c-f2f5e7bdea4a"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("af8105de-33ab-4b04-be00-e3d3100c10b8"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("facf7196-a1c5-497d-86bf-bf0bc8a98653"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("fd43166a-3f83-40a4-b515-940ffb7f43ce"));

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "Permissions",
                type: "uuid",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "EmployeeId", "Name", "ResourceCode" },
                values: new object[,]
                {
                    { new Guid("1bd44bc9-da35-4c89-8ce0-4d566f2ef82a"), null, "Criar e Gerenciar Empregado", "employee:create" },
                    { new Guid("2682564c-6c2f-41c3-b4f7-d0242561a168"), null, "Deletar Produto", "product:delete" },
                    { new Guid("3d46e73d-1fab-4673-9b18-b463a94b9e50"), null, "Criar e Gerenciar Produto", "product:create" },
                    { new Guid("3faebefa-ebbf-4afd-8475-9eee3e78a6b8"), null, "Criar e Gerenciar Pedidos", "order:create" },
                    { new Guid("7fa60b41-7b3b-40e9-b6ae-82d3013f9929"), null, "Criar e Gerenciar Cargos", "role:create" },
                    { new Guid("aab81c93-32c1-442d-bb8d-b7a857099570"), null, "Remover Pedidos", "order:delete" },
                    { new Guid("b272eced-116a-46cd-a989-48ac007644f3"), null, "ALL", "resource:owner" },
                    { new Guid("e54f45a3-57b6-46ba-a5ba-6b4b95825a4f"), null, "Remover Empregado", "employee:delete" },
                    { new Guid("f68fa854-4c7d-4094-bdb8-5215f02a6360"), null, "Deletar Cargos", "role:delete" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_EmployeeId",
                table: "Permissions",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Employees_EmployeeId",
                table: "Permissions",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
