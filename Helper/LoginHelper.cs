using System.Collections.Generic;
using System.Net.Cache;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Http;
using Newtonsoft.Json;
using vocabularyManagementTool.Helper.Dependencies;
using vocabularyManagementTool.Model;

namespace vocabularyManagementTool.Helper {
    public class LoginHelper : ILoginHelper {
        private readonly IHttpClientFactory _clientFactory;
        public readonly string webApiUrl = "https://services.cinarr.com/";

        public LoginHelper (IHttpClientFactory clientFactory) {
            _clientFactory = clientFactory;
        }

        //////
        //This method using for login.
        //Checking member in database.
        //////
        public async Task<bool> LoginMember (MemberViewModel member, string token) {
            Task<MemberViewModelByWebApi> success = null;

            var request = new HttpRequestMessage (HttpMethod.Post,
                webApiUrl + "api/Member/Login");

            request.Headers.Add ("Authorization", "Bearer " + token);

            var json = JsonConvert.SerializeObject (member);
            request.Content = new StringContent (json, UnicodeEncoding.UTF8, "application/json");

            var client = _clientFactory.CreateClient ();
            var response = await client.SendAsync (request);

            if (response.IsSuccessStatusCode) {
                success = response.Content.ReadAsAsync<MemberViewModelByWebApi> ();
            }

            if (success.Result != null) {
                return true;
            } else {
                return false;
            }
        }
    }
}