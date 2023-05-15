using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkflowR.Workflows.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class MakeFieldsNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                schema: "workflows",
                table: "task");

            migrationBuilder.AlterColumn<Guid>(
                name: "TaskOwnerId",
                schema: "workflows",
                table: "task",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ShouldBeCompletedBefore",
                schema: "workflows",
                table: "task",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SetOn",
                schema: "workflows",
                table: "task",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "InformUserWhenPreviousTaskIsCompleted",
                schema: "workflows",
                table: "task",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "InformManagerAboutProgress",
                schema: "workflows",
                table: "task",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "TaskStatus",
                schema: "workflows",
                table: "task",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskStatus",
                schema: "workflows",
                table: "task");

            migrationBuilder.AlterColumn<Guid>(
                name: "TaskOwnerId",
                schema: "workflows",
                table: "task",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ShouldBeCompletedBefore",
                schema: "workflows",
                table: "task",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "SetOn",
                schema: "workflows",
                table: "task",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "InformUserWhenPreviousTaskIsCompleted",
                schema: "workflows",
                table: "task",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "InformManagerAboutProgress",
                schema: "workflows",
                table: "task",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Value",
                schema: "workflows",
                table: "task",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
