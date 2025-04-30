using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RemindApp.Data.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddExternalLogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "LastModificationUserId",
                table: "MUsers",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 41)
                .OldAnnotation("Relational:ColumnOrder", 38);

            migrationBuilder.AlterColumn<double>(
                name: "LastModificationTimeTs",
                table: "MUsers",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 35)
                .OldAnnotation("Relational:ColumnOrder", 32);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "MUsers",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 40)
                .OldAnnotation("Relational:ColumnOrder", 37);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "MUsers",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean")
                .Annotation("Relational:ColumnOrder", 37)
                .OldAnnotation("Relational:ColumnOrder", 34);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionTime",
                table: "MUsers",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 42)
                .OldAnnotation("Relational:ColumnOrder", 39);

            migrationBuilder.AlterColumn<Guid>(
                name: "DeletedUserId",
                table: "MUsers",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 43)
                .OldAnnotation("Relational:ColumnOrder", 40);

            migrationBuilder.AlterColumn<double>(
                name: "DeletedDateTS",
                table: "MUsers",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 36)
                .OldAnnotation("Relational:ColumnOrder", 33);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorUserId",
                table: "MUsers",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Relational:ColumnOrder", 39)
                .OldAnnotation("Relational:ColumnOrder", 36);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "MUsers",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .Annotation("Relational:ColumnOrder", 38)
                .OldAnnotation("Relational:ColumnOrder", 35);

            migrationBuilder.AlterColumn<double>(
                name: "CreatedDateTS",
                table: "MUsers",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision")
                .Annotation("Relational:ColumnOrder", 34)
                .OldAnnotation("Relational:ColumnOrder", 31);

            migrationBuilder.AddColumn<string>(
                name: "ExternalLoginProvider",
                table: "MUsers",
                type: "text",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 22);

            migrationBuilder.AddColumn<string>(
                name: "ExternalLoginToken",
                table: "MUsers",
                type: "text",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 23);

            migrationBuilder.AddColumn<bool>(
                name: "IsUseThirdPartyLogin",
                table: "MUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false)
                .Annotation("Relational:ColumnOrder", 21);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExternalLoginProvider",
                table: "MUsers");

            migrationBuilder.DropColumn(
                name: "ExternalLoginToken",
                table: "MUsers");

            migrationBuilder.DropColumn(
                name: "IsUseThirdPartyLogin",
                table: "MUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "LastModificationUserId",
                table: "MUsers",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 38)
                .OldAnnotation("Relational:ColumnOrder", 41);

            migrationBuilder.AlterColumn<double>(
                name: "LastModificationTimeTs",
                table: "MUsers",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 32)
                .OldAnnotation("Relational:ColumnOrder", 35);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "MUsers",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 37)
                .OldAnnotation("Relational:ColumnOrder", 40);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "MUsers",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean")
                .Annotation("Relational:ColumnOrder", 34)
                .OldAnnotation("Relational:ColumnOrder", 37);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionTime",
                table: "MUsers",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 39)
                .OldAnnotation("Relational:ColumnOrder", 42);

            migrationBuilder.AlterColumn<Guid>(
                name: "DeletedUserId",
                table: "MUsers",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 40)
                .OldAnnotation("Relational:ColumnOrder", 43);

            migrationBuilder.AlterColumn<double>(
                name: "DeletedDateTS",
                table: "MUsers",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 33)
                .OldAnnotation("Relational:ColumnOrder", 36);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorUserId",
                table: "MUsers",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Relational:ColumnOrder", 36)
                .OldAnnotation("Relational:ColumnOrder", 39);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "MUsers",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .Annotation("Relational:ColumnOrder", 35)
                .OldAnnotation("Relational:ColumnOrder", 38);

            migrationBuilder.AlterColumn<double>(
                name: "CreatedDateTS",
                table: "MUsers",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision")
                .Annotation("Relational:ColumnOrder", 31)
                .OldAnnotation("Relational:ColumnOrder", 34);
        }
    }
}
