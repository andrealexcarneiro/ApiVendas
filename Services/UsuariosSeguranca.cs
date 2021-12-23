using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiVendas.Models;
using ApiVendas.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiVendas.Services
{
    public class UsuariosSeguranca
    {
        public static bool Login(string login, string senha)
        {
            using (AppDbContext entities = new AppDbContext())
            {
                return entities.usuarios.Any(user =>
               user.Nome.Equals(login, StringComparison.OrdinalIgnoreCase)
               && user.Senha == senha);
            }
        }
    }
}
