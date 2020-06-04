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
using Capa_Negocio;
using Capa_Entidades;
using System.Threading;
using System.Collections.ObjectModel;
using Capa_Presentacion.Utils;
using System.Text.RegularExpressions;

namespace Capa_Presentacion.UserControls
{
    /// <summary>
    /// Lógica de interacción para UsuariosControl.xaml
    /// Muestra un listado de los usuarios, permitiendo crear nuevos contactos o importarlos desde un .csv
    /// editarlos y exportarlos a un documento csv.
    /// El control tendrá dos vistas de la interfaz, la vista "insertar" y la vista "editar" esto se realizará 
    /// ocultando y haciendo visibles controles y cambiando el modo a través de una variables "bisagra" que será 
    /// el string modoVisualizacion, que podrá tomar valores Insertar o Editar.
    /// </summary>
    public partial class UsuariosControl : UserControl
    {

        Usuario usuario;
        Usuario usuarioOriginal;
        ObservableCollection<Usuario> listaUsuarios = new ObservableCollection<Usuario>();

        private CollectionViewSource vistaUsuarios = new CollectionViewSource();
        VentanaActivaSingleton panelActual;
        List<string> listaRoles;
        List<string> listaSedes;
        string modoVisualizacion;
        

        public UsuariosControl()
        {
            InitializeComponent();
           
            panelActual = VentanaActivaSingleton.Instancia;
            panelActual.VentanaActiva = "UsuariosControl";
            limpiarBarra();

            modoVisualizacion = "insertar";
            usuario = new Usuario();
            usuarioOriginal = new Usuario();
            gdGeneral.DataContext = usuario;
            try
            {
                listaUsuarios = Negocio.ObtenerUsuarios();
                vistaUsuarios.Source = listaUsuarios;
                listaRoles = Negocio.ObtenerNombresRoles();
                cbRoles.DataContext = listaRoles;
                listaSedes = Negocio.ObtenerNombresSedes();
                cbOficina.DataContext = listaSedes;
                cbBuscarSede.DataContext = listaSedes;
                dgUsuario.DataContext = vistaUsuarios;
            }
            catch (IOException error)
            {
                statusBar.Background = Brushes.IndianRed;
                tbStatusInformation.Text = error.Message;
            }
        }

        
        //--------------------------------------------FUNCIONES ASOCIADAS A EVENTOS-------------------------------------------------

