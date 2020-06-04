using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidades;
using Newtonsoft.Json;

namespace Capa_Datos
{
    public class EstadoUsuarioADO : ADO
    {
        // Leo todos los estados  de la BD
        public List<EstadoUsuario> LeerEstadoUsuarios()
        {
            List<EstadoUsuario> listaEstados = new List<EstadoUsuario>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/estadousuarios").Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaEstados = JsonConvert.DeserializeObject<List<EstadoUsuario>>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaEstados;
        }
        public EstadoUsuario LeerEstadoUsuario(int id)
        {
            EstadoUsuario estado = new EstadoUsuario();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/estadousuarios/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    estado = JsonConvert.DeserializeObject<EstadoUsuario>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return estado;
        }
        // Creo un nuevo usuario en la BD
        public bool InsertarEstadoUsuario(int idUsuario, int idConexion, DateTime fechaUltimaRevision)
        {
            try
            {
                EstadoUsuario est = new EstadoUsuario(idUsuario,idConexion,fechaUltimaRevision);

                HttpResponseMessage response = client.PostAsJsonAsync("api/estadousuarios", est).Result;
                //var response = client.PostAsync("api/usuarios", new StringContent(new JavaScriptSerializer().Serialize(usu), Encoding.UTF8, "application/json")).Result;
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
        public bool ActualizarEstadoUsuario(EstadoUsuario estado)
        {
            try
            {
                HttpResponseMessage response = client.PutAsJsonAsync("api/estadousuarios/" + estado.IdUsuario, estado).Result;

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

        public bool BorrarEstadoUsuario(int id)
        {
            try
            {

                HttpResponseMessage response = client.DeleteAsync("api/estadousuarios/" + id).Result;

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
