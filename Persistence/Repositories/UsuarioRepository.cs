using ApiVendas.Models;
using ApiVendas.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVendas.Persistence.Repositories
{
    public class UsuarioRepository : BaseRepository, IUsuarioRepository

    {
        public UsuarioRepository(AppDbContext context) : base(context)
        { }

        public async Task AddAsync(Usuario usuarios)
        {
            using (var ctx = new AppDbContext())
            {

                var UsuarioF = new Usuario
                {
                   
                    Nome = usuarios.Nome,
                    Login = usuarios.Login,
                    Senha = usuarios.Senha,
                    Inativo = usuarios.Inativo,
                    Master = usuarios.Master,
                   
                };
               
                ctx.usuarios.AddAsync(UsuarioF);
                ctx.SaveChanges();
            }
        }

          

        public async Task<IEnumerable<Usuario>> ListFuncionarios()
        {

            using (var contexto = new AppDbContext())
            {

                var ListarFuncionarios = (from func in contexto.usuarios
                                              //                            join dep in contexto.departamento on func.DeptoID equals dep.ID
                                          orderby func.Nome
                                          select new Usuario
                                          {
                                              tFuncionario_codigo = func.tFuncionario_codigo,
                                              Login = func.Login,
                                              Nome = func.Nome,
                                              Senha = func.Senha,
                                              Master = func.Master,
                                              Inativo = func.Inativo,
                                              //Departamentos = dep.Departamento
                                              //};
                                          }).ToList();

                return (IEnumerable<Usuario>)ListarFuncionarios;
            }

        }

        public async Task<IEnumerable<Usuario>> ListFuncionariosID(int id)
        {
            using (var contexto = new AppDbContext())
            {

                var ListarFuncionariosID = (from func in contexto.usuarios
                                            //join dep in contexto.departamento on func.DeptoID equals dep.ID
                                            where func.tFuncionario_codigo == id
                                            select new Usuario
                                            {
                                                tFuncionario_codigo = func.tFuncionario_codigo,
                                                Login = func.Login,
                                                Nome = func.Nome,
                                                Senha = func.Senha,
                                                Master = func.Master,
                                                Inativo = func.Inativo,
                                                //Departamentos = dep.Departamento,
                                                //};
                                            }).ToList();

                return (IEnumerable<Usuario>)ListarFuncionariosID;
            }
        }

        public async Task<IEnumerable<Usuario>> ListNomes(string name)
        {
            using (var contexto = new AppDbContext())
            {
                var resultado = contexto.usuarios
                                         .Where(m => EF.Functions.Like(m.Nome, "%" + name + "%"))
                                         .ToList();

                return (IEnumerable<Usuario>)resultado;
            }
        }
        public void Remove(Usuario usuarios)
        {
            _context.usuarios.Remove(usuarios);
        }

        public void Update(Usuario usuarios)
        {
            
            using (var ctx = new AppDbContext())
            {
               
                var pessoaF = new Usuario
               {
                    tFuncionario_codigo = usuarios.tFuncionario_codigo,
                    Nome = usuarios.Nome,
                    Login = usuarios.Login,
                    Senha = usuarios.Senha,
                    Inativo = usuarios.Inativo,
                    Master = usuarios.Master,
                    
                };
                
                ctx.usuarios.Update(pessoaF);
                ctx.SaveChanges();
            }

        }


        public IEnumerable<Usuario> GetFiltraConsulta(string criterio)
        {
            using (var contexto = new AppDbContext())
            {
                string Criterioi = criterio.Trim();
                var ListarFuncionariosID = (from func in contexto.usuarios
                                            //join dep in contexto.departamento on func.DeptoID equals dep.ID
                                            where func.Nome == "" + Criterioi + ""
                                            select new Usuario
                                            {
                                                tFuncionario_codigo = func.tFuncionario_codigo,
                                                Login = func.Login,
                                                Nome = func.Nome,
                                                Senha = func.Senha,
                                                Master = func.Master,
                                                Inativo = func.Inativo,
                                                //Departamentos = dep.Departamento,
                                                //};
                                            }).ToList();

                return (IEnumerable<Usuario>)ListarFuncionariosID;
            }
        }
    }
}
