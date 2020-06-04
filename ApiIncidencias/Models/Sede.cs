using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiIncidencias.Models
{
    public class Sede
    {
        [Key]
        public int? NumOficina { get; set; }
        public string Calle { get; set; }
        public string CodigoPostal { get; set; }
        public int? Planta { get; set; }
        [ForeignKey("localidad")]
        public int? Localidad { get; set; }
    }
}
