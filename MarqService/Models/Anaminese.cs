using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarqService.Models
{
    public class Anamnese
    {
        [Key]
        public int IdAnamnese { get; set; }
        public int IdCliente { get; set; }
        [ForeignKey("IdCliente")]
        public Cliente Cliente { get; set; }
        public DateTime DataAnamnese { get; set; }

        public ICollection<AnamnesesMedidas> AnamnesesMedidas { get; set; }
    }
}
