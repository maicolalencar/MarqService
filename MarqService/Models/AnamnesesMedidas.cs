using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarqService.Models
{
    public class AnamnesesMedidas
    {
        public int IdAnamnese { get; set; }

        public int IdMedidas { get; set; }

        public Anamnese Anamnese { get; set; }

        public Medida Medida { get; set; }

        public float ValorMedida { get; set; }


    }
}
