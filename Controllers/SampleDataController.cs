using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace vocabularyManagementTool.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        [HttpGet("[action]")]
        public ActionResult Authentication(string username, string password)
        {
            return Json(new { success = false, test = false });
        }
    }
}
