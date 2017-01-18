using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OwnersAndPets.Controllers
{
    public class SecondPageController : Controller
    {
        public ActionResult Index(int id)
        {
            ViewBag.Head = id;
            return View();
        }
    }
}