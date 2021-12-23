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
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public Task AddAsync(Produto produtos)
        {
            return _produtoRepository.AddAsync(produtos);
        }

        public async Task<Produto> FindByIdAsync(int id)
        {
            return await _produtoRepository.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Produto>> ListAsync()
        {
            return await _produtoRepository.ListAsync();
        }

        public async Task <IEnumerable<Produto>> ListNomes(string name)
        {
            return await _produtoRepository.ListNomes(name);
        }

        public async Task<IEnumerable<Produto>> ListNomesID(int Id)
        {
            return await _produtoRepository.ListNomesID(Id);
        }

        public void Remove(Produto produtos)
        {
            _produtoRepository.Remove(produtos);
        }

        public void Update(Produto produtos)
        {
            _produtoRepository.Update(produtos);
        }
    }
}
