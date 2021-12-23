using ApiVendas.Models;
using ApiVendas.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVendas.Domain.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly IUsuarioRepository _UsuarioRepository;
        public UsuarioServices(IUsuarioRepository usuarioRepository)
        {
            _UsuarioRepository = usuarioRepository;
        }
        public Task AddAsync(Usuario usuarios)
        {
            return _UsuarioRepository.AddAsync(usuarios);
        }

        

        public  async Task<IEnumerable<Usuario>> ListFuncionarios()
        {
            return await _UsuarioRepository.ListFuncionarios();
        }

        public async Task<IEnumerable<Usuario>> ListFuncionariosID(int Id)
        {
            return await _UsuarioRepository.ListFuncionariosID(Id);
        }

        public async Task<IEnumerable<Usuario>> ListNomes(string name)
        {
            return await _UsuarioRepository.ListNomes(name);
        }

        public void Remove(Usuario usuario)
        {
            _UsuarioRepository.Remove(usuario);
        }

        public void Update(Usuario usuario)
        {
            _UsuarioRepository.Update(usuario);
        }

        //public async Task<IEnumerable<Usuario>> ListNomes(string name)
        //{
        //    return await _UsuarioRepository.ListNomes(name);
        //}
    }
}
