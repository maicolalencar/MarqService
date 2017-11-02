using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarqService.Models
{
    public class Pagamentos
    {
        [Key]
        [Required]
        public DateTime DataPagamento { get; set; }
        [Required]
        public int IdCliente { get; set; }
        [Required]
        public Cliente Cliente { get; set; }
        [Required]
        public decimal Valor { get; set; }

    }
}
