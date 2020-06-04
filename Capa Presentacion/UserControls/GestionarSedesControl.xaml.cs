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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Capa_Negocio;
using Capa_Entidades;
using System.Collections.ObjectModel;
using Capa_Presentacion.Utils;
using System.IO;
using System.Text.RegularExpressions;

namespace Capa_Presentacion.UserControls
{
    /// <summary>
    /// Lógica de interacción para SedesControl.xaml
    /// Permite:
    /// - Visualizar sedes
    /// - Añadir sedes (opción desde csv)
    /// - Actualizar sedes
    /// - Exportar sedes a un archivo csv.
    /// </summary>
    public partial class SedesControl : UserControl
    {
       
        VentanaActivaSingleton panelActual;
        ObservableCollection<string> listaLocalidades;
        ObservableCollection<Sede> sedes;
        private CollectionViewSource vistaSedes;
        Sede sedeVentana;
        Sede sedeAuxiliar;
        String modoVisualizacion;


        public SedesControl()
        {
            InitializeComponent();
            panelActual = VentanaActivaSingleton.Instancia;
            panelActual.VentanaActiva = "SedesControl";
            limpiarBarra();

            vistaSedes = new CollectionViewSource();
            sedeVentana = new Sede();
            gdGeneral.DataContext = sedeVentana;
            modoVisualizacion = "insertar";
           
            try
            {
                listaLocalidades = Negocio.ObtenerNombresLocalidades();
                sedes = Negocio.ObtenerSedes();
                cbLocalidad.ItemsSource = listaLocalidades;
                vistaSedes.Source = sedes;
                dgSedes.DataContext = vistaSedes;
            }
            catch (IOException error)
            {
                statusBar.Background = Brushes.IndianRed;
                tbStatusInformation.Text = error.Message;
            }

        }

//-----------------------------------------------------------------------------------------------FUNCIONES ASOCIADAS A EVENTOS --------------------------------------------------------------------------


        /// <summary>
        /// Asociada al evento click del botón btBuscarSede, permite hacer un filtro de las sedes de acuerdo con el contenido del textbox tbBuscarSede.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtBuscarSede_Click(object sender, RoutedEventArgs e)
        {
            limpiarBarra();
            vistaSedes.Filter += Filtrar;
        }