       /// <summary>
       /// Asociado al evento click del botón "btImportarCSV" permite importar usuarios desde un archivo .csv y añadirlos a la base de datos
       /// para ello hace uso de una clase auxiliar <see cref="Utilidad.ImportarCSv(string)"/>
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void BtImportarCSV_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Utilidad.ImportarCSv("usuario");
                listaUsuarios = Negocio.ObtenerUsuarios();
                vistaUsuarios.Source = listaUsuarios;
            }
            catch (Exception error)
            {
                statusBar.Background = Brushes.IndianRed;
                tbStatusInformation.Text = error.Message;
            }
        }


        /// <summary>
        /// Asociado al evento click del botón "btAgregar" permite agregar un usuario a la base de datos , después de validar los datos
        /// <see cref="ValidarCampos"/>, la clave de usuario se codificará  en MD5  usando para ello el método <see cref="Utilidad.CalculateMD5Hash(string)"/>
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
                        usuario.Password = Utilidad.CalculateMD5Hash(usuario.Password);
                        if (Negocio.CrearUsuario(usuario))
                        {
                            VentanaInformacion modal = new VentanaInformacion("Usuario guardado", "exito");
                            modal.ShowDialog();
                            vistaUsuarios.Source = Negocio.ObtenerUsuarios();
                        }
                        else
                        {
                            VentanaInformacion modal = new VentanaInformacion("Error al insertar usuario", "advertencia");
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
                    if (tbNombre.Text.Equals(""))
                        usuario.Nombre = usuarioOriginal.Nombre;
                    if (tbApellidos.Text.Equals(""))
                        usuario.Apellidos = usuarioOriginal.Apellidos;
                    if (tbCorreo.Text.Equals(""))
                        usuario.Mail = usuarioOriginal.Mail;
                    if (pwPassword.Password.Equals(""))
                        usuario.Password = usuarioOriginal.Password;
                    List<string> errores = ValidarCampos();
                    if (errores.Count == 0)
                    {
                        usuario.Password = Utilidad.CalculateMD5Hash(usuario.Password);
                        if (Negocio.EditarUsuario(usuario))
                        {
                            VentanaInformacion modal = new VentanaInformacion("Usuario actualizado con éxito.", "exito");
                            modal.ShowDialog();
                            vistaUsuarios.Source = Negocio.ObtenerUsuarios();
                        }
                        else
                        {
                            VentanaInformacion modal = new VentanaInformacion("Error al actualizar usuario", "advertencia");
                            modal.ShowDialog();
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
            }
            catch (IOException error)
            {
                statusBar.Background = Brushes.IndianRed;
                tbStatusInformation.Text = error.Message;
            }

        }

      
        /// <summary>
        /// Asociado al evento click del botón "BtBuscarUsuario" permite realizar una búsqueda filtrada de usuarios
        /// <see cref="Filtrar(object, FilterEventArgs)"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtBuscarUsuario_Click(object sender, RoutedEventArgs e)
        {
            vistaUsuarios.Filter += Filtrar;
        }

        /// <summary>
        /// Asociado al evento click del botón "BtExportarCSV" permite exportar a un archivo csv los usuarios existentes
        /// en la base de datos, para ello hace uso de <see cref="Utilidad.ExportarCsv(List{object}, string)"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtExportarCSV_Click(object sender, RoutedEventArgs e)
        {
            List<Object> listaAexportar = new List<Object>();
            foreach (Usuario u in listaUsuarios)
            {
                listaAexportar.Add(u);
            }
            try
            {
                Utilidad.ExportarCsv(listaAexportar, "usuario");
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
        /// Permite realizar una búsqueda de usuarios por nombre y apellidos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Filtrar(object sender, FilterEventArgs e)
        {
            Usuario usuario =(Usuario) e.Item;
            string usuarioAbuscar = tbBuscarUsuario.Text;
            if ((usuario.Nombre + " " + usuario.Apellidos).Contains(usuarioAbuscar))
                e.Accepted = true;
            else
                e.Accepted = false;

        }

        /// <summary>
        /// Asociado al evento click del botón "BtEditar" añade la información del usuario seleccionado a el formulario de agregar usuario para
        /// posteriormente poder editarlo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtEditar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Usuario usuarioSeleccionado = (Usuario)dgUsuario.CurrentItem;
                usuarioOriginal = new Usuario(usuarioSeleccionado);
                if (usuarioSeleccionado != null)
                {
                    this.usuario.Extension = usuarioSeleccionado.Extension;
                    this.usuario.Nombre = usuarioSeleccionado.Nombre;
                    this.usuario.Apellidos = usuarioSeleccionado.Apellidos;
                    this.usuario.Mail = usuarioSeleccionado.Mail;
                    this.usuario.UsuarioId = usuarioSeleccionado.UsuarioId;
                    this.usuario.Password = usuarioSeleccionado.Password;
                    this.usuario.NumOficina = usuarioSeleccionado.NumOficina;
                    this.usuario.RolUsuario = usuarioSeleccionado.RolUsuario;

                }

                modoVisualizacion = "editar";
                listaRoles = Negocio.ObtenerNombresRoles();                                          //Garantizamos que si se crean roles mientras la ventana está abierat no se  produzca excepción.
                string rolUsuario = Negocio.ObtenerRolNombrePorId(usuario.RolUsuario);
                int index = listaRoles.IndexOf(rolUsuario);
                cbRoles.SelectedIndex = index;

                listaSedes = Negocio.ObtenerNombresSedes();
                string sede = Negocio.ObtenerDireccionSede((int)usuario.NumOficina);               //Garantizamos que se crean sedes mientras la ventana está abierta, no se produzca excepción.(Otro administrador)
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
        /// Asociado al evento click del botón "btVolver"
        /// Permite volver a la vista en modo "agregar" donde se muestra un listado de usuarios y los campos inicializados en blanco para poder agregar usuarios.
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
            tbApellidos.Text = "";
            tbExtension.Text = "";
            cbOficina.SelectedIndex = -1;
            cbRoles.SelectedIndex = -1;
            pwPassword.Password = "";
            pwRepeat.Password = "";
            tbCorreo.Text = "";
         
        }

        /// <summary>
        /// Asociado al evento selectionChanged del combobox "CbOficina" utiliza un tbText para hacer un binding, esto no sería necesario si se realizara un
        /// converter, dejamos pendiente TODO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbOficina_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbOficina.SelectedIndex != -1)
            {
                string sede = cbOficina.SelectedItem.ToString();
                try
                {
                    int? sedeId = Negocio.ObtenerSedeIdPorDireccion(sede);
                    tbOficina.Text = "" + sedeId;
                }
                catch (IOException error)
                {
                    statusBar.Background = Brushes.IndianRed;
                    tbStatusInformation.Text = error.Message;
                }
            }
            
        }

        /// <summary>
        /// Asociado al evento selectionChanged del combobox "CbRoles" utiliza un tbText para hacer un binding, esto no sería necesario si se realizara un
        /// converter, dejamos pendiente TODO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbRoles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbRoles.SelectedIndex != -1)
            {
                string rol = cbRoles.SelectedItem.ToString();
                int? rolId = Negocio.ObtenerRolIdPorNombre(rol);
                tbRol.Text = "" + rolId;
            }
           
        }



