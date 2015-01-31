using System;
using Database.Ingredients;
using NUnit.Framework;

namespace UnitTests.Tests
{
    [TestFixture]
    public class IngredientsJsonTest : BaseTest
    {
         [Test]
         public void SerializeTest()
         {
             var expected = new RecipieIngridients();
             expected.Components.Add(new Component(10, new ProductType(){DefaultMeasurement = MeasureType.Item,Name = "Мука"}, MeasureType.SoupSpoon ));
             string recipesJsonStr = expected.SerialiseToJsonString();
             Console.Out.WriteLine("recipesJsonStr = {0}", recipesJsonStr);
             var taken = new RecipieIngridients(recipesJsonStr);
             Assert.True(Compare(expected,taken));
         }
        protected bool Compare(RecipieIngridients one, RecipieIngridients two)
        {
            return one.Components.Count == two.Components.Count;
        }
    }
}