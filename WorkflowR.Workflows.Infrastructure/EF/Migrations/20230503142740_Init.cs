using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkflowR.Workflows.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "workflows");

            migrationBuilder.CreateTable(
                name: "task",
                schema: "workflows",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TaskOwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShouldBeCompletedBefore = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InformManagerAboutProgress = table.Column<bool>(type: "bit", nullable: false),
                    InformUserWhenPreviousTaskIsCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_task", x => x.Id);
                    table.ForeignKey(
                        name: "FK_task_task_TaskStatusId",
                        column: x => x.TaskStatusId,
                        principalSchema: "workflows",
                        principalTable: "task",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "taskstatus",
                schema: "workflows",
                columns: table => new
                {
                    Value = table.Column<int>(type: "int", nullable: false),
                    SetOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateIndex(
                name: "IX_task_TaskStatusId",
                schema: "workflows",
                table: "task",
                column: "TaskStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "task",
                schema: "workflows");

            migrationBuilder.DropTable(
                name: "taskstatus",
                schema: "workflows");
        }
    }
}
