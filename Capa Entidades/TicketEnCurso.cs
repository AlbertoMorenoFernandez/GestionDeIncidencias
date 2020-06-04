using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    /// <summary>
    /// Representa un ticket que se encuentra en el sistema activo, es decir que ha sido creado pero no ha sido
    /// resuelto, o en caso de ser resuelto no ha sido valorado o lleva menos de 4 días en el sistema.
    /// <example>
    /// id:1
    /// idUsuario:2
    /// idTecnico:3
    /// fechaCreacion:10/04/2020 08:40
    /// fechaAsignacion: 10/04/2020 09:40
    /// fechaEnCurso:null
    /// fechaFinalizacion:null
    /// </example>
    /// </summary>
    public class TicketEnCurso : INotifyPropertyChanged
    {

        private int? _id;
        private int? _idUsuario;
        private int? _idTecnico;
        private DateTime? _fechaCreacion;
        private DateTime? _fechaAsignacion;
        private DateTime? _fechaEnCurso;
        private DateTime? _fechaFinalizacion;



        public TicketEnCurso()
        {
            _id = null;
            _idUsuario = null;
            _idTecnico = null;
            _fechaCreacion = null;
            _fechaAsignacion = null;
            _fechaEnCurso = null;
            _fechaFinalizacion = null;
        }

  

        public TicketEnCurso(int? id, int? idUsuario, int? idTecnico, DateTime? fechaCreacion, DateTime? fechaAsignacion, DateTime? fechaEnCurso, DateTime? fechaFinalizacion)
        {
            _id = id;
            _idUsuario = idUsuario;
            _idTecnico = idTecnico;
            _fechaCreacion = fechaCreacion;
            _fechaAsignacion = fechaAsignacion;
            _fechaEnCurso = fechaEnCurso;
            _fechaFinalizacion = fechaFinalizacion;
        }



        public int? Id {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged("Id");
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

        public int? IdTecnico {
            get => _idTecnico;
            set
            {
                _idTecnico = value;
                OnPropertyChanged("IdTecnico");
            }
        }

        public DateTime? FechaCreacion {
            get => _fechaCreacion;
            set
            {
                _fechaCreacion = value;
                OnPropertyChanged("FechaCreacion");
            }
        }

        public DateTime? FechaAsignacion {
            get => _fechaAsignacion;
            set
            {
                _fechaAsignacion = value;
                OnPropertyChanged("FechaAsignacion");
            }
        }

        public DateTime? FechaEnCurso {
            get => _fechaEnCurso;
            set
            {
                _fechaEnCurso = value;
                OnPropertyChanged("FechaEnCurso");
            }
        }
        public DateTime? FechaFinalizacion {
            get => _fechaFinalizacion;
            set
            {
                _fechaFinalizacion = value;
                OnPropertyChanged("FechaFinalizacion");
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
