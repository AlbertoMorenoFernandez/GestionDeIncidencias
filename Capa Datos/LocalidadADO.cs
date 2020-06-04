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
    public class LocalidadADO : ADO
    {
        // Leo todas las localidades  de la BD
        public List<Localidad> LeerLocalidades()
        {
            List<Localidad> listaLocalidades = new List<Localidad>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/localidades").Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaLocalidades = JsonConvert.DeserializeObject<List<Localidad>>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaLocalidades;
        }
        public Localidad LeerLocalidad(int? id)
        {
            Localidad localidad = new Localidad();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/localidades/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    localidad = JsonConvert.DeserializeObject<Localidad>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return localidad;
        }
        // Creo una nueva localidad en la BD
        public bool InsertarLocalidad(int? id, string nombre)
        {
            try
            {
                Localidad local = new Localidad(0, nombre);

                HttpResponseMessage response = client.PostAsJsonAsync("api/localidades", local).Result;
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
        public bool ActualizarLocalidad(Localidad local)
        {
            try
            {
                HttpResponseMessage response = client.PutAsJsonAsync("api/localidades/" + local.Id, local).Result;

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

        public bool BorrarLocalidad(int? id)
        {
            try
            {

                HttpResponseMessage response = client.DeleteAsync("api/localidades/" + id).Result;

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
