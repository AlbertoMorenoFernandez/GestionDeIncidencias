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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Capa_Entidades;
using Capa_Negocio;

namespace Capa_Presentacion.UserControls
{
    /// <summary>
    /// Lógica de interacción para GestionarTecnicoTicketControl.xaml
    /// Desde este control podemos gestionar un ticket, cambiando su estado
    /// asignado--enCurso---Finalizado
    /// asignado--pendiente--Finalizado.
    /// </summary>
    public partial class GestionarTecnicoTicketControl : UserControl
    {
        Tecnico tecnicoActual;
        StackPanel panelPrincipal;
        Ticket ticketSeleccionado;
     
        List<string> listaCategorias;
        bool permitirEnCurso;                                                                       //Controla que no haya dos tickets en curso a la vez.
        VentanaActivaSingleton panelActual;


        /// <summary>
        /// Gestión de un ticket por parte de un técnico
        /// </summary>
        /// <param name="ticket">Ticket que deseamos gestionar</param>
        /// <param name="tecnico">técnico que gestiona el ticket</param>
        /// <param name="permitirEnCurso">True si el ticket puede ponerse en curso porque no hay otro en ese estado para el técnico indicado.</param>
        public GestionarTecnicoTicketControl(Ticket ticket, Tecnico tecnico, bool permitirEnCurso)
        {
            try
            {
                InitializeComponent();
               
                panelActual = VentanaActivaSingleton.Instancia;
                panelActual.VentanaActiva = "GestionarTecnicoTicketcontrol";
                limpiarBarra();
                //Verificamos que el usuario haya puesto el idEquipo en el ticket, sino se ha de poner.

                if (ticket.IdEquipo == null)
                {
                    tbTituloIdEquipo.Content = "IdEquipo*";
                    tbIdEquipo.BorderBrush = Brushes.IndianRed;
                }
                this.permitirEnCurso = permitirEnCurso;
                listaCategorias = new List<string>();
                listaCategorias = Negocio.ObtenerListaTipos();

                ticketSeleccionado = ticket;
                tecnicoActual = tecnico;
                panelGestionar.DataContext = ticketSeleccionado;
                List<string> listaEstados = new List<string>();
             

                switch (ticket.Estado)
                {
                    case (int)EstadoIncidencia.asignada:
                        listaEstados.Add("En Curso");
                        listaEstados.Add("Pendiente");
                        tbTituloResolucion.Visibility = Visibility.Hidden;
                        tbCategoria.Visibility = Visibility.Hidden;
                        cbCategoria.Visibility = Visibility.Hidden;
                        BdResolucion.Visibility = Visibility.Hidden;

                        break;
                    case (int)EstadoIncidencia.enCurso:
                        listaEstados.Add("Finalizado");
                        listaEstados.Add("Pendiente");
                        tbTituloResolucion.Visibility = Visibility.Visible;
                        tbCategoria.Visibility = Visibility.Visible;
                        cbCategoria.Visibility = Visibility.Visible;
                        BdResolucion.Visibility = Visibility.Visible;
                        tbTituloResolucion.Content = "Resolución:";
                        break;
                    case (int)EstadoIncidencia.finalizada:
                        listaEstados.Add("Finalizado");
                        break;
                    case (int)EstadoIncidencia.pendiente:
                        listaEstados.Add("Finalizado");
                        tbTituloResolucion.Visibility = Visibility.Visible;
                        tbCategoria.Visibility = Visibility.Visible;
                        cbCategoria.Visibility = Visibility.Visible;
                        BdResolucion.Visibility = Visibility.Visible;
                        break;

                }
                cbCategoria.ItemsSource = listaCategorias;
                cbEstado.ItemsSource = listaEstados;
                cbEstado.SelectedIndex = 0;
            }
            catch (IOException error)
            {
                statusBar.Background = Brushes.IndianRed;
                tbStatusInformation.Text = error.Message;
            }
        }

