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
using System.Windows.Shapes;
using System.Windows.Threading;
using Capa_Entidades;
using Capa_Negocio;
using Capa_Presentacion.UserControls;
using Capa_Presentacion.VentanasModales;

namespace Capa_Presentacion
{
    /// <summary>
    /// Lógica de interacción para VentanaAdministrador.xaml
    /// </summary>
    public partial class VentanaAdministrador : Window
    {
        DispatcherTimer timer;
        SoundPlayer sonido;
      
        List<string> listaNotificaciones = new List<string>();
        Usuario usuarioVentana;
        int notificiacionesNoLeidas = 0;
        List<TicketEnCurso> listaTickets = new List<TicketEnCurso>();
        ObservableCollection<TicketEnCurso> filtrados = new ObservableCollection<TicketEnCurso>();
        StackPanel principal;
        VentanaActivaSingleton panelActual;
        const int TIEMPODEACTUALIZACION = 30;

        public VentanaAdministrador()
        {
            InitializeComponent();
        }
        public VentanaAdministrador(Usuario user)
        {
            InitializeComponent();
            btSonido.IsChecked = Properties.Settings.Default.Sound;
            try
            {
                ticketsPendientescontrol contenido = new ticketsPendientescontrol();
                panelActual = VentanaActivaSingleton.Instancia;

                principal = (StackPanel)panelPrincipal;
                principal.Children.Insert(0, contenido);
                panelActual.VentanaActiva = "ticketsPendientescontrol";

                tbNombre.Text = user.Nombre+" "+user.Apellidos;
                tbMail.Text = user.Mail;
                tbRol.Text = Negocio.ObtenerRol((int)user.RolUsuario).Nombre;
                usuarioVentana = user;


                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(TIEMPODEACTUALIZACION);
                timer.Tick += timer_Tick;
                timer.Start();
                AnimarMail();

                listaTickets = Negocio.ObtenerTicketsEnCurso();
                filtrados.Clear();
                foreach (TicketEnCurso tick in listaTickets)
                    filtrados.Add(tick);

                listaNotificaciones = Negocio.ObtenerNotificacionesClientes(filtrados, (int)user.UsuarioId, "administrador");
                if (listaNotificaciones.Count != 0)
                {
                    tbNumNotifi.Text = "" + listaNotificaciones.Count;
                    notificiacionesNoLeidas = listaNotificaciones.Count;
                }

            }
            catch (IOException error)
            {
                gestionarBarra(Brushes.IndianRed, error.Message);

            }

        }



        //--------------------------------------------------------------------------------FUNCIONES ASOCIADAS A EVENTOS---------------------------------------------------------------------------   

        void timer_Tick(object sender, EventArgs e)
        {
            gestionarBarra(Brushes.WhiteSmoke, "");

            try
            {
                listaTickets = Negocio.ObtenerTicketsEnCurso();
                filtrados.Clear();
                foreach (TicketEnCurso tick in listaTickets)
                    filtrados.Add(tick);

                listaNotificaciones = Negocio.ObtenerNotificacionesClientes(filtrados, (int)usuarioVentana.UsuarioId, "administrador");
                if (listaNotificaciones.Count != notificiacionesNoLeidas)
                {
                    notificiacionesNoLeidas = listaNotificaciones.Count;
                    AnimarMail();
                    tbNumNotifi.Text = "" + listaNotificaciones.Count;
                    if (btSonido.IsChecked == true)
                    {
                        sonido = new SoundPlayer(AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\", "") + "Sonidos\\notificacion.wav");
                        sonido.Play();
                    }
                    
                }

            }
            catch (IOException error)
            {
                gestionarBarra(Brushes.IndianRed, error.Message);

            }

        }

        private void BtNotificaciones_Click(object sender, RoutedEventArgs e)
        {
            VerNotificacionesModal nueva = new VerNotificacionesModal(listaNotificaciones);

            nueva.ShowDialog();
            try
            {
                if (nueva.DialogResult == true)
                {
                    Negocio.ActualizarFechaRevision(new EstadoUsuario(usuarioVentana.UsuarioId, 1, DateTime.Now));
                    notificiacionesNoLeidas = 0;
                    tbNumNotifi.Text = "0";
                    listaNotificaciones = Negocio.ObtenerNotificacionesClientes(filtrados, (int)usuarioVentana.UsuarioId, "administrador");
                }
            }
            catch (IOException error)
            {
                gestionarBarra(Brushes.IndianRed, error.Message+ " Posible error en fecha de último conexión de usuario.");

            }
        }

        private void BtClose_Click(object sender, RoutedEventArgs e)
        {
            ConfirmarSalir salir = new ConfirmarSalir();
            salir.ShowDialog();
            if (salir.DialogResult == true)
                this.Close();
        }

        private void BtMinimizar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }


