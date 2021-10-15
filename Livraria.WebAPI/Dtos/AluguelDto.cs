using Livraria.WebAPI.Models;

namespace Livraria.WebAPI.Dtos
{
    public class AluguelDto
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int LivroId { get; set; }
        public Livro Livro { get; set; }
    }
}