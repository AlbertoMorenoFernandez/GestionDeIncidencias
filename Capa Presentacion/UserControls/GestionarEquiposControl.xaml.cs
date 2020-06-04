using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Capa_Presentacion.Utils;
using System.IO;

namespace Capa_Presentacion.UserControls
{
    /// <summary>
    /// Lógica de interacción para EquiposControl.xaml
    /// Permite mediante dos modos de isualización controlados por la variable modovisualizacion
    /// - Crear equipos
    /// - Crear equipos desde un csv
    /// - Exportar equipos a un csv
    /// - Editar equipos
    /// 
    /// </summary>
    public partial class EquiposControl : UserControl
    {
        ObservableCollection<Equipo> listaEquipos;
        CollectionViewSource vistaEquipos;
        Equipo equipoOriginal;
        Equipo equipoVentana;
        VentanaActivaSingleton panelActual;
        List<string> listaSedes;
        List<string> listaCategorias;
        string modoVisualizacion;

        public EquiposControl()
        {
           
            InitializeComponent();
            panelActual = VentanaActivaSingleton.Instancia;
            panelActual.VentanaActiva = "EquiposControl";
            limpiarBarra();

            try
            {
                listaEquipos = new ObservableCollection<Equipo>();
                vistaEquipos = new CollectionViewSource();
                equipoVentana = new Equipo();
                modoVisualizacion = "insertar";

                List<Equipo> listaEquiposBD = Negocio.ObtenerEquipos();

                foreach (Equipo team in listaEquiposBD)
                {
                    listaEquipos.Add(team);
                }
                vistaEquipos.Source = listaEquipos;
                dgEquipo.DataContext = vistaEquipos;
                gdGeneral.DataContext = equipoVentana;

                listaSedes = Negocio.ObtenerNombresSedes();
                cbOficina.ItemsSource = listaSedes;

                listaCategorias = Negocio.ObtenerNombresCategorias();
                cbCategoria.ItemsSource = listaCategorias;
            }
            catch (IOException error)
            {
                statusBar.Background = Brushes.IndianRed;
                tbStatusInformation.Text = error.Message;
            }

        }



//-------------------------------------------------------------------------------------MÉTODOS ASOCIADOS A EVENTOS-----------------------------------------------------------------------------

