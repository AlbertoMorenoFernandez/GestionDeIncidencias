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
using System.Windows.Shapes;
using Capa_Entidades;
using Capa_Presentacion.Utils;
using Capa_Negocio;
using System.Text.RegularExpressions;

namespace Capa_Presentacion.VentanasModales
{
    /// <summary>
    /// Lógica de interacción para CambiarPasswordModal.xaml
    /// Este control que se va a mostrar de forma modal en la aplicación, permite al usuario 
    /// el cambio de su contraseña, de acuerdo con las reglas de negocio.
    /// </summary>
    public partial class CambiarPasswordModal : Window
    {
        Usuario usuarioActual;

        public CambiarPasswordModal(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
        }

//---------------------------------------------------------------------FUNCIONES ASOCIADAS A EVENTOS -------------------------------------------------------------

        /// <summary>
        /// Asociado al evento click del botón cancelar permite cerrar la ventana modal y volver a la ventana de la aplicación
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// Asociada al evento click del botón "btCambiarPassword" permite cambiar la contraseña del usuario, por
        /// una contraseña que contenga al menos una mayúscula, un número y un caracter especial, con una longitud 
        /// de entre 8 y 12 caracteres.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtCambiarPassword_Click(object sender, RoutedEventArgs e)
        {
            string expresion;
            expresion = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,12}$";
            System.Text.RegularExpressions.Regex automata = new Regex(expresion);
            bool passwordCorrecto = automata.IsMatch(pwRepeat.Password);

            if (pwPassword.Password.Equals(pwRepeat.Password) && passwordCorrecto)
            {
                usuarioActual.Password = Utilidad.CalculateMD5Hash(pwPassword.Password);
                if (Negocio.EditarUsuario(usuarioActual))
                {
                    VentanaInformacion modal = new VentanaInformacion("Contraseña actualizada con éxito", "exito");
                    modal.ShowDialog();
                }
                else
                {
                    VentanaInformacion modal = new VentanaInformacion("Error al actualizar contraseña.", "advertencia");
                    modal.ShowDialog();
                }

            }
            else
            {
                string textoError;

                if (!passwordCorrecto)
                    textoError = "La contraseña debe tener al menos un digito, una mayúscula y un signo. Longitud permitida de 8 a 12 caracteres";
                else
                    textoError = "Las contraseñas no coinciden";

                VentanaInformacion modal = new VentanaInformacion(textoError, "advertencia");
                modal.ShowDialog();
            }
        }
    }
}
