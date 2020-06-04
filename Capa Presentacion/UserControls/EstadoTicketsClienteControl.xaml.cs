using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Media;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Capa_Entidades;
using Capa_Negocio;

namespace Capa_Presentacion.UserControls
{
    /// <summary>
    /// Lógica de interacción para HomeTicketControl.xaml
    /// Muestra información al cliente de los tickets que tiene en curso, mediante un desplegable
    /// puede ver que tickets tiene en curso y hacer un seguimiento de los mismos.
    /// </summary>
    public partial class HomeTicketControl : UserControl
    {
        int idTicket;
        Usuario usuario;
        DispatcherTimer timer;
        List<TicketEnCurso> listaTickets;
        ObservableCollection<TicketEnCurso> listaFiltradosPorUsuario;
        const int TIEMPO_DE_ACTUALIZACION = 30;
        VentanaActivaSingleton panelActual;
        List<string> listaTicketspendientes;


        public HomeTicketControl(Usuario user)
        {
            InitializeComponent();
            panelActual = VentanaActivaSingleton.Instancia;
            panelActual.VentanaActiva = "HomeTicketControl";
            limpiarBarra();

            usuario = user;
            listaTickets = new List<TicketEnCurso>();
            listaFiltradosPorUsuario = new ObservableCollection<TicketEnCurso>();

            try
            {
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(TIEMPO_DE_ACTUALIZACION);
                timer.Tick += timer_Tick;
                timer.Start();

                listaTickets = Negocio.ObtenerTicketsEnCurso();
                listaFiltradosPorUsuario.Clear();
                foreach (TicketEnCurso tick in listaTickets.Where(x => x.IdUsuario == user.UsuarioId).ToList())
                    listaFiltradosPorUsuario.Add(tick);
                listaTicketspendientes= Negocio.ObtenerResumenTicket((int)user.UsuarioId);
                if (listaTicketspendientes!=null)
                {
                    lbInformacion.Visibility = Visibility.Collapsed;
                    cbTickets.IsEnabled = true;
                    imgEstado.Visibility = Visibility.Visible;
                    bdValorar.Visibility = Visibility.Visible;
                }
                else
                {
                    lbInformacion.Visibility = Visibility.Visible;
                    imgEstado.Visibility = Visibility.Hidden;
                    bdValorar.Visibility = Visibility.Hidden;
                    cbTickets.IsEnabled = false;
                }
                cbTickets.ItemsSource = listaTicketspendientes;
                if (listaTicketspendientes != null)
                    cbTickets.SelectedIndex = 0;
            }
            catch (IOException error)
            {
                statusBar.Background = Brushes.IndianRed;
                tbStatusInformation.Text = error.Message;
            }

        }

        //--------------------------------------------------------------------------------FUNCIONES ASOCIADAS A EVENTOS---------------------------------------------------------------------------   

        /// <summary>
        /// Gestiona el timer, refrescando el combobox cada treinta segundos con los ticketsEnCurso y sus variaciones.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void timer_Tick(object sender, EventArgs e)
        {
            limpiarBarra();
            //en caso de cerrar el control paramos el timer
            if (this.Parent == null)
                timer.Stop();

            else
            {
                try
                {
                    listaTickets = Negocio.ObtenerTicketsEnCurso();
                    listaFiltradosPorUsuario.Clear();
                    foreach (TicketEnCurso tick in listaTickets.Where(x => x.IdUsuario == usuario.UsuarioId).ToList())
                        listaFiltradosPorUsuario.Add(tick);

                    listaTicketspendientes= Negocio.ObtenerResumenTicket((int)usuario.UsuarioId); 
                    if (listaTicketspendientes!=null)
                    {
                        lbInformacion.Visibility = Visibility.Collapsed;
                        cbTickets.IsEnabled = true;
                        imgEstado.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        lbInformacion.Visibility = Visibility.Visible;
                        imgEstado.Visibility = Visibility.Hidden;
                        cbTickets.IsEnabled = false;
                    }
                    cbTickets.ItemsSource = listaTicketspendientes;

                    if (listaFiltradosPorUsuario.Count != 0)
                    {
                        btValorar.Visibility = Visibility.Visible;
                        lvNotificaciones.Visibility = Visibility.Visible;
                        MostrarDetallesTicket();
                    }
                    else
                    {
                        lvNotificaciones.Visibility = Visibility.Hidden;
                        btValorar.Visibility = Visibility.Hidden;
                    }
                }
                catch (IOException error)
                {
                    statusBar.Background = Brushes.IndianRed;
                    tbStatusInformation.Text = error.Message;
                }
            } 
        }

       
        /// <summary>
        /// Gestiona el evento SelectionChanged, cuando selecciona un ticket muestra los detalles del mismo a traves de la función 
        /// <see cref="HomeTicketControl.MostrarDetallesTicket"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbTickets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            limpiarBarra();
            try
            {
                if (cbTickets.SelectedItem != null)
                {
                    MostrarDetallesTicket();
                }
                else
                {
                    lvNotificaciones.Visibility = Visibility.Hidden;
                }
            }
            catch (IOException error)
            {
                statusBar.Background = Brushes.IndianRed;
                tbStatusInformation.Text = error.Message;
            }
        }       


