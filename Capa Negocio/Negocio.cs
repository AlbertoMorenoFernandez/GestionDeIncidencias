using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidades;

namespace Capa_Negocio
{
    public static class Negocio

    {
        private static LocalidadADO accesoApiLocalidad = new LocalidadADO();
        private static UsuarioADO accesoApiUsuario = new UsuarioADO();
        private static EstadoADO accesoApiEstado= new EstadoADO();
        private static TipoADO accesoApiTipo= new TipoADO();
        private static TicketADO accesoApiTicket= new TicketADO();
        private static EquipoADO accesoApiEquipo= new EquipoADO();
        private static RolADO accesoApiRol= new RolADO();
        private static SedeADO accesoApiSede = new SedeADO();
        private static TecnicoADO accesoApiTecnico = new TecnicoADO();

      

        private static EstadoConexionADO accesoApiEstadoConexion = new EstadoConexionADO();
        private static EstadoUsuarioADO accesoApiEstadoUsuario = new EstadoUsuarioADO();
        private static TicketEnCursoADO accesoApiTicketEnCurso= new TicketEnCursoADO();


  

        /// <summary>
        /// Comprueba que un usuario esté en la base de datos, mediante su correo electrónico y password
        /// </summary>
        /// <param name="correo">El correo del usuario</param>
        /// <param name="pass">La contraseña introducida.</param>
        /// <returns>Devuelve el usuario si está en la base de datos o null sino está.</returns>
        public static Usuario VerificarLogin(string correo, string pass)
        {
            List<Usuario> usuarios;

            try
            {
                 usuarios = accesoApiUsuario.LeerUsuarios();
                List<Usuario> coincidencias = usuarios.Where(x => x.Mail.Equals(correo) && x.Password.Equals(pass)).ToList();
                if (coincidencias.Count != 1)
                    return null;
                else
                    return coincidencias[0];
          
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return null;
                
            }
           
        }


