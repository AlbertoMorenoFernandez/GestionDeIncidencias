using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
using Capa_Entidades;
using Capa_Negocio;

namespace Capa_Presentacion.UserControls
{
    /// <summary>
    /// Lógica de interacción para ticketsPendientescontrol.xaml
    /// Este control es usado por un administrador para gestionar los tickets que hay en curso actualmente,
    /// muestra un datagrid con los ticketsEncurso, a la derecha el detalle de los mismos siguiendo un esquema
    /// maestro-detalle, en la parte inferior se muestran dos gráficos, con el porcentaje de tickets asignados
    /// y los no asignados y el tiempo medio de resolución de averías de los últimos siete días.
    /// </summary>
    public partial class ticketsPendientescontrol : UserControl
    {
       
        ObservableCollection<TicketsPendientes> listaPendientes;
        
        TicketsPendientes ticketActual;
        VentanaActivaSingleton panelActual;
        SolidColorBrush rojoTenue = new SolidColorBrush(Color.FromRgb(242, 222, 222));
        private const int TIEMPO_SLA= 4;

        public ticketsPendientescontrol()
        {
            InitializeComponent();
            panelActual = VentanaActivaSingleton.Instancia;
            panelActual.VentanaActiva = "ticketsPendientescontrol";
            limpiarBarra();

            try
            {
                pieChart.DataContext = Negocio.obtenerTicketsAsignados();
                columnGrap.DataContext = Negocio.ObtenerTiempoResolucionMedio(DateTime.Now);
   
                listaPendientes = new ObservableCollection<TicketsPendientes>();
                listaPendientes = Negocio.ConvertirAticketsPendientes(Negocio.ObtenerTicketsEnCurso().Where(x => x.FechaAsignacion == null).ToList());
                gdTickets.DataContext = listaPendientes;
            }
            catch (IOException error)
            {
                statusBar.Background = Brushes.IndianRed;
                tbStatusInformation.Text = error.Message;
            }
        }



        //--------------------------------------------------------------------------------FUNCIONES ASOCIADAS A EVENTOS---------------------------------------------------------------------------   

        /// <summary>
        /// Cada vez que se carga una fila en el datagrid verífica si el ticket lleva más de 4 horas abierto
        /// y en caso de estarlo, lo representa con un color rojo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void DgTickesPendientes_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            DataGridRow tick = e.Row;
            TicketsPendientes tiquet=(TicketsPendientes) tick.DataContext;
            if (tiquet.FechaEntrada <= DateTime.Now.AddHours(-TIEMPO_SLA))
                e.Row.Background = rojoTenue;
        }
        
        /// <summary>
        /// Gestiona el evento selectionChanged del cbTecnicos, de forma que al seleccionar un técnico
        /// carga la ventana <see cref="VentanaAsignarTecnico"/> para confirmar que se desea asignar el ticket
        /// a dicho técnico, en caso afirmativo, se actualiza la base de datos con los valores.
        /// <example>
        /// El combobox de técnicos tiene el siguiente formato:
        /// 1.-Alberto Moreno Fernández
        /// 2.-Dario Hernández Robledo.
        /// Por lo que por medio de manipulación de cadenas, podemos obtener el idTecnico, que es lo que va antes de .-
        /// </example>
        /// el formato del list<string> del combobox puede verse en <see cref="TicketsPendientes"/> que es donde se forma
        /// la clase auxiliar con los campos que necesitamos para visualizar en formato amigable el datagrid resumen de esta ventana.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbTecnicos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            limpiarBarra();
            try
            {
                //Obtenemos el idUsuario
                string nombreTecnico = ((ComboBox)sender).SelectedItem.ToString();
                int idUsuario = int.Parse(nombreTecnico.Split('.')[0]);

                // a partir del idUsuario podemos obtener el idTecnico
                int idTecnico = (int)Negocio.ObtenerTecnico(idUsuario).IdTecnico;

                // obtenemos el nombre del técnico.
                string tecnico = nombreTecnico.Split('-')[1];

                ticketActual = (TicketsPendientes)dgTickesPendientes.SelectedItem;
                VentanaAsignarTecnico modal = new VentanaAsignarTecnico(idTecnico, (int)ticketActual.Id, tecnico);
                modal.ShowDialog();
                if (modal.DialogResult == true)
                {
                    List<TicketsPendientes> listaAuxiliar = listaPendientes.Where(x => x.Id != ticketActual.Id).ToList();
                    listaPendientes.Clear();
                    foreach (TicketsPendientes tick in listaAuxiliar)
                    {
                        listaPendientes.Add(tick);
                    }
                    pieChart.DataContext = Negocio.obtenerTicketsAsignados();
                }
            }
            catch (IOException error)
            {
                statusBar.Background = Brushes.IndianRed;
                tbStatusInformation.Text = error.Message;
            }
        }

        /// <summary>
        /// Reinicia la barra de estado a sus valores originales.
        /// </summary>
        public void limpiarBarra()
        {
            statusBar.Background = System.Windows.Media.Brushes.WhiteSmoke;
            tbStatusInformation.Text = "";
        }

        private void BtActualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                listaPendientes = Negocio.ConvertirAticketsPendientes(Negocio.ObtenerTicketsEnCurso().Where(x => x.FechaAsignacion == null).ToList());
                gdTickets.DataContext = listaPendientes;
                pieChart.DataContext = Negocio.obtenerTicketsAsignados();
            }
            catch (IOException error)
            {
                statusBar.Background = Brushes.IndianRed;
                tbStatusInformation.Text = error.Message;
            }
        }
    }
}
