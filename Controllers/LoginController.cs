using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using vocabularyManagementTool.Model;
using VocabularyManagementTool.Helper;
using Microsoft.AspNetCore.Http;

namespace vocabularyManagementTool.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly TokenHelper _tokenhelper;
        private readonly LoginHelper _loginHelper;
        IHttpContextAccessor _accessor;
        private string _token;

        public LoginController(TokenHelper tokenhelper, IHttpContextAccessor accessor, LoginHelper loginHelper)
        {
            _tokenhelper = tokenhelper;
            _accessor = accessor;
            _loginHelper = loginHelper;
        }

        //////
        //This method using for Login
        //////
        [HttpPost("[Action]")]
        public ActionResult Login(LoginViewModel request)
        {
            if(_tokenhelper.CheckToken()){
                var httpContent = _accessor.HttpContent;
                _token = httpContent.Session.GetStarting("_token");
            }else {
                _token = _tokenhelper.CreateToken();
            }

            _loginHelper.LoginMember(request, _token);

            return Json(new { success = false })
        }
    }
}
