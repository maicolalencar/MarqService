using MarqService.enumClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarqService.Models
{
    public class Agendamentos
    {
        public int id { get; set; }

        //[ForeignKey("Cliente")]
        public int ClienteIdCliente { get; set; }

        public DiasDaSemana DiaDaSemana { get; set; }

        public TimeSpan Hora { get; set; }
    }
}
