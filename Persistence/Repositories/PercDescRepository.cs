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
    public class PercDescRepository : BaseRepository, IPercDescRepository
    {
        public PercDescRepository(AppDbContext context) : base(context)
        { }

        public async Task AddAsync(PercDesconto percDescontos)
        {
            using (var ctx = new AppDbContext())
            {

                ctx.percDescontos.AddAsync(percDescontos);
                ctx.SaveChanges();
            }

            await _context.percDescontos.ToListAsync();
        }

        public async Task<PercDesconto> FindByIdAsync(int id)
        {
            return await _context.percDescontos.FindAsync(id);
        }

        public async Task<IEnumerable<PercDesconto>> ListAsync()
        {
            return await _context.percDescontos.ToListAsync();
        }

        public async Task<IEnumerable<PercDesconto>> ListNomes(string name)
        {
            return await _context.percDescontos.ToListAsync();
        }

        public async Task<IEnumerable<PercDesconto>> ListNomesID(int Id)
        {
            return await _context.percDescontos.ToListAsync();
        }

        public void Remove(PercDesconto percDescontos)
        {
            _context.percDescontos.Remove(percDescontos);
            _context.SaveChanges();
        }

        public void Update(PercDesconto percDescontos)
        {
            using (var ctx = new AppDbContext())
            {
                ctx.percDescontos.Update(percDescontos);
                ctx.SaveChanges();
            }
        }
    }
}
