using Aspose.BarCode;
using Aspose.BarCode.Generation;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Capa_Entidades;
using Capa_Negocio;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Diagnostics;

namespace Capa_Presentacion.UserControls
{
    /// <summary>
    /// Lógica de interacción para CrearCodigoBarrasContorl.xaml
    /// Permite crear un código de barras para después imprimirlo si se ve necesario, en caso 
    /// de que los equipos no dispongan de pegatina identificativa, también cuando un nuevo équipo se 
    /// da de alta.
    /// </summary>
    public partial class CrearCodigoBarrasContorl : UserControl
    {
        
        ObservableCollection<Equipo> equipos;
      
        StackPanel principal;
        private CollectionViewSource MiVista;
        BarcodeGenerator generator;
        BitmapImage bi3;
        VentanaActivaSingleton panelActual;
        public CrearCodigoBarrasContorl()
        {
            InitializeComponent();
            panelActual = VentanaActivaSingleton.Instancia;
            panelActual.VentanaActiva = "CrearCodigoBarrasControl";
            limpiarBarra();

            bi3 = new BitmapImage();
            
       
            equipos = new ObservableCollection<Equipo>();

            try
            {
                foreach (Equipo equipo in Negocio.ObtenerEquipos())
                {
                    equipos.Add(equipo);
                }

                MiVista = new CollectionViewSource();
                MiVista.Source = equipos;
                dtEquipos.DataContext = MiVista;
            }
            catch (IOException error)
            {
                statusBar.Background = System.Windows.Media.Brushes.IndianRed;
                tbStatusInformation.Text = error.Message;
            }

        }


        //--------------------------------------------------------------------------------FUNCIONES ASOCIADAS A EVENTOS---------------------------------------------------------------------------   
    
        /// <summary>
        /// Gestiona el evento click del botón btGenerar, para generar una etiqueta si el control es activado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtGenerar_Click(object sender, RoutedEventArgs e)
        {
            limpiarBarra();
            GenerarEtiqueta();
        }
       
   
        /// <summary>
        /// Gestiona el evento textChanged del textbox tbNumSerie para filtrar el datagrid,según sus valores.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbNumSerie_TextChanged(object sender, TextChangedEventArgs e)
        {
            MiVista.Filter += Filtrar;
        }
     
        /// <summary>
        /// Gestiona el evento dobleClick del datagrid dtEquipos, al seleccionar un equipo directamente se genera 
        /// el archivo con la etiqueta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DtEquipos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            limpiarBarra();
            Equipo equipo=(Equipo) dtEquipos.CurrentItem;
            if (equipo != null)
            {
                tbEtiqueta.Text = equipo.ServiceTag;
                GenerarEtiqueta();
            }
            
        }

        /// <summary>
        /// Establece el panel padre del user control el el evento loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            principal = (StackPanel)this.Parent;
        }

        /// <summary>
        /// Gestiona el evento click del botón btAbrirEtiqueta, al activarlo abre el visor de windows de fotos con el código de barras generado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtAbrirEtiqueta_Click(object sender, RoutedEventArgs e)
        {

            //TODO Verificar que el archivo exista antes de intentar abrirlo.
            //    Process.Start(Environment.CurrentDirectory.Replace("bin\\Debug", "") + "Imagenes\\codigoGenerado.png"); para modo debug

            limpiarBarra();
            string path = Environment.CurrentDirectory + "\\Imagenes\\codigoGenerado.png";
            if (!File.Exists(path))
                path = Environment.CurrentDirectory.Replace("bin\\Debug", "") + "Imagenes\\codigoGenerado.png";
                Process.Start(path);
         
         
        }

        //--------------------------------------------------------------------------------------FUNCIONES AUXILIARES----------------------------------------------------------------------------

        /// <summary>
        /// Genera un fichero con un código de barras en formato code128, en el directorio Imagenes
        /// con el nombre codigoGenerado.png
        /// </summary>
        private void GenerarEtiqueta()
        {
            string texto = tbEtiqueta.Text;
            if (!tbEtiqueta.Text.Equals(""))
            {
                //    Process.Start(Environment.CurrentDirectory.Replace("bin\\Debug", "") + "Imagenes\\codigoGenerado.png"); para modo debug
                string dataDir = Environment.CurrentDirectory+"\\Imagenes\\codigoGenerado.png";
                if (!File.Exists(dataDir))
                    dataDir = Environment.CurrentDirectory.Replace("bin\\Debug", "") + "Imagenes\\codigoGenerado.png";
                using (var myFile = File.OpenWrite(dataDir))
                {
                    try
                    {
                        // Instantiate object and set differnt barcode properties
                        generator = new BarcodeGenerator(EncodeTypes.Code128, texto);
                        generator.Parameters.Barcode.XDimension.Millimeters = 1f;

                        // Save the image to your system and set its image format to Jpeg
                        generator.Save(myFile, BarCodeImageFormat.Png);
                        generator.Dispose();
                        imgCodigo.Visibility = Visibility.Visible;
                        VentanaInformacion modal = new VentanaInformacion("La etiqueta " + texto + " ha sido generada con éxito", "exito");
                        modal.ShowDialog();
                    }
                    catch (Exception)
                    {

                        VentanaInformacion modal = new VentanaInformacion("Error al generar etiqueta", "advertencia");
                        modal.ShowDialog();
                        imgCodigo.Visibility = Visibility.Hidden;
                    }

                }

            }

        }


        /// <summary>
        /// Permite filtrar el datagrid por medio del número de serie introducido en tbNumSerie.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Filtrar(object sender, FilterEventArgs e)
        {
            Equipo equipo = (Equipo)e.Item;
            if (equipo != null)
            {
                if (equipo.NumSerie.ToUpper().Contains(TbNumSerie.Text.ToUpper()))
                {
                    if (equipo.NumSerie.ToUpper().Equals(TbNumSerie.Text.ToUpper()))
                        tbEtiqueta.Text = equipo.ServiceTag;
                    e.Accepted = true;
                }
                else
                    e.Accepted = false;
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
    }
}