        /// <summary>
        /// Asociado al evento selectionChange de "cbOficina"actualiza el valor del equipo asociado a la ventana para el binding.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbOficina_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbOficina.SelectedIndex != -1)
                {
                    string equipoElegido = cbOficina.SelectedItem.ToString();
                    int numSede = (int)Negocio.ObtenerSedeIdPorDireccion(equipoElegido);
                    equipoVentana.NumOficina = numSede;
                }
            }
            catch (IOException error)
            {
                statusBar.Background = Brushes.IndianRed;
                tbStatusInformation.Text = error.Message;
            }
        }

        /// <summary>
        /// Asociado al evento selectionChanged de "cbCategoria" actualiza el valor del equipo asociado a la ventana para el binding.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbCategoria.SelectedIndex != -1)
                {
                    int categoria = Negocio.ObtenerTipoIdPorNombre(cbCategoria.SelectedItem.ToString());
                    equipoVentana.Idtipo = categoria;
                }
            }
            catch (IOException error)
            {
                statusBar.Background = Brushes.IndianRed;
                tbStatusInformation.Text = error.Message;
            }
        }

        /// <summary>
        /// Asociado al evento click del botón "btImportarCSV"  permite importar un archivo .csv de equipos a través de
        /// <see cref="Utilidad.ImportarCSv(string)"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtImportarCSV_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Utilidad.ImportarCSv("equipo");
                List<Equipo> listaEquiposBD = Negocio.ObtenerEquipos();

                foreach (Equipo team in listaEquiposBD)
                {
                    listaEquipos.Add(team);
                }
                vistaEquipos.Source = listaEquipos;
            }
            catch (Exception error)
            {
                statusBar.Background = Brushes.IndianRed;
                tbStatusInformation.Text = error.Message;
            }
        }

        /// <summary>
        /// Asociado al evento click del botón "btAgregar" permite insertar o editar un equipo, en caso de producir un error lo muestra
        /// por pantalla mediante <see cref="VentanaInformacion"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (modoVisualizacion.Equals("insertar"))
                {
                    List<string> listaErrores = ValidarCampos();
                    if (listaErrores.Count == 0)
                    {
                        if (Negocio.CrearEquipo(equipoVentana))
                        {
                            VentanaInformacion modal = new VentanaInformacion("Equipo guardado", "exito");
                            modal.ShowDialog();
                            vistaEquipos.Source = Negocio.ObtenerEquipos();
                        }
                        else
                        {
                            VentanaInformacion modal = new VentanaInformacion("Error al insertar equipo", "advertencia");
                            modal.ShowDialog();
                        }

                    }
                    else
                    {
                        string erroresDetectado = "";
                        foreach (string error in listaErrores)
                            erroresDetectado += error + "\n";
                        VentanaInformacion modal = new VentanaInformacion(erroresDetectado, "advertencia");
                        modal.ShowDialog();
                    }

                }
                else
                {
                    List<string> listaErrores = ValidarCampos();
                    if (listaErrores.Count == 0)
                    {
                        if (Negocio.EditarEquipo(equipoVentana))
                        {
                            VentanaInformacion modal = new VentanaInformacion("Equipo actualizado con éxito.", "exito");
                            modal.ShowDialog();
                            vistaEquipos.Source = Negocio.ObtenerEquipos();
                        }
                        else
                        {
                            VentanaInformacion modal = new VentanaInformacion("Error al actualizar equipo", "advertencia");
                            modal.ShowDialog();
                        }

                    }
                    else
                    {
                        string erroresDetectado = "";
                        foreach (string error in listaErrores)
                            erroresDetectado += error + "\n";
                        VentanaInformacion modal = new VentanaInformacion(erroresDetectado, "advertencia");
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
        /// Asociado al evento click del botón "btExportarCSV" permite exportar todos los equipos de la base de datos a un archivo
        /// CSV, para ello hace uso de <see cref="Utilidad.ExportarCsv(List{object}, string)"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtExportarCSV_Click(object sender, RoutedEventArgs e)
        {
            List<Object> listaAexportar = new List<Object>();
            foreach (Equipo eq in listaEquipos)
            {
                listaAexportar.Add(eq);
            }
            try
            {
                Utilidad.ExportarCsv(listaAexportar, "equipo");
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
        /// Asociado al evento click del botón "btEditar"  permite cambiar el modo de visualización de la interfaz, ocultando los 
        /// controles de asociar y mostrando los datos del equipo seleccionado en el formulario de añadir usuario para poder editarlo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtEditar_Click(object sender, RoutedEventArgs e)
        {
            equipoOriginal = (Equipo)dgEquipo.CurrentItem;
            equipoVentana.ServiceTag = equipoOriginal.ServiceTag;
            equipoVentana.Marca = equipoOriginal.Marca;
            equipoVentana.Modelo = equipoOriginal.Modelo;
            equipoVentana.NumSerie = equipoOriginal.NumSerie;
            equipoVentana.FinGarantia = equipoOriginal.FinGarantia;
            equipoVentana.NumOficina = equipoOriginal.NumOficina;


            try
            {
                modoVisualizacion = "editar";
                listaCategorias = Negocio.ObtenerNombresCategorias();                                          //Garantizamos que si se crean roles mientras la ventana está abierat no se  produzca excepción.
                string categoriaNombre = Negocio.ObtenerNombrePorTipoId((int)equipoOriginal.Idtipo);
                int index = listaCategorias.IndexOf(categoriaNombre);                                          // indexOf en una colecciòn retorna el indice del primer miembro que coincida.
                cbCategoria.SelectedIndex = index;

                string sede = Negocio.ObtenerDireccionSede((int)equipoVentana.NumOficina);               //Garantizamos que se crean sedes mientras la ventana está abierta, no se produzca excepción.(Otro administrador)
                index = listaSedes.IndexOf(sede);
                cbOficina.SelectedIndex = index;

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

        /// <summary>
        /// Asociado al evento click del botón "btVolver"  devuelve a la interfaz la aparienciar del modo "insertar"
        /// haciendo visibles los controles ocultados en el modo "editar".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtVolver_Click(object sender, RoutedEventArgs e)
        {
            btAgregar.Content = "AGREGAR";
            btImportarCSV.Visibility = Visibility.Visible;
            btExportarCSV.Visibility = Visibility.Visible;
            panelEditar.Visibility = Visibility.Visible;
            btVolver.Visibility = Visibility.Hidden;
            panelInformacion.Visibility = Visibility.Hidden;
            tbServiceTag.Text = "";
            tbMarca.Text = "";
            tbModelo.Text = "";
            tbNumSerie.Text = "";
          

        }

        /// <summary>
        /// Asociado al evento click del botón "btBuscarEquipo" permite hacer un filtrado de equipos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtBuscarEquipo_Click(object sender, RoutedEventArgs e)
        {
            vistaEquipos.Filter += Filtrar;
        }

        /// <summary>
        /// Asociado al evento "selectedChanged" del datetimepicker "dtpGarantia" permite tener bien actualizado el binding
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DtpGarantia_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            equipoVentana.FinGarantia = dtpGarantia.SelectedDate;
        }

        //----------------------------------------------------------------------------------MÉTODOS AUXILIARES-----------------------------------------------------------------------------

        /// <summary>
        /// Permite filtrar las sedes cuya calle coincida con el texto introducido en el textbox tbBuscarSede
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Filtrar(object sender, FilterEventArgs e)
        {
            Equipo equipo = (Equipo)e.Item;
            string equipoAbuscar = tbBuscarEquipo.Text;
            if ((equipo.ServiceTag).Contains(equipoAbuscar))
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

        /// <summary>
        /// Valida que los campos cumplan la regla de negocio, la longitud de los campos está controlada por la interfaz
        /// en cada entidad, por lo que lo único que se verífica es que los campos no estén vacios. En caso de estar en modo "editar" 
        /// el campo vacío se considera no modificado por lo que no muestra error, genera una lista de errores de validación.
        /// </summary>
        /// <returns>Lista con los errores encontrados en la validación.</returns>
        private List<string> ValidarCampos()
        {
            List<string> listaErrores = new List<string>();
            if(modoVisualizacion.Equals("insertar"))
            {
                if (tbServiceTag.Text.Equals(""))
                    listaErrores.Add("- Service Tag es campo obligatorio");
                if (tbNumSerie.Text.Equals(""))
                    listaErrores.Add("- Nº Serie es campo obligatorio");
                if (tbModelo.Text.Equals(""))
                    listaErrores.Add("- Model es campo obligatorio");
                if (tbMarca.Text.Equals(""))
                    listaErrores.Add("- Marca es campo obligatorio");
                if (dtpGarantia.SelectedDate == null)
                    listaErrores.Add("- Fin de garantía es campo obligatorio");
            }
            else
            {
                if (tbServiceTag.Text.Equals(""))
                    equipoVentana.ServiceTag = equipoOriginal.ServiceTag;
                if (tbNumSerie.Text.Equals(""))
                    equipoVentana.NumSerie = equipoOriginal.NumSerie;
                if (tbModelo.Text.Equals(""))
                    equipoVentana.Modelo = equipoOriginal.Modelo;
                if (tbMarca.Text.Equals(""))
                    equipoVentana.Marca = equipoOriginal.Marca;
                if (dtpGarantia.SelectedDate == null)
                    equipoVentana.FinGarantia = equipoOriginal.FinGarantia;

            }
            return listaErrores;
        }

    }

       
    }
