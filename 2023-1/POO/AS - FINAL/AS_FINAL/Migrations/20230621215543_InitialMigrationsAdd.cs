using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AS_FINAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrationsAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    telefone = table.Column<string>(type: "varchar(50)", nullable: false),
                    documento = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "livros",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    titulo = table.Column<string>(type: "varchar(200)", nullable: false),
                    isbn = table.Column<string>(type: "varchar(50)", nullable: false),
                    usuario_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_livros", x => x.id);
                    table.ForeignKey(
                        name: "FK_Usuario_Empresta_Livros",
                        column: x => x.usuario_id,
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "autores",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    LivroId = table.Column<int>(type: "INTEGER", nullable: false),
                    telefone = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_autores", x => x.id);
                    table.ForeignKey(
                        name: "FK_Livro_Autores",
                        column: x => x.LivroId,
                        principalTable: "livros",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_autores_LivroId",
                table: "autores",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_livros_usuario_id",
                table: "livros",
                column: "usuario_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "autores");

            migrationBuilder.DropTable(
                name: "livros");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
