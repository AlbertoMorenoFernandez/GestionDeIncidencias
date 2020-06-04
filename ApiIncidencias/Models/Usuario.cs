using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiIncidencias.Models
{
    public class Usuario
    {
        [Key]
        public int? UsuarioID { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; } 
        public string  Apellidos { get; set; }
        public int? Extension { get; set; }
        public string Mail { get; set; }
        [ForeignKey("Sede")]
        public int? NumOficina { get; set; }
        [ForeignKey("Rol")]
        public int? RolUsuario { get; set; }
    }
}
