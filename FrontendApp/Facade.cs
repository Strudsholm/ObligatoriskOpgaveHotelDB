using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace FrontendApp
{
    public class Facade
    {

        string serverUrl;
        private HttpClientHandler handler;

        public Facade()
        {
            handler = new HttpClientHandler();
            serverUrl = "http://localhost:5922/";
            handler.UseDefaultCredentials = true;
        }

        //Http Get
        public void GetMetode()
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
    client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applicatione/json"));

                try
                {
                    var responce = client.GetAsync("api/Guests").Result;
                    if (responce.IsSuccessStatusCode)
                    {

                        var GuestJson = responce.Content.ReadAsStringAsync().Result;

    var listofguests = JsonConvert.DeserializeObject<List<Guest>>(GuestJson);
                    }
                }
                catch (Exception)
                {

                    
                }
            }
        }
        

       
    }
}
