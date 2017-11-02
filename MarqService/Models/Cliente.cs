using MarqService.enumClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarqService.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }

        [Required]
        public string NomeCliente { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Endereco { get; set; }

        public DiasDaSemana DiaDaSemana { get; set; }

        public TimeSpan Hora { get; set; }
    }
}
