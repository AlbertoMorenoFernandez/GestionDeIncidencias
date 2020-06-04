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
    /// Lógica de interacción para VerNotificacionesModal.xaml
    /// Se recibe una cadena con las notificaciones que se muestran en un datagrid, 
    /// en caso de pasar una lista vacía se muestra un mensaje indicando que no hay
    /// notificaiones pendientes. Está ventana se mostrará como modal y dependiendo 
    /// de el DialogResult las notificaciones se considerarán leídas o no en la ventana
    /// padre.
    /// </summary>
    public partial class VerNotificacionesModal : Window
    {
        public VerNotificacionesModal(List<String> listaNotificaciones)
        {
            InitializeComponent();
            dgNotificaciones.Background = Brushes.White;

            if(listaNotificaciones.Count!=0)
                dgNotificaciones.DataContext = listaNotificaciones;
            else
            {
                List<string> listaSinNotificaciones = new List<string>();
                listaSinNotificaciones.Add("No existen notificaciones no leídas.");
                btLeidas.Content = "Ok";
                dgNotificaciones.DataContext = listaSinNotificaciones;
            }
        }


        //--------------------------------------------------------------------------------------------FUNCIONES ASOCIADAS A EVENTOS------------------------------------------------------
        /// <summary>
        /// Gestiona el evento click del botón btLeidas, si hacemos click en él
        /// las notificaciones se considerarán leídas. Cuando no hay notificaciones pendientes
        /// el resultado es el mismo, considerar que están leídas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtLeidas_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        /// <summary>
        ///  Gestion el evento click del botón cancelar, si hacemos click en él , las notificaciones
        ///  no pasarán a leídas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtCancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
