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
using Capa_Presentacion.Utils;

namespace Capa_Presentacion.UserControls
{
    /// <summary>
    /// Lógica de interacción para LocalidadesControl.xaml
    /// Presenta las siguientes funcionalidades:
    /// - Crear Localidades en la base de datos
    /// - Importar Localidades de un .csv
    /// - Exportar Localidades de un .csv
    /// - Editar localidades existentes en la base de datos.
    /// Dispone de dos modos de visualización "insertar" y "editar" que permitan ocultando y mostrando controles cambiar
    /// la interfaz para una mejor interacción con el usuario.
    /// </summary>
    public partial class LocalidadesControl : UserControl
    {

        CollectionViewSource vistaLocalidad;
        ObservableCollection<Localidad> listaLocalidades;
       
        VentanaActivaSingleton panelVentana;
        string modoVisualizacion;
        Localidad localidadActual;
        Localidad localidadAuxiliar;
        
        public LocalidadesControl()
        {
            InitializeComponent();
            panelVentana = VentanaActivaSingleton.Instancia;
            panelVentana.VentanaActiva = "LocalidadesControl";
            limpiarBarra();

            localidadActual = new Localidad();
            modoVisualizacion = "insertar";


            try
            {
                List<Localidad> listaLocalidades = Negocio.ObtenerLocalidades();
                this.listaLocalidades = new ObservableCollection<Localidad>();
                foreach (Localidad local in listaLocalidades)
                {
                    this.listaLocalidades.Add(local);
                }
                vistaLocalidad = new CollectionViewSource();
                vistaLocalidad.Source = this.listaLocalidades;

                dgLocalidades.DataContext = vistaLocalidad;
                gdGeneral.DataContext = localidadActual;
            }
            catch (IOException error)
            {
                statusBar.Background = Brushes.IndianRed;
                tbStatusInformation.Text = error.Message;
            }

        }


//-----------------------------------------------------------------------------------------FUNCIONES ASOCIADAS A EVENTOS------------------------------------------

        /// <summary>
        /// Asociado al evento click del botón "btBuscarLocalidad" permite filtrar  localidades 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtBuscarLocalidad_Click(object sender, RoutedEventArgs e)
        { 
            vistaLocalidad.Filter += Filtrar;
        }


