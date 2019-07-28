
using System.Net.Http;
using System.Collections.Generic;
using vocabularyManagementTool.Model;

namespace VocabularyManagementTool.Helper
{
    public class WebApiHelper
    {
        private readonly IHttpClientFactory _clientFactory;
        public readonly string webApiUrl = "https://services.cinarr.com/";

        public WebApiHelper(IHttpClientFactory clientFactory){
            _clientFactory = clientFactory;
        }
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


    }   
}