using ApiVendas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ApiVendas.Persistence.Context;
using ApiVendas.Domain.Services;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiVendas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class tUsuarioController : ControllerBase
    {
        

       
        private readonly IUsuarioServices _UsuarioCabService;
        public tUsuarioController(IUsuarioServices usuarioServices)
        {
            _UsuarioCabService = usuarioServices;
        }

        [HttpGet]
        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            var usuarios = await _UsuarioCabService.ListFuncionarios();
            //var caixaCabs = await _caixaCabService.ListAsync();
            return usuarios;
        }
        //GET: api/tUsuario/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<Usuario>> GetUsuario(int id)
        {
            var usuarios = await _UsuarioCabService.ListFuncionariosID(id);
            //var caixaCabs = await _caixaCabService.FindByIdAsync(id);

            if (usuarios == null)
            {
                return (IEnumerable<Usuario>)NotFound();
            }
            //return (IEnumerable<CaixaCab>)caixaCabs;
            return usuarios;
        }
        [HttpGet("GetByUrlSlag/{urlSlag}")]
        public async Task<IEnumerable<Usuario>> GetByUrlSlag(string urlSlag)
        {
            var usuarios = await _UsuarioCabService.ListNomes(urlSlag);

            return usuarios;
        }
        public async Task AddAsync(Usuario usuario)
        {
            await _UsuarioCabService.AddAsync(usuario);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Usuario usuario)
        {
            
            if (id != usuario.tFuncionario_codigo)
            {
                return BadRequest();
            }

           

            try
            {
                _UsuarioCabService.Update(usuario);
               
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!UsuarioExists(id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                    throw;
                //}
            }

            return NoContent();
        }

        // POST: api/CaixaCab
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            _UsuarioCabService.AddAsync(usuario);

            return CreatedAtAction("GetUsuario", new { id = usuario.tFuncionario_codigo }, usuario);
        }

        // DELETE: api/CaixaCab/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //var caixaCab = await _UsuarioCabService.GetType(id);
            //if (caixaCab == null)
            //{
            //    return NotFound();
            //}

            //_UsuarioCabService.Remove(Usuario);


            return NoContent();
        }

        //private bool UsuarioExists(int id)
        //{
        //    return _UsuarioCabService.ListFuncionariosID..ListFuncionarios.Any(e => e.Id == id);
        //}
    }
}