        //-----------------------------------------------FUNCIONES EQUIPO-----------------------------------------------------
        /// <summary>
        /// Obtiene el equipo a través de su serviceTag
        /// </summary>
        /// <param name="serviceTag">serviceTag del equipo pasado</param>
        /// <returns>El equipo que coincide con el serviceTag pasado como parámetro o sino existe null.</returns>
        public static Equipo ObtenerEquipo(string serviceTag)
        {
            try
            {
                return !serviceTag.Equals("") ? accesoApiEquipo.LeerEquipo(serviceTag) : null;
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// Obtiene todos los equipos existentes en la base de datos.
        /// </summary>
        /// <returns> Lista con los equipos de la BD o null.</returns>
        public static List<Equipo> ObtenerEquipos()
        {
            try
            {
                return accesoApiEquipo.LeerEquipos();
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return null;
            }
        }

       



        /// <summary>
        /// Añade un equipo a la BD
        /// </summary>
        /// <param name="equipo"> Equipo que se desea añadir</param>
        /// <returns>True si el equipo se ha añadido correctamente.</returns>
        public static bool CrearEquipo(Equipo equipo)
        {
            try
            {
                return accesoApiEquipo.InsertarEquipo(equipo.ServiceTag, equipo.Marca, equipo.Modelo, equipo.FinGarantia, equipo.Idtipo, equipo.NumOficina, equipo.NumSerie);
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
               return false;
            }
        }
        /// <summary>
        /// Actualiza los datos de un equipo en la base de datos
        /// </summary>
        /// <param name="equipo">Equipo que se desea actualizar</param>
        /// <returns>True si el equipo se ha actualizado correctamente.</returns>
        public static bool EditarEquipo(Equipo equipo)
        {
            try
            {
                return accesoApiEquipo.ActualizarEquipo(equipo);
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return false;
            }
        }

     

        /// <summary>
        /// Elimina un equipo de la base de datos
        /// </summary>
        /// <param name="serviceTag">ServiceTag del equipo que se desea eliminar</param>
        /// <returns>True si el equipo se ha eliminado correctamente de la BD.</returns>
        public static bool EliminarEquipo(string serviceTag)
        {
            try
            {
                return accesoApiEquipo.BorrarEquipo(serviceTag);
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Valida un equipo según las reglas de negocio
        /// </summary>
        /// <param name="equipo"> Equipo que se desea validar</param>
        /// <returns>Una lista con los errores de validación en caso de haberlos.</returns>
        public static List<string> validarEquipo(Equipo equipo)
        { 
            List<string> listaErrores = new List<string>();
            if (equipo.ServiceTag == null)
                listaErrores.Add("ServiceTag: es campo obligatorio.");
            if (equipo.ServiceTag != null && equipo.ServiceTag.Length > 7)
                listaErrores.Add("ServiceTag: longitud máxima 7 caracteres.");
            if (equipo.Marca == null)
                listaErrores.Add("Marca: es campo obligatorio");
            if (equipo.Marca != null && equipo.Marca.Length > 50)
                listaErrores.Add("Marca: longitud máxima 50 caracteres.");
            if (equipo.Modelo == null)
                listaErrores.Add("Modelo: es campo obligatorio");
            if (equipo.Modelo != null && equipo.Modelo.Length > 50)
                listaErrores.Add("Modelo: longitud máxima 50 caracteres.");
            if (equipo.FinGarantia == null)
                listaErrores.Add("FinGarantia: es campo obligatorio");

            try
            {
                List<Tipo> listaTipos = ObtenerTipos();
                List<int> tipos = new List<int>();
                foreach (Tipo tip in listaTipos)
                    tipos.Add((int)tip.Id);
                if (!tipos.Contains(((int)equipo.Idtipo)))
                    listaErrores.Add("Categoria: categoría no registrada en base de datos");

                ObservableCollection<Sede> sedes = ObtenerSedes();
                List<int> listaSedes = new List<int>();
                foreach (Sede sede in sedes)
                {
                    listaSedes.Add((int)sede.NumOficina);
                }
                if (!listaSedes.Contains((int)equipo.NumOficina))
                    listaErrores.Add("Sede: sede no registrada en base de datos");
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                listaErrores.Add("Error de formato en  sede o categoría");
            }
          
            if (equipo.NumSerie == null)
                listaErrores.Add("NumSerie: es campo obligatorio");
            if (equipo.NumSerie != null && equipo.NumSerie.Length > 50)
                listaErrores.Add("NumSerie: longitud máxima 50 caracteres");

            return listaErrores;
        }

        //-----------------------------------------------FUNCIONES ESTADO-----------------------------------------------------
        /// <summary>
        /// Obtiene un Estado de la base de dtos
        /// </summary>
        /// <param name="id">id del Estado que se desea obtener</param>
        /// <returns>Estado solicitado</returns>
        public static Estado ObtenerEstado(int id)
        {
            try
            {               
                return accesoApiEstado.LeerEstado(id);
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// Obtiene todos los estados de la base de datos
        /// </summary>
        /// <returns>Lista con Estados de la base de datos.</returns>
        public static List<Estado> ObtenerEstados()
        {
            try
            {
                return accesoApiEstado.LeerEstados();
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// Insertar un Estado en la base de datos
        /// </summary>
        /// <param name="estado"> Estado que se desea insertar</param>
        /// <returns>True si el equipo ha sido insertado correctamente en la base de datos.</returns>
        public static bool CrearEstado(Estado estado)
        {
            try
            {
                return accesoApiEstado.InsertarEstado((int)estado.Id, estado.Descripcion);
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Actualiza un Estado en la base de datos
        /// </summary>
        /// <param name="estado">Estado que se desea actualizar</param>
        /// <returns> True si el Estado se ha actualizado con éxito.</returns>
        public static bool ActualizarEstado(Estado estado)
        {
            try
            {
                return accesoApiEstado.ActualizarEstado(estado);
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Elimina un estado de la base de datos
        /// </summary>
        /// <param name="id"> Id del Estado que deseamos eliminar</param>
        /// <returns> True si el estado ha sido eliminado con éxito.</returns>
        public static bool EliminarEstado(int id)
        {
            try
            {
                return accesoApiEstado.BorrarEstado(id);
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return false;
            }
        }

      

        //------------------------------------------------FUNCIONES LOCALIDAD ------------------------------------------------
        /// <summary>
        /// Obtiene una localidad de la base de datos
        /// </summary>
        /// <param name="id">Id de la localidad que deseamos obtener</param>
        /// <returns>Localidad solicitada o null sino existe</returns>
        public static Localidad ObtenerLocalidad(int id)
        {
            try
            {
                return accesoApiLocalidad.LeerLocalidad(id);
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return null;
            }
        }

      

        /// <summary>
        /// Obtiene localidades de la base de datos
        /// </summary>
        /// <returns>Lista con las localidades de la BD</returns>
        public static List<Localidad> ObtenerLocalidades()
        {
            try
            {
                return accesoApiLocalidad.LeerLocalidades();
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// Obtiene lista con nombres de localidades de la base de datos
        /// </summary>
        /// <returns>Lista con las localidades de la BD</returns>
        public static ObservableCollection<string> ObtenerNombresLocalidades()
        {
            try
            {
                ObservableCollection<string> localidades = new ObservableCollection<string>();
                List<Localidad> listaLocalidades= accesoApiLocalidad.LeerLocalidades();
                foreach (Localidad local in listaLocalidades)
                    localidades.Add(local.Nombre);
                return localidades;
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Insertar una Localidad en la base de datos. Como el nombre es campo único, verífica que no existe
        /// en la base de datos y en caso de no existir la inserta.
        /// </summary>
        /// <param name="local">Localidad que deseamos insertar</param>
        /// <returns>True si la Localidad se ha creado correctamente.</returns>
        public static bool CrearLocalidad(Localidad local)
        {
  
            try
            {
                List<Localidad> localidades = accesoApiLocalidad.LeerLocalidades();
                List<Localidad> localidadesFiltradas=localidades.Where(x => x.Nombre.Equals(local.Nombre)).ToList();
                if (localidadesFiltradas.Count == 0)
                    return accesoApiLocalidad.InsertarLocalidad(local.Id, local.Nombre);
                else
                    return false;
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return false;
            }
        }

     

        /// <summary>
        /// Permite editar una Localidad de la base de datos
        /// </summary>
        /// <param name="local">Localidad a editar</param>
        /// <returns> True si la localidad se ha editado correctamente.</returns>
        public static bool EditarLocalidad(Localidad local)
        {
            try
            {
                return accesoApiLocalidad.ActualizarLocalidad(local);
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Elimina una localidad de la base de datos
        /// </summary>
        /// <param name="id">Id de la Localidad a eliminar</param>
        /// <returns> True si la localidad se ha eliminado correctamente.</returns>
        public static bool EliminarLocalidad(int id)
        {
            try
            {
               return accesoApiLocalidad.BorrarLocalidad(id);
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return false;
            }
        }
         
        

        /// <summary>
        /// Obtiene el nombre de una Localidad
        /// </summary>
        /// <param name="id">Id del nombre que deseamos buscar</param>
        /// <returns> Nombre de la localidad elegida.</returns>
        public static string ObtenerNombreLocalidad(int id)
        {
            Localidad local;
            try
            {
                local = ObtenerLocalidad(id);
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return null;
            }
            return local.Nombre;
        }

       /// <summary>
       /// Valida una localidad según las reglas de negocio
       /// </summary>
       /// <param name="local">Localidad a validar</param>
       /// <returns> Lista con los errores de validación en caso de haberlos.</returns>
       public static List<string> ValidarLocalidad(Localidad local)
        {
            List<string> listaErrores = new List<string>();
            if (local.Nombre == null || local.Nombre.Equals(""))
                listaErrores.Add("Localidad: es campo obligatorio");
            if (local.Nombre.Length > 50)
                listaErrores.Add("Localidad: longitud máxima 50 caracteres");


            return listaErrores;

        }

        /// <summary>
        /// Encuentra el id de una localidad, dados su nombre
        /// </summary>
        /// <param name="localidad">Nombre de la localidad deseada</param>
        /// <returns>localidad id o -1 en caso de no existir. </returns>
        public static int ObtenerLocalidadIdPorNombre(string localidad)
        {
            try
            {
                return (int)ObtenerLocalidades().Where(x => x.Nombre.Equals(localidad)).ToList()[0].Id;
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return -1;
            }
        }

        //----------------------------------------------------------FUNCIONES ROL--------------------------------------------
        /// <summary>
        /// Obtiene rol de la base de datos
        /// </summary>
        /// <param name="id">id del Rol que se desea obtener</param>
        /// <returns>Rol con el id indicado en caso de existir.</returns>
        public static Rol ObtenerRol(int id)
        {
            try
            {
                return accesoApiRol.LeerRol(id);
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Obtiene los roles de la base de datos
        /// </summary>
        /// <returns>Lista con los Roles existentes en la BD.</returns>
        public static List<Rol> ObtenerRoles()
        {
            try
            {
                return accesoApiRol.LeerRoles();
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// Inserta un rol en la base de datos
        /// </summary>
        /// <param name="rol">Rol que se desea insertar en la base de datos.</param>
        /// <returns>True si el rol se ha insertado correctamente en la base de datos.</returns>
        public static bool CrearRol(Rol rol)
        {
            try
            {
                return accesoApiRol.InsertarRol((int)rol.Id, rol.Nombre);
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Edita un rol de la base de datos.
        /// </summary>
        /// <param name="rol">Rol que se desea editar</param>
        /// <returns>True si el rol ha sido editado correctamente.</returns>
        public static bool EditarRol(Rol rol)
        {
            try
            {
                return accesoApiRol.ActualizarRol(rol);
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Elimina un rol de la base de datos
        /// </summary>
        /// <param name="id">id del rol que se desea eliminar</param>
        /// <returns>True si se ha eliminado</returns>
        public static bool EliminarRol(int id)
        {
            try
            {
               return accesoApiRol.BorrarRoles(id);
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
               return false;
            }
        }


        /// <summary>
        /// Obtiene el nombre de los Roles existentes en la BD
        /// </summary>
        /// <returns>Lista con los nombres de los roles de la BD.</returns>
        public static List<string> ObtenerNombresRoles()
        {
            List<string> roles = new List<string>();
            List<Rol> rols;
            try
            {
                rols = ObtenerRoles();
                foreach (Rol rol in rols)
                {
                    roles.Add(rol.Nombre);
                }
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return null;
            }
            return roles ;
        }

        /// <summary>
        /// Obtiene el id de un rol dado su nombre.
        /// </summary>
        /// <param name="rol"> nombre del rol que requerimos.</param>
        /// <returns>Devuelve int con el id, en caso de no existir devuelve null</returns>
        public static int? ObtenerRolIdPorNombre(string rol)
        {
            try
            {
                List<Rol> roles = accesoApiRol.LeerRoles().Where(X => X.Nombre.Equals(rol)).ToList();
                return roles[0].Id;
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a la base de datos");
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Permite obtener el nombre de un rol dado su identificador
        /// </summary>
        /// <param name="rolUsuario"> identificador del rol</param>
        /// <returns>Nombre asociado al identificador pasado como parámetro.</returns>
        public static string ObtenerRolNombrePorId(int? rolUsuario)
        {
            List<Rol> listaRoles;
            try
            {
                listaRoles = ObtenerRoles();
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return null;
            }
            return listaRoles.Where(x => x.Id == rolUsuario).ToList()[0].Nombre;
           
        }

        /// <summary>
        /// Permite validar un rol según las reglas de negocio acordadas.
        /// </summary>
        /// <param name="rol">rol que se desea validar</param>
        /// <returns>Listado de errores de validación en caso de haberlos.</returns>
        public static List<string> ValidarRol(Rol rol)
        {
            List<string> listaErrores = new List<string>();
            try
            {
                List<Rol> roles = ObtenerRoles();
                if (rol.Nombre == null || rol.Nombre.Equals(""))
                    listaErrores.Add("Nombre: es campo obligatorio.");
                if (rol.Nombre.Length > 50)
                    listaErrores.Add("Nombre: Longitud máxima 50 caracteres.");
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return null;
            }
            return listaErrores;
        }

        //-------------------------------------------------------FUNCIONES SEDE -----------------------------------------------
        /// <summary>
        /// Obtiene una sede de la base de datos
        /// </summary>
        /// <param name="id">Id de la sede que deseamos obtener</param>
        /// <returns>La Sede solicitada en caso de existir.</returns>
        public static Sede ObtenerSede(int id)
        {
            try
            {
                return accesoApiSede.LeerSede(id);
            }
            catch (ExternalException)
            {
                return null;
            }
            catch (Exception)
            {
                throw new IOException("Error al acceder a base de datos");
            }
        }
        /// <summary>
        /// Obtiene las sedes de la base de datos
        /// </summary>
        /// <returns>Lista con las sedes de la base de datos</returns>
        public static ObservableCollection<Sede> ObtenerSedes()
        {
            try
            {
                ObservableCollection<Sede> sedes = new ObservableCollection<Sede>();
                List<Sede> listaSedes = accesoApiSede.LeerSedes();
                foreach (Sede sede in listaSedes)
                    sedes.Add(sede);
                return sedes;
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Inserta una sede en la Base de datos
        /// </summary>
        /// <param name="sede"> Sede que se desea insertar</param>
        /// <returns>True si la sede se ha insertado correctamente en la base de datos.</returns>
        public static bool CrearSede(Sede sede)
        {
            try
            {
                return accesoApiSede.InsertarSede((int)sede.NumOficina, sede.Calle, sede.CodigoPostal, (int)sede.Planta, (int)sede.Localidad);
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Edita una Sede de la base de datos
        /// </summary>
        /// <param name="sede">Sede que se desea editar</param>
        /// <returns> True si la sede se ha actualizado correctamente</returns>
        public static bool EditarSede(Sede sede)
        {
            try
            {
                return accesoApiSede.ActualizarSede(sede);
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return false;
            }

        }

        /// <summary>
        /// Elimina una sede de la base de datos
        /// </summary>
        /// <param name="id"> id de la sede que se desea eliminar</param>
        /// <returns>True si la sede se ha eliminado correctamente.</returns>
        public static bool EliminarSede(int id)
        {
            try
            {
               return accesoApiSede.BorrarSede(id);
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return false;
            }

        }

        /// <summary>
        /// Obtiene los nombres de las sedes de la base de datos.
        /// </summary>
        /// <returns>Lista con las sedes de la base de datos.</returns>
        public static List<string> ObtenerNombresSedes()
        {
            List<string> sedess = new List<string>();
            ObservableCollection<Sede> sedes = ObtenerSedes();
            try
            {
               
                foreach (Sede sed in sedes)
                {
                    sedess.Add(ObtenerDireccionSede((int)sed.NumOficina));
                }
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return null;
            }
            return sedess;
        }

        /// <summary>
        /// Obtiene el id de una sede a través de su nombre.
        /// </summary>
        /// <param name="nombreSede">Nombre de la sede</param>
        /// <returns>id de la sede</returns>
        public static int? obtenerSedeIdPorNombre(string nombreSede)
        {
            try
            {
                return accesoApiLocalidad.LeerLocalidades().Where(x => x.Nombre.Equals(nombreSede)).ToList()[0].Id;
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Permite dado un string de dirección determinar el número de sede, en base a su calle y su planta el string de dirección debe tener
        /// el siguiente formato:
        ///  sede.Calle + " CP: " + sede.CodigoPostal + " Planta: " + sede.Planta + " (" + localidad + ")";
        /// Avenida Oscar Esplá n 58 CP 03005 Planta: 2 (Alicante)
        /// Es decir es importante que aparezca CP y Planta: porque de acuerdo con el formato de sede, nos va a permitir dividir la cadena y 
        /// extraer su calle y su número de planta.
        /// </summary>
        /// <param name="direccion">Dirección de la que queremos obtener el número de sede</param>
        /// <returns> número de sede asociado a la dirección en caso de existir.</returns>
        public static int? ObtenerSedeIdPorDireccion(string direccion)
        {
            ObservableCollection<Sede> listaSedes;
            int sedeId;

            int calle = direccion.IndexOf(" CP");
            if (calle == -1)
                return null;
            string calleCorrecta = direccion.Substring(0, calle);
            int planta = direccion.IndexOf("Planta: ");
            if (planta == -1)
                return null;
            string cadenaPlanta = direccion.Substring(planta + 8, 2);  //Añadimos 8 para descartar Planta, Ejemplo Planta: 21  ==>  21
            planta = int.Parse(cadenaPlanta);
            try
            {
                listaSedes = ObtenerSedes();
                sedeId = (int)listaSedes.Where(x => x.Calle == calleCorrecta && x.Planta == planta).ToList()[0].NumOficina;
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return null;
            }
            return sedeId;
        }


        /// <summary>
        /// Dado un número de sede, permite extraer un string con su dirección en el siguiente formato:
        /// sede.Calle + " CP: " + sede.CodigoPostal + " Planta: " + sede.Planta + " (" + localidad + ")"
        /// </summary>
        /// <param name="numSede">numSede de cuya sede deseamos información.</param>
        /// <returns> La dirección de la sede pasada como parámetro.</returns>
        public static string ObtenerDireccionSede(int numSede)
        {
            Sede sede = ObtenerSede(numSede);
            String localidad;
            try
            {
                localidad = ObtenerLocalidad((int)sede.NumOficina).Nombre;
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
               return null;
            }
            return sede.Calle + " CP: " + sede.CodigoPostal + " Planta: " + sede.Planta + " (" + localidad + ")";
        }

        /// <summary>
        /// Permite validar una sede según las reglas de negocio
        /// </summary>
        /// <param name="sede">Sede a validar</param>
        /// <returns>Lista con errores de validación en caso de haberlos.</returns>
        public static List<string> ValidarSede(Sede sede)
        {
            List<string> listaErrores = new List<string>();
            if (sede.Calle == null)
                listaErrores.Add("Calle: es campo obligatorio");
            if (sede.Calle != null && sede.Calle.Length > 90)
                listaErrores.Add("Calle: longitud máxima de 90 caracteres.");
            if (sede.CodigoPostal == null)
                listaErrores.Add("CodigoPostal: es campo obligatorio");
            string cadenaValidacion = "[0 - 9]{5}";
            Regex codigoValido = new Regex(cadenaValidacion);
            if (!codigoValido.IsMatch("" + sede.CodigoPostal)) {
                listaErrores.Add("CodigoPostal: debe contener 5 números.");
            }
            if (sede.Planta == null)
                listaErrores.Add("Planta: es campo obligatorio");
            cadenaValidacion = "[0 - 9]{1,2}";
            Regex plantaValida = new Regex(cadenaValidacion);
            if (!plantaValida.IsMatch("" + sede.Planta))
            {
                listaErrores.Add("Planta: debe contener 2 números.");
            }
            try
            {
                if (ObtenerLocalidad((int)sede.Localidad) == null)
                    listaErrores.Add("Localidad: No existe en la base de datos");
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return null;
            }
            return listaErrores;
        }

        //---------------------------------------------------------FUNCIONES TÉCNICO----------------------------------------
        /// <summary>
        /// Obtiene un técnico de la base de datos
        /// </summary>
        /// <param name="id">Id del técnico que se desea obtener.</param>
        /// <returns>El tecnio seleccionado si existe.</returns>
        public static Tecnico ObtenerTecnico(int id) {
            try
            {
                return accesoApiTecnico.LeerTecnico(id);
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
               return null;
            }
        }

        /// <summary>
        /// Permite obtener el nombre del técnico, en el formato:
        /// tecnico.Nombre + " " + tecnico.Apellidos;
        /// Alberto Moreno Fernández
        /// para un idTecnico determinado.
        /// </summary>
        /// <param name="idTecnico">idTecnico del cual queremos obtener la información</param>
        /// <returns>Una cadena con el nombre y apellidos del técnico deseado, en caso de existir. Si no existe devuelve null.</returns>
        public static string ObtenerNombreTecnico(int idTecnico)
        {
            try
            {
                List<Tecnico> tecnicos = new List<Tecnico>();
                tecnicos=accesoApiTecnico.LeerTecnicos().Where(x => x.IdTecnico == idTecnico).ToList();
                if (tecnicos.Count==0)
                    return null;
                else
                {
                    int? usuarioTecnicoId = tecnicos[0].IdTecnico;
                    Usuario tecnico = accesoApiUsuario.LeerUsuario((int)usuarioTecnicoId);
                    return tecnico.Nombre + " " + tecnico.Apellidos;
                }
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
               return null;
            }
        }
            

        /// <summary>
        /// Obtiene los técnicos de la base de datos
        /// </summary>
        /// <returns>Listado con los técnicos</returns>
        public static List<Tecnico> ObtenerTecnicos()
        {
            try
            {
                return accesoApiTecnico.LeerTecnicos();
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
               return null;
            }
        }

        /// <summary>
        /// Inserta un Tecnico en la base de datos
        /// </summary>
        /// <param name="tecnico">Tecnico que se desea insertar</param>
        /// <returns>True si el técnico ha sido insertado correctamente.</returns>
        public static bool CrearTecnico(Tecnico tecnico)
        {
            try
            {
                return accesoApiTecnico.InsertarTecnico((int)tecnico.IdUsuario, (int)tecnico.IdTecnico);
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return false;
            }

        }

        /// <summary>
        /// Edita un técnico de la base de datos
        /// </summary>
        /// <param name="tecnico">Técnico a editar</param>
        /// <returns>True si el técnico se actualiza correctamente.</returns>
        public static bool EditarTecnico(Tecnico tecnico)
        {
            try
            {
                return accesoApiTecnico.ActualizarTecnico(tecnico);
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Elimina un Tecnico de la base de datos
        /// </summary>
        /// <param name="id">IdUsuario del tecnico a eliminar</param>
        /// <returns>True si el tecnico se elimina correctamente.</returns>
        public static bool EliminarTecnico(int id)
        {
            try
            {
                return accesoApiTecnico.BorrarTecnico(id);
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Permite obtener una lista de técnicos con el siguiente formato:
        /// idTecnico + ".-" + tecnico.Nombre + " " + tecnico.Apellidos
        /// <example>
        /// 2.-Alberto Moreno Fernández
        /// </example>
        /// <see cref="ConvertirAlistaString(List{Usuario})"/>
        /// </summary>
        /// <returns>Un listado con la información de los técnicos en el formato indicado en el resumen.</returns>

        public static List<string> ObtenerListaTecnicos()
        {
            try
            {
                List<string> tecnicos = new List<string>();
                List<Usuario> listaTecnicos = accesoApiUsuario.LeerUsuarios().Where(x => x.RolUsuario == (int)RolUsuario.tecnico).ToList();
                tecnicos = ConvertirAlistaString(listaTecnicos);
                return tecnicos;
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// Obtiene un listado con los técnicos existentes en la sede donde se encuentra el equipo pasado como parámetros,
        /// devuelve una lista con el formáto:
        /// idTecnico + ".-" + tecnico.Nombre + " " + tecnico.Apellidos
        /// <example>
        /// 2.-Alberto Moreno Fernández
        /// </example>
        /// <see cref="ConvertirAlistaString(List{Usuario})"/>
        /// 
        /// </summary>
        /// <param name="idEquipo">idEquipo del equipo del cual deseamos obtener los téncicos</param>
        /// <returns>Lista con los técnicos en el formato acordado o null en caso de no existir el equipo.</returns>
        public static List<string> ObtenerListaTecnicosPorEquipo(string idEquipo)
        {
            try
            {
                List<string> tecnicos = new List<string>();
                Equipo equipo = accesoApiEquipo.LeerEquipo(idEquipo);
                if (equipo == null)
                    return null;
                List<Usuario> listaTecnicos = accesoApiUsuario.LeerUsuarios().Where(x => x.RolUsuario == (int)RolUsuario.tecnico && x.NumOficina == equipo.NumOficina).ToList();
                tecnicos = ConvertirAlistaString(listaTecnicos);
                return tecnicos;
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Función auxiliar que permite obtener un listado de técnicos con el siguiente formato:
        /// idTecnico + ".-" + tecnico.Nombre + " " + tecnico.Apellidos
        /// <example>
        /// 2.-Alberto Moreno Fernández
        /// </example>
        /// </summary>
        /// <param name="listaTecnicos">lista de técnicos que deseamos convertir</param>
        /// <returns>Lista de técnicos con el formato deseado.</returns>
        private static List<string> ConvertirAlistaString(List<Usuario> listaTecnicos)
        {
            try
            {
                List<string> tecnicos = new List<string>();

                foreach (Usuario tecnico in listaTecnicos)
                {
                    int idTecnico = (int)accesoApiTecnico.LeerTecnico((int)tecnico.UsuarioId).IdTecnico;
                    tecnicos.Add(idTecnico + ".-" + tecnico.Nombre + " " + tecnico.Apellidos);
                }
                return tecnicos;
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
               return null;
            }
        }


        /// <summary>
        /// Dado un idTecnico verificado(existe en la base de datos) permite obtener la dirección donde está ubicado con el formato:
        /// sedeTecnico.Calle + ", Planta: " + sedeTecnico.Planta + ". CP: " + sedeTecnico.CodigoPostal + " (" + accesoApiLocalidad.LeerLocalidad(sedeTecnico.Localidad).Nombre + ")"
        /// </summary>
        /// <param name="idTecnico">idTecnico del cual queremos la información, debe ser un idTecnico existente en la base de datos</param>
        /// <returns>Una cadena con la dirección del técnico en el formato especificado.</returns>
        public static string ObtenerSedeTecnico(int idTecnico)
        {
            try
            {
                List<Tecnico> tecnicos = accesoApiTecnico.LeerTecnicos();
                int usuarioId = (int)tecnicos.Where(x => x.IdTecnico == idTecnico).ToList()[0].IdUsuario;
                int sede = (int)accesoApiUsuario.LeerUsuario(usuarioId).NumOficina;
                Sede sedeTecnico = accesoApiSede.LeerSede(sede);
                return sedeTecnico.Calle + ", Planta: " + sedeTecnico.Planta + ". CP: " + sedeTecnico.CodigoPostal + " (" + accesoApiLocalidad.LeerLocalidad(sedeTecnico.Localidad).Nombre + ")";
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
               return null;
            }
        }

        /// <summary>
        /// Permite dado un usuario con el rol de técnico obtener su idTecnico
        /// </summary>
        /// <param name="idUsuario">idUsuario del que queremos obtener el idtecnico, debe garantizarse que exista en la base de datos</param>
        /// <returns>El idTecnico solicitado o -1 en caso de no existir.</returns>

        public static int ObtenerTecnicoIdPorUsuario(int idUsuario)
        {
            try
            {
                return (int)accesoApiTecnico.LeerTecnico(idUsuario).IdTecnico;
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return -1;
            }
        }

        //----------------------------------------------------------FUNCIONES TICKET----------------------------------- 
        /// <summary>
        /// Obtiene un Ticket de la base de datos
        /// </summary>
        /// <param name="id">Id del ticket deseado</param>
        /// <returns>El Ticket solicitado en caso de existir</returns>           
        public static Ticket ObtenerTicket(int id)
        {
            try
            {
                return accesoApiTicket.LeerTicket(id);
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return null;
            }

        }

        /// <summary> 
        /// Obtiene todos los tickets de la base de datos.
        /// </summary>
        /// <returns>Listado con los Tickets de la base de datos.</returns>
        public static List<Ticket> ObtenerTickets()
        {
            try
            {
               return accesoApiTicket.LeerTickets();
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// Inserta un Ticket en la base de datos
        /// </summary>
        /// <param name="tick">Ticket que deseamos insertar</param>
        /// <returns>True si el ticket se ha insertado correctamente en la base de datos.</returns>
        public static bool CrearTicket(Ticket tick)
        {
            try
            {
                return accesoApiTicket.InsertarTicket(tick);
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Edita un ticket de la base de datos
        /// </summary>
        /// <param name="tick">Ticket que se desea editar</param>
        /// <returns>True si el ticket se ha editado correctamente.</returns>
        public static bool EditarTicket(Ticket tick)
        {
            try
            {
                return accesoApiTicket.AcutalizarTicket(tick);
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Elimina un ticket de la base de datos
        /// </summary>
        /// <param name="id">Id del ticket a eliminar</param>
        /// <returns>True si el Ticket se ha eliminado correctamente.</returns>
        public static bool EliminarTicket(int id)
        {
            try
            {
                return accesoApiTicket.BorrarTicket(id);
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Accede a los Ticketsencurso del usuario pasado como parámetro
        /// Genera un List<string> con el formato:
        /// <example>
        /// 1. El ordenador no funciona bien.
        /// </example>
        /// Donde 1 es el id del ticket y "el ordenador no funciona bien" la  descripción del ticket
        /// </summary>
        /// <param name="idUsuario">id del usuario del que deseamos obtener el resumen de tickets en curso </param>
        /// <returns>Lista con el resumén en el formato indicado.</returns>
        public static List<string> ObtenerResumenTicket(int idUsuario)
        {
            List<string> resumenTickets = null;
            List<TicketEnCurso> ticketsFiltrados = new List<TicketEnCurso>();
            List<int> listadoTickets = new List<int>();
            try
            {
                ticketsFiltrados = accesoApiTicketEnCurso.LeerTicketsEnCurso().Where(x => x.IdUsuario == idUsuario).ToList();

                if (ticketsFiltrados.Count != 0)
                {
                    foreach (TicketEnCurso tick in ticketsFiltrados)
                    {
                        listadoTickets.Add((int)tick.Id);
                    }
                    resumenTickets = new List<string>();
                    foreach (int ticketId in listadoTickets)
                    {
                        string descripcion = accesoApiTicket.LeerTicket(ticketId).Descripcion;
                        resumenTickets.Add(ticketId + ". " + descripcion);
                    }
                }
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return null;
            }
            return resumenTickets;
        }

        /// <summary>
        /// Comprueba si un equipo tiene algún ticket dado de alta en el sistema.
        /// </summary>
        /// <param name="idEquipo">idEquipo del equipo que queremos verificar, debe garantizarse su existencia en el sistema. </param>
        /// <returns>true si el equipo seleccionado tiene algún ticket no cerrado en el sistema.</returns>
        public static bool verificarTicketDuplicado(string equipo)
        {
            try
            {
                List<Ticket> tickets = ObtenerTickets();
                List<Ticket> ticketsFiltrados = tickets.Where(x =>  x.IdEquipo == equipo && x.FechaResolucion == null).ToList();
                if (ticketsFiltrados.Count == 0)
                    return false;
                else
                    return true;
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return false;
            }
        }
        //---------------------------------------------------------FUNCIONES TICKETSENCURSO-----------------------------------
        /// <summary>
        /// Obtiene un TicketEnCurso de la base de datos
        /// </summary>
        /// <param name="id">Id del ticketEnCursi deseado</param>
        /// <returns>El TicketEnCurso solicitado en caso de existir</returns>
        public static TicketEnCurso ObtenerTicketEnCurso(int id)
        {
            try
            {
                return accesoApiTicketEnCurso.LeerTicketEnCurso(id);
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
               return null;
            }

        }

        /// <summary>
        /// Obtiene todos los ticketsEnCurso de la base de datos.
        /// </summary>
        /// <returns>Listado con los TicketsEnCurso de la base de datos.</returns>
        public static List<TicketEnCurso> ObtenerTicketsEnCurso()
        {
            try
            {
                return accesoApiTicketEnCurso.LeerTicketsEnCurso();
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// Inserta un Ticket en la base de datos
        /// </summary>
        /// <param name="tick">Ticket que deseamos insertar</param>
        /// <returns>True si el ticket se ha insertado correctamente en la base de datos.</returns>
        public static bool CrearTicketEnCurso(TicketEnCurso tick)
        {
            try
            {
                return accesoApiTicketEnCurso.InsertarTicketEnCurso((int)tick.Id, (int)tick.IdUsuario,(int)tick.IdTecnico, (DateTime)tick.FechaCreacion, (DateTime)tick.FechaAsignacion, (DateTime)tick.FechaEnCurso,(DateTime)tick.FechaFinalizacion);
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Edita un ticketEnCurso de la base de datos
        /// </summary>
        /// <param name="tick">TicketEnCurso que se desea editar</param>
        /// <returns>True si el ticketEnCurso se ha editado correctamente.</returns>
        public static bool EditarTicketEnCurso(TicketEnCurso tick)
        {
            try
            {
                return accesoApiTicketEnCurso.AcutalizarTicketEnCurso(tick);
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
               return false;
            }
        }
        /// <summary>
        /// Elimina un ticketEnCurso de la base de datos
        /// </summary>
        /// <param name="id">Id del ticketEnCurso a eliminar</param>
        /// <returns>True si el TicketEnCurso se ha eliminado correctamente.</returns>
        public static bool EliminarTicketEnCurso(int id)
        {
            try
            {
                return accesoApiTicketEnCurso.BorrarTicketEnCurso(id);
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
               return false;
            }
        }


        /// <summary>
        /// Devuelve una colección del tipo PieData <see cref="PieData"/> con los ticketsEnCurso
        /// asignados y sin asignar
        /// <example>
        /// new PieData("Asignados",20);
        /// new PieData("No Asignados",80);
        /// </example>
        /// Los valores se entregan en forma de porcentaje, siendo una aproximación a entero de los mismos
        /// </summary>
        /// <returns>Colección PieData con los porcentajes de ticketsEnCurso asignados y sin asignar.</returns>
        public static ObservableCollection<PieData> obtenerTicketsAsignados()
        {
            List<TicketEnCurso> ticketsEnCurso;
            ObservableCollection<PieData> distribucionTickets = new ObservableCollection<PieData>();

            try
            {
                ticketsEnCurso = accesoApiTicketEnCurso.LeerTicketsEnCurso();
                if (ticketsEnCurso.Count != 0)
                {
                    float asig = ticketsEnCurso.Where(x => x.FechaAsignacion != null).ToList().Count;
                    float noAsig = ticketsEnCurso.Where(x => x.FechaAsignacion == null).ToList().Count;
                    int asignados = (int)Math.Round(asig / ticketsEnCurso.Count * 100);
                    int noAsignados = 100 - asignados;
                    distribucionTickets.Add(new PieData("Asignados", asignados));
                    distribucionTickets.Add(new PieData("No Asignados", noAsignados));
                }
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return null;
            }
           
            return distribucionTickets;
        }

        /// <summary>
        /// Obtiene una colección con los valores medios de resolución (FechaResolucíon-FechaCreacion) de los últimos 7 días anteriores a la fecha de referencia pasada como argumento.
        /// para ello hace uso de una clase auxiliar <see cref="BarAdminData"/> dicha estructura puede usarse para la representación de gráficos
        /// tipo barra. Los tiempos medios se dan con dos decimales y la fecha en formato corto
        /// <example>
        /// new BarAdminData(17-11-2020, 3,23);
        /// new BarAdminData(16-11-2020, 2,40);
        /// </example>
        /// </summary>
        /// <param name="fechaReferencia">Fecha de referencia para obtener la colección</param>
        /// <returns> colección con el día y el tiempo medio de averías de ese día</returns>
        public static ObservableCollection<BarAdminData> ObtenerTiempoResolucionMedio(DateTime fechaReferencia)
        {
            TimeSpan tiempoResolucion;
            DateTime fecha= DateTime.Now;
            DateTime fechaPasada;
            DateTime fechaResolucion=DateTime.Now;
            ObservableCollection<BarAdminData> datosResolucion = new ObservableCollection<BarAdminData>();
            List<Ticket> ticketsResueltos;

            try
            {
                ticketsResueltos = accesoApiTicket.LeerTickets().Where(X => X.FechaResolucion != null).ToList();
                List<Ticket> ticketsFiltrados = new List<Ticket>();

                for (int dias = 7; dias > 0; dias--)
                {
                    ticketsFiltrados.Clear();
                    tiempoResolucion = TimeSpan.Zero;
                    fechaPasada = fechaReferencia.AddDays(-1 * (dias));

                    // Filtramos los tickets de un día en concreto anterior al pasado como referencia, fechaPasada representa dicho anterior, el primero fecha-referencia-7 días
                    foreach (Ticket ti in ticketsResueltos)
                    {
                        fechaResolucion = (DateTime)ti.FechaResolucion;
                        if (fechaPasada.Day == fechaResolucion.Day)
                            ticketsFiltrados.Add(ti);
                    }
                    //Si ese día  tiene tickets resueltos, calculamos cuanto han tardado en resolverse y hallamos la media redondeada con dos decimales.
                    if (ticketsFiltrados.Count != 0)
                    {

                        foreach (Ticket tick in ticketsFiltrados)
                        {
                            tiempoResolucion += (DateTime)tick.FechaResolucion - (DateTime)tick.FechaEntrada;
                            fecha = (DateTime)tick.FechaResolucion;

                        }
                        datosResolucion.Add(new BarAdminData(fecha.ToShortDateString(), Math.Round(tiempoResolucion.TotalHours / ticketsFiltrados.Count, 2)));
                    }
                    //Si ese día no tienes tickets resueltos, le damos un valor 0 al tiempo medio.
                    else
                    {
                        fechaPasada = fechaReferencia.AddDays(-1 * (dias));
                        datosResolucion.Add(new BarAdminData(fechaPasada.ToShortDateString(), 0));
                    }

                }
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return null;
            }


            return datosResolucion;
        }


        /// <summary>
        /// Genera una clase auxiliar <see cref="TicketsPendientes"/> que facilita la visualización de los datos
        /// referentes a un ticketEnCurso para su mejor representación en estructuras de visualización. Para ello rellena campos
        /// accediendo a campos de otras tablas distintas a ticketsEnCurso para por ejemplo en vez de tener el usuarioId tener
        /// el nombre y apellidos del usuario y otros datos que para optimizar se almacenan en formato numérico, pero que para una mejor
        /// visualización se convierten a través de esta función y de la clase auxiliar.
        /// </summary>
        /// <param name="desasignados">Lista de tickets en curso no asignados</param>
        /// <returns> Una colección de TicketsPendietnes que representa los ticketsEnCurso pasados como argumento.</returns>
        public static ObservableCollection<TicketsPendientes> ConvertirAticketsPendientes(List<TicketEnCurso> desasignados)
        {
            ObservableCollection<TicketsPendientes> pendientes = new ObservableCollection<TicketsPendientes>();
            string usuario;
            string sede;
            string equipo;
            Usuario user;
            Sede sedeUsuario;
            Ticket enCurso;
            List<Usuario> listaTecnicosAux = new List<Usuario>();
            List<string> listaTecnicos = null;
            TicketsPendientes tiquet = null;
            List<Tecnico> tecnicos;

            try
            {

                tecnicos = accesoApiTecnico.LeerTecnicos();

                foreach (Tecnico tec in tecnicos)
                {
                    listaTecnicosAux.Add(accesoApiUsuario.LeerUsuario((int)tec.IdUsuario));
                }

                foreach (TicketEnCurso tick in desasignados)
                {
                    equipo = "";
                    tiquet = new TicketsPendientes();
                    listaTecnicos = new List<string>();

                    user = accesoApiUsuario.LeerUsuario((int)tick.IdUsuario);
                    //idUsuario en formato amigable
                    usuario = user.Nombre + " " + user.Apellidos;

                    sedeUsuario = accesoApiSede.LeerSede((int)user.NumOficina);
                    //numOficina en formato amigable.
                    sede = sedeUsuario.Calle + ", " + sedeUsuario.CodigoPostal + "(" + accesoApiLocalidad.LeerLocalidad(sedeUsuario.Localidad).Nombre + ")";

                    enCurso = accesoApiTicket.LeerTicket((int)tick.Id);
                    equipo = enCurso.IdEquipo;

                    //En este apartado creamos una lista de técnicos que tengan la misma ubicación del equipo del ticket o en caso de no existir del usuario que abrió el ticket.
                    foreach (Usuario tecnico in listaTecnicosAux)
                    {
                        if (equipo!=null)
                        {
                            Equipo equipoAveriado = ObtenerEquipo(equipo);
                            if (tecnico.NumOficina == equipoAveriado.NumOficina)
                            {
                                if (!listaTecnicos.Contains(tecnico.UsuarioId + ".-" + tecnico.Nombre + " " + tecnico.Apellidos))
                                    listaTecnicos.Add(tecnico.UsuarioId + ".-" + tecnico.Nombre + " " + tecnico.Apellidos);                //técnico en formato amigable "1.-Alberto Moreno Fernández" por ejemplo
                            }
                        }
                        else
                        {
                            if (tecnico.NumOficina == user.NumOficina)
                            {
                                if (!listaTecnicos.Contains(tecnico.UsuarioId + ".-" + tecnico.Nombre + " " + tecnico.Apellidos))
                                    listaTecnicos.Add(tecnico.UsuarioId + ".-" + tecnico.Nombre + " " + tecnico.Apellidos);                //técnico en formato amigable "1.-Alberto Moreno Fernández" por ejemplo
                            }
                        }

                    }
                    tiquet = new TicketsPendientes(tick.Id, enCurso.Descripcion, enCurso.FechaEntrada, listaTecnicos, equipo, usuario, sede);
                    pendientes.Add(tiquet);
                    tiquet = null;
                    listaTecnicos = null;
                }
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {

                return null;
            }
           
            return pendientes;
        }


        /// <summary>
        ///  Dado el idTecnico pasado como parámetro, obtiene los ticketsencurso que no tiene en estado finalizado(4)
        ///  y los mete en una lista de Tickets ordenados por fecha de creación descendente(primero los màs antiguos).
        /// </summary>
        /// <param name="idTecnico">idTecnico del técnico que deseamos obtener los tickets</param>
        /// <returns> Lista de tickets no finalizados del técnico pasado como parámetro. </returns>
        public static ObservableCollection<Ticket> ObtenerTicketsPendientesPorTecnico(int idTecnico)
        {
            ObservableCollection<Ticket> ticketsAsignados = new ObservableCollection<Ticket>();
            try
            {
                Ticket ticketAuxiliar;
                List<TicketEnCurso> listaTicketsEnCurso;
                listaTicketsEnCurso = accesoApiTicketEnCurso.LeerTicketsEnCurso().Where(x => x.IdTecnico == idTecnico).ToList();

                foreach (TicketEnCurso tick in listaTicketsEnCurso)
                {

                    ticketAuxiliar = accesoApiTicket.LeerTicket((int)tick.Id);
                    if (ticketAuxiliar.Estado != 4)                                          //estado=4 (finalizado)
                        ticketsAsignados.Add(ticketAuxiliar);
                }
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return null;
            }


            return new ObservableCollection<Ticket>(ticketsAsignados.OrderByDescending(x => x.FechaEntrada).ToList());          
           

        }
       


        //---------------------------------------------------------FUNCIONES TIPO---------------------------------------------

        /// <summary>
        /// Obtiene un tipo de la base de datos
        /// </summary>
        /// <param name="id">Id del tipo que queremos obtener</param>
        /// <returns>Tipo con Id indicado en caso de existir.</returns>
        public static Tipo ObtenerTipo(int id)
        {
            try
            {
                return accesoApiTipo.LeerTipo(id);
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
               return null;
            }
        }

        /// <summary>
        /// Obtiene los tipos de la base de datos
        /// </summary>
        /// <returns>Listado de Tipos de la base de datos.</returns>
        public static List<Tipo> ObtenerTipos()
        {
            try
            {
                return accesoApiTipo.LeerTipos();
            }
            catch (Exception)
            {
                throw new IOException("Error al acceder a base de datos");
            }
        }

        /// <summary>
        /// Inserta un Tipo en la base de datos
        /// </summary>
        /// <param name="tip">Tipo que deseamos insertar</param>
        /// <returns>True si el Tipo ha sido insertado correctamente.</returns>
        public static bool CrearTipo(Tipo tip)
        {
            try
            {
                return accesoApiTipo.InsertarTipo((int)tip.Id, tip.Nombre);
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Edita un tipo en la base de datos.
        /// </summary>
        /// <param name="tip">Tipo que se desea editar</param>
        /// <returns> True si el Tipo ha sido actualizado con éxito.</returns>
        public static bool EditarTipo(Tipo tip)
        {
            try
            {
                return accesoApiTipo.ActualizarTipo(tip);            
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Elimina un tipo de la base de datos.
        /// </summary>
        /// <param name="id"> Id del Tipo que desea eliminar.</param>
        /// <returns>True si el Tipo ha sido eliminado correctamente.</returns>
        public static bool EliminarTipo(int id)
        {
            try
            {
                return accesoApiTipo.BorrarTipo(id);
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
               return false;
            }
        }

        /// <summary>
        /// Obtiene un listado con el nombre de las categorías existentes en la base de datos
        /// </summary>
        /// <returns>Listado con el nombre de las categorías.</returns>
        public static List<string> ObtenerListaTipos()
        {
            try
            {
                List<string> listaTipos = new List<string>();
                List<Tipo> tipos = accesoApiTipo.LeerTipos();
                foreach (Tipo tipo in tipos)
                {
                    listaTipos.Add(tipo.Nombre);
                }
                return listaTipos;
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// Permite obtener el id de una categoría a partir de su nombre
        /// </summary>
        /// <param name="nombreTipo"> Nombre de la categoría </param>
        /// <returns>Si el nombre de la categoría existe devuelve su id, sino devuelve -1</returns>

        public static int ObtenerTipoIdPorNombre(string nombreTipo)
        {
            try
            {
                int tipoSeleccionado = -1;
                List<Tipo> tipos = accesoApiTipo.LeerTipos();
                foreach (Tipo tipo in tipos)
                {
                    if (tipo.Nombre.Equals(nombreTipo))
                        tipoSeleccionado = (int)tipo.Id;
                }
                return tipoSeleccionado;
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return -1;
            }
        }

      /// <summary>
      /// Permite obtener el nombre de una categoria dad o su id
      /// </summary>
      /// <param name="tipo">id de la categoría</param>
      /// <returns></returns>
      public static string ObtenerNombrePorTipoId(int tipo)
      {
            try
            {
                string tipoSeleccionado = "";
                List<Tipo> tipos = accesoApiTipo.LeerTipos();
                foreach (Tipo tip in tipos)
                {
                    if (tip.Id == tipo)
                        tipoSeleccionado = tip.Nombre;
                }
                return tipoSeleccionado;
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<string> ObtenerNombresCategorias()
        {
            List<string> nombreCategorias = new List<string>();
            List<Tipo> listaTipos = ObtenerTipos();
            foreach (Tipo t in listaTipos)
                nombreCategorias.Add(t.Nombre);
            return nombreCategorias;
        }


        /// <summary>
        ///  TODO
        /// </summary>

        public static List<string> ValidarCategoria()
        {
            return null;
        }


        //----------------------------------------------------------FUNCIONES USUARIO---------------------------------------


        /// <summary>
        /// Obtiene un Usuario de la base de datos
        /// </summary>
        /// <param name="id">Id del Usuario deseado.</param>
        /// <returns>El Usuario con id seleccionado en caso de existir.</returns>
        public static Usuario ObtenerUsuario(int id)
        {
            try
            {
                return accesoApiUsuario.LeerUsuario(id);
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return null;
            }

        }

        /// <summary>
        /// Obtiene los Usuarios de la base de datos.
        /// </summary>
        /// <returns>Listado con los Usuarios de la base de datos.</returns>
        public static ObservableCollection<Usuario> ObtenerUsuarios()
        {
            try
            {
                ObservableCollection<Usuario> lista = new ObservableCollection<Usuario>();
                List<Usuario> listaUsuarios = accesoApiUsuario.LeerUsuarios();
                foreach (Usuario user in listaUsuarios)
                    lista.Add(user);
                return lista;
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return null;
            }

        }

        /// <summary>
        /// Inserta un usuario en la base de datos.
        /// </summary>
        /// <param name="user"> Usuario a insertar.</param>
        /// <returns>True si el Usuario ha sido insertado con éxito.</returns>
        public static bool CrearUsuario(Usuario user)
        {
            try
            {
                return accesoApiUsuario.InsertarUsuario(user.Password, user.Nombre, user.Apellidos,(int)user.Extension, user.Mail,(int)user.NumOficina, (int)user.RolUsuario);
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
               return false;
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>

        public static List<string> ValidarUsuario(Usuario user)
        {
            return null;
        }




        /// <summary>
        /// Edita usuario de la base de datos
        /// </summary>
        /// <param name="user">Usuario que queremos editar</param>
        /// <returns>True si el Usuario se ha editado con éxito.</returns>
        public static bool EditarUsuario(Usuario user)
        {
            try
            {
                return accesoApiUsuario.ActualizarUsuario(user);
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Elimina un usuario de la base de datos
        /// </summary>
        /// <param name="id">Id del usuario a eliminar</param>
        /// <returns>True si el usuario ha sido eliminado con éxito.</returns>
        public static bool EliminarUsuario(int id)
        {
            try
            {
                return accesoApiUsuario.BorrarUsuario(id);
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
               return false;
            }
        }

        /// <summary>
        /// TODO  PENDIENTE HACER REGEX
        /// Permite validar una extensión para un usuario determinado, la extensión no puede repetirse en dos usuarios(negocio) 
        /// por lo que se verifica que tiene el formato correcto y sino lo tiene no la válida. Negocio establece que debe empezar por 3
        /// y tener un total de 4 números
        /// </summary>
        /// <param name="extension"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static bool ValidarExtension(string extension)
        {
            try
            {
            
                ObservableCollection<Usuario> usuarios = ObtenerUsuarios();
                List<Usuario> usuariosFiltrados = null;
                usuariosFiltrados = usuarios.Where(x => x.Extension == int.Parse(extension)).ToList();
                if (usuariosFiltrados == null)
                    return true;
                else
                    return false;
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (FormatException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }


        }


        /// <summary>
        /// TODO  PENDIENTE HACER REGEX
        /// Permite validar una extensión para un usuario determinado, la extensión no puede repetirse en dos usuarios(negocio) 
        /// por lo que se verifica que tiene el formato correcto y sino lo tiene no la válida. Negocio establece que debe empezar por 3
        /// y tener un total de 4 números
        /// </summary>
        /// <param name="extension"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static bool ValidarExtension(string extension, int userId)
        {
            try
            {
                Usuario user = ObtenerUsuario(userId);
                ObservableCollection<Usuario> usuarios = ObtenerUsuarios();
                List<Usuario> usuariosFiltrados = new List<Usuario>();
                usuariosFiltrados= usuarios.Where(x => x.Extension == int.Parse(extension)).ToList();
                foreach(Usuario us in usuariosFiltrados)
                {
                    if (us.Extension == user.Extension)
                        return true;
                    else
                        return false;
                }
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return false;
            }


        }


        /// <summary>
        /// Verificamos si un mail existe en la base de datos
        /// </summary>
        /// <param name="mail">Mail que deseamos controlar</param>
        /// <returns> True si el mail existe.</returns>
        public static Usuario VerificarUsuario(string mail)
        {
            List<Usuario> listaUsuarios;
            try
            {
                listaUsuarios = accesoApiUsuario.LeerUsuarios();
                List<Usuario> usuario = listaUsuarios.Where(x => x.Mail.Equals(mail)).ToList();
                if (usuario.Count != 0)
                    return usuario[0];
                else
                    return null;
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return null;
            }
           
        }
        //----------------------------------------------------------FUNCIONES GESTIÓN DE NOTIFICACIONES----------------------------------------------------------
       
        /// <summary>
        /// Genera una lista de notificaciones particularizada por tipo de usuario,  los usuarios reciben notificaciones cuando
        /// a) Una incidencia es asignada a un técnico
        /// b) Cuando un técnico pasa la incidencia a estado en curso.
        /// c) Cuando una incidencia pasa ha estado finalizada.
        /// </summary>
        /// <param name="ticketsFiltrados">Tickets en curso filtrados por el usuario que llama a la función</param>
        /// <param name="idUsuario">IdUsuario que llama a la función.</param>
        /// <param name="rol">Rol del usuario que llama a la función.</param>
        /// <returns></returns>
        public static List<string> ObtenerNotificacionesClientes(ObservableCollection<TicketEnCurso> ticketsFiltrados,int idUsuario, string rol)
        {
            List<string> notificaciones = new List<string>();

            //Obtener de estadoUsuario fecha  de la ultima conexion del usuario
            EstadoUsuario estadoUser;
            try
            {
                estadoUser = accesoApiEstadoUsuario.LeerEstadoUsuario(idUsuario);
                DateTime ultimaConexion = (DateTime)estadoUser.FechaUltimaRevision;

                //Si 
                // a) fechaAsignación >fechaUltimaConexion añadir mensaje a lista.
                // b) fechaEnCurso>fechaUltimaConexion añadir mensaje a lista.
                // c) fechaFinalización >fechaUltimaConexion añadir mensaje a lista.
                List<Tecnico> tecnicos;
                tecnicos = accesoApiTecnico.LeerTecnicos();
                Usuario user;
                DateTime fechaCorta;
                foreach (TicketEnCurso tick in ticketsFiltrados)
                {

                    if (tick.FechaCreacion > ultimaConexion)
                    {
                        if (!rol.Equals("tecnico"))
                            notificaciones.Add("Ticket " + tick.Id + "  ha sido creado correctamente. " + tick.FechaCreacion);                      // Los técnicos no reciben notificaciones de tickets creados.
                    }
                    if (tick.FechaAsignacion > ultimaConexion)
                    {
                        user = accesoApiUsuario.LeerUsuario((int)tecnicos.Where(x => x.IdTecnico == tick.IdTecnico).ToList()[0].IdUsuario);
                        fechaCorta = (DateTime)tick.FechaAsignacion;
                        notificaciones.Add("Ticket " + tick.Id + " asignado a " + user.Nombre + " " + user.Apellidos + ".  Fecha:  " + fechaCorta);
                    }
                    if (tick.FechaEnCurso > ultimaConexion)
                    {
                        notificaciones.Add("Ticket " + tick.Id + "  está siendo tratado actualmente. " + tick.FechaEnCurso + "\n Observaciones: " + accesoApiTicket.LeerTicket((int)tick.Id).NotasTecnico);
                    }
                    if (tick.FechaFinalizacion > ultimaConexion)
                    {
                        notificaciones.Add("Ticket " + tick.Id + "  ha pasado al estado de resuelto. " + tick.FechaFinalizacion + "\n Comentarios: " + accesoApiTicket.LeerTicket((int)tick.Id).Resolucion);

                    }
                }
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return null;
            }
           
            return notificaciones;
        }



        /// <summary>
        /// Acutaliza el estadoUsuario de un usuario
        /// </summary>
        /// <param name="estado">Nuevo EstadoUsuario deseado</param>
        /// <returns> True si el estado ha sido actualizado con éxito.</returns>
        public static bool ActualizarFechaRevision(EstadoUsuario estado)
        {
            try
            {
                if (accesoApiEstadoUsuario.ActualizarEstadoUsuario(estado))
                    return true;
                else
                    return false;
            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return false;
            }
        }



        /// <summary>
        /// Genera una lista con información de un TicketEnCurso para ser presentada como un seguimiento del mismo. Se debe pasar una lista con los
        /// tickets del usuario y el id del
        /// </summary>
        /// <param name="tickets"> Lista donde está el ticket del que queremos el resumen.</param>
        /// <param name="idTicket"> IdTicket del que queremos el resumen.</param>
        /// <returns>Una Lista de cadenas con el resumen del ticket solicitado.</returns>
        public static List<string> ObtenerInformacionTicket(ObservableCollection<TicketEnCurso> tickets,int idTicket)
        {
            List<string> informacionTicket = new List<string>();
            try
            {
                if (tickets.Count != 0)
                {
                    TicketEnCurso seleccionado = tickets.Where(x => x.Id == idTicket).ToList()[0];
                    if (seleccionado.FechaFinalizacion != null)
                    {
                        informacionTicket.Add(seleccionado.FechaFinalizacion + "\t Su ticket ha quedado resuelto.  Comentarios: " + accesoApiTicket.LeerTicket((int)seleccionado.Id).Resolucion);
                    }
                    if (seleccionado.FechaEnCurso != null)
                    {
                        informacionTicket.Add(seleccionado.FechaEnCurso + "\t Su ticket está siendo tratado actualmente.  Observaciones: " + accesoApiTicket.LeerTicket((int)seleccionado.Id).NotasTecnico);
                    }
                    if (seleccionado.FechaAsignacion != null)
                    {
                        List<Tecnico> tecnicos = accesoApiTecnico.LeerTecnicos();
                        Usuario user = accesoApiUsuario.LeerUsuario((int)tecnicos.Where(x => x.IdTecnico == seleccionado.IdTecnico).ToList()[0].IdUsuario);
                        informacionTicket.Add(seleccionado.FechaAsignacion + "\t Ticket asignado a " + user.Nombre + " " + user.Apellidos + ".");
                    }

                    if (seleccionado.FechaCreacion != null)
                        informacionTicket.Add(seleccionado.FechaCreacion + "\t Ticket creado.");
                }

            }
            catch (ExternalException)
            {
                throw new IOException("Error al acceder a base de datos");
            }
            catch (Exception)
            {
                return null;
            }
            
            return informacionTicket;
        }

    }
}
