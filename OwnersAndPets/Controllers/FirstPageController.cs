using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OwnersAndPets.Controllers
{
    public class FirstPageController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
