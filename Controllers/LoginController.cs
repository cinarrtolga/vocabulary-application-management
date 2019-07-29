using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using vocabularyManagementTool.Model;
using vocabularyManagementTool.Helper.Dependencies;
using Microsoft.AspNetCore.Http;

namespace vocabularyManagementTool.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly ITokenHelper _tokenhelper;
        private readonly ILoginHelper _loginHelper;
        IHttpContextAccessor _accessor;
        private string _token;

        public LoginController(ITokenHelper tokenhelper, IHttpContextAccessor accessor, ILoginHelper loginHelper)
        {
            _tokenhelper = tokenhelper;
            _accessor = accessor;
            _loginHelper = loginHelper;
        }

        //////
        //This method using for Login
        //////
        [HttpPost("[Action]")]
        public ActionResult Authentication(MemberViewModel request)
        {
            if(_tokenhelper.CheckToken()){
                var httpContext = _accessor.HttpContext;
                _token = httpContext.Session.GetString("_token");
            }else {
                //_token = _tokenhelper.CreateToken();
            }

            _loginHelper.LoginMember(request, _token);

            return Json(new { success = false });
        }
    }
}
