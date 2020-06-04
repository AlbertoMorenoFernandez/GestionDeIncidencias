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
    public class RolADO : ADO
    {
        // Leo todos los roles  de la BD
        public List<Rol> LeerRoles()
        {
            List<Rol> listaRoles = new List<Rol>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/roles").Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaRoles = JsonConvert.DeserializeObject<List<Rol>>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaRoles;
        }
        public Rol LeerRol(int id)
        {
            Rol rol = new Rol();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/roles/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    rol = JsonConvert.DeserializeObject<Rol>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return rol;
        }
        // Creo un nuevo rol en la BD
        public bool InsertarRol(int id, string nombre)
        {
            try
            {
                Rol rol = new Rol(0, nombre);

                HttpResponseMessage response = client.PostAsJsonAsync("api/roles", rol).Result;
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
        public bool ActualizarRol(Rol rol)
        {
            try
            {
                HttpResponseMessage response = client.PutAsJsonAsync("api/roles/" + rol.Id, rol).Result;

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

        public bool BorrarRoles(int id)
        {
            try
            {

                HttpResponseMessage response = client.DeleteAsync("api/roles/" + id).Result;

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
