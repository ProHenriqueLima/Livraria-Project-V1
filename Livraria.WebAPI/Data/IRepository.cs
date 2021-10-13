using Livraria.WebAPI.Models;

namespace Livraria.WebAPI.Data
{
    public interface IRepository
    {
         void Add<T>(T entity)where T : class;
         void update<T>(T entity)where T : class;
         void delete<T>(T entity)where T : class;
         bool SaveChanges();

         // Editora method

         Editora[] GetAllEditoras();
         Editora GetAllEditoraByID(int EditoraID);

         // Livro method

        Livro[] GetAllLivro();
        Livro GetAllLivroByID(int LivroID);

        Cliente[] GetAllCliente();
        Cliente GetClienteByID(int ClienteID);



    }
}