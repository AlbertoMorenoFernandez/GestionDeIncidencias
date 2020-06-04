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
    public class TipoADO : ADO
    {
        // Leo todos los tipos  de la BD
        public List<Tipo> LeerTipos()
        {
            List<Tipo> listaTipos = new List<Tipo>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/tipos").Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaTipos = JsonConvert.DeserializeObject<List<Tipo>>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaTipos;
        }
        public Tipo LeerTipo(int id)
        {
            Tipo tipo = new Tipo();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/tipos/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    tipo = JsonConvert.DeserializeObject<Tipo>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return tipo;
        }
        // Creo un nuevo tipo en la BD
        public bool InsertarTipo(int id, string nombre)
        {
            try
            {
                Tipo tip = new Tipo(0, nombre);

                HttpResponseMessage response = client.PostAsJsonAsync("api/tipos", tip).Result;
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
        public bool ActualizarTipo(Tipo tipo)
        {
            try
            {
                HttpResponseMessage response = client.PutAsJsonAsync("api/tipos/" + tipo.Id, tipo).Result;

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

        public bool BorrarTipo(int id)
        {
            try
            {

                HttpResponseMessage response = client.DeleteAsync("api/tipos/" + id).Result;

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
