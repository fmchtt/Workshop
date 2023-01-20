using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Workshop.Infra.Migrations
{
    /// <inheritdoc />
    public partial class PermissionSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
