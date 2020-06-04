using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidades;

namespace Capa_Datos
{
    public class UsuarioADO : ADO
    {
        // Leo todos los usuarios dela BD
        public List<Usuario> LeerUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/usuarios").Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaUsuarios = JsonConvert.DeserializeObject<List<Usuario>>(aux);
                }
            }
            catch (Exception )
            {
                throw new ExternalException("Error:");
            }

            return listaUsuarios;
        }
        public Usuario LeerUsuario(int id)
        {
            Usuario user = new Usuario();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/usuarios/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    user = JsonConvert.DeserializeObject<Usuario>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return user;
        }
        // Creo un nuevo usuario en la BD
        public bool InsertarUsuario(string pass, string nombre, string apellidos, int extension, string mail, int numOficina, int rolUsuario)
        {
            try
            {
               
                Usuario usu = new Usuario(0, pass,nombre,apellidos,extension,mail,numOficina,rolUsuario);

                HttpResponseMessage response = client.PostAsJsonAsync("api/usuarios", usu).Result;
            

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e);
            }

            return true;
        }
        public bool ActualizarUsuario(Usuario usuario)
        {
            try
            {
                HttpResponseMessage response = client.PutAsJsonAsync("api/usuarios/" + usuario.UsuarioId, usuario).Result;

                if (response.IsSuccessStatusCode)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }
        }

        public bool BorrarUsuario(int id)
        {
            try
            {

                HttpResponseMessage response = client.DeleteAsync("api/usuarios/" + id).Result;

                if (response.IsSuccessStatusCode)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }
        }
    }
}
