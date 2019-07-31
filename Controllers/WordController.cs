using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using vocabularyManagementTool.Model;
using vocabularyManagementTool.Helper.Dependencies;
using Microsoft.AspNetCore.Http;

namespace vocabularyManagementTool.Controllers
{
    [Route("api/[controller]")]
    public class WordController : Controller 
    {
        private readonly ITokenHelper _tokenhelper;
        private readonly IWordOperationHelper _webApiHelper;
        IHttpContextAccessor _accessor;
        private string _token;

        public WordController(ITokenHelper tokenhelper, IHttpContextAccessor accessor, IWordOperationHelper webApiHelper)
        {
            _tokenhelper = tokenhelper;
            _accessor = accessor;
            _webApiHelper = webApiHelper;
        }

        //////
        //Use for check all words.
        //This is using from Word Game.
        //No need parameter or anything.
        //////
        [HttpPost("[action]")]
        public ActionResult GetAllWords()
        {
            //Checking token for request
            if(_tokenhelper.CheckToken()){
                var httpContext = _accessor.HttpContext;
                _token = httpContext.Session.GetString("_token");
            }else{
                //_token = _tokenhelper.CreateToken();
                Task<string> result = _tokenhelper.CreateToken();
                result.Wait();
                _token = result.Result;
            }

            Task<WordsViewModelByWebApi> vocabularyList = _webApiHelper.GetWordsByWebApi(_token);
            vocabularyList.Wait();

            return Json(new { success = true, data = vocabularyList.Result });
        }

        //////
        //Use for insert new word.
        //This is using from Word Game.
        //////
        [HttpPost("[Action]")]
        public ActionResult NewWord(WordsViewModel data)
        {
            //Checking token for request
            if(_tokenhelper.CheckToken()){
                var httpContent = _accessor.HttpContext;
                _token = httpContent.Session.GetString("_token");
            }else{
                //_token = _tokenhelper.CreateToken();
            }

            _webApiHelper.InsertNewWordByWebApi(data, _token);

            return Json(new { success = true });
        }

        //////
        //Use for update word
        //This is using from Word Game
        //////
        [HttpPost("[Action]")]
        public ActionResult UpdateWord(WordsViewModel data)
        {
            if(_tokenhelper.CheckToken()){
                var httpContent = _accessor.HttpContext;
                _token = httpContent.Session.GetString("_token");
            }else {
                //_token = _tokenhelper.CreateToken();
            }

            _webApiHelper.UpdateWordByWebApi(data, _token);

            return Json(new { success = true });
        }

        //////
        //Use for update word
        //This is using from Word Game
        //////
        [HttpPost("[Action]")]
        public ActionResult DeleteWord(WordsViewModel data)
        {
            if(_tokenhelper.CheckToken()){
                var httpContent = _accessor.HttpContext;
                _token = httpContent.Session.GetString("_token");
            }else {
                //_token = _tokenhelper.CreateToken();
            }

            _webApiHelper.DeleteWordByWebApi(data, _token);

            return Json(new { success = true });
        }
    }
}
