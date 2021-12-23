using ApiVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiVendas.Domain.Services
{
    public interface IUsuarioServices
    {
        Task<IEnumerable<Usuario>> ListFuncionarios();
        Task<IEnumerable<Usuario>> ListFuncionariosID(int Id);
        Task AddAsync(Usuario usuarios);

        Task<IEnumerable<Usuario>> ListNomes(string name);

        void Update(Usuario usuarios);
        void Remove(Usuario usuarios);
        //Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
    }
}
