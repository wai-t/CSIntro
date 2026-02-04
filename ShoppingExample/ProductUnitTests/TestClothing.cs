using ProductsLib;
using ProductsLib.Voucher;
using ProductsLib.Clothing;

namespace ProductUnitTests;

public class TestClothing
{

    private Clothing cloth;
    [SetUp]

    public void Setup()
    {
        cloth = new WomenClothing("Pijamas", "long sleeves", Price.Pounds(12.5), "Leather", "Winter", true, "Zara", ClothingCategory.Casual,
            "Spain", ClothingSize.Small);
    }

    [Test]
    public void ClothingName()
    {
        Assert.That(cloth.Name, Is.EqualTo("Pijamas"));

    }
    [Test]
    public void ClothingPrice()
    {
        Assert.That(cloth.Price.Amount, Is.EqualTo(12.5).Within(0.01));
        Assert.That(cloth.Price.Currency, Is.EqualTo("GBP"));
    }
    [Test]
    public void IsHandWashonly()
    {
        Assert.IsTrue(cloth.HandWashOnly);
    }

    [Test]
    public void CheckSize()
    {
        Assert.That(cloth.Size, Is.EqualTo(ClothingSize.Small));
    }
    [Test]
    public void CheckSeason()
    {
        Assert.AreEqual("Winter", cloth.Season);
            }
}
