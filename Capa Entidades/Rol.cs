using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    public class Rol
    {
        private int? _id;
        private string _nombre;

        public Rol()
        {
            Id = null;
            Nombre = null;
        }
        public Rol(int? id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public int? Id { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
    }
}
