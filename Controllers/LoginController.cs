using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vocabularyManagementTool.Helper.Dependencies;
using vocabularyManagementTool.Model;

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
            if (_tokenhelper.CheckToken())
            {
                var httpContext = _accessor.HttpContext;
                _token = httpContext.Session.GetString("_token");
                httpContext = null;
            }
            else
            {
                Task<string> result = _tokenhelper.CreateToken();
                result.Wait();
                _token = result.Result;
            }

            Task<bool> memberCheck = _loginHelper.LoginMember(request, _token);
            memberCheck.Wait();

            if (memberCheck.Result)
            {
                var httpContext = _accessor.HttpContext;
                httpContext.Session.SetString("_member", "loggedIn");
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }

        //////
        //This method for login control in word list page
        //////
        [HttpPost("[Action]")]
        public ActionResult LoginCheck()
        {
            var httpContext = _accessor.HttpContext;
            _token = httpContext.Session.GetString("_member");
            httpContext = null;

            if (!string.IsNullOrEmpty(_token))
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }

        //////
        //This method for logout. This method clean all sessions.
        //////
        [HttpPost("[Action]")]
        public ActionResult Logout()
        {
            var httpContext = _accessor.HttpContext;
            HttpContext.Session.Clear();

            return Json(new { success = true });
        }
    }
}