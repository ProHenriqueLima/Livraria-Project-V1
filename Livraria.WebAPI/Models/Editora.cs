namespace Livraria.WebAPI.Models
{
    public class Editora
    {
        public Editora() { }

        public Editora(int id_editora, string name_editora, string cidade_editora)
        {
            this.id_editora = id_editora;
            this.name_editora = name_editora;
            this.cidade_editora = cidade_editora;

        }
        public int id_editora { get; set; }
        public string name_editora { get; set; }
        public string cidade_editora { get; set; }
    }
}