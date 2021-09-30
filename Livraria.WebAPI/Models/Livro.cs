namespace Livraria.WebAPI.Models
{
    public class Livro
    {
        public Livro(){}

        public Livro(int id, string nomeLivro, int idEditora)
        {
            Id = id;
            NomeLivro = nomeLivro;
            IdEditora = idEditora;
        }

        public int Id{ get; set; }
        public string NomeLivro { get; set; }
        public int IdEditora { get; set; }
    }
}