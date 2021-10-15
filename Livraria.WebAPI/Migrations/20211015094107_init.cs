using Microsoft.EntityFrameworkCore.Migrations;

namespace Livraria.WebAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeCliente = table.Column<string>(nullable: true),
                    CidadeCliente = table.Column<string>(nullable: true),
                    EnderecoCliente = table.Column<string>(nullable: true),
                    EmailCliente = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Editoras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NameEditora = table.Column<string>(nullable: true),
                    CidadeEditora = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editoras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeLivro = table.Column<string>(nullable: true),
                    LancamentoLivro = table.Column<string>(nullable: true),
                    AutorLivro = table.Column<string>(nullable: true),
                    Quantidade = table.Column<int>(nullable: false),
                    EditoraID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Livros_Editoras_EditoraID",
                        column: x => x.EditoraID,
                        principalTable: "Editoras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alugueis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(nullable: false),
                    LivroId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alugueis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alugueis_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alugueis_Livros_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "CidadeCliente", "EmailCliente", "EnderecoCliente", "NomeCliente" },
                values: new object[] { 1, "Fortaleza", "prohenriquelima@gmail.com", "Rua 27", "Marta" });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "CidadeCliente", "EmailCliente", "EnderecoCliente", "NomeCliente" },
                values: new object[] { 2, "Bahia", "prohenriquelima@gmail.com", "Rua 21", "Paula" });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "CidadeCliente", "EmailCliente", "EnderecoCliente", "NomeCliente" },
                values: new object[] { 3, "SaoPaulo", "prohenriquelima@gmail.com", "Rua 22", "Laura" });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "CidadeCliente", "EmailCliente", "EnderecoCliente", "NomeCliente" },
                values: new object[] { 4, "Juazeiro", "prohenriquelima@gmail.com", "Rua 23", "Luiza" });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "CidadeCliente", "EmailCliente", "EnderecoCliente", "NomeCliente" },
                values: new object[] { 5, "Fortim", "prohenriquelima@gmail.com", "Rua 24", "Lucas" });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "CidadeCliente", "EmailCliente", "EnderecoCliente", "NomeCliente" },
                values: new object[] { 6, "Aracati", "prohenriquelima@gmail.com", "Rua 25", "Pedro" });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "CidadeCliente", "EmailCliente", "EnderecoCliente", "NomeCliente" },
                values: new object[] { 7, "Quixaba", "prohenriquelima@gmail.com", "Rua 26", "Paulo" });

            migrationBuilder.InsertData(
                table: "Editoras",
                columns: new[] { "Id", "CidadeEditora", "NameEditora" },
                values: new object[] { 1, "Fortaleza", "Viva" });

            migrationBuilder.InsertData(
                table: "Editoras",
                columns: new[] { "Id", "CidadeEditora", "NameEditora" },
                values: new object[] { 2, "Fortaleza", "Tim" });

            migrationBuilder.InsertData(
                table: "Editoras",
                columns: new[] { "Id", "CidadeEditora", "NameEditora" },
                values: new object[] { 3, "Fortaleza", "Dominas" });

            migrationBuilder.InsertData(
                table: "Editoras",
                columns: new[] { "Id", "CidadeEditora", "NameEditora" },
                values: new object[] { 4, "Fortaleza", "Cacau" });

            migrationBuilder.InsertData(
                table: "Editoras",
                columns: new[] { "Id", "CidadeEditora", "NameEditora" },
                values: new object[] { 5, "Fortaleza", "Prog" });

            migrationBuilder.InsertData(
                table: "Livros",
                columns: new[] { "Id", "AutorLivro", "EditoraID", "LancamentoLivro", "NomeLivro", "Quantidade" },
                values: new object[] { 1, "João Sthepfan", 2, "04/2005", "Harry", 100 });

            migrationBuilder.InsertData(
                table: "Livros",
                columns: new[] { "Id", "AutorLivro", "EditoraID", "LancamentoLivro", "NomeLivro", "Quantidade" },
                values: new object[] { 2, "Jo Sthepf", 2, "05/2010", "Potter", 80 });

            migrationBuilder.InsertData(
                table: "Livros",
                columns: new[] { "Id", "AutorLivro", "EditoraID", "LancamentoLivro", "NomeLivro", "Quantidade" },
                values: new object[] { 3, "Marcos fan", 2, "06/2003", "RosiVelw", 20 });

            migrationBuilder.InsertData(
                table: "Livros",
                columns: new[] { "Id", "AutorLivro", "EditoraID", "LancamentoLivro", "NomeLivro", "Quantidade" },
                values: new object[] { 4, "JoJo epn", 2, "07/2005", "Biblia", 70 });

            migrationBuilder.InsertData(
                table: "Livros",
                columns: new[] { "Id", "AutorLivro", "EditoraID", "LancamentoLivro", "NomeLivro", "Quantidade" },
                values: new object[] { 5, "Henrique Show", 2, "08/2008", "Thomas", 60 });

            migrationBuilder.InsertData(
                table: "Alugueis",
                columns: new[] { "Id", "ClienteId", "LivroId" },
                values: new object[] { 1, 1, 2 });

            migrationBuilder.InsertData(
                table: "Alugueis",
                columns: new[] { "Id", "ClienteId", "LivroId" },
                values: new object[] { 2, 4, 2 });

            migrationBuilder.InsertData(
                table: "Alugueis",
                columns: new[] { "Id", "ClienteId", "LivroId" },
                values: new object[] { 3, 1, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Alugueis_ClienteId",
                table: "Alugueis",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Alugueis_LivroId",
                table: "Alugueis",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_EditoraID",
                table: "Livros",
                column: "EditoraID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alugueis");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Livros");

            migrationBuilder.DropTable(
                name: "Editoras");
        }
    }
}
