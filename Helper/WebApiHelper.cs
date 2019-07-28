
using System.Text;
using System.Net.Http;
using System.Collections.Generic;
using vocabularyManagementTool.Model;
using Newtonsoft.Json;

namespace VocabularyManagementTool.Helper
{
    public class WebApiHelper
    {
        private readonly IHttpClientFactory _clientFactory;
        public readonly string webApiUrl = "https://services.cinarr.com/";

        public WebApiHelper(IHttpClientFactory clientFactory){
            _clientFactory = clientFactory;
        }

        //////
        //This method getting all words from database
        //////
        public List<WordsViewModel> GetWordsByWebApi(string token){
            List<WordsViewModel> words = new List<WordsViewModel>();

            var request = new HttpRequestMessage(HttpMethod.Post,
            webApiUrl + "api/WordGame/GetAllWords");

            request.Headers.Add("Content-Type","application/json");
            request.Headers.Add("Authorization","Bearer " + token);

            var client = _clientFactory.CreateClient();
            var response = client.SendAsync(request);

            return words;
        }

        //////
        //This method using for insert new word in database
        //////
        public bool InsertNewWordByWebApi(WordsViewModel requestBody, string token){
            var request = new HttpRequestMessage(HttpMethod.Post,
            webApiUrl + "api/WordGame/InsertNewWord");

            request.Headers.Add("Content-Type", "application/json");
            request.Headers.Add("Authorization", "Bearer " + token);

            var json = JsonConvert.SerializeObject(requestBody);

            request.Content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var client = _clientFactory.CreateClient();
            var response = client.SendAsync(request);

            return true;
        }

        //////
        //This method using for update word in database
        //////
        public bool UpdateWordByWebApi(WordsViewModel requestBody, string token){
            var request = new HttpRequestMessage(HttpMethod.Post,
            webApiUrl + "api/WordGame/UpdateWord");

            request.Headers.Add("Content-Type", "application/json");
            request.Headers.Add("Authorization", "Bearer " + token);

            var json = JsonConvert.SerializeObject(requestBody);

            request.Content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var client = _clientFactory.CreateClient();
            var response = client.SendAsync(request);

           return true; 
        }

        //////
        //This method using for delete word in database
        //////
        public bool DeleteWordByWebApi(WordsViewModel requestBody, string token){
            var request = new HttpRequestMessage(HttpMethod.Post,
            webApiUrl + "api/WordGame/DeleteWord");

            request.Headers.Add("Content-Type", "application/json");
            request.Headers.Add("Authorization", "Bearer " + token);

            var json = JsonConvert.SerializeObject(requestBody);

            request.Content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var client = _clientFactory.CreateClient();
            var response = client.SendAsync(request);

            return true;
        }

    }   
}