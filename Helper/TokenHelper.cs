
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace VocabularyManagementTool.Helper
{
    public class TokenHelper
    {
        private readonly IHttpClientFactory _clientFactory;
        IHttpContextAccessor accessor;

        public TokenHelper(IHttpClientFactory clientFactory, IHttpContextAccessor accessor)
        {
            _clientFactory = clientFactory;
            this.accessor = accessor;
        }

        //////
        //Use for token check before web request
        /////
        public bool CheckToken()
        {
            var httpContext = accessor.HttpContext;
            var token = httpContext.Session.GetString("_token");

            if(!string.IsNullOrEmpty(token)){
                return true;
            }else {
                return false;
            }
        }

        //////
        //Use for create new token if token is null
        //////
        public async Task<string> CreateToken()
        {
           var request = new HttpRequestMessage(HttpMethod.Post,
           "http://services.cinarr.com/token");

            var values = new Dictionary<string, string>{
                {"grant_type", "password"},
                {"username", "tolgacinars"},
                {"password", "123963"}
            };

            request.Content = new FormUrlEncodedContent(values);
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            return "";
        }
    }
}