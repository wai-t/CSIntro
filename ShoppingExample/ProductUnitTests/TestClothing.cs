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
        cloth = new WomenClothing("Pijamas", "long sleeves", Price.Pounds(12.5));
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
        Assert.That(cloth.Price.Currency,Is.EqualTo("GBP"));
    }
}
