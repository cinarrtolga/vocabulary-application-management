using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.Http;
using Microsoft.AspNetCore.Http;
using vocabularyManagementTool.Model;
using vocabularyManagementTool.Helper.Dependencies;
using Newtonsoft.Json;

namespace vocabularyManagementTool.Helper
{
    public class WordOperationHelper : IWordOperationHelper
    {
        private readonly IHttpClientFactory _clientFactory;
        public readonly string webApiUrl = "http://services.cinarr.com/";

        public WordOperationHelper(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        //////
        //This method getting all words from database
        //////
        public async Task<WordsViewModelByWebApi> GetWordsByWebApi(string token)
        {
            Task<WordsViewModelByWebApi> success = null;

            var request = new HttpRequestMessage(HttpMethod.Get,
            webApiUrl + "api/WordGame/GetAllWords");

            request.Headers.Add("Authorization", "Bearer " + token);

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                success = response.Content.ReadAsAsync<WordsViewModelByWebApi>();
            }

            return await success;
        }

        //////
        //This method using for insert new word in database
        //////
        public async Task<bool> InsertNewWordByWebApi(WordsViewModel requestBody, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Post,
            webApiUrl + "api/WordGame/InsertNewWord");

            request.Headers.Add("Authorization", "Bearer " + token);

            var json = JsonConvert.SerializeObject(requestBody);

            request.Content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //////
        //This method using for update word in database
        //////
        public async Task<bool> UpdateWordByWebApi(WordsViewModel requestBody, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Post,
            webApiUrl + "api/WordGame/UpdateWord");

            request.Headers.Add("Authorization", "Bearer " + token);

            var json = JsonConvert.SerializeObject(requestBody);

            request.Content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //////
        //This method using for delete word in database
        //////
        public async Task<bool> DeleteWordByWebApi(WordsViewModel requestBody, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Post,
            webApiUrl + "api/WordGame/DeleteWord");

            request.Headers.Add("Authorization", "Bearer " + token);

            var json = JsonConvert.SerializeObject(requestBody);

            request.Content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}