//----------------------------------------------------------------------------------------------------FUNCIONES AUXILIARES-----------------------------------------------------------------------------------

        /// <summary>
        /// Realiza la validación de los campos, devolviendo un listado con los errores detectados
        /// </summary>
        /// <returns>Un listado con los errores de validación detectados.</returns>
        private List<string> ValidarCampos()
        {
            List<string> listaErrores = new List<string>();
            try
            {
                if (modoVisualizacion.Equals("insertar"))
                {
                    if (tbNombre.Text.Equals(""))
                        listaErrores.Add("Nombre es campo obligatorio");
                    if (tbApellidos.Text.Equals(""))
                        listaErrores.Add("Apellidos es campos obligatorio");
                    if (tbExtension.Text.Equals(""))
                        listaErrores.Add("Extensión es campo obligatorio");
                    if (cbOficina.SelectedIndex == -1)
                        listaErrores.Add("Debe seleccionar oficina");
                    if (cbRoles.SelectedIndex == -1)
                        listaErrores.Add("Debe seleccionar un rol de usuario");
                }
                if (!pwPassword.Password.Equals("") || !pwRepeat.Password.Equals(""))
                {
                    if (!pwPassword.Password.Equals(pwRepeat.Password))
                    {
                        listaErrores.Add("- Las contraseñas no coinciden");
                    }
                    else
                    {
                        string expresion;
                        expresion = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,12}$";
                        System.Text.RegularExpressions.Regex automata = new Regex(expresion);
                        bool passwordCorrecto = automata.IsMatch(pwRepeat.Password);
                        if (passwordCorrecto)
                            tbPassword.Text = pwPassword.Password;
                        else
                            listaErrores.Add("La contraseña debe tener de 8 a 12 caracteres e incluir una mayúscula, número y caracter especial");
                    }
                }
                if (modoVisualizacion.Equals("insertar"))
                {
                    if (!Negocio.ValidarExtension(tbExtension.Text))
                        listaErrores.Add("La extensión no es numérica o  está asignada a otro usuario,debe tener 4 digitos");
                }
                else
                {
                    if (!Negocio.ValidarExtension(tbExtension.Text, (int)usuario.UsuarioId))
                        listaErrores.Add("La extensión no es numérica o  está asignada a otro usuario,debe tener 4 digitos");
                }

                return listaErrores;
            }
            catch (IOException error)
            {
                statusBar.Background = Brushes.IndianRed;
                tbStatusInformation.Text = error.Message;
                return listaErrores;
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
