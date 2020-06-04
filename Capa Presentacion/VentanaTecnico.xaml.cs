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
    /// Lógica de interacción para VentanaTecnico.xaml
    /// </summary>
    public partial class VentanaTecnico : Window
    {
        StackPanel principal;
        DispatcherTimer timer;
        SoundPlayer sonido;

        List<string> listaNotificaciones = new List<string>();
        Usuario usuarioTecnico;
        Tecnico tecnico;
        int notificiacionesNoLeidas = 0;
        List<TicketEnCurso> listaTickets = new List<TicketEnCurso>();
        ObservableCollection<TicketEnCurso> filtrados = new ObservableCollection<TicketEnCurso>();
        const int TIEMPODEACTUALIZACION= 30;                                                                                    //Tiempo de actualización de las notificaciones.
        public string controlSeleccionado;
        VentanaActivaSingleton panelActual;
        public VentanaTecnico(Usuario user)
        {
            InitializeComponent();

            btSonido.IsChecked = Properties.Settings.Default.Sound;
            try
            {
                tecnico = Negocio.ObtenerTecnico((int)user.UsuarioId);

                principal = (StackPanel)panelPrincipal;

                usuarioTecnico = user;

                controlSeleccionado = "TicketTecnicoControl";
                panelActual = VentanaActivaSingleton.Instancia;
                TicketTecnicoControl contenido = new TicketTecnicoControl(tecnico);
                principal.Children.Add(contenido);
                panelActual.VentanaActiva = "TicketTecnicoControl";



                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(TIEMPODEACTUALIZACION);
                timer.Tick += timer_Tick;
                timer.Start();
                AnimarMail();

                tbNombre.Text = usuarioTecnico.Nombre + " " + usuarioTecnico.Apellidos;


                tbRol.Text = Negocio.ObtenerRol((int)usuarioTecnico.RolUsuario).Nombre;
                tbMail.Text = usuarioTecnico.Mail;
                listaTickets = Negocio.ObtenerTicketsEnCurso();
                filtrados.Clear();
                foreach (TicketEnCurso tick in listaTickets.Where(x => x.IdTecnico == tecnico.IdTecnico).ToList())
                    filtrados.Add(tick);

                listaNotificaciones = Negocio.ObtenerNotificacionesClientes(filtrados, (int)user.UsuarioId, "tecnico");

                if (listaNotificaciones.Count != 0)
                {
                    tbNumNotifi.Text = "" + listaNotificaciones.Count;
                    notificiacionesNoLeidas = listaNotificaciones.Count;
                }

            }
            catch (IOException e)
            {
                gestionarBarra(Brushes.IndianRed, e.Message);
            }

        }


        //-----------------------------------------------------------------------------FUNCIONES ASOCIADAS A EVENTOS--------------------------------------------------------------------
        /// <summary>
        /// Comprueba cambios en la seleccion del listview lvMenu, para abrir el usercontrol correspondiente según la opción elegida por el usuario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LvMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "lvMisTickets":
                    principal.Children.Clear();
                    TicketTecnicoControl contenido = new TicketTecnicoControl(tecnico);
                    principal.Children.Insert(0, contenido);
                    panelActual.VentanaActiva = "TicketTecnicoControl";
                    break;
                case "lvEtiquetas":
                    CrearCodigoBarrasContorl contenido2 = new CrearCodigoBarrasContorl();
                    principal.Children.Clear();
                    principal.Children.Insert(0, contenido2);
                    panelActual.VentanaActiva = "CrearCodigoBarrasControl";
                    break;
                
            }
        }

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
                foreach (TicketEnCurso tick in listaTickets.Where(x => x.IdTecnico == tecnico.IdTecnico).ToList())
                    filtrados.Add(tick);

                listaNotificaciones = Negocio.ObtenerNotificacionesClientes(filtrados, (int)usuarioTecnico.UsuarioId, "tecnico");
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
                    Negocio.ActualizarFechaRevision(new EstadoUsuario(usuarioTecnico.UsuarioId, 1, DateTime.Now));

                    notificiacionesNoLeidas = 0;
                    tbNumNotifi.Text = "0";
                    listaNotificaciones = Negocio.ObtenerNotificacionesClientes(filtrados, (int)usuarioTecnico.UsuarioId, "cliente");
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



        private void BtCambiarPassword_Click(object sender, RoutedEventArgs e)
        {
            CambiarPasswordModal modal = new CambiarPasswordModal(usuarioTecnico);
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
        //---------------------------------------------------------------------FUNCIONES AUXILIARES-------------------------------------------------------------------------------------


        private void gestionarBarra(Brush color, string error)
        {
            switch (panelActual.VentanaActiva)
            {
                case "TicketTecnicoControl":
                    TicketTecnicoControl control1 = (TicketTecnicoControl)principal.Children[0];
                    control1.statusBar.Background = color;
                    control1.tbStatusInformation.Text = error;
                    break;
                case "CrearCodigoBarrasControl":
                    CrearCodigoBarrasContorl control = (CrearCodigoBarrasContorl)principal.Children[0];
                    control.statusBar.Background = color;
                    control.tbStatusInformation.Text = error;
                    break;
                case "GestionarTecnicoTicketControl":
                    GestionarTecnicoTicketControl control2 = (GestionarTecnicoTicketControl)principal.Children[0];
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
