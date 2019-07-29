using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.Http;
using Microsoft.AspNetCore.Http;
using vocabularyManagementTool.Helper.Dependencies;
using vocabularyManagementTool.Model;

namespace vocabularyManagementTool.Helper {
    public class TokenHelper : ITokenHelper {
        private readonly IHttpClientFactory _clientFactory;
        IHttpContextAccessor accessor;

        public TokenHelper (IHttpClientFactory clientFactory, IHttpContextAccessor accessor) {
            _clientFactory = clientFactory;
            this.accessor = accessor;
        }

        //////
        //Use for token check before web request
        /////
        public bool CheckToken () {
            var httpContext = accessor.HttpContext;
            var token = httpContext.Session.GetString ("_token");

            if (!string.IsNullOrEmpty (token)) {
                return true;
            } else {
                return false;
            }
        }

        //////
        //Use for create new token if token is null
        //////
        public async Task CreateToken () {
            var request = new HttpRequestMessage (HttpMethod.Post,
                "http://services.cinarr.com/token");

            var values = new Dictionary<string, string> { 
                    { "grant_type", "password" },
                    { "username", "tolgacinars" },
                    { "password", "123963" }
                };

            request.Content = new FormUrlEncodedContent(values);
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
               var result = response.Content.ReadAsAsync<TokenViewModel>();
            }
        }
    }
}