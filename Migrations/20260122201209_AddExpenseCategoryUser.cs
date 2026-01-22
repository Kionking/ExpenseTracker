using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ExpenseTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddExpenseCategoryUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "TestEntities");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "TestEntities",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "TestEntities",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TestEntities",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TestEntities",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CategoryEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEntity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestEntities_CategoryId",
                table: "TestEntities",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TestEntities_UserId",
                table: "TestEntities",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestEntities_CategoryEntity_CategoryId",
                table: "TestEntities",
                column: "CategoryId",
                principalTable: "CategoryEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestEntities_UserEntity_UserId",
                table: "TestEntities",
                column: "UserId",
                principalTable: "UserEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestEntities_CategoryEntity_CategoryId",
                table: "TestEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_TestEntities_UserEntity_UserId",
                table: "TestEntities");

            migrationBuilder.DropTable(
                name: "CategoryEntity");

            migrationBuilder.DropTable(
                name: "UserEntity");

            migrationBuilder.DropIndex(
                name: "IX_TestEntities_CategoryId",
                table: "TestEntities");

            migrationBuilder.DropIndex(
                name: "IX_TestEntities_UserId",
                table: "TestEntities");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "TestEntities");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "TestEntities");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "TestEntities");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TestEntities");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TestEntities",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
