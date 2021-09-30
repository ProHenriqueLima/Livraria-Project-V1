namespace Livraria.WebAPI.Models
{
    public class Cliente
    {
        public Cliente() { }

        public Cliente(int id, string nomeCliente, string cidadeCliente, string enderecoCliente, string emailCliente, int idCliente)
        {
            Id = id;
            NomeCliente = nomeCliente;
            CidadeCliente = cidadeCliente;
            EnderecoCliente = enderecoCliente;
            EmailCliente = emailCliente;
            IdCliente = idCliente;
        }

        public int Id { get; set; }

        public string NomeCliente { get; set; }

        public string CidadeCliente { get; set; }

        public string EnderecoCliente { get; set; }

        public string EmailCliente { get; set; }
        public int IdCliente { get; set; }
    }
}