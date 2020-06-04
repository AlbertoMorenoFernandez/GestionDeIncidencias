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
    public class SedeADO : ADO
    {
        // Leo todas las sedes  de la BD
        public List<Sede> LeerSedes()
        {
            List<Sede> listaSedes = new List<Sede>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/sedes").Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaSedes = JsonConvert.DeserializeObject<List<Sede>>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaSedes;
        }
        public Sede LeerSede(int id)
        {
            Sede sede  = new Sede();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/sedes/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    sede = JsonConvert.DeserializeObject<Sede>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return sede;
        }
        // Creo una nueva sede en la BD
        public bool InsertarSede(int numOficina, string calle, string codigoPostal, int planta, int localidad)
        {
            try
            {
                Sede sede = new Sede(0, calle,codigoPostal,planta,localidad);

                HttpResponseMessage response = client.PostAsJsonAsync("api/sedes", sede).Result;
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
        public bool ActualizarSede(Sede sede)
        {
            try
            {
                HttpResponseMessage response = client.PutAsJsonAsync("api/sedes/" + sede.NumOficina, sede).Result;

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

        public bool BorrarSede(int id)
        {
            try
            {

                HttpResponseMessage response = client.DeleteAsync("api/sedes/" + id).Result;

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
