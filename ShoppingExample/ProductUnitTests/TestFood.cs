using ProductsLib;
using ProductsLib.Food;
using ProductsLib.Interfaces;

namespace ProductUnitTests;

public class TestFood
{
    private Food food;
    private Food notExpiredFood;
    private Food expiredFood;
    private Food bread;
    


    [SetUp]
    public void Setup()
    {
        notExpiredFood = new ReadyMeal(
               "Meat",
               "Steak",
               Price.Pounds(6),
               true,
               DietType.ContainMeats,
               DateTime.Now.AddDays(5)

           );

      

        expiredFood = new ReadyMeal(
               "Fish",
               "Salmon",
               Price.Pounds(7),
               true,
               DietType.ContainMeats,
               DateTime.Now.AddDays(-1)
    
               );
        food = new ReadyMeal(
            "Noddels",
            "noddels",
             Price.Pounds(1),
            false,
            DietType.Vegeterain
            
         );

        bread = new ReadyMeal(
            "Bread",
            "bread",
            Price.Pounds(1),
            false,
            DietType.Vegan
            );

    }


    public void NotExpiredFood_ShouldNotBeExpired()
    {
        Assert.IsFalse(notExpiredFood.IsExpired);
        Assert.That(notExpiredFood.ExpiryDate, Is.GreaterThan(DateTime.Now));
    }

    [Test]
    public void ExpiredFood_ShouldBeExpired()
    {
        Assert.IsTrue(expiredFood.IsExpired);
        Assert.That(expiredFood.ExpiryDate, Is.LessThan(DateTime.Now));
    }

    [Test]
    public void PriceChecked()
    {
        Assert.That(notExpiredFood.Price.Amount, Is.EqualTo(6));
        Assert.That(notExpiredFood.Price.Currency, Is.EqualTo("GBP"));
    }

    [Test]

    public void IsVegeterian()
    {

        Assert.That(food.DietType, Is.EqualTo(DietType.Vegeterain));

    }
    [Test]
    public void IsNotGlutenFree()
    {

        Assert.IsFalse(food.IsGlutenFree);
    }

}

