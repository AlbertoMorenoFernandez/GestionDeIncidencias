using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{   
    /// <summary>
    /// Representa el tipo de Equipo e incidencia que se almacena en el sistema, sirve para categorizar
    /// equipos e tickets.
    /// <example>
    /// id:1
    /// nombre: PC
    /// </example>
    /// </summary>
    public class Tipo : INotifyPropertyChanged
    {
       
        private int? _id;
        private string _nombre;
     

       
        public Tipo()
        {
            _id = null;
            _nombre = null;
        }

   
        
        public Tipo(int? id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public Tipo(Tipo oldTipo)
        {
            this._id = oldTipo.Id;
            this._nombre = oldTipo.Nombre;
        }



        public int? Id {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Nombre {
            get => _nombre;
            set
            {
                _nombre = value;
                OnPropertyChanged("Nombre");
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
