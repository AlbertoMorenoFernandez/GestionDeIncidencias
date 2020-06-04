using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    public class EstadoConexion
    {
        private int? _id;
        private string _conexion;

        public EstadoConexion()
        {
            Id = null;
            Conexion = null;
        }

        public EstadoConexion(int id,string conexion)
        {
            Id = id;
            Conexion = conexion;

        }

        public int? Id { get => _id; set => _id = value; }
        public string Conexion { get => _conexion; set => _conexion = value; }
    }
}
