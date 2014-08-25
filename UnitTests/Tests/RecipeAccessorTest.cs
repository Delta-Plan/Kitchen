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
    }
}