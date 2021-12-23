using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiVendas.Models
{
    [Table("tPercDesconto")]
    public class PercDesconto
    {
        [Key]
        public int ID { get; set; }
        public string Descricao { get; set; }
    }
}
