using System;
using System.Collections.Generic;
using System.IO;
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
using Capa_Entidades;
using Capa_Negocio;

namespace Capa_Presentacion
{
    /// <summary>
    /// Lógica de interacción para VentanaAsignarTecnico.xaml
    /// Solicita una confirmación para asignar un ticket a un 
    /// técnico determinado.
    /// </summary>
    public partial class VentanaAsignarTecnico : Window
    {
       
        int idTicket;
        int idTecnico;
        public VentanaAsignarTecnico(int idTecnico,int idTicket, string nombreTecnico)
        {
            InitializeComponent();
            this.idTicket = idTicket;
            this.idTecnico = idTecnico;
         
            tbInformacion.Text="¿Desea asignar el ticket "+idTicket+" a "+nombreTecnico+" ?";
        }

        //----------------------------------------------------------------FUNCIONES ASOCIADAS A EVENTOS----------------------------------------------------------------------------------------

        /// <summary>
        /// Controla el evento click del botón btAsignar, en caso  afirmativo se actualiza la base de datos
        /// y si no hay errores se informa al control padre mediante DialogResult.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
           
        private void BtAsignar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Ticket ticketAactualizar = Negocio.ObtenerTicket(idTicket);
                ticketAactualizar.TecnicoAsignado = idTecnico;
                ticketAactualizar.Estado = (int) EstadoIncidencia.asignada;
                if (Negocio.EditarTicket(ticketAactualizar))
                {
                    this.DialogResult = true;
                    this.Close();
                }

                else
                {
                    this.DialogResult = false;
                    VentanaInformacion modal = new VentanaInformacion("Error al asignar técnico", "advertencia");
                    modal.ShowDialog();
                }
            }
            catch (IOException)
            {
                VentanaInformacion modal = new VentanaInformacion("Error al acceder a la base de datos", "advertencia");
                modal.ShowDialog();
            }
                
        }

        /// <summary>
        /// Gestiona el evento click de BtClose, permite cerrar la ventana.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
