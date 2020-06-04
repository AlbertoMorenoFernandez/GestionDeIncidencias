using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiIncidencias.Models
{
    public class TicketEnCurso
    {
        [Key]
        public int? Id { get; set; }
        [ForeignKey ("usuario")]
        public int? IdUsuario { get; set; }
        [ForeignKey ("tecnico")]
        public int? IdTecnico { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        
        public DateTime? FechaEnCurso { get; set; }
       
        public DateTime? FechaAsignacion { get; set; }
    }
}
