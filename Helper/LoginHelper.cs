using System.Text;
using System.Net.Http;
using System.Collections.Generic;
using vocabularyManagementTool.Model;
using Newtonsoft.Json;

namespace vocabularyManagementTool.Helper
{
    public class LoginHelper
    {
        private readonly IHttpClientFactory _clientFactory;
        public readonly string webApiUrl = "https://services.cinarr.com/";

        public LoginHelper(IHttpClientFactory clientFactory){
            _clientFactory = clientFactory;
        }

        //////
        //This method using for login.
        //Checking member in database.
        //////
        public bool LoginMember(MemberViewModel member, string token){
            var request = new HttpRequestMessage(HttpMethod.Post,
            webApiUrl + "api/Member/Login");

            request.Headers.Add("Content-Type","application/json");
            request.Headers.Add("Authorization","Bearer " + token);

            var client = _clientFactory.CreateClient();
            var response = client.SendAsync(request);

            return true;
        } 
    }
}