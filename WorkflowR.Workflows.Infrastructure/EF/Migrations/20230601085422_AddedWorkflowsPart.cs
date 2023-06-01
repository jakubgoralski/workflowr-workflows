using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkflowR.Workflows.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddedWorkflowsPart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InformUserWhenPreviousTaskIsCompleted",
                schema: "workflows",
                table: "task",
                newName: "InformUserOfNextTaskWhenThisIsCompleted");

            migrationBuilder.AlterColumn<string>(
                name: "TaskName",
                schema: "workflows",
                table: "task",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TaskDescription",
                schema: "workflows",
                table: "task",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "NextTaskId",
                schema: "workflows",
                table: "task",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "WorkflowId",
                schema: "workflows",
                table: "task",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "workflow",
                schema: "workflows",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkflowStatus = table.Column<int>(type: "int", nullable: false),
                    FirstTaskInChain = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workflow", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_task_WorkflowId",
                schema: "workflows",
                table: "task",
                column: "WorkflowId");

            migrationBuilder.AddForeignKey(
                name: "FK_task_workflow_WorkflowId",
                schema: "workflows",
                table: "task",
                column: "WorkflowId",
                principalSchema: "workflows",
                principalTable: "workflow",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_task_workflow_WorkflowId",
                schema: "workflows",
                table: "task");

            migrationBuilder.DropTable(
                name: "workflow",
                schema: "workflows");

            migrationBuilder.DropIndex(
                name: "IX_task_WorkflowId",
                schema: "workflows",
                table: "task");

            migrationBuilder.DropColumn(
                name: "NextTaskId",
                schema: "workflows",
                table: "task");

            migrationBuilder.DropColumn(
                name: "WorkflowId",
                schema: "workflows",
                table: "task");

            migrationBuilder.RenameColumn(
                name: "InformUserOfNextTaskWhenThisIsCompleted",
                schema: "workflows",
                table: "task",
                newName: "InformUserWhenPreviousTaskIsCompleted");

            migrationBuilder.AlterColumn<string>(
                name: "TaskName",
                schema: "workflows",
                table: "task",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TaskDescription",
                schema: "workflows",
                table: "task",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
