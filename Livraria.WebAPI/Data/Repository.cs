using System.Linq;
using Livraria.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Livraria.WebAPI.Data
{
    public class Repository : IRepository
    {   
        private readonly LivrariaContext context;
        public Repository(LivrariaContext context)
        {
            this.context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            this.context.Add(entity);
        }
        public void update<T>(T entity) where T : class
        {
            this.context.Update(entity);
        }
        public void delete<T>(T entity) where T : class
        {
            this.context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (this.context.SaveChanges() > 0);
        }

        public Editora[] GetAllEditoras()
        {
            IQueryable<Editora> query = this.context.Editoras;

            query = query.AsNoTracking().OrderBy(livro => livro.Id);

            return query.ToArray();
        }

        public Editora GetAllEditoraByID(int EditoraID)
        {
            IQueryable<Editora> query = this.context.Editoras;
            query = query.AsNoTracking()
            .OrderBy(a => a.Id)
            .Where(editora => editora.Id == EditoraID);
            return query.FirstOrDefault();
        }

        public Livro[] GetAllLivro()
        {
           IQueryable<Livro> query = this.context.Livros;

           

            query = query.AsNoTracking().OrderBy(livro => livro.Id);

            return query.ToArray();
        }

        public Livro GetAllLivroByID(int LivroID)
        {
            IQueryable<Livro> query = this.context.Livros;
            query = query.AsNoTracking()
            .OrderBy(livro => livro.Id)
            .Where(livro => livro.Id == LivroID);
            return query.FirstOrDefault();
        }

        public Cliente[] GetAllCliente()
        {
            IQueryable<Cliente> query = this.context.Clientes;

            query = query.AsNoTracking().OrderBy(cliente => cliente.Id);

            return query.ToArray();
        }

        public Cliente GetClienteByID(int ClienteID)
        {
            IQueryable<Cliente> query = this.context.Clientes;
            query = query.AsNoTracking()
            .OrderBy(cliente => cliente.Id)
            .Where(cliente => cliente.Id == ClienteID);
            return query.FirstOrDefault();
        }
    }
}