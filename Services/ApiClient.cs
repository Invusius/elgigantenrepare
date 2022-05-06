using Elgigantenrepare.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace Elgigantenrepare.Services
{
    public class ApiClient 
    {

        static readonly HttpClient client = new HttpClient();

        string token = "7ac008adc2dbd432a146c48c09cbfcd96b0ec38f7dd131025fb31541f633105ec2195be4214273481add4ebbfb4410b0d335b83c9f741e49bb9f4899a92239a2";

        public async Task<TestModel> gettest()
        {

            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.thecatapi.com/v1/images/search");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token );

            HttpResponseMessage response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead); 

            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();

            var jlist = JsonConvert.DeserializeObject<List<TestModel>>(jsonString);

            //var test = JsonConvert.DeserializeObject<testmodel>(jsonString);

            return jlist[0];


        }

        public async Task<List<kundeModel>> getKunder()
        {



            var request = new HttpRequestMessage(HttpMethod.Get, "https://elrepair.semeicardia.online/api/kunder");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            //HttpResponseMessage response = await client.GetAsync("http://elrepair.semeicardia.online/api/kunder");

            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            
            var obj = JsonConvert.DeserializeObject<List<kundeModel>>(jsonString);

            return obj;

        }
        public async Task<List<medarbejdereModel>> getMedarbejdere()
        {

            var request = new HttpRequestMessage(HttpMethod.Get, "https://elrepair.semeicardia.online/api/medarbejdere");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

            //HttpResponseMessage response = await client.GetAsync("http://elrepair.semeicardia.online/api/medarbejdere");

            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<List<medarbejdereModel>>(jsonString);

            return obj;

        }

        public async Task<List<ProduktModel>> getProdukter()
        {

            var request = new HttpRequestMessage(HttpMethod.Get, "https://elrepair.semeicardia.online/api/produkter");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<List<ProduktModel>>(jsonString);

            return obj;

        }

        public async Task<List<StatusModel>> getStatuser()
        {

            var request = new HttpRequestMessage(HttpMethod.Get, "https://elrepair.semeicardia.online/api/statuser");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<List<StatusModel>>(jsonString);

            return obj;

        }

        public async Task<List<SagTypeModel>> getSagstyper()
        {

            var request = new HttpRequestMessage(HttpMethod.Get, "https://elrepair.semeicardia.online/api/sagstyper");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<List<SagTypeModel>>(jsonString);

            return obj;

        }

        public async Task<List<SagModel>> getSager()
        {

            var request = new HttpRequestMessage(HttpMethod.Get, "https://elrepair.semeicardia.online/api/sager");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<List<SagModel>>(jsonString);

            return obj;

        }

        public async Task<bool> putSag(int id, opretSagModel opretSag)
        {

            using (var content = new StringContent(JsonConvert.SerializeObject(opretSag), System.Text.Encoding.UTF8, "application/json"))
            {

                var request = new HttpRequestMessage(HttpMethod.Put, "https://elrepair.semeicardia.online/api/sager/"+id);

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                request.Content = content;

                HttpResponseMessage response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }

            }


            return true;

        }

        public async Task<bool> deleteSag(int id)
        {
       
            var request = new HttpRequestMessage(HttpMethod.Delete, "https://elrepair.semeicardia.online/api/sager/" + id);

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            


            return true;

        }


        public async Task<SagModel> getSag(int id)
        {

            var request = new HttpRequestMessage(HttpMethod.Get, "https://elrepair.semeicardia.online/api/sager/" + id);

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<SagModel>(jsonString);

            return obj;

        }

        public async Task<List<LeveringsTypeModel>> getLeveringsTyper()
        {

            var request = new HttpRequestMessage(HttpMethod.Get, "https://elrepair.semeicardia.online/api/afhentningstyper");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<List<LeveringsTypeModel>>(jsonString);

            return obj;

        }

        public async Task<bool> postSag(opretSagModel opretSag)
        {



            using (var content = new StringContent(JsonConvert.SerializeObject(opretSag), System.Text.Encoding.UTF8, "application/json"))
            {

                var request = new HttpRequestMessage(HttpMethod.Post, "https://elrepair.semeicardia.online/api/sager");

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                request.Content = content; 

                HttpResponseMessage response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }

            }
             
                
            return true; 

        }

        public async Task<bool> postMedarbejderlogin(medarbejderloginModel login)
        {
            
            using (var content = new StringContent(JsonConvert.SerializeObject(login), System.Text.Encoding.UTF8, "application/json"))
            {

                var request = new HttpRequestMessage(HttpMethod.Post, "https://elrepair.semeicardia.online/api/medarbejdere/login");

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                request.Content = content;

                HttpResponseMessage response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }
                return true;

            }
        }

    }
}