        /// <summary>
        /// Gestiona el evento MouseDown del Control object, permitiendo valorar un ticket a traves de 
        /// <see cref="valorarTicketModal"/>
        /// actualiza la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void BtValorar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var animacionClick = new DoubleAnimation();
            animacionClick.From = 1;
            animacionClick.To = 0;
            animacionClick.AutoReverse = true;
            animacionClick.Duration = TimeSpan.FromMilliseconds(500);
            btValorar.BeginAnimation(StackPanel.OpacityProperty, animacionClick);
            valorarTicketModal valorarModal = new valorarTicketModal(idTicket);
            try
            {
                valorarModal.ShowDialog();
                if (valorarModal.DialogResult == true)
                {
                    Negocio.ActualizarFechaRevision(new EstadoUsuario(usuario.UsuarioId, 1, DateTime.Now));
                    listaTickets = Negocio.ObtenerTicketsEnCurso().Where(x => x.IdUsuario == usuario.UsuarioId).ToList();
                    if (listaTickets.Count != 0)
                    {
                        bdValorar.Visibility = Visibility.Visible;
                        lvNotificaciones.Visibility = Visibility.Visible;
                        MostrarDetallesTicket();
                    }

                    else
                    {
                        bdValorar.Visibility = Visibility.Hidden;
                        lvNotificaciones.Visibility = Visibility.Hidden;
                    }
                    listaFiltradosPorUsuario.Clear();
                    foreach (TicketEnCurso tick in listaTickets.Where(x => x.IdUsuario == usuario.UsuarioId).ToList())
                        listaFiltradosPorUsuario.Add(tick);
                    listaTicketspendientes=Negocio.ObtenerResumenTicket((int)usuario.UsuarioId);
                    if (listaTicketspendientes!=null)
                    {
                        lbInformacion.Visibility = Visibility.Collapsed;
                        cbTickets.IsEnabled = true;
                        imgEstado.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        lbInformacion.Visibility = Visibility.Visible;
                        imgEstado.Visibility = Visibility.Hidden;
                        cbTickets.IsEnabled = false;
                    }
                    cbTickets.ItemsSource = listaTicketspendientes;
                    cbTickets.SelectedIndex = 0;


                }
            }
            catch (IOException error)
            {
                statusBar.Background = Brushes.IndianRed;
                tbStatusInformation.Text = error.Message + " valoración no guardada";
            }
        }

        //--------------------------------------------------------------------------------FUNCIONES AUXILIARES--------------------------------------------------------------------------   

        /// <summary>
        /// Reinicia la barra de estado a sus valores originales.
        /// </summary>
        public void limpiarBarra()
        {
            statusBar.Background = System.Windows.Media.Brushes.WhiteSmoke;
            tbStatusInformation.Text = "";
        }

        /// <summary>
        /// Permite mostrar de una manera visual un seguimiento del ticket, viendo si ha sido asignado, puesto en curso o finalizado
        /// Para ello hace uso de <see cref="Negocio.ObtenerInformacionTicket(ObservableCollection{TicketEnCurso}, int)"/>
        /// En caso de ser un ticket resuelto, también ofrece la fecha máxima de valoración antes de que el ticketEnCurso desaparezca.
        /// </summary>
        private void MostrarDetallesTicket()
        {
            limpiarBarra();
            try
            {
                lvNotificaciones.Visibility = Visibility.Visible;
                string idTicketSeleccionado = cbTickets.SelectedItem.ToString();
                string[] idTicketStringAuxiliar = idTicketSeleccionado.Split('.');
                idTicket = int.Parse(idTicketStringAuxiliar[0]);
                List<string> informacion = Negocio.ObtenerInformacionTicket(listaFiltradosPorUsuario, idTicket);
                lvNotificaciones.ItemsSource = informacion;
                switch (informacion.Count)
                {
                    case 1:
                        imgEstado.Source = new BitmapImage(new Uri(@"/Imagenes/creada.png", UriKind.Relative));
                        bdValorar.Visibility = Visibility.Hidden;
                        break;
                    case 2:
                        imgEstado.Source = new BitmapImage(new Uri(@"/Imagenes/asignada.png", UriKind.Relative));
                        bdValorar.Visibility = Visibility.Hidden;
                        break;
                    case 3:
                        imgEstado.Source = new BitmapImage(new Uri(@"/Imagenes/enCurso.png", UriKind.Relative));
                        bdValorar.Visibility = Visibility.Hidden;
                        break;
                    default:
                        imgEstado.Source = new BitmapImage(new Uri(@"/Imagenes/resuelta.png", UriKind.Relative));
                        bdValorar.Visibility = Visibility.Visible;
                        DateTime fechaLimite = (DateTime)Negocio.ObtenerTicket(idTicket).FechaResolucion;
                        tbFechaLimite.Text = fechaLimite.AddDays(4).ToString();
                        break;
                }
            }
            catch (IOException error)
            {
                statusBar.Background = Brushes.IndianRed;
                tbStatusInformation.Text = error.Message;
            }
        }

        private void BtActualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                listaTicketspendientes = Negocio.ObtenerResumenTicket((int)usuario.UsuarioId);
                if (listaTicketspendientes != null)
                {
                    lbInformacion.Visibility = Visibility.Collapsed;
                    cbTickets.IsEnabled = true;
                    imgEstado.Visibility = Visibility.Visible;
                    bdValorar.Visibility = Visibility.Visible;
                }
                else
                {
                    lbInformacion.Visibility = Visibility.Visible;
                    imgEstado.Visibility = Visibility.Hidden;
                    bdValorar.Visibility = Visibility.Hidden;
                    cbTickets.IsEnabled = false;
                }
                cbTickets.ItemsSource = listaTicketspendientes;
                if (listaTicketspendientes != null)
                    cbTickets.SelectedIndex = 0;
            }
            catch (IOException error)
            {
                statusBar.Background = Brushes.IndianRed;
                tbStatusInformation.Text = error.Message + " valoración no guardada";
            }
        }
    }
}
