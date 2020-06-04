using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Capa_Presentacion
{
    /// <summary>
    /// Lógica de interacción para VentanaInformacion.xaml
    /// Permite mandar un MessageBox personalizado con información de eventos que sucedan en nuestra aplicación.
    /// </summary>
    public partial class VentanaInformacion : Window
    {
        public VentanaInformacion()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Constructor que permite indicar el texto que deseamos mostrar y el icono que deseamos que aparezca junto a la información.
        /// </summary>
        /// <param name="texto">Texto que deseamos que muestre la ventana.</param>
        /// <param name="tipoImagen">Determina si queremos que salga un icono de advertencia si su valor es "advertencia", o de información si su valor es "informacion"</param>
        public VentanaInformacion(string texto, string tipoImagen)
        {
            InitializeComponent();

            tbInformacion.Text = texto;
            switch (tipoImagen)
            {
                case "exito":
                    imgTipoInformacion.Source = new BitmapImage(new Uri(@"../Imagenes/exito.png", UriKind.Relative));
                    break;
                case "advertencia":
                    imgTipoInformacion.Source = new BitmapImage(new Uri(@"../Imagenes/advertencia.png", UriKind.Relative));
                    break;
            }
        }


        //--------------------------------------------------------------------------------FUNCIONES ASOCIADAS A EVENTOS-------------------------------------------------------------------
        /// <summary>
        /// Asociado al evento click del btClose, permite cerrar la ventana.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Asociado al evento click del btAceptar, permite cerrar la ventana.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtAceptar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
