using NUnit.Framework;
using ProductsLib;
using ProductsLib.Electronics;
using ProductsLib.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductUnitTests.Collections
{
    [TestFixture]
    internal class TestCollections
    {
        [Test]
        public void List()
        {
            var list = new List<int>();
           
            list.Add(1);
            list.Add(2);
            for (int i =3; i<10000; i++)
            {
                list.Add(i);
            }
            var count = list.Count;

            //
            // num => num > 5000
            // this is an anonymous function. It receives a parameter called num and return num > 5000 (which is a bool)
            var bigNumbers = list
                .Where(num => num > 5000) // Where is a Linq function. All of the Linq functions belong to IEnumerable<T>
                .ToList();

            var totalOfBigNumbers = bigNumbers.Sum(); // Sum is an aggregate function (outputs only one value)

            var howManyEvenNumbers = list
                .Where(num => num % 2 == 0)
                .Count();
        }

        public class Box<T>
        {
            public T Value { get; }

            public Box(T value)
            {
                Value = value;
            }
        }

        [Test]
        public void Generic_Box_ShouldStoreAnyType()
        {
            
            var intBox = new Box<int>(10);
            Assert.AreEqual(10, intBox.Value);

          
            var stringBox = new Box<string>("Hello");
            Assert.AreEqual("Hello", stringBox.Value);

           
            var laptop = new Laptop("Dell", "Gaming laptop", Price.Pounds(1500));
            var electronicsBox = new Box<Electronics>(laptop);

            Assert.AreEqual("Dell", electronicsBox.Value.Name);
        }




        [Test]
        public void TestElectricalsList()
        {
            var list = new List<Electronics>();

            for (var i = 0; i < 10000; i++)
            {
                var laptop = new Laptop($"Laptop_{i}", "A laptop", Price.Pounds(1000 + i / 100));
                var phone = new Phone($"Phone_{i}", "A phone", Price.Pounds(300 + i / 100), "Nokia" , MobileOsType.Android , 4,120,false,300);
                list.Add(laptop);
                list.Add(phone);
            }

            //var countPhones = list.Where(e => e is Phone).Count();
            var countPhones = list.OfType<Phone>().Count();

            var eleventhItem = list[10];

            var productNameList = list
                .Select(e => e.Name)
                .Select(f => f.Length)
                .ToList();

            //var productNameLengthList = list
            //   .Select(e =>  e.Name + " " + e.Name.Length.ToString())
            //   .ToList();

            var productNameLengthList = list
   .Select(e => new
   {
       e.Name,
       e.Name.Length
   })
   .ToList();
        }

        [Test]
        public void TestDictionaruElectricals()
        {
            var dictionary = new Dictionary<string, Electronics>();

            for (var i = 0; i < 10000; i++)
            {
                var laptopKey = $"Laptop_{i}";
                var laptop = new Laptop(laptopKey, "A laptop", Price.Pounds(1000 + i / 100));
                var phoneKey = $"Phone_{i}";
                var phone = new Phone(phoneKey, "A phone", Price.Pounds(300 + i / 100), "Nokia", MobileOsType.Android,4,120 , false , 400 );
                dictionary[laptopKey] = laptop;
                dictionary[phoneKey] = phone;
            }


            var laptop_789 = dictionary["Laptop_789"];

            
        }
        [Test]

        public void TestFood()
        {
           
            var foods = new ReadyMeal("Spagetti", "pasta", Price.Pounds(12) , false , DietType.Vegan, 450,20,10);

            var list = new List<int>();

            for (var i = 0; i <=10; i++)
            {
                list.Add(i);
            }
        }
    }
}
