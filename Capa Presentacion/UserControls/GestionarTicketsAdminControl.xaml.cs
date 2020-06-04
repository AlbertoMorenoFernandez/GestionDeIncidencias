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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Capa_Entidades;
using Capa_Negocio;


namespace Capa_Presentacion.UserControls
{
    /// <summary>
    /// Lógica de interacción para GestionarTicketsAdminControl.xaml
    /// </summary>
    public partial class GestionarTicketsAdminControl : UserControl
    {
        TimeSpan tiempoResolucion;
        string tiempoResolucionTicket;       
        StackPanel panelPrincipal;
        Usuario usuario;
        Ticket ticket;
        VentanaActivaSingleton panelActual;

        public GestionarTicketsAdminControl(Ticket tick, Usuario user)
        {
            InitializeComponent();
            panelActual = VentanaActivaSingleton.Instancia;
            panelActual.VentanaActiva = "GestionarTicketsAdminControl";
            limpiarBarra();

            usuario = user;
            ticket = tick;
     
            gdPrincipal.DataContext = tick;       
            List<string> listaTecnicos= Negocio.ObtenerListaTecnicos();
            listaTecnicos.Add("6.-Ramón López Lorca");
            cbTecnicos.DataContext = listaTecnicos;
            string idTecnico =""+ (int)tick.TecnicoAsignado;
            int contador = 0;
            int indiceTecnico = 0;
            foreach(string tecnico in listaTecnicos)
            {
                string tecnicoLista= tecnico.Split('.')[0];
                if (idTecnico.Equals(tecnicoLista))
                    indiceTecnico = contador;
                else
                    contador++;
            }

            cbTecnicos.SelectedIndex =indiceTecnico;
            try
            {

                List<string> listatipos = Negocio.ObtenerListaTipos();
                cbCategoria.DataContext = listatipos;
                if (ticket.Categoria != null)
                {
                    string tipoTicket = Negocio.ObtenerNombrePorTipoId((int)ticket.Categoria);
                    int index = listatipos.IndexOf(tipoTicket);
                    cbCategoria.SelectedIndex = index;
                }



                if (tick.FechaResolucion == null)
                {
                    tiempoResolucion = (TimeSpan)(DateTime.Now - tick.FechaEntrada);
                    lbTituloReloj.Content = "TIEMPO DESDE CREACIÓN:";
                }
                else
                {
                    tiempoResolucion = (TimeSpan)(tick.FechaResolucion - tick.FechaEntrada);
                    lbTituloReloj.Content = "TIEMPO DE RESOLUCIÓN:";
                    rbAsignar.IsEnabled = false;
                    rbCerrar.IsEnabled = false;
                    cbTecnicos.IsEnabled = false;
                }
                if (tiempoResolucion.Days == 0)
                {
                    string minutos = tiempoResolucion.Minutes.ToString();
                    if (minutos.Length == 1)
                        minutos = "0" + minutos;
                    string horas = tiempoResolucion.Hours.ToString();
                    if (horas.Length == 1)
                        horas = "0" + horas;
                    tiempoResolucionTicket = horas + "h" + minutos + "'";
                    switch (tiempoResolucion.Hours)
                    {
                        case 4:
                            imgRelojSLA.Source = new BitmapImage(new Uri(@"/Imagenes/fueraSLA.png", UriKind.Relative));
                            break;
                        case 3:
                            imgRelojSLA.Source = new BitmapImage(new Uri(@"/Imagenes/cercaSLA.png", UriKind.Relative));
                            break;
                        case 2:
                        case 1:
                        case 0:
                            imgRelojSLA.Source = new BitmapImage(new Uri(@"/Imagenes/lejosSLA.png", UriKind.Relative));
                            break;
                        default:
                            imgRelojSLA.Source = new BitmapImage(new Uri(@"/Imagenes/fueraSLA.png", UriKind.Relative));
                            break;
                    }
                }
                else
                {
                    tiempoResolucionTicket = ">24h00'";
                    imgRelojSLA.Source = new BitmapImage(new Uri(@"/Imagenes/fueraSLA.png", UriKind.Relative));
                }

                tbTiempoResolucion.Text = tiempoResolucionTicket;
            }
            catch (IOException error)
            {
                statusBar.Background = Brushes.IndianRed;
                tbStatusInformation.Text = error.Message;
            }

        }
        //--------------------------------------------------------------------------------FUNCIONES ASOCIADAS A EVENTOS----------------------------------------------------------------

