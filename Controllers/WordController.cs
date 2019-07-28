using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using vocabularyManagementTool.Model;
using VocabularyManagementTool.Helper;
using Microsoft.AspNetCore.Http;

namespace vocabularyManagementTool.Controllers
{
    [Route("api/[controller]")]
    public class WordController : Controller
    {
        private readonly TokenHelper _tokenhelper;
        private readonly WebApiHelper _webApiHelper;
        IHttpContextAccessor _accessor;
        private string _token;

        public WordController(TokenHelper tokenhelper, IHttpContextAccessor accessor, WebApiHelper webApiHelper)
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
                _token = _tokenhelper.CreateToken();
            }

            List<WordsViewModel> vocabularyList = _webApiHelper.GetWordsByWebApi(_token);

            return Json(new { success = true, data = vocabularyList });
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
                _token = _tokenhelper.CreateToken();
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
                _token = _tokenhelper.CreateToken();
            }

            _webApiHelper.UpdateWordByWebApi(data, _token);

            return Json(new { success = true });
        }

        [HttpPost("[Action]")]
        public ActionResult GetWordByWordId(WordsViewModel data)
        {
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
                _token = _tokenhelper.CreateToken();
            }

            _webApiHelper.DeleteWordByWebApi(data, _token);

            return Json(new { success = true });
        }
    }
}
