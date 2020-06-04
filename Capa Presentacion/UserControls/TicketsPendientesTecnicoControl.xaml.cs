using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Capa_Datos;
using Capa_Entidades;
using Capa_Negocio;

namespace Capa_Presentacion.UserControls
{
    /// <summary>
    /// Lógica de interacción para TicketTecnicoControl.xaml
    /// Este control muestar una lista con los tickets que tiene
    /// el técnico asignados, para ello utiliza una clase auxiliar
    /// <see cref="TicketsPendientes"/> que permite una mejor 
    /// visualización de la información de los mismos.
    /// </summary>
    public partial class TicketTecnicoControl : UserControl
    {
      
        StackPanel principal;
        Tecnico tecnicoActual;
        bool permitirEnCurso = false;
        VentanaActivaSingleton panelActual;

        public TicketTecnicoControl(Tecnico tecnico)
        {
            InitializeComponent();
            panelActual = VentanaActivaSingleton.Instancia;
            panelActual.VentanaActiva = "TicketTecnicoControl";
            limpiarBarra();
   
            tecnicoActual= tecnico;

            try
            {
                ObservableCollection<Ticket> ticketsPendientes = Negocio.ObtenerTicketsPendientesPorTecnico((int)tecnico.IdTecnico);
                List<Ticket> ticketsEnCurso = ticketsPendientes.Where(x => x.Estado == (int) EstadoIncidencia.enCurso).ToList();
                if (ticketsEnCurso.Count == 0)
                    permitirEnCurso = true;
                myListView.ItemsSource = ticketsPendientes;
                if (ticketsPendientes.Count == 0)
                    tbSinTickets.Visibility = Visibility.Visible;
            }
            catch (IOException error)
            {
                statusBar.Background = Brushes.IndianRed;
                tbStatusInformation.Text = error.Message;
            }
        }

        //----------------------------------------------------------------FUNCIONES ASOCIADAS A EVENTOS----------------------------------------------------------------------------------------

        /// <summary>
        /// Controla el evento selectionChanged del listView MyListView que contiene el listado de tickets,
        /// al seleccionar uno, abre el userControls <see cref="GestionarTecnicoTicketControl"/> , para
        /// gestionar dicho ticket, pasándole el ticket, el técnico y si existen o no ticketsencurso(sólo se permite uno)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            principal = (StackPanel)this.Parent;
            Ticket tick = (Ticket)myListView.SelectedItem;
            GestionarTecnicoTicketControl contenido = new GestionarTecnicoTicketControl(tick,tecnicoActual,permitirEnCurso);
            principal.Children.Insert(1,contenido);
            principal.Children.RemoveAt(0);
            panelActual.VentanaActiva = "GestionarTecnicoTicketControl";    
        }



        //-----------------------------------------------------------------FUNCIONES AUXILIARES---------------------------------------------------------------------------------------

        /// <summary>
        /// Reinicia la barra de estado a sus valores originales.
        /// </summary>
        public void limpiarBarra()
        {
            statusBar.Background = Brushes.WhiteSmoke;
            tbStatusInformation.Text = "";
        }
    }
}
