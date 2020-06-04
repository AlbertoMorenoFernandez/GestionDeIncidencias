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
    public class EstadoADO : ADO
    {
        // Leo todos los estados  de la BD
        public List<Estado> LeerEstados()
        {
            List<Estado> listaEstados = new List<Estado>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/estados").Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaEstados = JsonConvert.DeserializeObject<List<Estado>>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaEstados;
        }
        public Estado LeerEstado(int id)
        {
            Estado estado = new Estado();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/estados/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    estado = JsonConvert.DeserializeObject<Estado>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return estado;
        }
        // Creo un nuevo usuario en la BD
        public bool InsertarEstado(int id, string descripcion)
        {
            try
            {
                Estado est = new Estado(0, descripcion);

                HttpResponseMessage response = client.PostAsJsonAsync("api/estados", est).Result;
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
        public bool ActualizarEstado(Estado estado)
        {
            try
            {
                HttpResponseMessage response = client.PutAsJsonAsync("api/estados/" + estado.Id, estado).Result;

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

        public bool BorrarEstado(int id)
        {
            try
            {

                HttpResponseMessage response = client.DeleteAsync("api/estados/" + id).Result;

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
