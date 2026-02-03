using ProductsLib;
using ProductsLib.Electronics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductUnitTests
{
    public class MobilePhoneTest
    {

        private Phone phones;
        private Phone iosChecked;
        private Phone isDual;
        private Phone apple;


        [SetUp]

        public void SetUp()
        {
            iosChecked = new Phone(
                "GYT54",
                "Smart Phone",
                 Price.Pounds(700),
                 "Apple",
                 MobileOsType.IOS,
                 4,
                 120,
                 false,
                 350
                 );

            isDual = new(

                "tk65",
                "Smart Phone",
                 Price.Pounds(400),
                 "Nokia",
                 MobileOsType.Android,
                 4,
                 120,
                 true,
                 350

                );


            apple = new (
                "Hp34",
                "Smart Phone",
                 Price.Pounds(470),
                 "Apple",
                 MobileOsType.IOS,
                 4,
                 120,
                 false,
                 400

                );
        }


        [Test]
       
        public void OperationSystemCheck()
        {

            Assert.That(iosChecked.MobileOsType, Is.EqualTo(MobileOsType.IOS));

        }

        [Test]
        public void IsDual()
        {

            Assert.IsTrue(isDual.DualSim);
        }

        [Test]
        public void MemoryStorage()
        {

            var phones = new Phone("GYT54",
                "Smart Phone",
                 Price.Pounds(700),
                 "Apple",
                 MobileOsType.IOS,
                 4,
                 120,
                 false,
                 350);

            Assert.That(phones.RamMemory, Is.EqualTo(4));
        }
        [Test]
        public void CheckBrand()
        {
            Assert.That(apple.Brand, Is.EqualTo("Apple"));
        }
        [Test]
        public void CheckName()
        {
            Assert.AreEqual("Hp34", apple.Name);
        }

        [Test]
        public void CheckWeight()
        {
            Assert.That(apple.PhoneWeight, Is.GreaterThan(30));
        }

    }
}
