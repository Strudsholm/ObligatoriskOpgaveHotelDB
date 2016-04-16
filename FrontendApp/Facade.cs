using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FrontendApp.Model;
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
            serverUrl = "http://localhost:24061/";
            handler.UseDefaultCredentials = true;
            
        }

        //Http Get
        //Sætter min singleton = gæste listen via webservice
        public void GetMetode()
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applicatione/json"));

                var listofguests = new List<Guest>();

                try
                {
                    var responce = client.GetAsync("api/Guests").Result;
                    if (responce.IsSuccessStatusCode)
                    {

                        var GuestJson = responce.Content.ReadAsStringAsync().Result;

                        listofguests = JsonConvert.DeserializeObject<List<Guest>>(GuestJson);
                        GuestListSingleton.Instance.Guests = listofguests;


                    }

                }
                catch (Exception)
                {


                }
               
            }
        }



    }
}
