using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProCodeGuide.ContractPact.Mock
{
    class APIClient
    {

        private readonly HttpClient _client;


        public APIClient(string baseUri = null)
        {
            _client = new HttpClient { BaseAddress = new Uri(baseUri ?? "http://localhost:5000") };
            //https://localhost:44360/api/Maths
        }


        public async Task<string> GetString()
        {

            string reasonPhrase;

            var request = new HttpRequestMessage(HttpMethod.Get, "/api/Maths");
            request.Headers.Add("Accept", "application/json");

            var response = await _client.SendAsync(request);

            var content = response.Content.ReadAsStringAsync().Result;
            var status = response.StatusCode;


            reasonPhrase = response.ReasonPhrase;

            request.Dispose();
            response.Dispose();

            if (status == System.Net.HttpStatusCode.OK)
                return !String.IsNullOrEmpty(content) ? content : null;


            //return new Exception(reasonPhrase);
            return null;
        }

        public  string GetTestString()
        {

            string reasonPhrase;

            var request = new HttpRequestMessage(HttpMethod.Get, "/api/Maths/GetTestValue");
            request.Headers.Add("Accept", "application/json");

            var response = _client.SendAsync(request);

            var content = response.Result.Content.ReadAsStringAsync().Result;
            var status = response.Result.StatusCode;


            reasonPhrase = response.Result.ReasonPhrase;


            request.Dispose();
            response.Dispose();

            if (status == System.Net.HttpStatusCode.OK)
                return !String.IsNullOrEmpty(content) ? content : null;


            throw new Exception(reasonPhrase);
        }

        //public async Task<string> GetSum(int x, int y)
        //{

        //    string reasonPhrase;

        //    var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5000/api/Maths/Add?x1=2&x2=3");
        //    request.Headers.Add("Accept", "application/json");

        //    var values = new List<KeyValuePair<string, string>>();
        //    values.Add(new KeyValuePair<string, string>("x1", "1"));
        //    values.Add(new KeyValuePair<string, string>("x2", "3"));

        //    request.Content = new FormUrlEncodedContent(values);

        //    //var response = _client.SendAsync(request);

        //    HttpResponseMessage response = await _client.SendAsync(request);

        //    var content = await response.Content.ReadAsStringAsync();
        //    var status = response.StatusCode;


        //    reasonPhrase = response.ReasonPhrase;

        //    request.Dispose();
        //    response.Dispose();

        //    if (status == System.Net.HttpStatusCode.OK)
        //        return !String.IsNullOrEmpty(content) ? content : null;


        //    throw new Exception(reasonPhrase);
        //    //return null;
        //}



    }
}
