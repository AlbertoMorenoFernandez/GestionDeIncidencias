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
    public class TicketEnCursoADO : ADO
    {
        // Leo todos los tickets en curso  de la BD
        public List<TicketEnCurso> LeerTicketsEnCurso()
        {
            List<TicketEnCurso> listaTickets = new List<TicketEnCurso>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/ticketencursos").Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaTickets = JsonConvert.DeserializeObject<List<TicketEnCurso>>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaTickets;
        }
        public TicketEnCurso LeerTicketEnCurso(int id)
        {
            TicketEnCurso ticket = new TicketEnCurso();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/ticketencursos/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    ticket = JsonConvert.DeserializeObject<TicketEnCurso>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return ticket;
        }
        // Creo un nuevo ticket en curso en la BD
        public bool InsertarTicketEnCurso(int id, int idUsuario, int idTecnico, DateTime fechaCreacion, DateTime fechaAsignacion, DateTime fechaEnCurso, DateTime fechaFinalizacion)
        {
            try
            {
                TicketEnCurso newTicket = new TicketEnCurso(id,idUsuario,idTecnico,fechaFinalizacion,fechaCreacion,fechaEnCurso,fechaFinalizacion);

                HttpResponseMessage response = client.PostAsJsonAsync("api/ticketencursos", newTicket).Result;
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
        public bool AcutalizarTicketEnCurso(TicketEnCurso tick)
        {
            try
            {
                HttpResponseMessage response = client.PutAsJsonAsync("api/ticketencursos/" + tick.Id, tick).Result;

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

        public bool BorrarTicketEnCurso(int id)
        {
            try
            {

                HttpResponseMessage response = client.DeleteAsync("api/ticketencursos/" + id).Result;

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
