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
    /// Lógica de interacción para impUserModal.xaml
    /// Muestra un resumén de la colección de objetos que se le pasa a través del constructor y en caso de 
    /// confirmar se añaden a la base de datos mediante las funciones de la capa negocio.
    /// </summary>
    public partial class impUserModal : Window
    {
        List<Usuario> listaUsuarios = new List<Usuario>();
        List<Tipo> listaCategorias = new List<Tipo>();
        List<Localidad> listaLocalidades = new List<Localidad>();
        List<Equipo> listaEquipos = new List<Equipo>();
        List<Sede> listaSedes = new List<Sede>();
        string tipoObjeto;


        public impUserModal()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listaObjetos"></param>
        /// <param name="tipo">Permite determinar si la lista que recibimos será de equipos, usuarios, sedes... para reutilizar al máximo el código.</param>
        /// <param name="texto"></param>
        public impUserModal(List<Object> listaObjetos,string tipo)
        {
            InitializeComponent();
           
            tipoObjeto = tipo;

            switch (tipo) {
                case "usuario":
                    foreach(Object t in listaObjetos)
                    {
                                listaUsuarios.Add((Usuario)t);
                    }
                    lbImportar.Content = "¿Desea añadir " + listaObjetos.Count + " usuarios a la base de datos?";
                    dgImportar.DataContext = listaUsuarios;
                    break;

                case "categoria":
                    foreach (Object t in listaObjetos)
                    {
                        listaCategorias.Add((Tipo)t);
                    }
                    lbImportar.Content = "¿Desea añadir " + listaObjetos.Count + " categorías a la base de datos?";
                    dgImportar.DataContext = listaCategorias;
                    break;

                case "localidad":
                    foreach (Object t in listaObjetos)
                    {

                        listaLocalidades.Add((Localidad)t);
                    }
                    lbImportar.Content = "¿Desea añadir " + listaObjetos.Count + " localidades a la base de datos?";
                    dgImportar.DataContext = listaLocalidades;
                    break;

                case "equipo":
                    foreach (Object t in listaObjetos)
                    {
                        listaEquipos.Add((Equipo)t);
                    }
                    lbImportar.Content = "¿Desea añadir " + listaObjetos.Count + " equipos a la base de datos?";
                    dgImportar.DataContext = listaEquipos;
                    break;

                case "sede":
                    foreach (Object t in listaObjetos)
                    {
                        listaSedes.Add((Sede)t);
                    }
                    lbImportar.Content = "¿Desea añadir " + listaObjetos.Count + " sedes a la base de datos?";
                    dgImportar.DataContext = listaSedes;
                    break;
            }
        }

        //--------------------------------------------------------------------------------FUNCIONES ASOCIADAS A EVENTOS---------------------------------------------------------------------------   

          /// <summary>
          /// Gestiona el evento click del botón btAñadir, va a permitir añadir de forma másiva un listado de objetos a la base de datos
          /// en primer lugar se realizará una selección para determinar que tipo de tabla hemos de rellenar y a continuación se procederá
          /// a actualizar la base de datos.
          /// TODO validar campos, ahora si los campos no son válidos simplemente no se crea el registro, lo ideal sería validar para dar un mensaje
          /// sobre el porque no se crea.
          /// </summary>
          /// <param name="sender"></param>
          /// <param name="e"></param>
        private void BtAñadir_Click(object sender, RoutedEventArgs e)
        {
            int contador = 0;
            //aquí añadir usuarios a la base de datos
            try
            {
                switch (tipoObjeto)
                {
                    case "usuario":
                        
                        foreach (Usuario user in listaUsuarios)
                        {
                            user.Password = Utils.Utilidad.CalculateMD5Hash(user.Password);
                            if (Negocio.CrearUsuario(user))
                                contador++;
                        }
                        VentanaInformacion modal = new VentanaInformacion(contador + " Usuarios añadidos a la base de datos.","exito");
                        modal.ShowDialog();
                        break;
                    case "localidad":
                        foreach (Localidad local in listaLocalidades)
                        {
                            if (Negocio.CrearLocalidad(local))
                                contador++;
                        }
                        VentanaInformacion modal2 = new VentanaInformacion(contador + " Localidades añadidas a la base de datos.", "exito");
                        modal2.ShowDialog();
                       
                        break;
                    case "categoria":
                        foreach (Tipo tipo in listaCategorias)
                        {
                            if (Negocio.CrearTipo(tipo))
                                contador++;
                        }
                        VentanaInformacion modal3 = new VentanaInformacion(contador + " Categorias añadidas a la base de datos.", "exito");
                        modal3.ShowDialog();
                        break;

                    case "equipo":
                        foreach (Equipo equipo in listaEquipos)
                        {
                            if (Negocio.CrearEquipo(equipo))
                                contador++;
                        }
                        VentanaInformacion modal4 = new VentanaInformacion(contador + " Equipos añadidos a la base de datos.", "exito");
                        modal4.ShowDialog();
                        break;
                    case "sede":
                        foreach (Sede sede in listaSedes)
                        {
                            if (Negocio.CrearSede(sede))
                                contador++;
                        }
                        VentanaInformacion modal5= new VentanaInformacion(contador + " Sedes añadidas a la base de datos.", "exito");
                        modal5.ShowDialog();
                        break;
                }
            }
            catch (IOException )
            {
                VentanaInformacion modal = new VentanaInformacion("Error al acceder a la base de datos", "advertencia");
                modal.ShowDialog();
            }
            this.Close();
        }

        /// <summary>
        /// Gestiona el evento click del botón btCancelar, en caso de activarse, cierra la ventana.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
