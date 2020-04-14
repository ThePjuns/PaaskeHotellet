
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Persistency
{
    class HotelPersistency : IPersist<Hotel>
    {
        public const string ServerUrl = "Http://localhost:53995";

        #region Create
        public void Create(Hotel TObject)
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
                    var response = client.PostAsJsonAsync("api/Hotels", TObject).Result;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
        #endregion


        #region Read
        public List<Hotel> Read()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.UseDefaultCredentials = true;

            List<Hotel> ListObjects = new List<Hotel>();
            using (var client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/Hotels").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var List = response.Content.ReadAsAsync<IEnumerable<Hotel>>().Result;
                        foreach (var ob in List)
                        {
                            ListObjects.Add(ob);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            return ListObjects;

        }
        #endregion


        #region Update
        public void Update(Hotel TObject, Hotel OObject)
        {
            throw new NotImplementedException();
        }
        #endregion


        #region Delete
        public void Delete(Hotel TObject)
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
                    var response = client.DeleteAsync($"api/Hotels/{TObject.Hotel_No}").Result;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        } 
        #endregion
    }
}


