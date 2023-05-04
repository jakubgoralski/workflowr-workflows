using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkflowR.Workflows.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTaskStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_task_task_TaskStatusId",
                schema: "workflows",
                table: "task");

            migrationBuilder.DropTable(
                name: "taskstatus",
                schema: "workflows");

            migrationBuilder.DropIndex(
                name: "IX_task_TaskStatusId",
                schema: "workflows",
                table: "task");

            migrationBuilder.DropColumn(
                name: "TaskStatusId",
                schema: "workflows",
                table: "task");

            migrationBuilder.AddColumn<DateTime>(
                name: "SetOn",
                schema: "workflows",
                table: "task",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Value",
                schema: "workflows",
                table: "task",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SetOn",
                schema: "workflows",
                table: "task");

            migrationBuilder.DropColumn(
                name: "Value",
                schema: "workflows",
                table: "task");

            migrationBuilder.AddColumn<Guid>(
                name: "TaskStatusId",
                schema: "workflows",
                table: "task",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "taskstatus",
                schema: "workflows",
                columns: table => new
                {
                    SetOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateIndex(
                name: "IX_task_TaskStatusId",
                schema: "workflows",
                table: "task",
                column: "TaskStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_task_task_TaskStatusId",
                schema: "workflows",
                table: "task",
                column: "TaskStatusId",
                principalSchema: "workflows",
                principalTable: "task",
                principalColumn: "Id");
        }
    }
}