        private void LvMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
                {
                    case "lvTickets":
                        ticketsPendientescontrol contenido = new ticketsPendientescontrol();
                        principal.Children.Clear();
                        principal.Children.Insert(0, contenido);
                        panelActual.VentanaActiva = "ticketsPendientescontrol";
                        break;
                    case "lvCrear":
                        CrearTicketsAdminControl contenido2 = new CrearTicketsAdminControl(usuarioVentana.UsuarioId);
                        principal.Children.Clear();
                        principal.Children.Insert(0, contenido2);
                        panelActual.VentanaActiva = "CrearTicketsAdminControl";
                        break;
                    case "lvEditar":
                        EditarTicketsAdminControl contenido9 = new EditarTicketsAdminControl(usuarioVentana);
                        principal.Children.Clear();
                        principal.Children.Insert(0, contenido9);
                        panelActual.VentanaActiva = "EditarTicketsAdminControl";
                        break;
                    case "lvUsuarios":
                        UsuariosControl controlUsuario = new UsuariosControl();
                        panelPrincipal.Children.Clear();
                        panelPrincipal.Children.Insert(0, controlUsuario);
                        panelActual.VentanaActiva = "UsuariosControl";
                        break;

                    case "lvSedes":
                        SedesControl controlUsuario1 = new SedesControl();
                        panelPrincipal.Children.Clear();
                        panelPrincipal.Children.Insert(0, controlUsuario1);
                        panelActual.VentanaActiva = "SedesControl";
                        break;
                    case "lvCategorias":
                        CategoriasControl contenido5 = new CategoriasControl();
                        principal.Children.Clear();
                        principal.Children.Insert(0, contenido5);
                        panelActual.VentanaActiva = "CategoriasControl";
                        break;

                    case "lvCiudades":
                        LocalidadesControl contenido6 = new LocalidadesControl();
                        principal.Children.Clear();
                        principal.Children.Insert(0, contenido6);
                        panelActual.VentanaActiva = "LocalidadesControl";
                        break;

                    case "lvEquipos":
                        EquiposControl contenido7 = new EquiposControl();
                        principal.Children.Clear();
                        principal.Children.Insert(0, contenido7);
                        panelActual.VentanaActiva = "EquiposControl";
                        break;

                }
            }
            catch (IOException error)
            {
                gestionarBarra(Brushes.IndianRed, error.Message);

            }
        }

        private void BtSonido_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtCambiarPassword_Click(object sender, RoutedEventArgs e)
        {
            CambiarPasswordModal modal = new CambiarPasswordModal(usuarioVentana);
            modal.ShowDialog();
        }
        private void BarraSistema_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch { }
        }

        private void BtSonido_Checked(object sender, RoutedEventArgs e)
        {
            if (btSonido.IsChecked == true)
            {
                Properties.Settings.Default.Sound = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.Sound = false;
                Properties.Settings.Default.Save();
            }
        }

        //--------------------------------------------------------------------------------FUNCIONES AUXILIARES---------------------------------------------------------------------------   

        private void gestionarBarra(Brush color, string error)
        {
            switch (panelActual.VentanaActiva)
            {

                
                case "TicketTecnicoControl":
                    TicketTecnicoControl control25 = (TicketTecnicoControl)principal.Children[0];
                    control25.statusBar.Background = color;
                    control25.tbStatusInformation.Text = error;
                    break;
                case "GestionarTecnicoTicketcontrol":
                    GestionarTecnicoTicketControl control24 = (GestionarTecnicoTicketControl)principal.Children[0];
                    control24.statusBar.Background = color;
                    control24.tbStatusInformation.Text = error;
                    break;
                case "GestionarTicketsAdminControl":
                    GestionarTicketsAdminControl control23 = (GestionarTicketsAdminControl)principal.Children[0];
                    control23.statusBar.Background = color;
                    control23.tbStatusInformation.Text = error;
                    break;
                case "HomeTicketControl":
                    HomeTicketControl control22 = (HomeTicketControl)principal.Children[0];
                    control22.statusBar.Background = color;
                    control22.tbStatusInformation.Text = error;
                    break;
                case "CrearCodigoBarrasControl":
                    CrearCodigoBarrasContorl control20 = (CrearCodigoBarrasContorl)principal.Children[0];
                    control20.statusBar.Background = color;
                    control20.tbStatusInformation.Text = error;
                    break;
                case "CrearTicketControl":
                    CrearTicketControl control21 = (CrearTicketControl)principal.Children[0];
                    control21.statusBar.Background = color;
                    control21.tbStatusInformation.Text = error;
                    break;
                case "ticketsPendientescontrol":
                    ticketsPendientescontrol control1 = (ticketsPendientescontrol)principal.Children[0];
                    control1.statusBar.Background = color;
                    control1.tbStatusInformation.Text = error;
                    break;
                case "CrearTicketsAdminControl":
                    CrearTicketsAdminControl control = (CrearTicketsAdminControl)principal.Children[0];
                    control.statusBar.Background = color;
                    control.tbStatusInformation.Text = error;
                    break;
                case "VerHistoricoTicketsControl":
                    VerHistoricoTicketsControl control2 = (VerHistoricoTicketsControl)principal.Children[0];
                    control2.statusBar.Background = color;
                    control2.tbStatusInformation.Text = error;
                    break;
                case "EditarTicketsAdminControl":
                    EditarTicketsAdminControl control3 = (EditarTicketsAdminControl)principal.Children[0];
                    control3.statusBar.Background = color;
                    control3.tbStatusInformation.Text = error;
                    break;
                case "UsuariosControl":
                    UsuariosControl control4 = (UsuariosControl)principal.Children[0];
                    control4.statusBar.Background = color;
                    control4.tbStatusInformation.Text = error;
                    break;
                case "SedesControl":
                    SedesControl control5 = (SedesControl)principal.Children[0];
                    control5.statusBar.Background = color;
                    control5.tbStatusInformation.Text = error;
                    break;
                case "LocalidadesControl":
                    LocalidadesControl control6 = (LocalidadesControl)principal.Children[0];
                    control6.statusBar.Background = color;
                    control6.tbStatusInformation.Text = error;
                    break;
              case "CategoriasControl":
                    CategoriasControl control7 = (CategoriasControl)principal.Children[0];
                    control7.statusBar.Background = color;
                    control7.tbStatusInformation.Text = error;
                    break;
                case "EquiposControl":
                    EquiposControl control8= (EquiposControl)principal.Children[0];
                    control8.statusBar.Background = color;
                    control8.tbStatusInformation.Text = error;
                    break;

            }
        }
        private void AnimarMail()
        {
            var showAnimation = new DoubleAnimation();
            showAnimation.From = 40;
            showAnimation.To = 0;
            showAnimation.AutoReverse = true;
            showAnimation.Duration = TimeSpan.FromSeconds(1);
            btNotificaciones.BeginAnimation(Image.WidthProperty, showAnimation);
        }



    }
}
