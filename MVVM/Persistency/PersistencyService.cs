using PaaskeHotellet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Persistency
{
    class PersistencyService
    {
        public const string ServerUrl = "http://localhost:50466/";


        public static List<Hotel> GetEvents()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.UseDefaultCredentials = true;

            List<Hotel> listHotels = new List<Hotel>();
            using (var client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/object").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var Tobject = response.Content.ReadAsAsync<IEnumerable<Hotel>>().Result;
                        foreach (var ho in Tobject)
                        {
                            listHotels.Add(ho);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            return listHotels;

        }

        public static void AddTobject(Hotel ho)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.UseDefaultCredentials = true;
            using (var client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.PostAsJsonAsync("api/object", ho).Result;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public static void DeleteTobject(Hotel ho)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.UseDefaultCredentials = true;
            using (var client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.DeleteAsync($"api/object/{ho.Id}").Result;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }


    }
}

