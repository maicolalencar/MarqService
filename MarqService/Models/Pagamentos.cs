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
        public int Id { get; set; }
        public DateTime DataPagamento { get; set; }
        public int IdCliente { get; set; }
        public decimal Valor { get; set; }

    }
}
