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
using System.Windows.Shapes;
using Capa_Entidades;
using Capa_Negocio;

namespace Capa_Presentacion
{
    /// <summary>
    /// Lógica de interacción para valorarTicketModal.xaml
    /// Permite crear una valoración para un ticket, mediante el constructor recibe
    /// un idTicket y se actualiza la base de datos con el valor seleccionado, y un texto
    /// no obligatorio.
    /// </summary>
    public partial class valorarTicketModal : Window
    {
        int idTicket;
        int valoracion = 1;
   
        public valorarTicketModal(int id)
        {
            InitializeComponent();
            idTicket = id;
        }

        //-------------------------------------------------------------------FUNCIONES ASOCIADAS A EVENTOS-----------------------------------------------------------------------------


         /// <summary>
         /// Gestiona el evento de pulsar con el ratón una estrella., cada uno de los siguientes
         /// se corresponde con cada una de las 5 estrellas de valoración, no se puede dar cero estrellas
         /// 
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param> 
        private void ImgStar1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            valoracion = 1;
            RellenarEstrellas(valoracion);
        }

        private void ImgStar2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            valoracion = 2;
            RellenarEstrellas(valoracion);
        }

        private void ImgStar3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            valoracion = 3;
            RellenarEstrellas(valoracion);
        }

        private void ImgStar4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            valoracion = 4;
            RellenarEstrellas(valoracion);
        }

        private void ImgStar5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            valoracion = 5;
            RellenarEstrellas(valoracion);
        }

    
        /// <summary>
        /// Gestiona el evento click de btValorar, en caso de que se pulse se actualiza la valoración en la base de datos
        /// determinando las estrellas seleccionadas y en caso de haber texto, con el texto seleccionado. Actualiza la base de datos
        /// y en caso de valorar se elimina el ticketEnCurso en la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtValorar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Ticket ticketOriginal = Negocio.ObtenerTicket(idTicket);
                if (Negocio.EditarTicket(new Ticket(ticketOriginal.NumTicket, ticketOriginal.IdEquipo, ticketOriginal.IdUsuario, ticketOriginal.FechaEntrada,
                    ticketOriginal.FechaResolucion, ticketOriginal.Descripcion, ticketOriginal.Resolucion, ticketOriginal.Estado, ticketOriginal.Categoria, ticketOriginal.TecnicoAsignado, ticketOriginal.NotasTecnico, valoracion, tbValoracion.Text)))
                {
                    Negocio.EliminarTicketEnCurso(idTicket);
                    VentanaInformacion informacion = new VentanaInformacion("Valoración realizada con éxito", "exito");
                    informacion.ShowDialog();
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    VentanaInformacion advertencia = new VentanaInformacion("No se ha podido realizar la valoración", "advertencia");
                    advertencia.ShowDialog();
                }
            }
            catch (IOException )
            {
                VentanaInformacion modal = new VentanaInformacion("Error al acceder a la base de datos", "advertencia");
                modal.ShowDialog();
               
            }
            
        }

        /// <summary>
        /// Gestiona el evento click del botón btCancelar, en caso de pulsarlo se cierra esta ventana.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }


        //--------------------------------------------------------------------------------------FUNCIONES AUXILIARES---------------------------------------------------------------------

        /// <summary>
        /// Cambia el source de las distintas imagenes para representar el número de estrellas de valoración que haya seleccionado el usuario.
        /// </summary>
        /// <param name="valoracion"></param>
        private void RellenarEstrellas(int valoracion)
        {
            switch (valoracion)
            {
                case 1:
                    imgStar1.Source = new BitmapImage(new Uri(@"../Imagenes/estrellaOk.png", UriKind.Relative));
                    imgStar2.Source = new BitmapImage(new Uri(@"../Imagenes/estrellaNoOk.png", UriKind.Relative));
                    imgStar3.Source = new BitmapImage(new Uri(@"../Imagenes/estrellaNoOk.png", UriKind.Relative));
                    imgStar4.Source = new BitmapImage(new Uri(@"../Imagenes/estrellaNoOk.png", UriKind.Relative));
                    imgStar5.Source = new BitmapImage(new Uri(@"../Imagenes/estrellaNoOk.png", UriKind.Relative));
                    break;
                case 2:
                    imgStar1.Source = new BitmapImage(new Uri(@"../Imagenes/estrellaOk.png", UriKind.Relative));
                    imgStar2.Source = new BitmapImage(new Uri(@"../Imagenes/estrellaOk.png", UriKind.Relative));
                    imgStar3.Source = new BitmapImage(new Uri(@"../Imagenes/estrellaNoOk.png", UriKind.Relative));
                    imgStar4.Source = new BitmapImage(new Uri(@"../Imagenes/estrellaNoOk.png", UriKind.Relative));
                    imgStar5.Source = new BitmapImage(new Uri(@"../Imagenes/estrellaNoOk.png", UriKind.Relative));
                    break;
                case 3:
                    imgStar1.Source = new BitmapImage(new Uri(@"../Imagenes/estrellaOk.png", UriKind.Relative));
                    imgStar2.Source = new BitmapImage(new Uri(@"../Imagenes/estrellaOk.png", UriKind.Relative));
                    imgStar3.Source = new BitmapImage(new Uri(@"../Imagenes/estrellaOk.png", UriKind.Relative));
                    imgStar4.Source = new BitmapImage(new Uri(@"../Imagenes/estrellaNoOk.png", UriKind.Relative));
                    imgStar5.Source = new BitmapImage(new Uri(@"../Imagenes/estrellaNoOk.png", UriKind.Relative));
                    break;
                case 4:
                    imgStar1.Source = new BitmapImage(new Uri(@"../Imagenes/estrellaOk.png", UriKind.Relative));
                    imgStar2.Source = new BitmapImage(new Uri(@"../Imagenes/estrellaOk.png", UriKind.Relative));
                    imgStar3.Source = new BitmapImage(new Uri(@"../Imagenes/estrellaOk.png", UriKind.Relative));
                    imgStar4.Source = new BitmapImage(new Uri(@"../Imagenes/estrellaOk.png", UriKind.Relative));
                    imgStar5.Source = new BitmapImage(new Uri(@"../Imagenes/estrellaNoOk.png", UriKind.Relative));
                    break;
                case 5:
                    imgStar1.Source = new BitmapImage(new Uri(@"../Imagenes/estrellaOk.png", UriKind.Relative));
                    imgStar2.Source = new BitmapImage(new Uri(@"../Imagenes/estrellaOk.png", UriKind.Relative));
                    imgStar3.Source = new BitmapImage(new Uri(@"../Imagenes/estrellaOk.png", UriKind.Relative));
                    imgStar4.Source = new BitmapImage(new Uri(@"../Imagenes/estrellaOk.png", UriKind.Relative));
                    imgStar5.Source = new BitmapImage(new Uri(@"../Imagenes/estrellaOk.png", UriKind.Relative));
                    break;
            }
        }
    }
}
