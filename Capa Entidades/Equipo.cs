using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    /// <summary>
    /// Representa un equipo informático en el sistema.
    /// <example>
    /// serviceTag: A05030
    /// marca: HP
    /// modelo: pavilion 350
    /// finGarantia: 16/05/2020 
    /// idtipo:1
    /// numOficina:2
    /// numSerie: a003333990
    /// </example>
    /// </summary>
    public class Equipo : INotifyPropertyChanged
    {


        private string _serviceTag;
        private string _marca;
        private string _modelo;
        private DateTime? _finGarantia;
        private int? _idtipo;
        private int? _numOficina;
        private string _numSerie;
        

      

        public Equipo()
        {
            _serviceTag = null;
            _marca = null;
            _modelo = null;
            _finGarantia = null;
            _idtipo = null;
            _numOficina = null;
            _numSerie = null;
        }

     

        public Equipo(Equipo equipoAuxiliar)
        {
            ServiceTag = equipoAuxiliar.ServiceTag;
            Marca = equipoAuxiliar.Marca;
            Modelo = equipoAuxiliar.Modelo;
            FinGarantia = equipoAuxiliar.FinGarantia;
            Idtipo = equipoAuxiliar.Idtipo;
            NumOficina = equipoAuxiliar.NumOficina;
            NumSerie = equipoAuxiliar.NumSerie;
        }

       

        public Equipo(string serviceTag, string marca, string modelo, DateTime? finGarantia, int? idtipo, int? numOficina, string numSerie)
        {
            ServiceTag = serviceTag;
            Marca = marca;
            Modelo = modelo;
            FinGarantia = finGarantia;
            Idtipo = idtipo;
            NumOficina = numOficina;
            NumSerie = numSerie;
        }

    

        public string ServiceTag {
            get => _serviceTag;
            set
            {
                _serviceTag = value;
                OnPropertyChanged("ServiceTag");
            }
        }

        public string Marca {
            get => _marca;
            set
            {
                _marca = value;
                OnPropertyChanged("Marca");
            }
        }

        public string Modelo {
            get => _modelo;
            set  {
                _modelo = value;
                OnPropertyChanged("Modelo");
            }

        }

        public DateTime? FinGarantia {
            get => _finGarantia;
            set
            {
                _finGarantia = value;
                OnPropertyChanged("FinGarantia");
            }
        }

        public int? Idtipo {
            get => _idtipo;
            set
            {
                _idtipo = value;
                OnPropertyChanged("Idtipo");
            }
        }

        public int? NumOficina {
            get => _numOficina;
            set
            {
                _numOficina = value;
                OnPropertyChanged("NumOficina");
            }
        }

        public string NumSerie {
            get => _numSerie;
            set
            {
                _numSerie = value;
                OnPropertyChanged("NumSerie");
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
