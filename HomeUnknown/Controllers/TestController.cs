using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeUnknown.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult InputEvent()
        {
            return View();
        }

        public ActionResult InputContent()
        {
            return View();
        }
    }
}