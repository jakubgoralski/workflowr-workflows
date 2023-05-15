using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkflowR.Workflows.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSetOn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SetOn",
                schema: "workflows",
                table: "task");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SetOn",
                schema: "workflows",
                table: "task",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
