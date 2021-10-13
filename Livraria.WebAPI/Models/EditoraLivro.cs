namespace Livraria.WebAPI.Models
{
    public class EditoraLivro
    {


        public EditoraLivro(int editoraId, int livroId)
        {
            this.EditoraId = editoraId;
            this.LivroId = livroId;
        }
        public int EditoraId { get; set; }
        public Editora Editora { get; set; }
        public int LivroId { get; set; }
        public Livro Livro { get; set; }
    }
}