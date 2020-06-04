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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Capa_Negocio;
using Capa_Entidades;
using System.Collections.ObjectModel;
using System.IO;

namespace Capa_Presentacion.UserControls
{
    /// <summary>
    /// Lógica de interacción para VerHistoricoTicketsControl.xaml
    /// permite una visuazliación de los tickets de un determinado usuario
    /// que se pasa como parámetro en el constructor.
    /// </summary>
    public partial class VerHistoricoTicketsControl : UserControl
    {
      
        Usuario usuario;
        ObservableCollection<Ticket> tickets;
        private CollectionViewSource MiVista;
        SolidColorBrush rojoInformacion = new SolidColorBrush(Color.FromRgb(242, 222, 222));
        VentanaActivaSingleton panelActual;
        private const int TIEMPO_SLA = 4;

        public VerHistoricoTicketsControl(Usuario user)
        {
            
            InitializeComponent();
            panelActual = VentanaActivaSingleton.Instancia;
            panelActual.VentanaActiva = "VerHistoricoTicketsControl";
            limpiarBarra();

            usuario = user;
            MiVista = new CollectionViewSource();
            tickets=new ObservableCollection<Ticket>();
            
            try
            {
                List<Ticket> lista = Negocio.ObtenerTickets().Where(x => x.IdUsuario == user.UsuarioId).ToList();
                foreach (Ticket tick in lista)
                    tickets.Add(tick);
                MiVista.Source = tickets;
                dtTickets.DataContext = MiVista;
            }
            catch (IOException error )
            {
                statusBar.Background = Brushes.IndianRed;
                tbStatusInformation.Text = error.Message;
            }
        }


        //--------------------------------------------------------------------------------FUNCIONES ASOCIADAS A EVENTOS---------------------------------------------------------------------------   

        /// <summary>
        /// Gestiona el evento que se produce al cargar una fila, determina si el ticket
        /// ha tardado más de 4 horas en ser resuelto y si es así, marca esa fila en el datagrid
        /// con un color rojo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DtTickets_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            DataGridRow tick = e.Row;
            Ticket tiquet = (Ticket)tick.DataContext;
             
            if (tiquet.FechaResolucion-tiquet.FechaEntrada > TimeSpan.FromHours(TIEMPO_SLA))             //Ponemos los tickets que no cumplieron sla en rojo.
                e.Row.Background = rojoInformacion;
            else
                e.Row.Background = Brushes.White;
        
        }

        /// <summary>
        /// Controla el evento click del botón btFiltrar, para mostrar una vista filtrada de los tickets
        /// según las fechas indicadas en los controles datapicker.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtFiltrar_Click(object sender, RoutedEventArgs e)
        {
            limpiarBarra();
            //Verifica si hay una fecha seleccionada, deben estar las dos, sino  no hay problema.
            if (dtpHasta.SelectedDate == null && dtpDesde.SelectedDate != null || dtpHasta.SelectedDate != null && dtpDesde.SelectedDate == null)
            {
                VentanaInformacion modal = new VentanaInformacion("Para búsqueda por fechas ha de seleccionar ambas fechas", "advertencia");
                modal.ShowDialog();
            }
            else
                MiVista.Filter += Filtrar;
        }




        //--------------------------------------------------------------------------------FUNCIONES AUXILIARES--------------------------------------------------------------------------   

        /// <summary>
        /// Crea un filtro para los tickets, con las fechas indicadas(si las hubiere) y el texto del textbox
        /// tbEquipo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Filtrar(object sender, FilterEventArgs e)
        {
            limpiarBarra();
            Ticket tick = (Ticket)e.Item;
            if (tick != null)
            {
                if (dtpDesde.SelectedDate != null && dtpHasta.SelectedDate != null)
                {
                    DateTime fechaDesde = (DateTime) tick.FechaEntrada;
                    DateTime fechaHasta = (DateTime)tick.FechaEntrada;

                    if (tick.IdEquipo!=null)
                    {
                        if (tick.IdEquipo.ToUpper().Contains(tbEquipo.Text.ToUpper()) && fechaDesde.Day >= dtpDesde.SelectedDate.Value.Day && fechaHasta.Day <= dtpHasta.SelectedDate.Value.Day)
                            e.Accepted = true;
                        else
                            e.Accepted = false; 
                    }
                    else
                    {
                        if (fechaDesde.Day >= dtpDesde.SelectedDate.Value.Day && fechaHasta.Day <= dtpHasta.SelectedDate.Value.Day)
                            e.Accepted = true;
                        else
                            e.Accepted = false;
                    }
                }
                else
                {
                    if (tick.IdEquipo != null)
                    {
                        if (tick.IdEquipo.ToUpper().Contains(tbEquipo.Text.ToUpper()))
                            e.Accepted = true;
                        else
                            e.Accepted = false;
                    }
                    else
                    {
                        e.Accepted = true;
                    }   
                }  
            }
        }


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
