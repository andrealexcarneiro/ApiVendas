using ApiVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVendas.Persistence.Repositories
{
    public interface IUsuarioRepository
    {
        
        Task<IEnumerable<Usuario>> ListFuncionarios();
        Task<IEnumerable<Usuario>> ListFuncionariosID(int id);

        Task<IEnumerable<Usuario>> ListNomes(string name);
        Task AddAsync(Usuario usuario);

        //Task<CaixaCab> FindByIdAsync(int id);

        void Update(Usuario usuario);
      
        void Remove(Usuario usuario);
    }
}