        //--------------------------------------------------------------------------------FUNCIONES ASOCIADAS A EVENTOS---------------------------------------------------------------------------   
        /// <summary>
        /// Controla el evento selectionchanged del cbEstado, dependiendo del estado del ticket se habilitarán unas opciones u otras:
        /// a) En curso: se esconderán todos los controles
        /// b) Pendiente: se cambia el titulo del textbox de resolución y se hace visible el mismo.
        /// c) Finalizado: qieda visible el combobox de categoría y el textbox de resolución y su título cambia de valor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbEstado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            limpiarBarra();
            string estado = cbEstado.SelectedItem.ToString();
            switch (estado){
                case "En Curso":
                    tbTituloResolucion.Visibility = Visibility.Hidden;
                    tbCategoria.Visibility = Visibility.Hidden;
                    cbCategoria.Visibility = Visibility.Hidden;
                    BdResolucion.Visibility = Visibility.Hidden;

                    break;
                case "Pendiente":
                    tbTituloResolucion.Visibility = Visibility.Visible;
                    tbCategoria.Visibility = Visibility.Hidden;
                    cbCategoria.Visibility = Visibility.Hidden;
                    BdResolucion.Visibility = Visibility.Visible;
                    tbTituloResolucion.Content = "Motivo Pendiente:";
                    break;
                case "Finalizado":
                    tbTituloResolucion.Visibility = Visibility.Visible;
                    tbCategoria.Visibility = Visibility.Visible;
                    cbCategoria.Visibility = Visibility.Visible;
                    BdResolucion.Visibility = Visibility.Visible;
                    tbTituloResolucion.Content = "Resolución:";
                    break;
            }

        }

        /// <summary>
        /// Controla el evento click del botón btVolver, permite volver a la lista de tickets pendientes sin
        /// realizar ninguna acción adicional.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtVolver_Click(object sender, RoutedEventArgs e)
        {
            TicketTecnicoControl ventana = new TicketTecnicoControl(tecnicoActual);
            panelPrincipal.Children.Insert(1, ventana);
            panelPrincipal.Children.RemoveAt(0);            
        }

