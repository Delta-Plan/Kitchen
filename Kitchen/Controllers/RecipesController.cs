using System.Web.Mvc;
using Database.Ingredients;
using Database.Models;
using Kitchen.Models;
using Database.Accessors;

namespace Kitchen.Controllers
{
    public class RecipesController : Controller
    {
        //
        // GET: /Recipes/

        public ActionResult Index(int id=0)
        {
            if (id==0)
            {
                id = 2;//S.Rozhin todo for normal
            }
            var reader = RecipeAccessor.Instance;
            var readed = GetFakeRecipeForDebug();//reader.SelectById(id);
            return View(readed);
        }

        private SimpleRecipeViewModel GetFakeRecipeForDebug()
        {
            return new SimpleRecipeViewModel
                {
                    Name = "Сэндвич с сливочным сыром и лососем",
                    Description =
                        "Кофе в кемексе получается нежным и лишённым горечи, мягким и с яркой индивидуальностью.",
                    Ingridients = new[]
                        {
                                    new IngridientViewModel
                                        {
                                            Ammount = "2",
                                            MeasureName = MeasureType.TeaSpoon.ToString(),
                                                    //Description = "обычный тип продукта",
                                            Name = "Солъ"
                                        },
                                     new IngridientViewModel
                                        {
                                            Ammount = "1",
                                            MeasureName = MeasureType.AtTaste.ToString(),
                                                    //Description = "не обычный тип продукта",
                                            Name = "Перец"
                                        }
                                   
                                }
                };
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
                var ingrName = data["IngridientName"];
                var ingrAmm = data["IngridientAmmount"];
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
