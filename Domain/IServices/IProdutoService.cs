using ApiVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVendas.Domain.IServices
{
   public  interface IProdutoService
    {
        Task<IEnumerable<Produto>> ListAsync();
        Task<IEnumerable<Produto>> ListNomes(string name);
        Task<IEnumerable<Produto>> ListNomesID(int Id);
        Task AddAsync(Produto produtos);
        Task<Produto> FindByIdAsync(int id);
        void Update(Produto produtos);
        void Remove(Produto produtos);
    }
}
