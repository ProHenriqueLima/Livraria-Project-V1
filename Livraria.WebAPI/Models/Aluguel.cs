using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.WebAPI.Models
{
    public class Aluguel
    {

        public Aluguel(int id, int clienteId, int livroId)
        {
            this.Id = id;
            this.ClienteId = clienteId;
            this.LivroId = livroId;

        }
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int LivroId { get; set; }
        public Livro Livro { get; set; }
    }
}
