using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    /// <summary>
    /// La clase estado representa el estado de un ticket en el sistema
    /// <example>
    /// id:1 descripcon:creada
    /// id:2 descripcion:asignada
    /// id:3 descripcion: en Curso
    /// id:4 descripcion: finalizada
    /// id:5 descripcion: pendiente
    /// </example>
    /// </summary>
    public class Estado : INotifyPropertyChanged
    {
  
        int? _id;
        string _descripcion;

  
        public Estado()
        {
            _id = null;
            _descripcion = null;
        }


        public Estado(int? id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;
        }


        public int? Id {

            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }
        public string Descripcion
        {
            get => _descripcion;
            set
            {
                _descripcion = value;
                OnPropertyChanged("Descripcion");
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
