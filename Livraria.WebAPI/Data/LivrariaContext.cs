using Livraria.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Livraria.WebAPI.Data
{
    public class LivrariaContext : DbContext
    {
        public LivrariaContext(DbContextOptions<LivrariaContext> options) : base(options){}
        public DbSet<Editora> Editoras { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Livro> Livros { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Livro>()
            .HasData(new List<Livro>(){
                    new Livro(1, "Harry", 0),
                    new Livro(2, "Potter", 0),
                    new Livro(3, "RosiVelw", 0),
                    new Livro(4, "Biblia", 0),
                    new Livro(5, "Thomas", 0),
            });

            builder.Entity<Editora>()
                .HasData(new List<Editora>(){
                    new Editora(1, "Viva", "Fortaleza", 0),
                    new Editora(2, "Tim", "Fortaleza", 0),
                    new Editora(3, "Dominas", "Fortaleza", 0),
                    new Editora(4, "Cacau", "Fortaleza", 0),
                    new Editora(5, "Prog", "Fortaleza", 0)
                });

            builder.Entity<Cliente>()
                .HasData(new List<Cliente>(){
                    new Cliente(1, "Marta", "Fortaleza", "Rua 27", "prohenriquelima@gmail.com", 0),
                    new Cliente(2, "Paula", "Bahia", "Rua 21", "prohenriquelima@gmail.com", 0),
                    new Cliente(3, "Laura", "SaoPaulo", "Rua 22", "prohenriquelima@gmail.com", 0),
                    new Cliente(4, "Luiza", "Juazeiro", "Rua 23", "prohenriquelima@gmail.com", 0),
                    new Cliente(5, "Lucas", "Fortim", "Rua 24", "prohenriquelima@gmail.com", 0),
                    new Cliente(6, "Pedro", "Aracati", "Rua 25", "prohenriquelima@gmail.com", 0),
                    new Cliente(7, "Paulo", "Quixaba", "Rua 26", "prohenriquelima@gmail.com", 0)
                });


        }

    }
}