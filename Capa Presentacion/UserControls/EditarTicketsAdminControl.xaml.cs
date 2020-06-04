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
    /// Lógica de interacción para EditarTicketsAdminControl.xaml
    /// Presenta las siguientes funcionalidades:
    /// a) Filtrar tickets por "finalizados/noFinalizados" "Fuera de SLA o dentro de SLA", "por técnico", "por usuario", por "idTicket"
    /// b) permite a través de <see cref="GestionarTicketsAdminControl"/> reasignar o cerrar dichos tickets.
    /// </summary>
    public partial class EditarTicketsAdminControl : UserControl
    {
     
        VentanaActivaSingleton panelActual;
        private CollectionViewSource MiVista;
        List<Ticket> listaTickets;
        ObservableCollection<Usuario> listaUsuarios;
        List<Tecnico> listaTecnicos;
        SolidColorBrush naranjaClaro = new SolidColorBrush(Color.FromRgb(255, 203, 153));
        SolidColorBrush rojoClaro = new SolidColorBrush(Color.FromRgb(251, 227, 228));
        SolidColorBrush verdeClaro = new SolidColorBrush(Color.FromRgb(236, 239, 196));
        StackPanel panelPrincipal;
        Usuario usuario;
        private const int TIEMPO_SLA = 4;

        public EditarTicketsAdminControl( Usuario user)
        {
            InitializeComponent();

            try
            {
                panelActual = VentanaActivaSingleton.Instancia;
                panelActual.VentanaActiva = "EditarTicketsAdminControl";
                limpiarBarra();

                MiVista = new CollectionViewSource();
                listaTickets = new List<Ticket>();
                usuario = user;
                listaUsuarios = Negocio.ObtenerUsuarios();
                listaTickets = Negocio.ObtenerTickets().Where(x => x.TecnicoAsignado != null).OrderByDescending(x => x.FechaEntrada).ToList();
                listaTecnicos = Negocio.ObtenerTecnicos();
                MiVista.Source = listaTickets;
                dtTickets.DataContext = MiVista;
                cbSLA.SelectedIndex = 0;
                cbCategorias.SelectedIndex = 0;
            }
            catch (IOException error)
            {
                statusBar.Background = Brushes.IndianRed;
                tbStatusInformation.Text = error.Message;
            }
        }



        //--------------------------------------------------------------------------------FUNCIONES ASOCIADAS A EVENTOS----------------------------------------------------------------

        /// <summary>
        /// Asociado al evento click del botón "btDetallesTicket" permite modificar un ticket haciendo uso de
        /// <see cref="GestionarTicketsAdminControl"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtDetallesTicket_Click(object sender, RoutedEventArgs e)
        {
            Ticket ticketActual = (Ticket)dtTickets.SelectedItem;
            GestionarTicketsAdminControl contenido = new GestionarTicketsAdminControl(ticketActual, usuario);
            panelPrincipal.Children.Insert(1, contenido);
            panelActual.VentanaActiva = "GestionarTicketsAdminControl";
            panelPrincipal.Children.RemoveAt(0);
        }




        /// <summary>
        /// Asociada el evnto textChanged del textbox "tbTecnico" permite filtrar por  técnico.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbTecnico_TextChanged(object sender, TextChangedEventArgs e)
        {
            MiVista.Filter += Filtrar;
        }
    
        /// <summary>
        /// Asociada al evento textChanged del textbox "tbusuario" permite filtrar por usuario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {
            MiVista.Filter += Filtrar;
        }

        /// <summary>
        /// Asociada al evento selectionChanged del combobox "cbSLA" permite filtra por SLA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbSLA_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MiVista.Filter += Filtrar;
        }

        /// <summary>
        /// Asociada al evento textChanged del textbox "tbIdTicket" permite filtrar por idTicket.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbIdTicket_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!TbIdTicket.Text.Equals(""))
            {
                TbTecnico.IsEnabled = false;
                tbUsuario.IsEnabled = false;
                cbCategorias.IsEnabled = false;
                cbSLA.IsEnabled = false;
                MiVista.Filter += Filtrar;
            }
            else
            {
                TbTecnico.IsEnabled = true;
                tbUsuario.IsEnabled = true;
                cbCategorias.IsEnabled = true;
                cbSLA.IsEnabled = true;
            }
        }

        /// <summary>
        /// Permite  cambiar el color de las filas de forma dinámica al cargar el datagrid, mostrando los tickets fuera de SLA
        /// en color rojo claro, los que están próximos a él en color naranaja y los que están dentro de SLA en color blanco.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DtTickets_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            DataGridRow ticketEnCurso = e.Row;
            Ticket tiquet = (Ticket)ticketEnCurso.DataContext;

            if (tiquet.Estado != (int?)EstadoIncidencia.finalizada) {
                TimeSpan tiempoAbierta = (TimeSpan)(DateTime.Now - tiquet.FechaEntrada);
                if (tiempoAbierta.Hours >= TIEMPO_SLA && tiempoAbierta.Days==0 || tiempoAbierta.Days>=1)
                    e.Row.Background = rojoClaro;
                else if (tiempoAbierta.Hours == 3 && tiempoAbierta.Days==0 )
                    e.Row.Background = naranjaClaro;
                else
                    e.Row.Background = Brushes.White;
            }    
            else
                e.Row.Background = Brushes.White;
        }

        /// <summary>
        /// Permite determinar el padre del userControl.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            panelPrincipal = (StackPanel)this.Parent;
        }

        //--------------------------------------------------------------------------------FUNCIONES AUXILIARES--------------------------------------------------------------------------   

        /// <summary>
        /// Crea un filtro para los tickets, con las fechas indicadas(si las hubiere) y el texto del textbox
        /// tbEquipo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Filtrar(object sender, FilterEventArgs e)
        {
            limpiarBarra();
            Ticket tick = (Ticket)e.Item;
            Usuario user = listaUsuarios.Where(x => x.UsuarioId == tick.IdUsuario).ToList()[0];
            int? idtecnico = listaTecnicos.Where(x => x.IdTecnico == tick.TecnicoAsignado).ToList()[0].IdUsuario;
            Usuario tecnico = listaUsuarios.Where(x => x.UsuarioId == idtecnico).ToList()[0];
            if (tick != null)
            {
               if (TbIdTicket.Text.Equals(""))
                {
                    // El indice 0 muestra todas las incidencias, el 1 sólo las que está fuera de S.L.A
                    if (cbSLA.SelectedIndex == 0)
                    {
                        if ((user.Nombre + " " + user.Apellidos).ToUpper().Contains(tbUsuario.Text.ToUpper()) && ((tecnico.Nombre + " " + tecnico.Apellidos).ToUpper().Contains(TbTecnico.Text.ToUpper())))
                        {
                            if (cbCategorias.SelectedIndex == 0 && tick.Estado == (int?)EstadoIncidencia.finalizada || cbCategorias.SelectedIndex == 1 && tick.Estado != (int?)EstadoIncidencia.finalizada)
                                e.Accepted = true;
                            else
                                e.Accepted = false;
                        }
                          
                        else
                            e.Accepted = false;
                    }
                    else
                    {
                        if (tick.Estado == (int?)EstadoIncidencia.finalizada)
                        {
                            if (tick.FechaResolucion - tick.FechaEntrada > TimeSpan.FromHours(4))
                            {
                                if ((user.Nombre + " " + user.Apellidos).ToUpper().Contains(tbUsuario.Text.ToUpper()) && ((tecnico.Nombre + " " + tecnico.Apellidos).ToUpper().Contains(TbTecnico.Text.ToUpper())))
                                {
                                    if (cbCategorias.SelectedIndex == 0 && tick.Estado == (int?)EstadoIncidencia.finalizada || cbCategorias.SelectedIndex == 1 && tick.Estado != (int?)EstadoIncidencia.finalizada)
                                        e.Accepted = true;
                                    else
                                        e.Accepted = false;
                                }
                                else
                                    e.Accepted = false;
                            }

                            else
                            {
                                //Los tickets  con tiempo de resolución menor a 4 horas no están fuera de SLA y por tanto no se muestran.
                                e.Accepted = false;
                            }

                        }
                        else
                        {
                            if (tick.FechaEntrada < DateTime.Now.AddHours(-4))
                            {
                                if ((user.Nombre + " " + user.Apellidos).ToUpper().Contains(tbUsuario.Text.ToUpper()) && ((tecnico.Nombre + " " + tecnico.Apellidos).ToUpper().Contains(TbTecnico.Text.ToUpper())))
                                {
                                    if (cbCategorias.SelectedIndex == 0 && tick.Estado == (int?)EstadoIncidencia.finalizada || cbCategorias.SelectedIndex == 1 && tick.Estado != (int?)EstadoIncidencia.finalizada)
                                        e.Accepted = true;
                                    else
                                        e.Accepted = false;
                                }
                                else
                                    e.Accepted = false;

                            }
                            else
                            {
                                //Los tickets que llevan abiertos menos de 4 horas, no están fuera de SLA y por tanto no se muestran.
                                e.Accepted = false;
                            }
                        }
                    }
                }
                else
                {
                    if (("" + tick.NumTicket).Contains(TbIdTicket.Text))
                    {
                        e.Accepted = true;
                    }
                    else
                        e.Accepted = false;
                }

            }
        }



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
