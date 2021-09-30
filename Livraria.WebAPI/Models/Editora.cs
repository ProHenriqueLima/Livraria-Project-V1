namespace Livraria.WebAPI.Models
{
    public class Editora
    {
        public Editora() { }

        public Editora(int id, string nameEditora, string cidadeEditora, int idEditora)
        {
            Id = id;
            NameEditora = nameEditora;
            CidadeEditora = cidadeEditora;
            IdEditora = idEditora;
        }

        public int Id { get; set; }
        public string NameEditora { get; set; }
        public string CidadeEditora { get; set; }
        public int IdEditora { get; set; }
    }
}