        /// <summary>
        /// Asociado al evento click del botón btEditar, permite editar una sede de la bse de datos, para ello
        /// oculta elementos de la interfaz para poder optimizar el  userControl y que el usuario tenga una perspectiva correcta
        /// de la acción que va a realizar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtEditar_Click(object sender, RoutedEventArgs e)
        {
            limpiarBarra();
            Sede sede = (Sede)dgSedes.CurrentItem;
            if (sede != null)
            {
                sedeVentana.NumOficina = sede.NumOficina;
                sedeVentana.Calle = sede.Calle;
                sedeVentana.Planta = sede.Planta;
                sedeVentana.CodigoPostal = sede.CodigoPostal;
                sedeVentana.Localidad = sede.Localidad;
                sedeAuxiliar = new Sede(sedeVentana);
            }

            modoVisualizacion = "editar";
            tbLocalidad.Text = ""+sede.Localidad;
            try
            {
                string localidadElegida = Negocio.ObtenerNombreLocalidad((int)sede.Localidad);

                int index = listaLocalidades.IndexOf(localidadElegida);
                cbLocalidad.SelectedIndex = index;

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
        /// Permite exportar todas las sedes a un fichero csv, para ello hace uso de una clase auxiliar
        /// <see cref="Utilidad.ExportarCsv(List{object}, string)"/>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtExportarCSV_Click(object sender, RoutedEventArgs e)
        {
            limpiarBarra();
            List<Object> listaAexportar = new List<Object>();
            foreach (Sede u in sedes)
            {
                listaAexportar.Add(u);
            }
            try
            {
                Utilidad.ExportarCsv(listaAexportar, "sede");
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
        /// Asociado al evento click del botón btVolver, permite visualizar el contenido necesario para el modo "insertar" sede.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtVolver_Click(object sender, RoutedEventArgs e)
        {
            limpiarBarra();
            modoVisualizacion = "insertar";
            btAgregar.Content = "AGREGAR";
            btImportarCSV.Visibility = Visibility.Visible;
            btExportarCSV.Visibility = Visibility.Visible;
            panelEditar.Visibility = Visibility.Visible;
            btVolver.Visibility = Visibility.Hidden;
            panelInformacion.Visibility = Visibility.Hidden;
            tbCalle.Text = "";
            tbPlanta.Text = "";
            tbCodigoPostal.Text = "";
            cbLocalidad.SelectedIndex = -1;
            tbLocalidad.Text = "";
          
        }
        /// <summary>
        /// Asociado al evento click del botón btAgregar, permite agregar o actualizar una sede, según el valor que tenga la variable modo
        /// modo= insertar ---> valida la sede y en caso de ser correcta la insertar en la base de datos, si no lo es muestra un error en forma de pantalla emergente <see cref="VentanaInformacion"/>
        /// modeo= editar ----> valida la sede y en caso de ser correcta la actualiza en la base de datos, en caso de no serlo muestra un error en forma de pantalla emergente.
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtAgregar_Click(object sender, RoutedEventArgs e) {
            limpiarBarra();
            try
            {
                List<string> errores = ValidarCampos();
                if (errores.Count == 0)
                {
                    if (modoVisualizacion.Equals("insertar"))
                    {
                        if (Negocio.CrearSede(sedeVentana))
                        {
                            VentanaInformacion modal = new VentanaInformacion("Sede Creada con éxito.", "exito");
                            modal.ShowDialog();
                            vistaSedes.Source = Negocio.ObtenerSedes();
                        }
                        else
                        {
                            VentanaInformacion modal = new VentanaInformacion("Error al crear Sede", "advertencia");
                            modal.ShowDialog();
                        }
                    }
                    else
                    {
                        if (tbCalle.Text.Equals(""))
                            sedeVentana.Calle = sedeAuxiliar.Calle;

                        if (tbCodigoPostal.Text.Equals(""))
                            sedeVentana.CodigoPostal = sedeAuxiliar.CodigoPostal;

                        if (tbPlanta.Text.Equals(""))
                            sedeVentana.Planta = sedeAuxiliar.Planta;

                        if (Negocio.EditarSede(sedeVentana))
                        {
                            VentanaInformacion modal = new VentanaInformacion("Sede actualizada con éxito.", "exito");
                            modal.ShowDialog();
                            vistaSedes.Source = Negocio.ObtenerSedes();
                        }
                        else
                        {
                            VentanaInformacion modal = new VentanaInformacion("Error al actualizar Sede", "advertencia");
                            modal.ShowDialog();
                        }
                    }
                }
                else
                {
                    string erroresDetectado = "";

                    foreach (string error in errores)
                        erroresDetectado += error + "\n";

                    VentanaInformacion modal = new VentanaInformacion(erroresDetectado, "advertencia");
                    modal.ShowDialog();
                }
            }
            catch (IOException error)
            {
                statusBar.Background = Brushes.IndianRed;
                tbStatusInformation.Text = error.Message;
            }
        }

        /// <summary>
        /// Asociado al evento click de la botón btImportarCsv, permite importar sedes desde un archivo CSV, se hace valer de una clase Auxiliar
        /// <see cref=Utilidad.ImportarCSv(string)">"/> que permite reutilizar código para las distintas entidades.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtImportarCSV_Click(object sender, RoutedEventArgs e)
        {
            limpiarBarra();
            try
            {
                Utilidad.ImportarCSv("sede");
                vistaSedes.Source = Negocio.ObtenerSedes();
            }
            catch (Exception error)
            {
                statusBar.Background = Brushes.IndianRed;
                tbStatusInformation.Text = error.Message;
            }
        }
        /// <summary>
        /// Asociado al evento selectionchanged del combobox cbLocalidad, actualiza el valor de un textbox con visibilidad collapsed que utilizamos para hacer el binding de la Sede y que en todo momento
        /// se mantenga actualizado con los valores seleccionados por el usuario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbLocalidad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            limpiarBarra();
            try
            {
                if (cbLocalidad.SelectedIndex != -1)
                {
                    string localidad = cbLocalidad.SelectedItem.ToString();
                    int? localidadId = Negocio.ObtenerLocalidadIdPorNombre(localidad);
                    tbLocalidad.Text = "" + localidadId;
                }
            }
            catch (IOException error)
            {
                statusBar.Background = Brushes.IndianRed;
                tbStatusInformation.Text = error.Message;
            }
        }

//--------------------------------------------------------------------------------------------------------FUNCIONES AUXILIARES ------------------------------------------------------------------------




        /// <summary>
        /// Realiza una validación de campos de acuerdo con las reglas de negocio:
        /// - Calle obligatorio, la longitud máxima está limitada por el interfaz (maxLineLength), es 90
        /// - Planta obligatorio, de 0 a 99, sólo admite dígitos
        /// - Código Postal obligatorio, debe contener 5 dígitos
        /// En caso de  alguno de los campos no cumpla las regla de validación muestra un mensaje de error
        /// En caso de encontrarse en modo "editar" admite que ciertos campos tomen el valor "" vacio, puesto que posteriormente recuperará el valor original.
        /// </summary>
        /// <returns> Lista de errores con los fallos de validación detectados.</returns>
        private List<string> ValidarCampos()
        {
            List<string> listaErrores = new List<string>();
            if (tbCalle.Text.Equals("") && modoVisualizacion.Equals("insertar"))
                listaErrores.Add("- Calle es campo obligatorio");
            if (tbPlanta.Text.Equals("") && modoVisualizacion.Equals("insertar"))
            {
                listaErrores.Add("- Planta es campo obligatorio");
            }
            else
            {
                try
                {
                    int planta = int.Parse(tbPlanta.Text);
                }
                catch
                {
                    listaErrores.Add("- Planta debe ser numérico, de 0 a 99");
                }
            }
            Regex regex = new Regex("[0-9]{5}");

            if (!regex.IsMatch(tbCodigoPostal.Text) && modoVisualizacion.Equals("insertar") || ( !tbCodigoPostal.Text.Equals("") && modoVisualizacion.Equals("editar") && (!regex.IsMatch(tbCodigoPostal.Text))))
            {
                listaErrores.Add("- CP es obligatorio y debe contener 5 digitos.");
            }

            if (cbLocalidad.SelectedIndex == -1)
                listaErrores.Add("- Localidad es obligatorio, por favor escoja una ciudad");

            return listaErrores;
        }


        /// <summary>
        /// Permite filtrar las sedes cuya calle coincida con el texto introducido en el textbox tbBuscarSede
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Filtrar(object sender, FilterEventArgs e)
        {
            Sede sede = (Sede)e.Item;
            string sedeAbuscar = tbBuscarSede.Text;
            if ((sede.Calle).Contains(sedeAbuscar))
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
