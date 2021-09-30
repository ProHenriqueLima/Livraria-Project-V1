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
                    EmailCliente = table.Column<string>(nullable: true),
                    IdCliente = table.Column<int>(nullable: false)
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
                    CidadeEditora = table.Column<string>(nullable: true),
                    IdEditora = table.Column<int>(nullable: false)
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
                    IdEditora = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "CidadeCliente", "EmailCliente", "EnderecoCliente", "IdCliente", "NomeCliente" },
                values: new object[] { 1, "Fortaleza", "prohenriquelima@gmail.com", "Rua 27", 0, "Marta" });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "CidadeCliente", "EmailCliente", "EnderecoCliente", "IdCliente", "NomeCliente" },
                values: new object[] { 2, "Bahia", "prohenriquelima@gmail.com", "Rua 21", 0, "Paula" });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "CidadeCliente", "EmailCliente", "EnderecoCliente", "IdCliente", "NomeCliente" },
                values: new object[] { 3, "SaoPaulo", "prohenriquelima@gmail.com", "Rua 22", 0, "Laura" });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "CidadeCliente", "EmailCliente", "EnderecoCliente", "IdCliente", "NomeCliente" },
                values: new object[] { 4, "Juazeiro", "prohenriquelima@gmail.com", "Rua 23", 0, "Luiza" });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "CidadeCliente", "EmailCliente", "EnderecoCliente", "IdCliente", "NomeCliente" },
                values: new object[] { 5, "Fortim", "prohenriquelima@gmail.com", "Rua 24", 0, "Lucas" });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "CidadeCliente", "EmailCliente", "EnderecoCliente", "IdCliente", "NomeCliente" },
                values: new object[] { 6, "Aracati", "prohenriquelima@gmail.com", "Rua 25", 0, "Pedro" });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "CidadeCliente", "EmailCliente", "EnderecoCliente", "IdCliente", "NomeCliente" },
                values: new object[] { 7, "Quixaba", "prohenriquelima@gmail.com", "Rua 26", 0, "Paulo" });

            migrationBuilder.InsertData(
                table: "Editoras",
                columns: new[] { "Id", "CidadeEditora", "IdEditora", "NameEditora" },
                values: new object[] { 5, "Fortaleza", 0, "Prog" });

            migrationBuilder.InsertData(
                table: "Editoras",
                columns: new[] { "Id", "CidadeEditora", "IdEditora", "NameEditora" },
                values: new object[] { 4, "Fortaleza", 0, "Cacau" });

            migrationBuilder.InsertData(
                table: "Editoras",
                columns: new[] { "Id", "CidadeEditora", "IdEditora", "NameEditora" },
                values: new object[] { 2, "Fortaleza", 0, "Tim" });

            migrationBuilder.InsertData(
                table: "Editoras",
                columns: new[] { "Id", "CidadeEditora", "IdEditora", "NameEditora" },
                values: new object[] { 1, "Fortaleza", 0, "Viva" });

            migrationBuilder.InsertData(
                table: "Editoras",
                columns: new[] { "Id", "CidadeEditora", "IdEditora", "NameEditora" },
                values: new object[] { 3, "Fortaleza", 0, "Dominas" });

            migrationBuilder.InsertData(
                table: "Livros",
                columns: new[] { "Id", "IdEditora", "NomeLivro" },
                values: new object[] { 4, 0, "Biblia" });

            migrationBuilder.InsertData(
                table: "Livros",
                columns: new[] { "Id", "IdEditora", "NomeLivro" },
                values: new object[] { 1, 0, "Harry" });

            migrationBuilder.InsertData(
                table: "Livros",
                columns: new[] { "Id", "IdEditora", "NomeLivro" },
                values: new object[] { 2, 0, "Potter" });

            migrationBuilder.InsertData(
                table: "Livros",
                columns: new[] { "Id", "IdEditora", "NomeLivro" },
                values: new object[] { 3, 0, "RosiVelw" });

            migrationBuilder.InsertData(
                table: "Livros",
                columns: new[] { "Id", "IdEditora", "NomeLivro" },
                values: new object[] { 5, 0, "Thomas" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Editoras");

            migrationBuilder.DropTable(
                name: "Livros");
        }
    }
}
