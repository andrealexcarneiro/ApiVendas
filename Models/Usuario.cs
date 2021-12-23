using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ApiVendas.Models
{
    [Table("tUsuario")]
    public class Usuario
    {
        [Key]
        public int tFuncionario_codigo { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public bool Master { get; set; }
        public bool Inativo { get; set; }
        public string Cargo { get; set; }

    }
}
