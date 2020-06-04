using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    /// <summary>
    /// Representa la dirección de una oficina del sistema
    /// <example>
    /// numOficina:1
    /// calle: Avenida Oscar Esplá nº58
    /// codigoPostal: 03006
    /// planta:2
    /// localidad: 1
    /// </example>
    /// </summary>
    public class Sede : INotifyPropertyChanged
    {
        private int? _numOficina;
        private string _calle;
        private string _codigoPostal;
        private int? _planta;
        private int? _localidad;

  

        public Sede()
        {
            _numOficina = null;
            _calle = null;
            _codigoPostal = null;
            _planta = null;
            _localidad = null;
        }

  
        
        public Sede(Sede oldSede)
        {
            _numOficina = oldSede.NumOficina;
            _calle = oldSede.Calle;
            _codigoPostal = oldSede.CodigoPostal;
            _planta = oldSede.Planta;
            _localidad = oldSede.Localidad;
        }

        public Sede(int? numOficina, string calle, string codigoPostal, int? planta, int? localidad)
        {
            NumOficina = numOficina;
            Calle = calle;
            CodigoPostal = codigoPostal;
            Planta = planta;
            Localidad = localidad;
        }

        public int? NumOficina {
            get => _numOficina;
            set
            {
                _numOficina = value;
                OnPropertyChanged("NumOficina");
            }
        }
        public string Calle {
            get => _calle;
            set
            {
                _calle = value;
                OnPropertyChanged("Calle");
            }
        }
        public string CodigoPostal {
            get => _codigoPostal;
            set
            {
                _codigoPostal = value;
                OnPropertyChanged("CodigoPostal");
            }
        }
        public int? Planta {
            get => _planta;
            set
            {
                _planta = value;
                OnPropertyChanged("Planta");
            }
        }
        public int? Localidad {
            get => _localidad;
            set
            {
                _localidad = value;
                OnPropertyChanged("Localidad");
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
