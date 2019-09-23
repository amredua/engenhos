using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Engenhos.AzureDevOps.Infraestrutura.Migrations
{
    public partial class alteracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataCriacao",
                table: "WorkItem",
                newName: "DataCriacaoWorkItem");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "WorkItem",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IdWorkItem",
                table: "WorkItem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WorkItem_IdWorkItem",
                table: "WorkItem",
                column: "IdWorkItem",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WorkItem_IdWorkItem",
                table: "WorkItem");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "WorkItem");

            migrationBuilder.DropColumn(
                name: "IdWorkItem",
                table: "WorkItem");

            migrationBuilder.RenameColumn(
                name: "DataCriacaoWorkItem",
                table: "WorkItem",
                newName: "DataCriacao");
        }
    }
}
