using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiVendas.Models;
using Microsoft.AspNetCore.Authorization;
using ApiVendas.Persistence.Context;
using ApiVendas.Domain.Services;
using ApiVendas.Domain.IServices;

namespace ApiVendas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;
        public ProdutoController(IProdutoService produtoservice)
        {
            _produtoService = produtoservice;
        }

        [HttpGet]
        public async Task<IEnumerable<Produto>> GetAllAsync()
        {
            var produtos = await _produtoService.ListAsync();

            return produtos;
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            var produto = await _produtoService.FindByIdAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }
        [HttpGet("GetByUrlSlag/{urlSlag}")]
        public async Task<IEnumerable<Produto>> GetByUrlSlag(string urlSlag)
        {
            var produto = await _produtoService.ListNomes(urlSlag);

            return produto;
        }

        public async Task AddAsync(Produto produto)
        {
            await _produtoService.AddAsync(produto);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Produto produto)
        {
            if (id != produto.ID)
            {
                return BadRequest();
            }

            try
            {
                _produtoService.Update(produto);
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {

            _produtoService.AddAsync(produto);

            return CreatedAtAction("Getproduto", new { id = produto.ID }, produto);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            var produto = await _produtoService.FindByIdAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            _produtoService.Remove(produto);


            return NoContent();
        }
    }
}
