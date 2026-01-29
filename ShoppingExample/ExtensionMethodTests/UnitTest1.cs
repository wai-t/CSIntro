using ProductsLib;
using ProductsLib.Clothing;
using ProductsLib.Food;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionMethodTests
{
    public class MealTestList
    {
        public List<Food> Meals { get; } = new List<Food>
        {
            new ReadyMeal("pasta", "pasta", Price.Pounds(1), false, DietType.Vegan, DateTime.Now.AddDays(5)),
            new ReadyMeal("Chicken Pie", "Chicken Pie", Price.Pounds(5), false, DietType.ContainMeats, DateTime.Now.AddDays(3)),
            new ReadyMeal("Fish Finger", "Fish Finger", Price.Pounds(3), true, DietType.ContainMeats, DateTime.Now.AddDays(7)),
            new ReadyMeal("Bread", "Bread", Price.Pounds(2), true, DietType.Vegeterain, DateTime.Now.AddDays(7)),
            new ReadyMeal("cake", "cake", Price.Pounds(3), false, DietType.Vegeterain, DateTime.Now.AddDays(7)),
            new ReadyMeal("lobster", "Lobster", Price.Pounds(80), true, DietType.ContainMeats, DateTime.Now.AddDays(5))
        };
    }

    public static class ExtensionMethods
    {
        public static string MakeUpperCaseAndReverse(this string input)
        {
            return string.Join("", input.ToUpper().Reverse());
        }

        public static int AddOne(this int input)
        {
            return input + 1;
        }

        public static string UpperCaseStringRepresentation<T>(this T input)
        {
            return input.ToString().ToUpper();
        }

        public static bool IsExpired(this Food food)
        {
            return food.ExpiryDate < DateTime.Now;
        }

        public static IEnumerable<Food> CheapMeals(this IEnumerable<Food> foods, double maxPrice)
        {
            return foods.Where(f => f.Price.Amount <= maxPrice);
        }
    }

  
    public class ExtensionMethodTests
    {
        private MealTestList meals;

        [SetUp]
        public void Setup()
        {
            meals = new MealTestList();
        }

        [Test]
        public void TestAggregate_TotalPrice()
        {
            var totalPrice = meals.Meals.Aggregate(0.0, (sum, m) => sum + m.Price.Amount);
            Assert.AreEqual(94.0, totalPrice);
        }

        [Test]
        public void TestAggregate_CheapestMeal()
        {
            var cheapest = meals.Meals.Aggregate(double.MaxValue, (min, m) => m.Price.Amount < min ? m.Price.Amount : min);
            Assert.AreEqual(1.0, cheapest);
        }

        [Test]
        public void TestAggregate_CombineMealsIntoReadyMeal()
        {
            var combinedMeal = meals.Meals.Aggregate(
                (working, next) => new ReadyMeal(
                    "MultiPack",
                    "FamilyMeal",
                    Price.Pounds(working.Price.Amount + next.Price.Amount),
                    true,
                    DietType.ContainMeats)
            );

            Assert.AreEqual("MultiPack", combinedMeal.Name);
            Assert.AreEqual(94, combinedMeal.Price.Amount);
            Assert.AreEqual(DietType.ContainMeats, combinedMeal.DietType);
            Assert.IsTrue(combinedMeal.IsGlutenFree);
        }

      
        [Test]
        public void TestWhere_VeganMeals()
        {
            var veganMeals = meals.Meals.Where(m => m.DietType == DietType.Vegan).ToList();
            Assert.AreEqual(1, veganMeals.Count);
            Assert.IsTrue(veganMeals.All(m => m.DietType == DietType.Vegan));
        }

        [Test]
        public void TestAnyContainMeat()
        {
            Assert.IsTrue(meals.Meals.Any(m => m.DietType == DietType.ContainMeats));
        }

        [Test]
        public void TestAllGlutenFree()
        {
            Assert.IsFalse(meals.Meals.All(m => m.IsGlutenFree));
        }

        [Test]
        public void TestSelect_MealNames()
        {
            var names = meals.Meals.Select(m => m.Name).ToList();
            CollectionAssert.Contains(names, "pasta");
            CollectionAssert.Contains(names, "cake");
        }

        [Test]
        public void TestGroupBy_DietType()
        {
            var grouped = meals.Meals.GroupBy(m => m.DietType);
            Assert.AreEqual(3, grouped.Count());
        }

        [Test]
        public void TestOrderByPrice()
        {
            var ordered = meals.Meals.OrderBy(m => m.Price.Amount).ToList();
            Assert.AreEqual(1, ordered.First().Price.Amount);
            Assert.AreEqual(80, ordered.Last().Price.Amount);
        }

        [Test]
        public void TestAppend_NewMeal()
        {
            var updatedMeals = meals.Meals.Append(
                new ReadyMeal("tuna", "tuna", Price.Pounds(8), true, DietType.ContainMeats, DateTime.Now.AddDays(3))
            ).ToList();

            Assert.AreEqual(meals.Meals.Count + 1, updatedMeals.Count);
            Assert.AreEqual("tuna", updatedMeals.Last().Name);
        }

        [Test]
        public void TestChunk_Meals()
        {
            var chunks = meals.Meals.Chunk(3).ToList();
            Assert.AreEqual(2, chunks.Count);
            Assert.AreEqual(3, chunks[0].Length);
            Assert.AreEqual(3, chunks[1].Length);
        }

        [Test]
        public void TestMinMaxAverage()
        {
            Assert.AreEqual(80, meals.Meals.Max(m => m.Price.Amount));
            Assert.AreEqual(1, meals.Meals.Min(m => m.Price.Amount));
            Assert.AreEqual(94.0 / 6, meals.Meals.Average(m => m.Price.Amount));
        }

        // ---------------------------
        // Extension Method Tests
        // ---------------------------
        [Test]
        public void TestMakeUpperCaseAndReverse()
        {
            string input = "hello";
            var result = input.MakeUpperCaseAndReverse();
            Assert.AreEqual("OLLEH", result);
        }

        [Test]
        public void TestAddOne()
        {
            int x = 5;
            Assert.AreEqual(6, x.AddOne());
        }

        [Test]
        public void TestUpperCaseStringRepresentation()
        {
            int x = 5;
            string result = x.UpperCaseStringRepresentation();
            Assert.AreEqual("5", result);
        }

        [Test]
        public void TestIsExpired()
        {
            var expired = meals.Meals.First().IsExpired();
            Assert.IsFalse(expired);
        }

        [Test]
        public void TestCheapMealsExtension()
        {
            var cheapMeals = meals.Meals.CheapMeals(3).ToList();
            Assert.IsTrue(cheapMeals.All(m => m.Price.Amount <= 3));
            Assert.AreEqual(4, cheapMeals.Count);
        }


        [Test]
        public void TestFirst_ExpensiveMeal() 
        {
            var expensive = meals.Meals.First(m => m.Price.Amount > 50);
            Assert.AreEqual("lobster", expensive.Name.ToLower());
            Assert.AreEqual(80, expensive.Price.Amount);
        
        }

        [Test]
        public void TestSum_GluteenFreePrice()
        {
            var sum = meals.Meals.Where(m => m.IsGlutenFree).Sum(m => m.Price.Amount);
            Assert.AreEqual(85, sum);
        }

        [Test] 
        public void GroupBy_MostCommonType()
        {
            var mostCommon = meals.Meals.GroupBy(m => m.DietType).OrderByDescending(g => g.Count()).First().Key;
            Assert.AreEqual(DietType.ContainMeats, mostCommon);
        }

        [Test]
        public void ToDictionary_MealPrice() 
        {

            var dict = meals.Meals.ToDictionary(m => m.Name, m => m.Price.Amount);

            Assert.AreEqual(6, dict.Count);
            Assert.AreEqual(80, dict["lobster"]);
            Assert.AreEqual(1, dict["pasta"]);

        
        }



    }

    public static class ClothingBuilder
    {
        public static Clothing MakeWool(this Clothing item)
        {
            item.Material = "Wool";
            return item;
        }
    }
}
