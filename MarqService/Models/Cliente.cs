using MarqService.enumClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public string email { get; set; }

        public string telefone { get; set; }

        public IList<Agendamentos> Agendamentos { get; set; }

        public IList<Pagamentos> Pagamentos { get; set; }
    }
}
