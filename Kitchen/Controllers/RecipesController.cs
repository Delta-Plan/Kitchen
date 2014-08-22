using System.Web.Mvc;
using Database.Models;
using common.Logging;
using Database;
using Database.Accessors;

namespace Kitchen.Controllers
{
    public class RecipesController : Controller
    {
        //
        // GET: /Recipes/

        public ActionResult Index(int id=0)
        {
            var reader = RecipeAccessor.Instance;
            var readed = reader.SelectById(id);
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
        public ActionResult Create(FormCollection data)
        {
            try
            {
                var toSubmit = new BaseRecipe {Name = data["Name"], Description = data["Description"]};
                RecipeAccessor.Instance.Insert(toSubmit);
                return Content("Рецепт успешно сохранён в книге");//RedirectToAction("Index");
            }
            catch
            {
                return Content("Не удалось сохранить рецепт");
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
