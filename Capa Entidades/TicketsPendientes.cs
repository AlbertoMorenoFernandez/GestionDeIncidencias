using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Capa_Entidades
{
    public class TicketsPendientes
    {
        private int? _id;
        private string _descripcion;
        private string _sede;
        private string _idEquipo;
        private string _usuario;
        private DateTime? _fechaEntrada;
        private List<string> _tecnicos;

        public TicketsPendientes()
        {
            _id = null;
            _descripcion = null;
            _fechaEntrada = null;
            _tecnicos = null;
            IdEquipo = null;
            Usuario = null;
            Sede = null;
        }



        public TicketsPendientes(int? id, string descripcion, DateTime? fechaEntrada, List<string> tecnicos, string idEquipo, string usuario, string sede)
        {
            Id = id;
            Descripcion = descripcion;
            FechaEntrada = fechaEntrada;
            Tecnicos = tecnicos;
            IdEquipo = idEquipo;
            Usuario = usuario;
            Sede = sede;
        }

        public int? Id { get => _id; set => _id = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public DateTime? FechaEntrada { get => _fechaEntrada; set => _fechaEntrada = value; }
        public List<string> Tecnicos { get => _tecnicos; set => _tecnicos = value; }
        public string Sede { get => _sede; set => _sede = value; }
        public string IdEquipo { get => _idEquipo; set => _idEquipo = value; }
        public string Usuario { get => _usuario; set => _usuario = value; }
    }
}
