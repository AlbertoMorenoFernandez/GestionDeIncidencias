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
    public class EquipoADO : ADO
    {
        // Leo todos los tipos  de la BD
        public List<Equipo> LeerEquipos()
        {
            List<Equipo> listaEquipos = new List<Equipo>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/equipos").Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaEquipos = JsonConvert.DeserializeObject<List<Equipo>>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaEquipos;
        }
        public Equipo LeerEquipo(string id)
        {
            Equipo equipo = null;
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/equipos/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    equipo = JsonConvert.DeserializeObject<Equipo>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return equipo;
        }
        // Creo un nuevo equipo en la BD
        public bool InsertarEquipo(string serviceTag, string marca, string modelo, DateTime? finGarantia, int? idtipo, int? numOficina, string numSerie)
        {
            try
            {
                Equipo team = new Equipo(serviceTag, marca,modelo,finGarantia,idtipo,numOficina,numSerie);

                HttpResponseMessage response = client.PostAsJsonAsync("api/equipos", team).Result;
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
        public bool ActualizarEquipo(Equipo equipo)
        {
            try
            {
                HttpResponseMessage response = client.PutAsJsonAsync("api/equipos/" + equipo.ServiceTag, equipo).Result;

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

        public bool BorrarEquipo(string id)
        {
            try
            {

                HttpResponseMessage response = client.DeleteAsync("api/equipos/" + id).Result;

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
