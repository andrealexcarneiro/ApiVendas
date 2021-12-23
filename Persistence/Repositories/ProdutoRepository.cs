using ApiVendas.Models;
using ApiVendas.Persistence.Context;
using ApiVendas.Persistence.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVendas.Persistence.Repositories
{
    public class ProdutoRepository : BaseRepository, IProdutoRepository
    {
        public ProdutoRepository(AppDbContext context) : base(context)
        { }

        public async Task AddAsync(Produto produtos)
        {
            using (var ctx = new AppDbContext())
            {

                ctx.produtos.AddAsync(produtos);
                ctx.SaveChanges();
            }

            await _context.produtos.ToListAsync();
        }

        public async Task<Produto> FindByIdAsync(int id)
        {
            return await _context.produtos.FindAsync(id);
        }

        public async Task<IEnumerable<Produto>> ListAsync()
        {
            return await _context.produtos.ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ListNomes(string name)
        {
            using (var contexto = new AppDbContext())
            {
                var resultado = contexto.produtos
                                         .Where(m => EF.Functions.Like(m.Descricao, "%" + name + "%"))
                                         .ToList();

                return (IEnumerable<Produto>)resultado;
            }
        }

        public async Task<IEnumerable<Produto>> ListNomesID(int Id)
        {
            return await _context.produtos .ToListAsync();
        }

        public void Remove(Produto produtos)
        {
            _context.produtos.Remove(produtos);
            _context.SaveChanges();
        }

        public void Update(Produto produtos)
        {
            using (var ctx = new AppDbContext())
            {
                ctx.produtos.Update(produtos);
                ctx.SaveChanges();
            }
        }
    }
}
