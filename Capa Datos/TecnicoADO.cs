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
    public class TecnicoADO:ADO
    {
        // Leo todos los tipos  de la BD
        public List<Tecnico> LeerTecnicos()
        {
            List<Tecnico> listaTecnicos = new List<Tecnico>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/tecnicos").Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaTecnicos = JsonConvert.DeserializeObject<List<Tecnico>>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaTecnicos;
        }
        public Tecnico LeerTecnico(int id)
        {
            Tecnico tecnico = null;
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/tecnicos/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    tecnico = JsonConvert.DeserializeObject<Tecnico>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return tecnico;
        }
        // Creo un nuevo tipo en la BD
        public bool InsertarTecnico(int idUsuario, int idTecnico)
        {
            try
            {
                Tecnico tecnico = new Tecnico(idUsuario, idTecnico);

                HttpResponseMessage response = client.PostAsJsonAsync("api/tecnicos", tecnico).Result;
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
        public bool ActualizarTecnico(Tecnico tecnico)
        {
            try
            {
                HttpResponseMessage response = client.PutAsJsonAsync("api/tecnicos/" + tecnico.IdUsuario, tecnico).Result;

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

        public bool BorrarTecnico(int id)
        {
            try
            {

                HttpResponseMessage response = client.DeleteAsync("api/tecnicos/" + id).Result;

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
