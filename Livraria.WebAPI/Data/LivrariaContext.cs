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
        public DbSet<Aluguel> Alugueis { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            
            builder.Entity<Livro>()
            .HasData(new List<Livro>(){
                    new Livro(1, "Harry","04/2005","João Sthepfan", 100,2),
                    new Livro(2, "Potter","05/2010","Jo Sthepf", 80,2),
                    new Livro(3, "RosiVelw","06/2003","Marcos fan", 20,2),
                    new Livro(4, "Biblia","07/2005","JoJo epn", 70,2),
                    new Livro(5, "Thomas","08/2008","Henrique Show", 60,2),
            });


            builder.Entity<Editora>()
                .HasData(new List<Editora>(){
                    new Editora(1, "Viva", "Fortaleza"),
                    new Editora(2, "Tim", "Fortaleza"),
                    new Editora(3, "Dominas", "Fortaleza"),
                    new Editora(4, "Cacau", "Fortaleza"),
                    new Editora(5, "Prog", "Fortaleza")
                });
            
            builder.Entity<Cliente>()
                .HasData(new List<Cliente>(){
                    new Cliente(1, "Marta", "Fortaleza","Rua 27", "prohenriquelima@gmail.com"),
                    new Cliente(2, "Paula", "Bahia", "Rua 21", "prohenriquelima@gmail.com"),
                    new Cliente(3, "Laura", "SaoPaulo", "Rua 22", "prohenriquelima@gmail.com"),
                    new Cliente(4, "Luiza", "Juazeiro", "Rua 23", "prohenriquelima@gmail.com"),
                    new Cliente(5, "Lucas", "Fortim", "Rua 24", "prohenriquelima@gmail.com"),
                    new Cliente(6, "Pedro", "Aracati", "Rua 25", "prohenriquelima@gmail.com"),
                    new Cliente(7, "Paulo", "Quixaba", "Rua 26", "prohenriquelima@gmail.com")
                });
            builder.Entity<Aluguel>()
                .HasData(new List<Aluguel>(){
                    new Aluguel(1,1,2),
                    new Aluguel(2,4,2),
                    new Aluguel(3,1,3),
                });
            


        }

    }
}