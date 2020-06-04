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
    public class EstadoConexionADO : ADO
    {
        // Leo todos los estados  de la BD
        public List<EstadoConexion> LeerEstadoConexiones()
        {
            List<EstadoConexion> listaEstados = new List<EstadoConexion>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/estadoconexiones").Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaEstados = JsonConvert.DeserializeObject<List<EstadoConexion>>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaEstados;
        }
        public EstadoConexion LeerEstadoConexion(int id)
        {
            EstadoConexion estado = new EstadoConexion();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/estadoconexiones/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    estado = JsonConvert.DeserializeObject<EstadoConexion>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return estado;
        }
        // Creo un nuevo usuario en la BD
        public bool InsertarEstadoConexion(int id,string descripcion)
        {
            try
            {
                EstadoConexion est = new EstadoConexion(id,descripcion);

                HttpResponseMessage response = client.PostAsJsonAsync("api/estadoconexiones", est).Result;
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
        public bool ActualizarEstadoConexion(EstadoConexion estado)
        {
            try
            {
                HttpResponseMessage response = client.PutAsJsonAsync("api/estadoconexiones/" + estado.Id, estado).Result;

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

        public bool BorrarEstadoConexion(int id)
        {
            try
            {

                HttpResponseMessage response = client.DeleteAsync("api/estadoconexiones/" + id).Result;

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
