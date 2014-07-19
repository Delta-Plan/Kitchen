using System.Web.Mvc;
using common.Logging;using System.Web.UI.WebControls;
using Database;using Database.Accessors;

namespace Kitchen.Controllers
{
    public class RecipesController : Controller
    {
        //
        // GET: /Recipes/

        public ActionResult Index(int id=0)
        {
            ILogger logger = NLogWrapper.GetNLogWrapper();
            var readed = RecipeAccessor.GetRecipie(id, logger);
            return View(readed);
        }

        //
        // GET: /Recipes/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Recipes/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Recipes/Create

        [HttpPost]
        public ActionResult Create(BaseRecipe collection)
        {
            try
            {
                // TODO: Add insert logic here

                return Content("Рецепт успешно сохранён в книге");//RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Recipes/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Recipes/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Recipes/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Recipes/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
