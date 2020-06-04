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
using System.Net;
using System.Net.Mail;
using Capa_Presentacion.Utils;
using System.Configuration;
using System.IO;

namespace Capa_Presentacion
{
 
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// Va a permitir identificar al usuario y en caso de no recordar la contraseña, hacerle llegar una por correo electrónico.
    /// </summary>
    public partial class MainWindow : Window
    {
        private int intentos = 0;
        private const int INTENTOS_PERMITIDOS = 3;
        private bool baseDeDatosOffline;
      
        public MainWindow()
        {
            InitializeComponent();  
        }

        /// <summary>
        /// Gestiona el evento click del botón ingresar, verifica que el correo electrónico y el password 
        /// introducidos en los textbox existan en la base de datos, en caso de no existir, permite hasta
        /// un máximo de tres intentos, sino se autentica muestra un mensaje de advertencia y cierra la 
        /// aplicación. En caso de ser correcto, comprueba el rol y abre la ventana correspondiente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btIngresar_Click(object sender, RoutedEventArgs e)
        {
            IngresarSistema();  
        }


        /// <summary>
        /// Comprueba usuario y contraseña haciendo uso de <see cref="Negocio.VerificarLogin(string, string)"/>
        /// En caso de ser un usuario correcto, determina su rol y en función de él abre la aplicación en modo "cliente", "técnico" o
        /// "administrador". En caso de ingresar tres veces mál la contraseña, muestra un error y cierra la aplicación.
        /// </summary>
        private void IngresarSistema()
        {

            Usuario user = null;
            baseDeDatosOffline = false;

            try
            {
                user = Negocio.VerificarLogin(tbCorreo.Text, Utilidad.CalculateMD5Hash(tbPassword.Password.ToString()));
            }
            catch (IOException e)
            {
                baseDeDatosOffline = true;
                VentanaInformacion modal = new VentanaInformacion(e.Message, "advertencia");
                modal.ShowDialog();
            }
            if (user != null)
            {
                switch (user.RolUsuario)
                {
                    case (int)RolUsuario.cliente:
                        VentanaCliente cliente = new VentanaCliente(user);
                        cliente.Owner = this;
                        this.Visibility = Visibility.Hidden;
                        cliente.Show();
                        break;
                    case (int)RolUsuario.tecnico:
                        VentanaTecnico tecnico = new VentanaTecnico(user);
                        tecnico.Owner = this;
                        this.Visibility = Visibility.Hidden;
                        tecnico.Show();
                        break;
                    case (int)RolUsuario.gerente:
                        VentanaGerente gerente = new VentanaGerente(user);
                        gerente.Owner = this;
                        this.Visibility = Visibility.Hidden;
                        gerente.Show();
                        break;
                    case (int)RolUsuario.administrador:
                        VentanaAdministrador principal = new VentanaAdministrador(user);
                        principal.Owner = this;
                        this.Visibility = Visibility.Hidden;
                        principal.Show();
                        break;
                    default:
                        MessageBox.Show("No hay contenido para este tipo de usuario");
                        break;
                }
            }
            else
            {
                if (!baseDeDatosOffline)
                {
                    intentos++;
                    if (intentos < INTENTOS_PERMITIDOS)
                    {
                        VentanaInformacion modal = new VentanaInformacion("Usuario o password erróneos, intento " + intentos + " de " + INTENTOS_PERMITIDOS + ".", "advertencia");
                        modal.ShowDialog();
                    }
                    else
                    {
                        VentanaInformacion modal = new VentanaInformacion("Número de intentos, superados", "advertencia");
                        modal.ShowDialog();
                        this.Close();
                    }

                }
            }
        }

        /// <summary>
        /// Damos al textbox apariencia de hypervinculo, cuando se detecta el ratón sobre él cambiamos el cursor al cursor
        /// con forma de mano.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbRecuperar_MouseEnter(object sender, MouseEventArgs e)
        {
            tbRecuperar.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// Asociado al evento mouseDown del textblock "tbRecuperar" permite recuperar la clave en caso de haberla perdido
        /// a través de <see cref="VentanaRecuperarClave"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbRecuperar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            VentanaRecuperarClave ventanaModal = new VentanaRecuperarClave();
            ventanaModal.ShowDialog();
        }

     
        /// <summary>
        /// Asociada al evento click del botón "btClose" permite  cerrar la aplicación mostrando antes un mensaje de confirmación
        /// <see cref="ConfirmarSalir"/>
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
        /// Permite miniminzar la ventana.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtMinimizar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }


        /// <summary>
        /// Permite una vez introducida la contraseña  intentar acceder a la aplicación pulsando la tecla "Enter" sin tener que hacer
        /// click en el botón, mejora la usabilidad del progarma.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                IngresarSistema();
        }

        private void BarraSistema_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch { }
        }
    }
}
