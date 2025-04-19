using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RemindApp.Data.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTodoListV4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "TodoList");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "TodoList",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 10);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false),
                    Icon = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTS = table.Column<double>(type: "double precision", nullable: false),
                    LastModificationTimeTs = table.Column<double>(type: "double precision", nullable: true),
                    DeletedDateTS = table.Column<double>(type: "double precision", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModificationUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "TodoList");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "TodoList",
                type: "integer",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 10);
        }
    }
}
