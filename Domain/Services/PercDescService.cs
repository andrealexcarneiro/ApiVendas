using ApiVendas.Domain.IServices;
using ApiVendas.Models;
using ApiVendas.Persistence.IRepositories;
using ApiVendas.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVendas.Domain.Services
{
    public class PercDescService : IPercDescService
    {
        private readonly IPercDescRepository _percdescRepository;

        public PercDescService(IPercDescRepository percdescRepository)
        {
            _percdescRepository = percdescRepository;
        }

        public Task AddAsync(PercDesconto percDescontos)
        {
            return _percdescRepository.AddAsync(percDescontos);
        }

        public async Task<PercDesconto> FindByIdAsync(int id)
        {
            return await _percdescRepository.FindByIdAsync(id);
        }

        public async Task<IEnumerable<PercDesconto>> ListAsync()
        {
            return await _percdescRepository.ListAsync();
        }

        public async Task<IEnumerable<PercDesconto>> ListNomes(string name)
        {
            return await _percdescRepository.ListNomes(name);
        }

        public async Task <IEnumerable<PercDesconto>> ListNomesID(int Id)
        {
            return await _percdescRepository.ListNomesID(Id);
        }

        public void Remove(PercDesconto percDescontos)
        {
            _percdescRepository.Remove(percDescontos);
        }

        public void Update(PercDesconto percDescontos)
        {
            _percdescRepository.Update(percDescontos);
        }
    }
}
