using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RemindApp.Data.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTodoListv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "LastModificationUserId",
                table: "TodoList",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 28)
                .OldAnnotation("Relational:ColumnOrder", 27);

            migrationBuilder.AlterColumn<double>(
                name: "LastModificationTimeTs",
                table: "TodoList",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 22)
                .OldAnnotation("Relational:ColumnOrder", 21);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "TodoList",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 27)
                .OldAnnotation("Relational:ColumnOrder", 26);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "TodoList",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean")
                .Annotation("Relational:ColumnOrder", 24)
                .OldAnnotation("Relational:ColumnOrder", 23);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionTime",
                table: "TodoList",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 29)
                .OldAnnotation("Relational:ColumnOrder", 28);

            migrationBuilder.AlterColumn<Guid>(
                name: "DeletedUserId",
                table: "TodoList",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 30)
                .OldAnnotation("Relational:ColumnOrder", 29);

            migrationBuilder.AlterColumn<double>(
                name: "DeletedDateTS",
                table: "TodoList",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 23)
                .OldAnnotation("Relational:ColumnOrder", 22);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorUserId",
                table: "TodoList",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Relational:ColumnOrder", 26)
                .OldAnnotation("Relational:ColumnOrder", 25);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "TodoList",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .Annotation("Relational:ColumnOrder", 25)
                .OldAnnotation("Relational:ColumnOrder", 24);

            migrationBuilder.AlterColumn<double>(
                name: "CreatedDateTS",
                table: "TodoList",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision")
                .Annotation("Relational:ColumnOrder", 21)
                .OldAnnotation("Relational:ColumnOrder", 20);

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "TodoList",
                type: "integer",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 10);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "TodoList");

            migrationBuilder.AlterColumn<Guid>(
                name: "LastModificationUserId",
                table: "TodoList",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 27)
                .OldAnnotation("Relational:ColumnOrder", 28);

            migrationBuilder.AlterColumn<double>(
                name: "LastModificationTimeTs",
                table: "TodoList",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 21)
                .OldAnnotation("Relational:ColumnOrder", 22);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "TodoList",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 26)
                .OldAnnotation("Relational:ColumnOrder", 27);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "TodoList",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean")
                .Annotation("Relational:ColumnOrder", 23)
                .OldAnnotation("Relational:ColumnOrder", 24);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionTime",
                table: "TodoList",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 28)
                .OldAnnotation("Relational:ColumnOrder", 29);

            migrationBuilder.AlterColumn<Guid>(
                name: "DeletedUserId",
                table: "TodoList",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 29)
                .OldAnnotation("Relational:ColumnOrder", 30);

            migrationBuilder.AlterColumn<double>(
                name: "DeletedDateTS",
                table: "TodoList",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 22)
                .OldAnnotation("Relational:ColumnOrder", 23);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorUserId",
                table: "TodoList",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Relational:ColumnOrder", 25)
                .OldAnnotation("Relational:ColumnOrder", 26);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "TodoList",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .Annotation("Relational:ColumnOrder", 24)
                .OldAnnotation("Relational:ColumnOrder", 25);

            migrationBuilder.AlterColumn<double>(
                name: "CreatedDateTS",
                table: "TodoList",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision")
                .Annotation("Relational:ColumnOrder", 20)
                .OldAnnotation("Relational:ColumnOrder", 21);
        }
    }
}
