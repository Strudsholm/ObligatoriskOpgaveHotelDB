using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;
using FrontendApp.Model;
using Newtonsoft.Json;
using HttpClient = System.Net.Http.HttpClient;
using UnicodeEncoding = Windows.Storage.Streams.UnicodeEncoding;


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
            CreateGuest(new Guest() {Address = "asd", Guest_No = 123, Name = "asd"});
            //DeleteGuest(2);


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
                    var response = client.GetAsync("api/Guests").Result;
                    if (response.IsSuccessStatusCode)
                    {

                        var GuestJson = response.Content.ReadAsStringAsync().Result;

                        listofguests = JsonConvert.DeserializeObject<List<Guest>>(GuestJson);
                        GuestListSingleton.Instance.Guests = listofguests;


                    }

                }
                catch (Exception)
                {


                }

            }
        }

        public void CreateGuest(Guest nyGuest)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    //var JsonGuest = JsonConvert.SerializeObject(nyGuest);

                    //StringContent content = new StringContent(JsonGuest, Encoding.UTF8, "application/json");

                    var response = client.PostAsJsonAsync("api/Guests", nyGuest).Result;
                    if (response.IsSuccessStatusCode)
                    {

                    }
                }
                catch (Exception)
                {
                    throw;

                }
            }
        }

        //public void DeleteGuest(int id)
        //{
        //    using (var client = new HttpClient(handler))
        //    {
        //        client.BaseAddress = new Uri(serverUrl);
        //        client.DefaultRequestHeaders.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applicatione/json"));

        //        try
        //        {
        //            var response = client.DeleteAsync("api/Guests/2").Result;
        //            if (response.IsSuccessStatusCode)
        //            {

        //            }
        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }
        //    }
        //}


    }
}
