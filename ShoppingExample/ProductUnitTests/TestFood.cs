using NuGet.Frameworks;
using ProductsLib;
using ProductsLib.Food;
using ProductsLib.Interfaces;

namespace ProductUnitTests;

public class TestFood
{

    private Food notExpiredFood;
    private Food expiredFood;
    private Food food;

    [SetUp]
    public void Setup()
    {
        notExpiredFood = new ReadyMeal(
               "Pasta",
               "Pasta",
               Price.Pounds(2),
               true,
               DietType.Vegan,
               300,
               10,
               0
           );

        expiredFood = new ReadyMeal(
                "Salmon",
                "Fish",
                Price.Pounds(7),
                true,
                DietType.ContainMeats,
                200,
                30,
                0,
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
        Assert.That(notExpiredFood.Price.Amount, Is.EqualTo(2));
        Assert.That(notExpiredFood.Price.Currency, Is.EqualTo("GBP"));
    }

    [Test]

    public void IsVegeterian()
    {
        var vegetarianMeal = new ReadyMeal("Noddles", "Noddless", Price.Pounds(2), true, DietType.Vegeterain, 420, 10, 40);

        Assert.That(vegetarianMeal.DietType, Is.EqualTo(DietType.Vegeterain));

    }

    [Test]
    public void IsNotGlutenFree()
    {
        var glutenFreeMeal = new ReadyMeal("Rice", "rice", Price.Pounds(2.5), true, DietType.Vegeterain, 420, 10, 10);
        Assert.IsTrue(glutenFreeMeal.IsGlutenFree);
    }


    public void FatChecker()
    {
        var fatInMeal = new ReadyMeal("Rice", "rice", Price.Pounds(2.5), true, DietType.Vegeterain, 420, 10, 10);
        Assert.That(fatInMeal.SugarPerUnit.Equals(10));


    }



}

