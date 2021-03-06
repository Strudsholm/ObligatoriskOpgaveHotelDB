﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;
using FrontendApp.Model;
using FrontendApp.ViewModel;
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
            //CreateGuest(new Guest() {Name = "xdtrolllll", Guest_No = 31, Address = "jn"});
            //DeleteGuest(2);
            //UpdateGuest(1, new Guest() {Guest_No = 1, Address = "hhhhh", Name = "tesssst"});
            

        }

        public List<GuestAndBookings> ViewGetMetode()
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var view = new List<GuestAndBookings>();

                try
                {
                    var response = client.GetAsync("api/GuestAndBookings").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var ViewJson = response.Content.ReadAsStringAsync().Result;

                        view = JsonConvert.DeserializeObject<List<GuestAndBookings>>(ViewJson);
                        return view;
                    }
                    return null;
                }
                catch (Exception)
                {
                    return null;
                    throw;
                }
            }
        }

        //Http Get
        //Sætter min singleton = gæste listen via webservice
        public void GetMetode()
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

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
        public Guest GetMetode1(int id)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var guestinfo = new Guest();
                Guest fejlgæst = new Guest() { Guest_No = 119, Name = "fejl", Address = "fejl" };

                try
                {
                    var response = client.GetAsync("api/Guests/"+id).Result;
                    if (response.IsSuccessStatusCode)
                    {

                        var GuestJson = response.Content.ReadAsStringAsync().Result;

                        guestinfo = JsonConvert.DeserializeObject<Guest>(GuestJson);

                        return guestinfo;

                    }
                    return fejlgæst;
                }
                catch (Exception)
                {
                    return fejlgæst;

                }

            }
        }

        public async Task CreateGuest(Guest nyGuest)
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


                    var response = await client.PostAsJsonAsync("api/Guests", nyGuest);
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

        public async Task UpdateGuest(int id, Guest nyGuest)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.PutAsJsonAsync("api/Guests/"+id, nyGuest);
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

        public async Task DeleteGuest(int id)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.DeleteAsync("api/Guests/"+id);
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


    }
}
