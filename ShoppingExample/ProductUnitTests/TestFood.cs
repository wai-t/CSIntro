using ProductsLib;
using ProductsLib.Food;
using ProductsLib.Interfaces;

namespace ProductUnitTests;

public class TestFood
{
    private Food food;
    private Food notExpiredFood;
    private Food expiredFood;


    [SetUp]
    public void Setup()
    {
        notExpiredFood = new ReadyMeal(
               "Meat",
               "Steak",
               Price.Pounds(6),
               DateTime.Now.AddDays(5)
           );

        expiredFood = new ReadyMeal(
               "Fish",
               "Salmon",
               Price.Pounds(7),
               DateTime.Now.AddDays(-1)
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
}

