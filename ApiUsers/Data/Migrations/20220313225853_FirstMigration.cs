using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiUsers.Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "TEXT", maxLength: 100000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "id", "Content", "Title" },
                values: new object[] { 1, "Este es el post 1 con contenido muy divertido.", "Post 1" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "id", "Content", "Title" },
                values: new object[] { 2, "Este es el post 2 con contenido muy divertido.", "Post 2" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "id", "Content", "Title" },
                values: new object[] { 3, "Este es el post 3 con contenido muy divertido.", "Post 3" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "id", "Content", "Title" },
                values: new object[] { 4, "Este es el post 4 con contenido muy divertido.", "Post 4" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "id", "Content", "Title" },
                values: new object[] { 5, "Este es el post 5 con contenido muy divertido.", "Post 5" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "id", "Content", "Title" },
                values: new object[] { 6, "Este es el post 6 con contenido muy divertido.", "Post 6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
