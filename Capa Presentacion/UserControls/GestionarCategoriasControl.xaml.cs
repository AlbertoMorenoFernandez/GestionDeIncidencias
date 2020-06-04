using Capa_Entidades;
using Capa_Negocio;
using Capa_Presentacion.Utils;
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

namespace Capa_Presentacion.UserControls
{
    /// <summary>
    /// Lógica de interacción para CategoriasControl.xaml
    /// Tiene las siguientes funcionalidades:
    /// a) Crear categorías
    /// b) Importar categorías desde un CSV
    /// c) Exportar categorías a un CSV
    /// d) Editar una categoría
    /// Tiene dos modos de visualización "insertar" y "editar" que permiten mejorar la forma
    /// en la que el usuario interactua con la aplicación ocultando y mostrando controles .
    /// </summary>
    public partial class CategoriasControl : UserControl
    {
        CollectionViewSource vistaCategoria;
        ObservableCollection<Tipo> listaCategorias;
        VentanaActivaSingleton panelVentana;
        string modoVisualizacion;
        Tipo categoriaVentana;
        Tipo categoriaOriginal;

        public CategoriasControl()
        {
            InitializeComponent();
            try
            {
                panelVentana = VentanaActivaSingleton.Instancia;
                panelVentana.VentanaActiva = "CategoriasControl";
                limpiarBarra();

                categoriaVentana = new Tipo();
                modoVisualizacion = "insertar";


                List<Tipo> listaCategoriasBD = Negocio.ObtenerTipos();
                listaCategorias = new ObservableCollection<Tipo>();
                foreach (Tipo tip in listaCategoriasBD)
                {
                    listaCategorias.Add(tip);
                }
                vistaCategoria = new CollectionViewSource();
                vistaCategoria.Source = listaCategorias;

                dgCategorias.DataContext = vistaCategoria;
                gdGeneral.DataContext = categoriaVentana;
            }
            catch (IOException error)
            {
                statusBar.Background = Brushes.IndianRed;
                tbStatusInformation.Text = error.Message;
            }

        }

//--------------------------------------------------------------------------------FUNCIONES ASOCIADAS A EVENTOS ----------------------------------------------------------

        /// <summary>
        /// Asociado al evento click del botón "btBuscarCategoria"  permite filtrar las categorías.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtBuscarCategoria_Click(object sender, RoutedEventArgs e)
        {
            vistaCategoria.Filter += Filtrar;
        }

        /// <summary>
        /// Asociada al evento click del botón "btExportarCSV" permite  exportar todas las categorías de la base de datos a un archivo .csv
        /// por medio de <see cref="Utilidad.ExportarCsv(List{object}, string)"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtExportarCSV_Click(object sender, RoutedEventArgs e)
        {
            List<Object> listaAexportar = new List<Object>();
            foreach (Tipo u in listaCategorias)
            {
                listaAexportar.Add(u);
            }
            try
            {
                Utilidad.ExportarCsv(listaAexportar, "categoria");
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
        /// Asociado al evento click del botón "btAgregar" permite insertar o editar categorías en la base de datos
        /// mostrando un error a través de <see cref="VentanaInformacion"/> en caso de no poder realizar la transacción.
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
                        if (Negocio.CrearTipo(categoriaVentana))
                        {
                            VentanaInformacion modal = new VentanaInformacion("Categoría creada con éxito", "exito");
                            modal.ShowDialog();
                            vistaCategoria.Source = Negocio.ObtenerTipos();
                        }
                        else
                        {
                            VentanaInformacion modal = new VentanaInformacion("Error al crear categoría", "advertencia");
                            modal.ShowDialog();
                        }
                    }
                }
                else
                {
                    if (tbNombre.Text.Equals(""))
                    {
                        if (Negocio.EditarTipo(categoriaVentana))
                        {
                            VentanaInformacion modal = new VentanaInformacion("Categoría actualizada sin cambios.", "exito");
                            modal.ShowDialog();
                            vistaCategoria.Source = Negocio.ObtenerTipos();
                        }

                    }
                    else
                    {
                        if (Negocio.EditarTipo(categoriaVentana))
                        {
                            VentanaInformacion modal = new VentanaInformacion("Categoría actualizada con éxito", "exito");
                            modal.ShowDialog();
                            vistaCategoria.Source = Negocio.ObtenerTipos();
                        }
                        else
                        {
                            VentanaInformacion modal = new VentanaInformacion("Error al actualizar categoría", "advertencia");
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
        /// Asociada al evento click del botón "btImportarCSV" permite importar desde un archivo .csv un listado de categorías
        /// mediante <see cref="Utilidad.ImportarCSv(string)"/> en caso de existir algún problema en la transacción muestra un error
        /// a través de <see cref="VentanaInformacion"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtImportarCSV_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Utilidad.ImportarCSv("categoria");
                List<Tipo> listaCategoriasBD = Negocio.ObtenerTipos();
                listaCategorias = new ObservableCollection<Tipo>();
                foreach (Tipo tip in listaCategoriasBD)
                {
                    listaCategorias.Add(tip);
                }
                vistaCategoria.Source = listaCategorias;
            }
            catch (Exception error)
            {
                statusBar.Background = Brushes.IndianRed;
                tbStatusInformation.Text = error.Message;
            }
        }

        /// <summary>
        /// Asociado al evento click del botón "btVolver" permite  volver al modo de visualización "insertar"
        /// volviendo a mostrar controles como el listado de categorías. 
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
        /// Asociado al evento click del botón "btEditar" cambia el modo de visualización a "editar"
        /// inserta la categoría seleccionada en el formulario de entrada de categorías para poder editarlo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtEditar_Click(object sender, RoutedEventArgs e)
        {
            Tipo categoriaSeleccionada = (Tipo)dgCategorias.CurrentItem;
            if (categoriaSeleccionada != null)
            {
                categoriaVentana.Id = categoriaSeleccionada.Id;
                categoriaVentana.Nombre = categoriaSeleccionada.Nombre;
                categoriaOriginal = new Tipo(categoriaVentana);
            }

            modoVisualizacion = "editar";

            try
            {
                tbNombre.Text = categoriaVentana.Nombre;
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
            Tipo categoria = (Tipo)e.Item;
            string categoriaAbuscar = tbBuscarCategoria.Text;
            if (categoria.Nombre.Contains(categoriaAbuscar))
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