        /// <summary>
        /// Asociado al eventó click del botón "btExportarCsv" permite exportar las localidades de la base de datos a un archivo .csv
        /// usando <see cref="Utilidad.ExportarCsv(List{object}, string)"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtExportarCSV_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Object> lista = new List<Object>();
                foreach (Localidad u in listaLocalidades)
                {
                    lista.Add(u);
                }
                Utilidad.ExportarCsv(lista, "localidad");
            }
            catch (FormatException e1)
            {
                VentanaInformacion modal = new VentanaInformacion(e1.Message, "advertencia");
                modal.ShowDialog();
            }
            catch (Exception error)
            {
                statusBar.Background = Brushes.IndianRed;
                tbStatusInformation.Text = error.Message;
            }
        }

        /// <summary>
        /// Asociado al evento click del botón "btAgregar" permite insertar o editar localidades en la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (modoVisualizacion.Equals("insertar"))
                {
                    if (tbNombre.Text.Equals(""))
                    {
                        VentanaInformacion modal = new VentanaInformacion("Nombre es campo obligatorio", "advertencia");
                        modal.ShowDialog();
                    }
                    else
                    {
                        if (Negocio.CrearLocalidad(localidadActual))
                        {
                            VentanaInformacion modal = new VentanaInformacion("Localidad creada con éxito", "exito");
                            modal.ShowDialog();
                            vistaLocalidad.Source = Negocio.ObtenerLocalidades();
                        }
                        else
                        {
                            VentanaInformacion modal = new VentanaInformacion("Error al crear localidad", "advertencia");
                            modal.ShowDialog();
                        }
                    }
                }
                else
                {
                    if (tbNombre.Text.Equals(""))
                    {
                        if (Negocio.EditarLocalidad(localidadAuxiliar))
                        {
                            VentanaInformacion modal = new VentanaInformacion("Localidad actualizada sin cambios.", "exito");
                            modal.ShowDialog();
                            vistaLocalidad.Source = Negocio.ObtenerLocalidades();
                        }

                    }
                    else
                    {
                        if (Negocio.EditarLocalidad(localidadActual))
                        {
                            VentanaInformacion modal = new VentanaInformacion("Localidad actualizada con éxito", "exito");
                            modal.ShowDialog();
                            vistaLocalidad.Source = Negocio.ObtenerLocalidades();
                        }
                        else
                        {
                            VentanaInformacion modal = new VentanaInformacion("Error al actualizar localidad", "advertencia");
                            modal.ShowDialog();
                        }
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
        /// Asociado al evento click del botón "btImportarCSV" permite importar localidades existentes en un archivo .csv
        /// para ello hace uso de <see cref="Utilidad.ImportarCSv(string)"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtImportarCSV_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Utilidad.ImportarCSv("localidad");
                List<Localidad> listaLocalidades = Negocio.ObtenerLocalidades();
                this.listaLocalidades = new ObservableCollection<Localidad>();
                foreach (Localidad local in listaLocalidades)
                {
                    this.listaLocalidades.Add(local);
                }
                vistaLocalidad.Source = this.listaLocalidades;
            }
            catch (Exception error)
            {
                statusBar.Background = Brushes.IndianRed;
                tbStatusInformation.Text = error.Message;
            }
        }


        /// <summary>
        /// Asociada al evento click del botón "btVolverClick" permite cambiar el modo de visualización de la interfaz a modo "insertar"
        /// volviendo a mostrar los controles ocultados en el modo "editar".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtVolver_Click(object sender, RoutedEventArgs e)
        {
            modoVisualizacion = "insertar";
            btAgregar.Content = "AGREGAR";
            btImportarCSV.Visibility = Visibility.Visible;
            btExportarCSV.Visibility = Visibility.Visible;
            panelEditar.Visibility = Visibility.Visible;
            btVolver.Visibility = Visibility.Hidden;
            panelInformacion.Visibility = Visibility.Hidden;
            tbNombre.Text = "";

        }

        /// <summary>
        /// Asociado al evento click del botón "btEditar" permite cambiar el modo de visualización a "editar" ocultando ciertos controles
        /// y pasando la información de la localidad seleccionada al formulario de agregar localidades para su edición.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtEditar_Click(object sender, RoutedEventArgs e)
        {
            Localidad localidadSeleccionada = (Localidad)dgLocalidades.CurrentItem;
            if (localidadSeleccionada != null)
            {
                localidadActual.Id= localidadSeleccionada.Id;
                localidadActual.Nombre = localidadSeleccionada.Nombre;
                localidadAuxiliar = new Localidad(localidadActual);
            }

            modoVisualizacion = "editar";
           
            try
            {
                tbNombre.Text = localidadActual.Nombre;
                btAgregar.Content = "EDITAR";
                btImportarCSV.Visibility = Visibility.Hidden;
                btExportarCSV.Visibility = Visibility.Hidden;
                panelEditar.Visibility = Visibility.Hidden;
                btVolver.Visibility = Visibility.Visible;
                panelInformacion.Visibility = Visibility.Visible;
            }
            catch (IOException error)
            {
                statusBar.Background = Brushes.IndianRed;
                tbStatusInformation.Text = error.Message;
            }
        }

        //--------------------------------------------------------------------------------------------------------FUNCIONES AUXILIARES ------------------------------------------------------------------------

        /// <summary>
        /// Permite filtrar las sedes cuyo nombre coincida con el texto introducido en el textbox tbBuscarLocalidad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Filtrar(object sender, FilterEventArgs e)
        {
            Localidad local = (Localidad)e.Item;
            string localidadABuscar = tbBuscarLocalidad.Text;
            if (local.Nombre.Contains(localidadABuscar))
                e.Accepted = true;
            else
                e.Accepted = false;

        }
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
