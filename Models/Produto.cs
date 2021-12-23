using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiVendas.Models
{
    [Table("tProduto")]
    public class Produto
    {
        [Key]
        public int ID { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int PercDesc01 { get; set; }
        public int PercDesc02 { get; set; }
        public int PercDesc03 { get; set; }
        public int PercDesc04 { get; set; }
        public int PercDesc05 { get; set; }
        public int PercDesc06 { get; set; }
        public int PercDesc07 { get; set; }
    }
}
