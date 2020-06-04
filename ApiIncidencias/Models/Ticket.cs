using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiIncidencias.Models
{
    public class Ticket
    {
        [Key]
        public int? NumTicket { get; set; }
        [ForeignKey("equipo")]
        public string IdEquipo { get; set; }
        [ForeignKey("usuario")]
        public int? IdUsuario { get; set; }
        public DateTime? FechaEntrada { get; set; }
        public DateTime? FechaResolucion { get; set; }
        public string Descripcion { get; set; }
        public string Resolucion { get; set; }
        public int? Estado { get; set; }
        [ForeignKey("tipo")]
        public int? Categoria { get; set; }
        [ForeignKey("tecnico")]
        public int? TecnicoAsignado { get; set; }

        public string NotasTecnico { get; set; }
        public int? Valoracion { get; set; }
        public string TextoValoracion { get; set; }
   
    }
}
