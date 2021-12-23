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
    public class PercDescController : Controller
    {
        private readonly IPercDescService _percdescService;
        public PercDescController(IPercDescService percdescservice)
        {
            _percdescService = percdescservice;
        }

        [HttpGet]
        public async Task<IEnumerable<PercDesconto>> GetAllAsync()
        {
            var percdesc = await _percdescService.ListAsync();

            return percdesc;
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<PercDesconto>> GetPercDesconto(int id)
        {
            var percdesc = await _percdescService.FindByIdAsync(id);

            if (percdesc == null)
            {
                return NotFound();
            }

            return percdesc;
        }
        [HttpGet("GetByUrlSlag/{urlSlag}")]
        public async Task<IEnumerable<PercDesconto>> GetByUrlSlag(string urlSlag)
        {
            var percdesc = await _percdescService.ListNomes(urlSlag);

            return percdesc;
        }

        public async Task AddAsync(PercDesconto percdesc)
        {
            await _percdescService.AddAsync(percdesc);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PercDesconto perdesc)
        {
            if (id != perdesc.ID)
            {
                return BadRequest();
            }

            try
            {
                _percdescService.Update(perdesc);
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<PercDesconto>> PostPercDesc(PercDesconto percdesc)
        {

            _percdescService.AddAsync(percdesc);

            return CreatedAtAction("Getpercdesc", new { id = percdesc.ID }, percdesc);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePercDesconto(int id)
        {
            var percdesc = await _percdescService.FindByIdAsync(id);
            if (percdesc == null)
            {
                return NotFound();
            }

            _percdescService.Remove(percdesc);


            return NoContent();
        }
    }
}
