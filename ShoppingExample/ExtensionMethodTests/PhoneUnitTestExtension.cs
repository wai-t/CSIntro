using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ProductsLib;
using ProductsLib.Electronics;

namespace ExtensionMethodTests
{
    public class PhoneUnitTestExtension
    {

        [Test]
        public void TestSelect_OsTpe()
        {
            var phones = new List<Phone>()
            {
                new Phone ("X135", "Mobile",Price.Pounds(250) , "Samding", MobileOsType.Android, 4,120, true , 400),
                new Phone ("KN12", "Mobile",Price.Pounds(150) , "Nokia", MobileOsType.Android, 2,160, false , 300),
                new Phone ("VV6", "Mobile",Price.Pounds(800) , "Apple", MobileOsType.IOS, 4,160, true , 360),
            };

            var osType = phones.
                Where(m => m.MobileOsType == MobileOsType.IOS)
                .Select(m => m.Name).ToList();

            Assert.AreEqual("VV6", osType[0]);
        }


        public void TestSun_ProductWotrh()
        {
            var phones = new List<Phone>()
            {
                new Phone ("GH66", "Mobile",Price.Pounds(200) , "huawei", MobileOsType.Android, 4,120, true , 400),
                new Phone ("KN12", "Mobile",Price.Pounds(150) , "Nokia", MobileOsType.Android, 2,160, false , 300),
                new Phone ("VV6", "Mobile",Price.Pounds(150) , "Apple", MobileOsType.IOS, 4,160, true , 360),
            };


            var total = phones.Sum(m => m.Price.Amount);
            Assert.AreEqual(500, total);
        }


        public void TestAccnding_MostExpenxive()
        {
            var phones = new List<Phone>()
            {
                new Phone ("GH66", "Mobile",Price.Pounds(400) , "Samsung", MobileOsType.Android, 4,120, true , 400),
                new Phone ("KN12", "Mobile",Price.Pounds(350) , "Apple", MobileOsType.IOS, 2,160, false , 300),
                new Phone ("VV6", "Mobile",Price.Pounds(700) , "Apple", MobileOsType.IOS, 4,160, true , 360),
            };


            var expensive = phones.OrderByDescending(m => m.Price.Amount).First();
            Assert.AreEqual("VV6", expensive.Name);
        }

        public void TestAggrigate_TotalPrice()
        {
            var phones = new List<Phone>()
            {
                new Phone ("GH66", "Mobile",Price.Pounds(350) , "Samsung", MobileOsType.Android, 4,120, true , 400),
                new Phone ("KN12", "Mobile",Price.Pounds(350) , "Apple", MobileOsType.IOS, 2,160, false , 300),
                new Phone ("VV6", "Mobile",Price.Pounds(700) , "Apple", MobileOsType.IOS, 4,160, true , 360),
                new Phone ("KK9", "Mobile",Price.Pounds(300) , "Samsung", MobileOsType.Android, 4,120, true , 400),
                new Phone ("090ou", "Mobile",Price.Pounds(300) , "Apple", MobileOsType.IOS, 2,160, false , 300),
                new Phone ("123DED", "Mobile",Price.Pounds(700) , "Apple", MobileOsType.IOS, 4,160, true , 360)
            };


            var total = phones.Aggregate(0.0, (sum, next) => sum + next.Price.Amount);

                

        }
        
    }
}
