using ProductsLib;
using ProductsLib.Clothing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodTests
{
    public class ClothingTestExtension
    {
        private Clothing clothing;
        private Clothing clothingforall;

        [SetUp]
        public void SetUp()
        {
            clothingforall = new WomenClothing("Pijamas", "long sleeves", Price.Pounds(12.5), "Cotton", "Winter", false, "Zara", ClothingCategory.HomeWear, "Spain", ClothingSize.Small);
        }


        [Test]
        public void TestAny_SizeSmal()
        {
            var clothing = new List<Clothing>()
            { new WomenClothing ("Pijamas", "long sleeves", Price.Pounds(12.5), "Cotton", "Winter", false, "Zara", ClothingCategory.HomeWear, "Spain", ClothingSize.Small),
              new WomenClothing ("Coat", "long sleeves", Price.Pounds(192.5), "Leather", "Winter", true, "Dior", ClothingCategory.Casual, "Italy", ClothingSize.Medium),
              new WomenClothing ("Skirt", "Short", Price.Pounds(17.5), "Wool", "Winter", true, "H&M", ClothingCategory.Casual, "Spain", ClothingSize.Small),
            };

            var small = clothing.Any(m => m.Size == ClothingSize.Small);
            Assert.IsTrue(small);
        }


        [Test]
        public void TestMinBy_PriceCheck()
        {
            var clothing = new List<Clothing>()
            {
              new WomenClothing ("Trousers", "long", Price.Pounds(200), "Wool", "Winter", true, "Dior", ClothingCategory.Smart, "Spain", ClothingSize.Small),
              new WomenClothing ("Coat", "long sleeves", Price.Pounds(192.5), "Leather", "Winter", true, "Dior", ClothingCategory.Casual, "Italy", ClothingSize.Medium),
              new WomenClothing ("Jacket", "", Price.Pounds(165), "Wool", "Winter", true, "H&M", ClothingCategory.Casual, "Spain", ClothingSize.Small),
            };

            var cheapest = clothing.MinBy(m => m.Price.Amount);
            Assert.That(cheapest.Price.Amount, Is.EqualTo(165));


            var expensive = clothing.OrderByDescending(m => m.Price.Amount).First();
            Assert.That(expensive.Price.Amount, Is.EqualTo(200));
        }




    }       
    
}
