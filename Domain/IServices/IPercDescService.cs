using ApiVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVendas.Domain.IServices
{
    public interface IPercDescService
    {
        Task<IEnumerable<PercDesconto>> ListAsync();
        Task<IEnumerable<PercDesconto>> ListNomes(string name);
        Task<IEnumerable<PercDesconto>> ListNomesID(int Id);
        Task AddAsync(PercDesconto percDescontos);
        Task<PercDesconto> FindByIdAsync(int id);
        void Update(PercDesconto percDescontos);
        void Remove(PercDesconto percDescontos);
    }
}