        /// <summary>
        /// Asociado al  evento checked del radiobutton "rbAsignar" muestra el combobox "cbTecnicos" cuando la opción
        /// "asignar" ha sido seleccionada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RbAsignar_Checked(object sender, RoutedEventArgs e)
        {
            cbTecnicos.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Asociado al evento checked del radiobutton "rbCerrar" oculta el combobox "cbTecnicos" cuando la opción "cerrar" ha
        /// sido seleccionada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RbCerrar_Checked(object sender, RoutedEventArgs e)
        {
            if(cbTecnicos!=null)
                cbTecnicos.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Asociada al evento selectionChanged del combobox "cbTecnicos" , permite visualizar el total de avisos y avisos pendientes
        /// de el técnico seleccionado en el combobox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbTecnicos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int totalAvisos = 0;
            int avisosPendientes = 0;
            string tecnico=cbTecnicos.SelectedItem.ToString();
            int idTecnico = int.Parse(tecnico.Split('.')[0]);
            tbTecnico.Text = tecnico.Split('-')[1];
            try
            {
                tbTecnicoDireccion.Text = Negocio.ObtenerSedeTecnico(idTecnico);
                List<TicketEnCurso> ticketsEnCurso = Negocio.ObtenerTicketsEnCurso().Where(x => x.IdTecnico == idTecnico && x.FechaFinalizacion == null).ToList();
                totalAvisos = ticketsEnCurso.Count;
                foreach (TicketEnCurso tick in ticketsEnCurso)
                {
                    if (Negocio.ObtenerTicket((int)tick.Id).NotasTecnico != null)
                        avisosPendientes++;
                }

                tbAsignadas.Text = "" + totalAvisos;
                tbPendientes.Text = "" + avisosPendientes;
            }
            catch (IOException error)
            {
                statusBar.Background = Brushes.IndianRed;
                tbStatusInformation.Text = error.Message;
            }
        }

        /// <summary>
        /// Asociado al evento click del botón "btVolver" permite volver a la ventana "EditarTicketsAdminControl" <see cref="EditarTicketsAdminControl"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtVolver_Click(object sender, RoutedEventArgs e)
        {
            EditarTicketsAdminControl contenido = new EditarTicketsAdminControl(usuario);
            panelPrincipal.Children.Insert(1, contenido);
            panelPrincipal.Children.RemoveAt(0);
        }

        /// <summary>
        /// Asociado al evento click de botón "btActualizar" permite actualizar el ticket que hayamos elegido, con los valores
        /// introducidos, ya sea para finalizarlos o para reasignarlo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtActualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ticket.Resolucion = tbResolucion.Text;
                ticket.NotasTecnico = tbNotasTecnico.Text;

                if (rbAsignar.IsChecked == true)
                {
                    ticket.TecnicoAsignado = int.Parse(cbTecnicos.SelectedItem.ToString().Split('.')[0]);
                    ticket.Estado = (int?)EstadoIncidencia.asignada;
                    if (Negocio.EditarTicket(ticket))
                    {
                        VentanaInformacion modal = new VentanaInformacion("Ticket actualizado con éxito", "exito");
                        modal.ShowDialog();
                    }
                    else
                    {
                        VentanaInformacion modal = new VentanaInformacion("Error al actualizar el ticket", "advertencia");
                        modal.ShowDialog();
                    }
                }
                else
                {

                    if (!tbResolucion.Text.Equals(""))
                    {
                        if (cbCategoria.SelectedIndex != -1)
                        {
                            ticket.TecnicoAsignado = Negocio.ObtenerTecnicoIdPorUsuario((int)usuario.UsuarioId);
                            ticket.Estado = (int?)EstadoIncidencia.finalizada;
                            ticket.Categoria = Negocio.ObtenerTipoIdPorNombre(cbCategoria.SelectedItem.ToString());
                            if (Negocio.EditarTicket(ticket))
                            {
                                VentanaInformacion modal = new VentanaInformacion("Ticket actualizado con éxito", "exito");
                                modal.ShowDialog();
                            }
                            else
                            {
                                VentanaInformacion modal = new VentanaInformacion("Error al actualizar el ticket", "advertencia");
                                modal.ShowDialog();
                            }
                        }
                        else
                        {
                            VentanaInformacion modal = new VentanaInformacion("Campo categoría debe tener un valor,por favor.", "advertencia");
                            modal.ShowDialog();
                        }

                    }

                    else
                    {
                        VentanaInformacion modal = new VentanaInformacion("Campo resolución debe tener un valor, por favor.", "advertencia");
                        modal.ShowDialog();
                    }
                }
            }
            catch (IOException error)
            {
                statusBar.Background = Brushes.IndianRed;
                tbStatusInformation.Text = error.Message;
            }
        }


        /// <summary>
        /// Nos va a permitir establecer el padre del userControl una vez cargado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            panelPrincipal = (StackPanel)this.Parent;
        }

        /// <summary>
        /// Reinicia la barra de estado a sus valores originales.
        /// </summary>
        public void limpiarBarra()
        {
            statusBar.Background = System.Windows.Media.Brushes.WhiteSmoke;
            tbStatusInformation.Text = "";
        }

    }
}
