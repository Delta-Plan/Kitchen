using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Database;
using Database.Accessors;

namespace Kitchen.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var reader = RecipeAccessor<SimpleRecipe>.Instance;
            var lastAdded = reader.LastUpdated(20);
            ViewBag.Entries = lastAdded;
            return View();
        }

    }
}
