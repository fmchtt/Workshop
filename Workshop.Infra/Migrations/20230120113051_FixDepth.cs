using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Workshop.Infra.Migrations
{
    /// <inheritdoc />
    public partial class FixDepth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_UserId",
                table: "Employees");

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

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Name", "ResourceCode" },
                values: new object[,]
                {
                    { new Guid("102f1eb3-aa60-4761-9606-e2382b99e0ad"), "Remover Pedidos", "order:delete" },
                    { new Guid("20578b79-f52f-4b42-adc1-2c83ee1969f8"), "ALL", "resource:owner" },
                    { new Guid("2e0edd7c-f17b-4102-b34a-b4451129dfc8"), "Criar e Gerenciar Empregado", "employee:create" },
                    { new Guid("530eda6e-bf5a-4c24-9564-08d03f1f517f"), "Remover Empregado", "employee:delete" },
                    { new Guid("78398c16-7298-4dbe-9dcf-3c9352c7039b"), "Deletar Produto", "product:delete" },
                    { new Guid("81da03c4-8b01-416f-8420-e237c3a04a4c"), "Criar e Gerenciar Cargos", "role:create" },
                    { new Guid("9cca7e6b-b33c-4f3d-b34f-fd6743ea9135"), "Criar e Gerenciar Pedidos", "order:create" },
                    { new Guid("a36938e4-039c-48bb-ae7f-fba5cc7d9bdb"), "Deletar Cargos", "role:delete" },
                    { new Guid("e369ccf9-43ad-4a81-9357-2d1e58e1547b"), "Criar e Gerenciar Produto", "product:create" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_UserId",
                table: "Employees");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("102f1eb3-aa60-4761-9606-e2382b99e0ad"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("20578b79-f52f-4b42-adc1-2c83ee1969f8"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("2e0edd7c-f17b-4102-b34a-b4451129dfc8"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("530eda6e-bf5a-4c24-9564-08d03f1f517f"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("78398c16-7298-4dbe-9dcf-3c9352c7039b"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("81da03c4-8b01-416f-8420-e237c3a04a4c"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("9cca7e6b-b33c-4f3d-b34f-fd6743ea9135"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("a36938e4-039c-48bb-ae7f-fba5cc7d9bdb"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("e369ccf9-43ad-4a81-9357-2d1e58e1547b"));

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
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId",
                unique: true);
        }
    }
}
