using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    /// <summary>
    /// La clase localidad sirve para representar la localidad donde se ubican las 
    /// sedes.
    /// <example>
    /// id:1 nombre:San Joan d´Alacant
    /// </example>
    /// </summary>
    public class Localidad : INotifyPropertyChanged
    {
    

        private int? _id;
        private string _nombre;
      
               
        public Localidad()
        {
            _id = null;
            _nombre = null;
        }


        public Localidad(Localidad oldLocalidad)
        {
            _id = oldLocalidad.Id;
            _nombre = oldLocalidad.Nombre;
        }

     

        public Localidad(int? id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

     

        public int? Id {
            get => _id;
            set {
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
