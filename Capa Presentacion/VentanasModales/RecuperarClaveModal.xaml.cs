using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
using Capa_Presentacion.Utils;

namespace Capa_Presentacion
{
    /// <summary>
    /// Lógica de interacción para VentanaRecuperarClave.xaml
    /// Esta ventana permite al usuario restablecer su contraseña y que la aplicación automáticamente
    /// genere un e-mail y se lo mande con una clave aleatoria que el usuario después deberá cambiar,
    /// actualizando también los datos de la tabla "usuario"
    /// </summary>
    public partial class VentanaRecuperarClave : Window
    {
       
        public VentanaRecuperarClave()
        {
            InitializeComponent();
           
        }


        //-----------------------------------------------------------------------------FUNCIONES ASOCIADAS A EVENTOS------------------------------------------------------------------------

      
        /// <summary>
        /// Gestiona el evento Click de BtEnviar, permite mandar un mail al usuario con la contraseña generada de forma aleatoria
        /// <see cref="GenerarClaveAleatoria"/>
        /// Verífica el mail y si existe manda la contraseña y actualiza la base de datos "usuario".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtEnviar_Click(object sender, RoutedEventArgs e)
        {
            // Aquí en destinatario pondríamos destinatario=tbCorreo.Text;
            string destinatario = "usuario.alitec@outlook.es";
            string password = "Everis2020";                         //Aquí iria password del administrador(cuenta sólo para enviar contraseñas)
            string remitente = "gestor.alitec@outlook.es";          //Aquí iria dirección de correo del administrador.
            string gestorCorreo = "SMTP.Office365.com";             // Para cada gestor de correo es distinta


            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.To.Add(new MailAddress(destinatario));
            msg.Subject = "Información seleccionada";               //Evitamos poner clave, password... por si un filtro busca información.
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            string clave = GenerarClaveAleatoria();
            msg.Body = "Su nueva clave es: " + clave;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;
           
            msg.From = new MailAddress(remitente);
            
            //Desde correo de outlook funciona bien
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient(gestorCorreo, 587);
            NetworkCredential myCreds = new NetworkCredential(remitente, password);
            cliente.Credentials = myCreds;

            cliente.EnableSsl = true;

            try
            {
                Usuario usuario = Negocio.VerificarUsuario(tbCorreo.Text);
                if (usuario != null)
                {
                    if (Negocio.EditarUsuario(new Usuario(usuario.UsuarioId, Utilidad.CalculateMD5Hash(clave), usuario.Nombre, usuario.Apellidos, usuario.Extension, usuario.Mail, usuario.NumOficina, usuario.RolUsuario)))
                    {
                        VentanaInformacion modal = new VentanaInformacion("Su clave ha sido restablecida, siga las instrucciones recibidas en su correo electrónico", "exito");
                        modal.ShowDialog();
                    }
                    else
                    {
                        VentanaInformacion modal = new VentanaInformacion("Error al restablecer la clave, reintentelo de nuevo.", "advertencia");
                        modal.ShowDialog();
                    }
                    cliente.Send(msg);
                }

                else
                {
                    VentanaInformacion modal = new VentanaInformacion("El email introducido no es válido", "advertencia");
                    modal.ShowDialog();
                }
                   

                
            }
            catch(IOException)
            {
                VentanaInformacion modal = new VentanaInformacion("Error al acceder a la base de datos, base de datos no actualizada.", "advertencia");
                modal.ShowDialog();
            }
            catch(Exception )
            {
                VentanaInformacion modal = new VentanaInformacion("Error al enviar el e-mail, revise su conexión.", "advertencia");
                modal.ShowDialog();
            }
        }
        /// <summary>
        /// Controla el evento click del boton btClose, permite cerrar la ventana VentanaRecuperarClave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        ///  Controla el evento click del boton btClose, permite cerrar la ventana VentanaRecuperarClave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



        //----------------------------------------------------------------------------------FUNCIONES AUXILIARES------------------------------------------------------------------------
        /// <summary>
        /// Genera una clave aleatoria formada por dos letras, un número, una tercera letra y un signo
        /// <example>
        ///  string clave= GenerarClaveAleatoria();
        ///  System.out.println(clave);
        ///  -----------------------------
        ///  Ahj4!
        /// </example>
        /// </summary>
        /// <returns>Clave generada en formato string</returns>
        private string GenerarClaveAleatoria()
        {
            Random random = new Random(Environment.TickCount);
            int aleatorio = random.Next(65, 91);  //mayúsculas 
            char letra1 = (char)aleatorio;
            aleatorio = random.Next(97, 123);     //minúsculas
            char letra2 = (char)aleatorio;
            aleatorio = random.Next(48, 58);     //números   
            char numero1 = (char)aleatorio;
            aleatorio = random.Next(97, 123);   //minúsculas
            char letra3 = (char)aleatorio;
            aleatorio = random.Next(35, 39);    //carácteres especiales
            char signo = (char)aleatorio;
            aleatorio = random.Next(97, 123);     //minúsculas
            char letra4 = (char)aleatorio;
            aleatorio = random.Next(97, 123);     //minúsculas
            char letra5 = (char)aleatorio;
            aleatorio = random.Next(97, 123);     //minúsculas
            char letra6 = (char)aleatorio;





            string clave= "" + letra1 + letra2 + numero1 + letra3 + signo+letra4+letra5+letra6;
            return clave;
        }
    }
}
