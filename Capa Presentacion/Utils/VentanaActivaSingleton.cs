using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Presentacion
{
    /// <summary>
    ///  Esta clase va a permitir saber cual es el userControl cargado en cada momento en el panel principal de la aplicación.
    ///  la clase está marcada como “sealed”, por lo que nos garantizamos de que nadie va a poder heredar de esta clase y crear múltiples
    ///  instancias de nuestro singleton.
    /// </summary>
    sealed class VentanaActivaSingleton
    {
        private string ventanaActiva;
        
        private VentanaActivaSingleton() {  }

        public static readonly VentanaActivaSingleton Instancia = new VentanaActivaSingleton();
        public string VentanaActiva {
            get => ventanaActiva;
            set => ventanaActiva = value;
        }
    }
}
