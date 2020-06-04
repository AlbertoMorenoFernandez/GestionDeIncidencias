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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Capa_Presentacion
{
    /// <summary>
    /// Lógica de interacción para ConfirmarSalir.xaml
    /// Solicita una confirmación para salir de la aplicación, para evitar una salida del programa no deseada.
    /// </summary>
    public partial class ConfirmarSalir : Window
    {
       
        public string ReturnString { get; set; }
        DoubleAnimation anim;

        public ConfirmarSalir()
        {
            InitializeComponent();
            
        }

        public ConfirmarSalir(String text)
        {
            InitializeComponent();
            tbText.Text = text;
        }

        //----------------------------------------------------------------FUNCIONES ASOCIADAS A EVENTOS----------------------------------------------------------------------------------------

        /// <summary>
        /// Gestiona el evento click del botón btnClose, permite cerrar la aplicación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            Close();
        }

        /// <summary>
        /// Realiza una animación al salir de la ventana jugando con el parametro opacity.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Closing -= Window_Closing;
            e.Cancel = true;
            anim = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(0.3));
            anim.Completed += (s, _) => this.Close();
            this.BeginAnimation(UIElement.OpacityProperty, anim);
        }

        /// <summary>
        /// Gestiona el evento click del boton btSalir, si hacemos click en él
        /// se saldrá de la aplicación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSalir_Click(object sender, RoutedEventArgs e)
        {

            this.DialogResult = true;
            this.DialogResult = true;
            this.Close();
        }

        /// <summary>
        /// Gestiona el evento click del botón btNoSalir, si hacemos click en él
        /// no se saldrá de la aplicación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btNoSalir_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            Close();
        }

        //----------------------------------------------------------------FUNCIONES AUXILIARES----------------------------------------------------------------------------------------
        /// <summary>
        /// Hace posible que la ventana se mueva por el escritorio al hacer click sobre ella.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch { }
        }

    }
}


