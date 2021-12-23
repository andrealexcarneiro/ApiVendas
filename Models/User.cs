using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVendas.Models
{
    public class User
    {
        public int Ambiente { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string GuidTenant { get; set; }
    }
}
