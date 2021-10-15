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

        Livro[] GetAllLivro( bool includeEditora);
        Livro GetAllLivroByID(int LivroID , bool includeEditora);

        Cliente[] GetAllCliente();
        Cliente GetClienteByID(int ClienteID);

        Aluguel[] GetAllAluguel(bool includeLivro , bool includeCliente);
        Aluguel GetAluguelById(int AluguelID , bool includeLivro , bool includeCliente);

    }
}