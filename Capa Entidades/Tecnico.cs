using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{

    /// <summary>
    /// Representa un usuario con el rol de técnico en el sistema
    /// <example>
    /// idusuario:1
    /// idTecnico:2
    /// </example>
    /// </summary>
    public class Tecnico : INotifyPropertyChanged
    {
 
        private int? _idUsuario;
        private int? _idTecnico;


        public Tecnico(){
            IdUsuario = null;
            IdTecnico = null;
        }

 

        public Tecnico(int? idUsuario, int? idTecnico)
        {
            IdUsuario = idUsuario;
            IdTecnico = idTecnico;
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