        /// <summary>
        /// Cuando se carga el control, asignamos el padre a el mismo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //Una vez el user control ya está cargado, podemos definir cual es su StackPanel padre, por eso lo ponemos aquí.
            panelPrincipal = (StackPanel)this.Parent;
        }

        /// <summary>
        /// Controla el evento click del botón actualizar, permite actualizar el estado de un ticket de acuerdo con los 
        /// valores asignados en los distintos controles.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtActualizar_Click(object sender, RoutedEventArgs e)
        {
            limpiarBarra();
            string estado = cbEstado.SelectedItem.ToString();
            try
            {
                switch (estado)
                {
                    case "En Curso":
                        if (permitirEnCurso)
                        {
                            if (tbIdEquipo.Text.Equals(""))                                                                                             
                            {
                                VentanaInformacion advertencia = new VentanaInformacion("Introduzca IdEquipo, si el equipo no tiene pegatina de identificación,recuerde que puede imprimir una desde \"generar código de barras\"", "advertencia");
                                advertencia.ShowDialog();
                            }
                            else
                            {
                                ticketSeleccionado.Estado = 3;                                                              //Pasamos ticket a estado "en Curso"
                                if (Negocio.EditarTicket(ticketSeleccionado) && permitirEnCurso)
                                {
                                    VentanaInformacion modal = new VentanaInformacion("Ticket actualizado con éxito.", "exito");
                                    modal.ShowDialog();
                                    TicketTecnicoControl ventana = new TicketTecnicoControl(tecnicoActual);
                                    panelPrincipal.Children.Insert(1, ventana);
                                    panelPrincipal.Children.RemoveAt(0);
                                }
                                else
                                {
                                    VentanaInformacion modal = new VentanaInformacion("No se ha podido actualizar el ticket", "advertencia");
                                    modal.ShowDialog();
                                }
                            }

                        }
                        else
                        {
                            VentanaInformacion modal = new VentanaInformacion("Transición no válida, no pueden haber dos tickets en curso.", "advertencia");
                            modal.ShowDialog();
                        }

                        break;
                    case "Pendiente":
                        Equipo equipoValido = Negocio.ObtenerEquipo(tbIdEquipo.Text);
                        if (tbIdEquipo.Text.Equals("") || equipoValido == null)
                        {
                            if (equipoValido == null)
                            {
                                VentanaInformacion advertencia = new VentanaInformacion("El equipo introducido no existe en la base de datos.", "advertencia");
                                advertencia.ShowDialog();
                            }
                            else
                            {
                                VentanaInformacion advertencia = new VentanaInformacion("Introduzca IdEquipo, si el equipo no tiene pegatina de identificación,recuerde que puede imprimir una desde \"generar código de barras\"", "advertencia");
                                advertencia.ShowDialog();
                            }

                        }
                        else
                        {
                            if (!tbResolucion.Text.Equals(""))
                            {
                                ticketSeleccionado.Estado = 5;                                                  //Pasamos ticket a estado pendiente(5)
                                ticketSeleccionado.NotasTecnico = tbResolucion.Text;
                                if (Negocio.EditarTicket(ticketSeleccionado))
                                {
                                    VentanaInformacion modal = new VentanaInformacion("Ticket actualizado con éxito.", "exito");
                                    modal.ShowDialog();
                                    TicketTecnicoControl ventana = new TicketTecnicoControl(tecnicoActual);
                                    panelPrincipal.Children.Insert(1, ventana);
                                    panelPrincipal.Children.RemoveAt(0);
                                }
                                else
                                {
                                    VentanaInformacion modal = new VentanaInformacion("No se ha podido actualizar el ticket", "advertencia");
                                    modal.ShowDialog();
                                }

                            }
                            else
                            {
                                VentanaInformacion modal = new VentanaInformacion("Debe indicar motivo por el que queda pendiente.", "advertencia");
                                modal.ShowDialog();
                            }
                        }
                        break;
                    case "Finalizado":
                        if (!tbResolucion.Text.Equals("") && cbCategoria.SelectedItem != null)
                        {
                            ticketSeleccionado.Estado = 4;                                                                          //Pasamos ticket a estado finalizado(4)
                            ticketSeleccionado.FechaResolucion = DateTime.Now;
                            ticketSeleccionado.Categoria = Negocio.ObtenerTipoIdPorNombre(cbCategoria.SelectedItem.ToString());
                            ticketSeleccionado.Resolucion = tbResolucion.Text;
                            if (Negocio.EditarTicket(ticketSeleccionado))
                            {
                                VentanaInformacion modal = new VentanaInformacion("Ticket actualizado con éxito.", "exito");
                                modal.ShowDialog();
                                TicketTecnicoControl ventana = new TicketTecnicoControl(tecnicoActual);
                                panelPrincipal.Children.Insert(1, ventana);
                                panelPrincipal.Children.RemoveAt(0);
                            }
                            else
                            {
                                VentanaInformacion modal = new VentanaInformacion("No se ha podido actualizar el ticket", "advertencia");
                                modal.ShowDialog();
                            }
                        }
                        else
                        {
                            VentanaInformacion modal = new VentanaInformacion("Debe introducir categoria y texto de resolución.", "advertencia");
                            modal.ShowDialog();
                        }
                        break;
                }
            }
            catch (IOException error)
            {
                statusBar.Background = Brushes.IndianRed;
                tbStatusInformation.Text = error.Message;
            }
        }



        //---------------------------------------------------------------------------FUNCIONES AUXILIARES----------------------------------------------------------------------------------------

        /// <summary>
        /// Reinicia la barra de estado a sus valores originales.
        /// </summary>
        public void limpiarBarra()
        {
            statusBar.Background = Brushes.WhiteSmoke;
            tbStatusInformation.Text = "";
        }
    }
}
