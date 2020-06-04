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
    public class TicketADO : ADO
    {
        // Leo todos los tickets  de la BD
        public List<Ticket> LeerTickets()
        {
            List<Ticket> listaTickets = new List<Ticket>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/tickets").Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaTickets = JsonConvert.DeserializeObject<List<Ticket>>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaTickets;
        }
        public Ticket LeerTicket(int id)
        {
            Ticket ticket = new Ticket();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/tickets/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    ticket = JsonConvert.DeserializeObject<Ticket>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return ticket;
        }
        // Creo un nuevo ticket en la BD
        public bool InsertarTicket(Ticket tick)
        {
            try
            {
               

                HttpResponseMessage response = client.PostAsJsonAsync("api/tickets", tick).Result;
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
        public bool AcutalizarTicket(Ticket tick)
        {
            try
            {
                HttpResponseMessage response = client.PutAsJsonAsync("api/tickets/" + tick.NumTicket, tick).Result;

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

        public bool BorrarTicket(int id)
        {
            try
            {

                HttpResponseMessage response = client.DeleteAsync("api/tickets/" + id).Result;

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
