using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BabysitterKata.Controllers
{
    public class BabysitterController : Controller
    {
        // GET: Babysitter
        public ActionResult Index()
        {
            return View();
        }
    }
}