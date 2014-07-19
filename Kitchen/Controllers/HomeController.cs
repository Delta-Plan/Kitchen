using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Database.Accessors;

namespace Kitchen.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var reader = new RecipeAccessor();
            var lastAdded = reader.LastUpdated(20);
            ViewBag.Entries = lastAdded;
            return View();
        }

    }
}
