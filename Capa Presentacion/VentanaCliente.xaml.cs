using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
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
    /// Lógica de interacción para VentanaUsuario.xaml
    /// </summary>
    public partial class VentanaCliente : Window
    {
        StackPanel principal;
        DispatcherTimer timer;
        SoundPlayer sonido;
 
        List<string> listaNotificaciones = new List<string>();
        Usuario usuarioCliente;
        int notificiacionesNoLeidas = 0;
        List<TicketEnCurso> listaTickets = new List<TicketEnCurso>();
        ObservableCollection<TicketEnCurso> filtrados = new ObservableCollection<TicketEnCurso>();
        const int TIEMPO_DE_ACTUALIZACION = 30;
        VentanaActivaSingleton panelActual;

        public VentanaCliente(Usuario user)
        {
            InitializeComponent();

            btSonido.IsChecked= Properties.Settings.Default.Sound;

            principal = (StackPanel)panelPrincipal;
            usuarioCliente = user;
            panelActual = VentanaActivaSingleton.Instancia;
            HomeTicketControl contenido = new HomeTicketControl(user);
            principal.Children.Add(contenido);
            panelActual.VentanaActiva = "HomeTicketControl";

            try
            {
                tbNombre.Text = usuarioCliente.Nombre + " " + usuarioCliente.Apellidos;
                tbRol.Text = Negocio.ObtenerRol((int)usuarioCliente.RolUsuario).Nombre;
                tbMail.Text = usuarioCliente.Mail;

                //Creamos temporizador para las notificaciones.
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(TIEMPO_DE_ACTUALIZACION);
                timer.Tick += timer_Tick;
                timer.Start();

                AnimarMail();

                listaTickets = Negocio.ObtenerTicketsEnCurso();
                filtrados.Clear();
                foreach (TicketEnCurso tick in listaTickets.Where(x => x.IdUsuario == usuarioCliente.UsuarioId).ToList())
                    filtrados.Add(tick);

                listaNotificaciones = Negocio.ObtenerNotificacionesClientes(filtrados, (int)usuarioCliente.UsuarioId, "cliente");
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


        //----------------------------------------------------------------FUNCIONES ASOCIADAS A EVENTOS----------------------------------------------------------------------------------------

        /// <summary>
        /// Temporizador que controla si se han recibido notificaciones nuevas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        void timer_Tick(object sender, EventArgs e)
        {
            gestionarBarra(Brushes.WhiteSmoke, "");
            try
            {
                listaTickets = Negocio.ObtenerTicketsEnCurso();
                filtrados.Clear();
                foreach (TicketEnCurso tick in listaTickets.Where(x => x.IdUsuario == usuarioCliente.UsuarioId).ToList())
                    filtrados.Add(tick);

                listaNotificaciones = Negocio.ObtenerNotificacionesClientes(filtrados, (int)usuarioCliente.UsuarioId, "cliente");
                if (listaNotificaciones.Count != notificiacionesNoLeidas)
                {
                    notificiacionesNoLeidas = listaNotificaciones.Count;
                    AnimarMail();
                    tbNumNotifi.Text = "" + listaNotificaciones.Count;
                    if(btSonido.IsChecked == true){
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

        /// <summary>
        /// Gestiona el evento click del botón de notificaciones que permite visualizar las notificaciones que tiene el usuario de la aplicación
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtNotificaciones_Click(object sender, RoutedEventArgs e)
        {
            VerNotificacionesModal nueva = new VerNotificacionesModal(listaNotificaciones);

            try
            {
                nueva.ShowDialog();
                if (nueva.DialogResult == true)
                {
                    Negocio.ActualizarFechaRevision(new EstadoUsuario(usuarioCliente.UsuarioId, 1, DateTime.Now));
                    notificiacionesNoLeidas = 0;
                    tbNumNotifi.Text = "0";
                    listaNotificaciones = Negocio.ObtenerNotificacionesClientes(filtrados, (int)usuarioCliente.UsuarioId, "cliente");
                }
            }
            catch (IOException error)
            {
                gestionarBarra(Brushes.IndianRed, error.Message);
            }

        }

        /// <summary>
        /// Permite cerrar la aplicación, gestiona el evento click del btCLose
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtClose_Click(object sender, RoutedEventArgs e)
        {
            ConfirmarSalir salir = new ConfirmarSalir();
            salir.ShowDialog();
            if (salir.DialogResult == true)
                this.Close();
        }

        /// <summary>
        /// Permite minimizar la aplicación, gestiona el evento click de la 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtMinimizar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// Comprueba cambios en la seleccion del listview lvMenu, para abrir el usercontrol correspondiente según la opción elegida por el usuario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LvMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
                {
                    case "lvHome":
                        HomeTicketControl contenido = new HomeTicketControl(usuarioCliente);
                        principal.Children.Insert(1, contenido);
                        principal.Children.RemoveAt(0);
                        panelActual.VentanaActiva = "HomeTicketControl";
                        break;
                    case "lvCrear":
                        CrearTicketControl contenido2 = new CrearTicketControl(usuarioCliente);
                        principal.Children.Insert(1, contenido2);
                        principal.Children.RemoveAt(0);
                        panelActual.VentanaActiva = "CrearTicketControl";
                        break;
                    case "lvVer":
                        VerHistoricoTicketsControl contenido3 = new VerHistoricoTicketsControl(usuarioCliente);
                        principal.Children.Insert(1, contenido3);
                        principal.Children.RemoveAt(0);
                        panelActual.VentanaActiva = "VerHistoricoTicketsControl";
                        break;
                }
            }
            catch (IOException error)
            {
                gestionarBarra(Brushes.IndianRed,error.Message);

            }
        }

        /// <summary>
        /// Asociado al evento click de "btCambiarPassword" situado en el menú desplegable de la ventana,
        /// permite el cambio de contraseña haciendo uso de <see cref="CambiarPasswordModal"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtCambiarPassword_Click(object sender, RoutedEventArgs e)
        {
            CambiarPasswordModal modal = new CambiarPasswordModal(usuarioCliente);
            modal.ShowDialog();
        }


        /// <summary>
        /// Asociado al evento click de "btSonido" situado en el menú desplegable de la ventana, permite activar o 
        /// desactivar el sonido de las notificaciones de la aplicación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtSonido_Click(object sender, RoutedEventArgs e)
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

        /// <summary>
        /// Asociado al evento mousedownd de la barra de sistema de la aplicación permite desplazarla por el escritorio a otra posición.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BarraSistema_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch { }
        }

        //-------------------------------------------------------------------FUNCIONES AUXILIARES------------------------------------------------------------------------------------------

        /// <summary>
        /// Permite gestionar la barra de estado de la aplicación, mostrando errores relacionados con el acceso a  la base de datos.
        /// </summary>
        /// <param name="color"></param>
        /// <param name="error"></param>
        private void gestionarBarra(Brush color,string error)
        {
            switch (panelActual.VentanaActiva)
            {
                case "HomeTicketControl":
                    HomeTicketControl control1 = (HomeTicketControl)principal.Children[0];
                    control1.statusBar.Background = color;
                    control1.tbStatusInformation.Text = error;
                    break;
                case "CrearTicketControl":
                    CrearTicketControl control = (CrearTicketControl)principal.Children[0];
                    control.statusBar.Background = color;
                    control.tbStatusInformation.Text = error;
                    break;
                case "VerHistoricoTicketsControl":
                    VerHistoricoTicketsControl control2 = (VerHistoricoTicketsControl)principal.Children[0];
                    control2.statusBar.Background = color;
                    control2.tbStatusInformation.Text = error;
                    break;
            }
        }
        
        /// <summary>
        /// Crea una animación en el botón de notificaciones, cambiando su tamaño y emitiendo un sonido
        /// para que el usuario pueda percibir que se han recibido notificaciones nuevas.
        /// </summary>
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
