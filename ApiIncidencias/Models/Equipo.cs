using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiIncidencias.Models
{
    public class Equipo
    {
        [Key]
        public string ServiceTag { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public DateTime? FinGarantia { get; set; }
        [ForeignKey("Tipo")]
        public int? IdTipo { get; set; }
        [ForeignKey("Sede")]
        public int? NumOficina { get; set; }
        public string NumSerie { get; set; }
    }
}
