using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiIncidencias.Models
{
    public class Tecnico
    {
        [Key]
        public int? IdUsuario { get; set; }
        public int? IdTecnico { get; set; }
    }
}
