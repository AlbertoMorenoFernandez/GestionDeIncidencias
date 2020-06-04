using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    public class EstadoUsuario
    {
        private int? _idUsuario;
        private int? _idConexion;
        private DateTime? _fechaUltimaRevision;

        public EstadoUsuario()
        {
            IdUsuario = null;
            IdConexion = null;
            FechaUltimaRevision = null;
        }

        public EstadoUsuario(int? idUsuario, int? idConexion, DateTime? fechaUltimaRevision)
        {
            IdUsuario = idUsuario;
            IdConexion = idConexion;
            FechaUltimaRevision = fechaUltimaRevision;
        }

        public int? IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public int? IdConexion { get => _idConexion; set => _idConexion = value; }
        public DateTime? FechaUltimaRevision { get => _fechaUltimaRevision; set => _fechaUltimaRevision = value; }
    }
}
