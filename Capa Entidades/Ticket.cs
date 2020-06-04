using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    /// <summary>
    /// Representa una incidencia técnica en el sistema
    /// <example>
    /// numticket:1
    /// idEquipo: A02040
    /// idUsuario: 1
    /// fechaEntrada: 20/04/2020 10:21
    /// fechaResolucion: null
    /// descripcion: El ratón no funciona.
    /// estado: 2
    /// categoria:null
    /// tecnicoAsignado:null
    /// valoracion:null
    /// textoValoracion:null
    /// </example>
    /// </summary>
    public class Ticket : INotifyPropertyChanged
    {
    

        private int? _numTicket;
        private string _idEquipo;
        private int? _idUsuario;
        private DateTime? _fechaEntrada;
        private DateTime? _fechaResolucion;
        private string _descripcion;
        private string _resolucion;
        private int? _estado;
        private int? _categoria;
        private int? _tecnicoAsignado;
        private string _notasTecnico;
        private int? _valoracion;
        private string _textoValoracion;

    

        public Ticket()
        {
            _numTicket = null;
            _idEquipo = null;
            _idUsuario = null;
            _fechaEntrada = null;
            _fechaResolucion = null;
            _descripcion = null;
            _resolucion = null;
            _estado = null;
            _categoria = null;
            _tecnicoAsignado = null;
            _notasTecnico = null;
        }

   

        public Ticket(int? numTicket, string idEquipo, int? idUsuario, DateTime? fechaEntrada, DateTime? fechaResolucion, string descripcion, string resolucion, int? estado, int? categoria, int? tecnicoAsignado,string notasTecnico, int? valoracion, string textoValoracion)
        {
            Valoracion = valoracion;
            TextoValoracion = textoValoracion;
            NumTicket = numTicket;
            IdEquipo = idEquipo;
            IdUsuario = idUsuario;
            FechaEntrada = fechaEntrada;
            FechaResolucion = fechaResolucion;
            Descripcion = descripcion;
            Resolucion = resolucion;
            Estado = estado;
            Categoria = categoria;
            TecnicoAsignado = tecnicoAsignado;
            NotasTecnico = notasTecnico;
        }


        public int? NumTicket {
            get => _numTicket;
            set
            {
                _numTicket = value;
                OnPropertyChanged("NumTicket");
            }
        }

        public string IdEquipo {
            get => _idEquipo;
            set
            {
                _idEquipo = value;
                OnPropertyChanged("IdEquipo");
            }
        }

        public int? IdUsuario {
            get => _idUsuario;
            set
            {
                _idUsuario = value;
                OnPropertyChanged("IdUsuario");
            }
        }

        public DateTime? FechaEntrada {
            get => _fechaEntrada;
            set
            {
                _fechaEntrada = value;
                OnPropertyChanged("FechaEntrada");
            }
        }

        public DateTime? FechaResolucion {
            get => _fechaResolucion;
            set
            {
                _fechaResolucion = value;
                OnPropertyChanged("FechaResolucion");
            }
        }

        public string Descripcion {
            get => _descripcion;
            set
            {
                _descripcion = value;
                OnPropertyChanged("Descripcion");
            }
        }

        public string Resolucion {
            get => _resolucion;
            set
            {
                _resolucion = value;
                OnPropertyChanged("Resolucion");
            }
        }

        public int? Estado {
            get => _estado;
            set
            {
                _estado = value;
                OnPropertyChanged("Estado");
            }

        }

        public int? Categoria {
            get => _categoria;
            set
            {
                _categoria = value;
                OnPropertyChanged("Categoria");
            }
        }

        public int? TecnicoAsignado {
            get => _tecnicoAsignado;
            set
            {
                _tecnicoAsignado = value;
                OnPropertyChanged("TecnicoAsignado");
            }
        }

        public string NotasTecnico {
            get => _notasTecnico;
            set
            {
                _notasTecnico = value;
                OnPropertyChanged("NotasTecnico");
            }
        }

        public int? Valoracion {
            get => _valoracion;
            set
            {
                _valoracion = value;
                OnPropertyChanged("Valoracion");
            }
        }

        public string TextoValoracion {
            get => _textoValoracion;
            set
            {
                _textoValoracion = value;
                OnPropertyChanged("TextoValoracion");
            }
        }

    


        public event PropertyChangedEventHandler PropertyChanged;



        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
