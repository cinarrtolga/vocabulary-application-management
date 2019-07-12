using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vocabularyManagementTool.Model;

namespace vocabularyManagementTool.Controllers
{
    [Route("api/[controller]")]
    public class WordController : Controller
    {
        [HttpPost("[action]")]
        public ActionResult GetAllWords()
        {
            List<WordsViewModel> vocabularyList = new List<WordsViewModel>();
            vocabularyList.Add(new WordsViewModel { Id = 1, Keyword = "Test1", Mean = "Ornek 1", Status = true });
            vocabularyList.Add(new WordsViewModel { Id = 2, Keyword = "Test2", Mean = "Ornek 2", Status = true });
            vocabularyList.Add(new WordsViewModel { Id = 3, Keyword = "Test3", Mean = "Ornek 3", Status = true });
            vocabularyList.Add(new WordsViewModel { Id = 4, Keyword = "Test4", Mean = "Ornek 4", Status = true });

            return Json(new { success = true, data = vocabularyList });
        }

        [HttpPost("[Action]")]
        public ActionResult NewWord(WordsViewModel data)
        {
            return Json(new { success = true });
        }

        [HttpPost("[Action]")]
        public ActionResult GetWordByWordId(WordsViewModel data)
        {
            return Json(new { success = true });
        }

        [HttpPost("[Action]")]
        public ActionResult UpdateWord(WordsViewModel data)
        {
            return Json(new { success = true });
        }

        [HttpPost("[Action]")]
        public ActionResult DeleteWord(WordsViewModel data)
        {
            return Json(new { success = true });
        }
    }
}
