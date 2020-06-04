using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Lógica de interacción para CrearTicketsAdminControl.xaml
    /// Permite crear un "Ticket" a un administrador, el proceso es similar a la creación por parte de un usuario
    /// pero en esta ocasión el administrador debe asignar el ticket a un técnico en su creación. 
    /// </summary>
    public partial class CrearTicketsAdminControl : UserControl
    {
        List<string> listaTecnicos;
        int idTecnico;
        bool idEquipoCorrecto = false;
        int? tecnicoId = 0;
        int? usuarioId = 0;
        VentanaActivaSingleton panelActual;

        public CrearTicketsAdminControl(int? usuarioId)
        {
            InitializeComponent();
            panelActual = VentanaActivaSingleton.Instancia;
            panelActual.VentanaActiva = "CrearTicketsAdminControl";
            limpiarBarra();
          
            try
            {
                listaTecnicos = Negocio.ObtenerListaTecnicos();
                cbTecnicos.ItemsSource = listaTecnicos;
                cbTecnicosExternos.ItemsSource = listaTecnicos;
                this.usuarioId = usuarioId;
            }
            catch (IOException error)
            {
                statusBar.Background = Brushes.IndianRed;
                tbStatusInformation.Text = error.Message;
            }
        }



        //-----------------------------------------------------------------------------FUNCIONES ASOCIADAS A EVENTOS-------------------------------------------------------------------------------------

        /// <summary>
        /// Asociada el evento MouseLeave, verifica si los datos introducidos en el textbox tbEquipo
        /// coinciden con algún equipo de la base de datos, para ellos hace uso de <see cref="Negocio.ObtenerEquipo(string)"/>
        /// en caso de coincidir rellena el combobox cbtecnicos con los técnicos que haya registrados en la misma sede que
        /// se encuentre dicho equipo <see cref="Negocio.ObtenerListaTecnicosPorEquipo(string)"/>. Por otro lado gestiona la
        /// visibilidad de la imagen que indica al usuario si el equipo introducido es correcto o no.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbEquipo_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                Equipo equipo = Negocio.ObtenerEquipo(tbEquipo.Text);
                if (equipo == null && !tbEquipo.Text.Equals(""))
                {
                    imgVerificar.Visibility = Visibility.Visible;
                    imgVerificar.Source = new BitmapImage(new Uri(@"/Imagenes/noOk.png", UriKind.Relative));
                    cbTecnicos.ItemsSource = listaTecnicos;
                }
                else if (!tbEquipo.Text.Equals("") && equipo != null)
                {
                    imgVerificar.Source = new BitmapImage(new Uri(@"/Imagenes/ok.png", UriKind.Relative));
                    imgVerificar.Visibility = Visibility.Visible;
                    cbTecnicos.ItemsSource = Negocio.ObtenerListaTecnicosPorEquipo(tbEquipo.Text);
                }
                else
                {
                    imgVerificar.Visibility = Visibility.Hidden;
                    cbTecnicos.ItemsSource = listaTecnicos;
                }
            }
            catch (IOException error)
            {
                statusBar.Background = Brushes.IndianRed;
                tbStatusInformation.Text = error.Message;
            }
        }

        /// <summary>
        /// Asociada el evento MouseLeave, verifica si los datos introducidos en el textbox tbEquipo
        /// coinciden con algún equipo de la base de datos, para ellos hace uso de <see cref="Negocio.ObtenerEquipo(string)"/>
        /// en caso de coincidir rellena el combobox cbtecnicos con los técnicos que haya registrados en la misma sede que
        /// se encuentre dicho equipo <see cref="Negocio.ObtenerListaTecnicosPorEquipo(string)"/>. Por otro lado gestiona la
        /// visibilidad de la imagen que indica al usuario si el equipo introducido es correcto o no.        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbEquipo_LostFocus(object sender, RoutedEventArgs e)
        {

            try
            {
                Equipo equipo = Negocio.ObtenerEquipo(tbEquipo.Text);
                if (equipo == null && !tbEquipo.Text.Equals(""))
                {
                    imgVerificar.Visibility = Visibility.Visible;
                    imgVerificar.Source = new BitmapImage(new Uri(@"/Imagenes/noOk.png", UriKind.Relative));
                    cbTecnicos.ItemsSource = listaTecnicos;
                }
                else if (!tbEquipo.Text.Equals("") && equipo != null)
                {
                    imgVerificar.Source = new BitmapImage(new Uri(@"/Imagenes/ok.png", UriKind.Relative));
                    imgVerificar.Visibility = Visibility.Visible;
                    cbTecnicos.ItemsSource = Negocio.ObtenerListaTecnicosPorEquipo(tbEquipo.Text);
                }
                else
                {
                    imgVerificar.Visibility = Visibility.Hidden;
                    cbTecnicos.ItemsSource = listaTecnicos;
                }
            }
            catch (IOException error)
            {
                statusBar.Background = Brushes.IndianRed;
                tbStatusInformation.Text = error.Message;
            }
        }

        ///<summary>
        /// verifica si los datos introducidos en el textbox tbEquipo
        /// coinciden con algún equipo de la base de datos, para ellos hace uso de <see cref="Negocio.ObtenerEquipo(string)"/>
        /// en caso de coincidir rellena el combobox cbtecnicos con los técnicos que haya registrados en la misma sede que
        /// se encuentre dicho equipo <see cref="Negocio.ObtenerListaTecnicosPorEquipo(string)"/>. Por otro lado gestiona la
        /// visibilidad de la imagen que indica al usuario si el equipo introducido es correcto o no.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbEquipo_TextChanged(object sender, TextChangedEventArgs e)
        {
            limpiarBarra();
            if (tbEquipo.Text.Length == 6)
            {
                try
                {
                    Equipo equipo = Negocio.ObtenerEquipo(tbEquipo.Text);
                    if (equipo == null)
                    {
                        imgVerificar.Visibility = Visibility.Visible;
                        imgVerificar.Source = new BitmapImage(new Uri(@"/Imagenes/noOk.png", UriKind.Relative));
                        cbTecnicos.ItemsSource = listaTecnicos;
                        idEquipoCorrecto = false;
                    }
                    else
                    {
                        imgVerificar.Source = new BitmapImage(new Uri(@"/Imagenes/ok.png", UriKind.Relative));
                        imgVerificar.Visibility = Visibility.Visible;
                        cbTecnicos.ItemsSource = Negocio.ObtenerListaTecnicosPorEquipo(tbEquipo.Text);
                        idEquipoCorrecto = true;
                    }
                }
                catch (IOException error)
                {
                    statusBar.Background = Brushes.IndianRed;
                    tbStatusInformation.Text = error.Message;
                }
            }
            else
            {
                imgVerificar.Visibility = Visibility.Hidden;
                cbTecnicos.ItemsSource = listaTecnicos;
                idEquipoCorrecto = false;
            }
        }

        /// <summary>
        /// Gestiona el evento selectionChanged de cbTecnicos, al seleccionar un técnico se muestra información útil para que
        /// el administrador decida si es el técnico adecuado para poner el ticket. Para mostrar dicha información <see cref="CrearTicketsAdminControl.rellenarInformacion(string)"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbTecnicos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            limpiarBarra();
            ComboBox combo = (ComboBox)sender;
            if (combo.SelectedItem != null)
            {
                rellenarInformacion(cbTecnicos.SelectedItem.ToString());
            } 
        }


        /// <summary>
        /// Gestiona el evento unchecked, para ocultar el combobox cbtecnicosExternos en caso de querer
        /// ques se visualicen sólo los técnicos que haya en la sede donde esté ubicado el equipo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChbTecnicos_Unchecked(object sender, RoutedEventArgs e)
        {
            limpiarBarra();
            cbTecnicosExternos.Visibility = Visibility.Hidden;
            cbTecnicos.IsEnabled = true;
        }

        /// <summary>
        /// Gestiona el evento checked, muestra el combobox cbtecnicosExternos para poder elegir entre todos los 
        /// técnicos y no sólo los de la sede donde se encuentre el equipo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChbTecnicos_Checked(object sender, RoutedEventArgs e)
        {
            limpiarBarra();
            cbTecnicosExternos.Visibility = Visibility.Visible;
            cbTecnicos.IsEnabled = false;
        }

        /// <summary>
        /// Gestiona el evento selectionChanged de cbTecnicosExternos, al seleccionar un técnico se muestra información útil para que
        /// el administrador decida si es el técnico adecuado para poner el ticket. Para mostrar dicha información <see cref="CrearTicketsAdminControl.rellenarInformacion(string)"/> 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbTecnicosExternos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            limpiarBarra();
            ComboBox combo = (ComboBox)sender;
            if (combo.SelectedItem != null)
            {
                rellenarInformacion(cbTecnicosExternos.SelectedItem.ToString());
            }
        }
        /// <summary>
        /// Gestiona el evento click de  BtCrear para crear un ticket a través de <see cref="CrearTicketsAdminControl.crearTicket(int?, string)"/>
        /// verifica el estado del checkbox chbTecnicos y si el idEquipo introducido es correcto para llamar al método.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtCrear_Click(object sender, RoutedEventArgs e)
        {
            limpiarBarra();
            List<string> erroresDetectados = validarCampos();
            if (erroresDetectados.Count == 0)
            {
                if (idEquipoCorrecto)
                {
                    if (chbTecnicos.IsChecked == true)
                    {
                        tecnicoId = int.Parse(cbTecnicosExternos.SelectedItem.ToString().Split('.')[0]);
                        crearTicket(tecnicoId, tbEquipo.Text);
                    }
                    else
                    {
                        tecnicoId = int.Parse(cbTecnicos.SelectedItem.ToString().Split('.')[0]);
                        crearTicket(tecnicoId, tbEquipo.Text);
                    }
                }
                else
                {
                    if (chbTecnicos.IsChecked == true)
                    {
                        tecnicoId = int.Parse(cbTecnicosExternos.SelectedItem.ToString().Split('.')[0]);
                        crearTicket(tecnicoId, null);
                    }
                    else
                    {
                        tecnicoId = int.Parse(cbTecnicos.SelectedItem.ToString().Split('.')[0]);
                        crearTicket(tecnicoId, null);
                    }
                }

            }
            else
            {
                string errores="";
                foreach (String s in erroresDetectados)
                {
                    errores = errores + s + "\n";
                }
                VentanaInformacion modal = new VentanaInformacion(errores, "advertencia");
                modal.ShowDialog();
            } 
        }

       

        /// <summary>
        /// Gestiona el evento click de BtBorrar, inicializando la descripción y el equipo para poder 
        /// crear un ticket nuevo sin tener que borrarlos a mano.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtBorrar_Click(object sender, RoutedEventArgs e)
        {
            limpiarBarra();
            tbDescripcion.Text = "";
            tbEquipo.Text = "";
            tbAsignadas.Text = "-";
            tbPendientes.Text = "-";
            cbTecnicos.SelectedIndex = -1;
            cbTecnicosExternos.SelectedIndex = -1;
            tbDireccionTecnico.Text = "";
            tbNombreTecnico.Text = "";
        }


        //-----------------------------------------------------------------------------FUNCIONES AUXILIARES-------------------------------------------------------------------------------------

        /// <summary>
        /// Permite visualizar la información de un técnico(nombre y dirección) y los avisos que tiene en curso y de ellos
        /// los que están en estado pendiente.
        /// </summary>
        /// <param name="tecnico"></param>
        private void rellenarInformacion(string tecnico)
        {
            int totalAvisos = 0;
            int avisosPendientes = 0;
            idTecnico = int.Parse(tecnico.Split('.')[0]);
            string nombreTecnico = tecnico.Split('-')[1];
            try
            {
                List<TicketEnCurso> ticketsEnCurso = Negocio.ObtenerTicketsEnCurso().Where(x => x.IdTecnico == idTecnico).ToList();
                totalAvisos = ticketsEnCurso.Count;
                foreach (TicketEnCurso tick in ticketsEnCurso)
                {
                    if (Negocio.ObtenerTicket((int)tick.Id).NotasTecnico != null)
                        avisosPendientes++;
                }

                tbAsignadas.Text = "" + totalAvisos;
                tbPendientes.Text = "" + avisosPendientes;
                tbNombreTecnico.Text = nombreTecnico;
                tbDireccionTecnico.Text = Negocio.ObtenerSedeTecnico(idTecnico);
            }
            catch (IOException error)
            {
                statusBar.Background = Brushes.IndianRed;
                tbStatusInformation.Text = error.Message;
            }
        }

       /// <summary>
       /// Crea un ticket con los datos introducidos en los distintos controles en la base de dato.
       /// </summary>
       /// <param name="tecnico">idTecnico que tiene asignado el ticket</param>
       /// <param name="equipoId">equipoId del ticket, puede ser null</param>
        private void crearTicket(int? tecnico, string equipoId)
        {
            try
            {
                if (Negocio.CrearTicket(new Ticket(0, equipoId, usuarioId, DateTime.Now, null, tbDescripcion.Text, null, (int?)EstadoIncidencia.asignada, null, tecnico, null, 0, null)))
                {
                    VentanaInformacion aviso = new VentanaInformacion("Ticket creado con éxito", "exito");
                    aviso.ShowDialog();
                }
                else
                {
                    VentanaInformacion aviso = new VentanaInformacion("Error al crear ticket.", "advertencia");
                    aviso.ShowDialog();
                }
            }
            catch (IOException error)
            {
                statusBar.Background = Brushes.IndianRed;
                tbStatusInformation.Text = error.Message;
            }
        }

        /// <summary>
        /// Reinicia la barra de estado a sus valores originales.
        /// </summary>
        public void limpiarBarra()
        {
            statusBar.Background = System.Windows.Media.Brushes.WhiteSmoke;
            tbStatusInformation.Text = "";
        }

        /// <summary>
        /// Verifica que los campos necesarios para crear un ticket tengan el formato correcto:
        /// - Descripción obligatorio
        /// - Tecnico seleccionado
        /// - Se permite que el equipo sea incorrecto o no exista, si es incorrecto se pondrá null
        /// Genera una lista con los errores detectados
        /// 
        /// </summary>
        /// <returns>Una lista con los errores de validación detectados</returns>
        private List<string> validarCampos()
        {
            List<string> listaErrores = new List<string>();
            if (chbTecnicos.IsChecked == true)
            {
                if (cbTecnicosExternos.SelectedIndex == -1)
                    listaErrores.Add("- Debe seleccionar un técnico externo");
            }
            else
            {
                if (cbTecnicos.SelectedIndex == -1)
                    listaErrores.Add("- Debe seleccionar un técnico");

            }
            if (tbDescripcion.Text.Equals(""))
                listaErrores.Add("- Por favor introduzca descripción del problema");
            return listaErrores;
        }
    }
}
