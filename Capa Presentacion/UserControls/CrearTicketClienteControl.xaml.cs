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
    /// Lógica de interacción para CrearTicketControl.xaml
    /// </summary>
    public partial class CrearTicketControl : UserControl
    {
        bool equipoSinEtiqueta = false;
        bool equipoIdentificado = false;
       
        List<string> listaNotificaciones = new List<string>();
        Usuario usuario;
        VentanaActivaSingleton panelActual;

        public CrearTicketControl(Usuario user)
        {
            InitializeComponent();
            panelActual = VentanaActivaSingleton.Instancia;
            panelActual.VentanaActiva = "CrearTicketControl";
            limpiarBarra();

            usuario = user;
        }

        //--------------------------------------------------------------------------------FUNCIONES ASOCIADAS A EVENTOS---------------------------------------------------------------------------   
      
        /// <summary>
        ///  Gestiona el evento click del botón "btSearch", verifica que el equipo introducido exista en la base de datos
        ///  en caso de que exista muestra una imagen de que el equipo ha sido correctamente verificado y en caso de no 
        ///  existir muestra una imagen de error..
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtSearch_Click(object sender, RoutedEventArgs e)
        {
            limpiarBarra();
            try
            {
                Equipo equipo = Negocio.ObtenerEquipo(tbServiceTag.Text);
                if (equipo == null)
                {
                    imgResultadoBusqueda.Visibility = Visibility.Visible;
                    imgResultadoBusqueda.Source = new BitmapImage(new Uri(@"/Imagenes/noOk.png", UriKind.Relative));
                    equipoIdentificado = false;
                }

                else
                {
                    imgResultadoBusqueda.Visibility = Visibility.Visible;
                    imgResultadoBusqueda.Source = new BitmapImage(new Uri(@"/Imagenes/ok.png", UriKind.Relative));
                    equipoIdentificado = true;
                }
            }
            catch (IOException error)
            {
                statusBar.Background = Brushes.IndianRed;
                tbStatusInformation.Text = error.Message;
            }
        }

        /// <summary>
        /// Asegura que el icono que muestra si el equipo es válido sólo aparezca cuando se pulse sobre él y 
        /// que desaparezca cuando volvamos a escribir en el textbox otro equipo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbServiceTag_TextChanged(object sender, TextChangedEventArgs e)
        {
            imgResultadoBusqueda.Visibility = Visibility.Hidden;
        }

       
        /// <summary>
        /// Gestiona el evento click del botón btCrear, para crear un ticket en caso de que se produzca y actualizar la base de datos.
        /// a)sinEtiqueta=true  ->  se crea un ticket con idEquipo=null
        /// b)sinEtiqueta=false -> se crea un ticket con idEquipo=tbServiceTag.Text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtCrear_Click(object sender, RoutedEventArgs e)
        {
            limpiarBarra();
            try
            {
                if (equipoSinEtiqueta)
                {
                    if (Negocio.CrearTicket(new Ticket(0, null, usuario.UsuarioId, DateTime.Now, null, tbDescripcion.Text, "", 1, null, null, "", null, "")))
                    {
                        VentanaInformacion modal = new VentanaInformacion("Ticket creado con éxito.", "exito");
                        modal.ShowDialog();

                    }
                    else
                    {
                        VentanaInformacion modal = new VentanaInformacion("Error al crear ticket", "advertencia");
                        modal.ShowDialog();
                    }
                }
                else
                {
                    if (equipoIdentificado)
                    {
                        if (!Negocio.verificarTicketDuplicado(tbServiceTag.Text))
                        {
                            if (Negocio.CrearTicket(new Ticket(0, tbServiceTag.Text, usuario.UsuarioId, DateTime.Now, null, tbDescripcion.Text, null, 1, null, null, null, null, null)))
                            {
                                VentanaInformacion modal = new VentanaInformacion("Ticket creado con éxito.", "exito");
                                modal.ShowDialog();
                            }
                            else
                            {
                                VentanaInformacion modal = new VentanaInformacion("Error al crear ticket", "advertencia");
                                modal.ShowDialog();
                            }
                        }
                        else
                        {
                            VentanaInformacion modal = new VentanaInformacion("El equipo indicado ya tiene un ticket activo.", "advertencia");
                            equipoIdentificado = false;
                            modal.ShowDialog();
                        }

                    }
                    else
                    {
                        VentanaInformacion modal = new VentanaInformacion("SERVICE TAG no verificado, realice comprobación.", "advertencia");
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
        /// Gestiona el evento checked del checkbox chbEquipo para verificar si el usuario desea abrir un ticket sin introducir la etiqueta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChbEquipo_Checked(object sender, RoutedEventArgs e)
        {
            limpiarBarra();
            equipoSinEtiqueta = true;
        }

        /// <summary>
        /// Gestiona el evento Unchecked de checkbox ChbEquipo para verificar si el usuario desea abrir un ticket introduciendo  la etiqueta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChbEquipo_Unchecked(object sender, RoutedEventArgs e)
        {
            limpiarBarra();
            equipoSinEtiqueta = false;
        }

        /// <summary>
        /// Gestiona el evento MouseDown de ImgHelp de forma que muestra una ayuda de como usar el control al pulsarlo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImgHelp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            limpiarBarra();
            if (panelAyuda.Visibility == Visibility.Hidden)
            {
                panelAyuda.Visibility = Visibility.Visible;
                imgHelp.Source = new BitmapImage(new Uri(@"/Imagenes/hidehelp.png", UriKind.Relative));
                cvSeparador.Visibility = Visibility.Visible;
            }
            else
            {
                panelAyuda.Visibility = Visibility.Hidden;
                imgHelp.Source = new BitmapImage(new Uri(@"/Imagenes/help.png", UriKind.Relative));
                cvSeparador.Visibility = Visibility.Hidden;
            }
        }
        /// <summary>
        /// Gestiona el evento MouseEnter sobre ImgHelp para cambiar el cursor y simular el comportamiento de un bótón.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImgHelp_MouseEnter_1(object sender, MouseEventArgs e)
        {
            limpiarBarra();
            imgHelp.Cursor = Cursors.Hand;
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
    }
}
