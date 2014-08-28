using System.Diagnostics;
using System.Linq;
using Database.Accessors;
using NUnit.Framework;
using UnitTests.Tests;

namespace UnitTests.Tests
{
    [TestFixture]
    public class RecipeAccessorTest : BaseTest
    {
         [Test]
         public void GetByIdTest()
         {
             var recipe = RecipeAccessor.Instance.SelectById(2);
             Assert.NotNull(recipe);
         }

         [Test]
         public void GetQueryableTest()//S.Rozhin todo normal test
         {
             var allRecipes = RecipeAccessor.Instance.SelectAll();
             Assert.NotNull(allRecipes);
             var one = allRecipes.FirstOrDefault(rec=>rec.Id==2);
             var two = RecipeAccessor.Instance.SelectById(2);
             Assert.AreEqual(one.Id,two.Id);
         }
    }
}