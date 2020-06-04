using System;

using System.Net.Http;
using System.Net.Http.Headers;


namespace Capa_Datos
{
    public abstract class ADO
    {
        protected HttpClient client = new HttpClient();

        public ADO()
        {
            client.BaseAddress = new Uri("http://localhost:55956");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = TimeSpan.FromMinutes(10);
        }
    }
}
