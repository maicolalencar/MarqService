using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarqService.Models
{
    public class Medida
    {
        [Key]
        public int IdMedida { get; set; }
        public string NomeMedida { get; set; }

        public ICollection<AnamnesesMedidas> AnamnesesMedidas { get; set; }

    }
}
