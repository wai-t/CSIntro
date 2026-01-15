using ProductsLib;
using ProductsLib.Clothing;
using ProductsLib.Food;
using System.Xml.Schema;

namespace ExtensionMethodTests
{


    // HomeWork 
    public class MealTestList
    {
        public List<Food> Meals { get; } = new List<Food>
    {
        new ReadyMeal( "pasta",
            "pasta",
            Price.Pounds(1),
            false,
            DietType.Vegan,
            DateTime.Now.AddDays(5)

            ),
        new ReadyMeal(
            "Chicken Pie",
            "Chicken Pie",
            Price.Pounds(5),
            false,
            DietType.ContainMeats,
            DateTime.Now.AddDays(3)
            ),
        new ReadyMeal(

            "Fish Finger",
            "Fish Finger",
            Price.Pounds(3),
            true,
            DietType.ContainMeats,
            DateTime.Now.AddDays(7)


            ),
         new ReadyMeal(

            "Bread",
            "Bread",
            Price.Pounds(2),
            true,
            DietType.Vegeterain,
            DateTime.Now.AddDays(7)
            ),

          new ReadyMeal(

            "cake",
            "cake",
            Price.Pounds(3),
            false,
            DietType.Vegeterain,
            DateTime.Now.AddDays(7)
            )



    };




    }

    //
    // Example of a class that contains Extension Methods
    public static class ExtensionMethods
    {

        // Example extension method
        public static string MakeUpperCaseAndReverse(this string input)
        {
            return string.Join("", input.ToUpper().Reverse());
        }
        // Second extension method
        public static int AddOne(this int input)
        {
            return input + 1;
        }
        // Generic extension method
        public static string UpperCaseStringRepresentation<T>(this T input)
        {
            return input.ToString().ToUpper();
        }


        public static bool IsExpired(this Food food)
        {
            return food.ExpiryDate < DateTime.Now;
        }


        public static IEnumerable<Food> CheapMeals(this IEnumerable<Food> foods,double maxPrice)
        {
            return foods.Where(f => f.Price.Amount <= maxPrice);
        }

    }




    public class ExtensionMethodTests
    {
        [SetUp]
        public void Setup()
        {
        }



        [Test]
        public void TestLinqIEnumerable()
        {
            var meals = new MealTestList();

            //var TestAggregatw = meals.Meals.Aggregate(());

            bool TestAll = meals.Meals.All(m => m.IsGlutenFree);

            bool TestAny = meals.Meals.Any(m => m.DietType == DietType.ContainMeats);

            var TestGroupBy = meals.Meals.GroupBy(m => m.DietType);



            var Testindexed = meals.Meals.Select((m, i) => new { Index = i, m.Name });


            var repeated = Enumerable.Repeat("pasta", 3);

            var TestAppend = meals.Meals.Append(
                new ReadyMeal
                ("tuna",
                "tuna",
                Price.Pounds(8),
                true,
                DietType.ContainMeats,
                DateTime.Now.AddDays(3)
                                               )
                ).ToList();



            // AsEnumerable()
            // cast

            var TestChunk = meals.Meals.Chunk(3);

            foreach (var chunk in TestChunk)
            {
                Console.WriteLine("chunk");
                foreach (var meal in chunk)
                {
                    Console.WriteLine($" {meal.Name}");
                }


                var TestAvrage = meals.Meals.Average(m => m.Price.Amount);
                var TestMin = meals.Meals.Min(m => m.Price.Amount);
                var TestMax = meals.Meals.Max(m => m.Name.Length);
                var TestMinBy = meals.Meals.MinBy(m => m.Name.Length);
                //bool TestContain = meals.Meals.Contains(pasta);

                //var reversedMeals = meals.Meals.Reverse().ToList();


                var TestSelect = meals.Meals.Select(m => m.Name).ToList();

                var TestWhere = meals.Meals.Where(m => m.DietType == DietType.Vegan).ToList();

                // Food extension
                bool expired = meals.Meals.First().IsExpired();

                // Collection extension
                var cheapMeals = meals.Meals.CheapMeals(3).ToList();

            }
        }



        [Test]
        public void TestLinqIEnumerableTest()
        {
            var meals = new MealTestList();

           
            bool allGlutenFree = meals.Meals.All(m => m.IsGlutenFree);
            Assert.IsFalse(allGlutenFree);

           
            bool anyContainMeat = meals.Meals.Any(m => m.DietType == DietType.ContainMeats);
            Assert.IsTrue(anyContainMeat); 

            
            var grouped = meals.Meals.GroupBy(m => m.DietType);
            Assert.AreEqual(3, grouped.Count()); 

            
            var mealNames = meals.Meals.Select(m => m.Name).ToList();
            CollectionAssert.Contains(mealNames, "pasta");
            CollectionAssert.Contains(mealNames, "cake");

           
            var veganMeals = meals.Meals.Where(m => m.DietType == DietType.Vegan).ToList();
            Assert.IsTrue(veganMeals.All(m => m.DietType == DietType.Vegan)); 
            Assert.AreEqual(2, veganMeals.Count); 

           
            bool firstMealExpired = meals.Meals.First().IsExpired();
            Assert.IsFalse(firstMealExpired); 

            
            var cheapMeals = meals.Meals.CheapMeals(3).ToList();
            Assert.IsTrue(cheapMeals.All(m => m.Price.Amount <= 3)); 
            Assert.AreEqual(4, cheapMeals.Count); 

          

          
            var updatedMeals = meals.Meals.Append(
                new ReadyMeal("tuna", "tuna", Price.Pounds(8), true, DietType.ContainMeats, DateTime.Now.AddDays(3))
            ).ToList();
            Assert.AreEqual(meals.Meals.Count + 1, updatedMeals.Count); // Count increased by 1
            Assert.AreEqual("tuna", updatedMeals.Last().Name); // Last meal is tuna

            

            var chunks = meals.Meals.Chunk(3).ToList();
            Assert.AreEqual(2, chunks.Count); // With 5 meals, chunk size 3 ? 2 chunks
            Assert.AreEqual(3, chunks[0].Length); // First chunk has 3 meals
            Assert.AreEqual(2, chunks[1].Length); // Second chunk has 2 meals
        }






        [Test]
        public void Test1()
        {
            string myString = "abcdef";

            var output = myString.MakeUpperCaseAndReverse();
            var netVersion = myString.ToUpper();

            double x = 9;
            var tx = x.UpperCaseStringRepresentation<double>();

            DateTime dt = DateTime.Now;
            var dtt = dt.UpperCaseStringRepresentation();

            Assert.Pass();
        }

        [Test]
        public void TestClothingBuilder()
        {
            var shirt = new MansShirt("Shirt", "Woolly Shirt", Price.Pounds(20.0));
            var woollyShirt = shirt.MakeWool();

        }



    }

    // This is not the way the classic "Builder" pattern is implemented, but just
    // an example of using extension methods to implement a set of "Builder" methods
    public static class ClothingBuilder
    {
        public static Clothing MakeWool(this Clothing item)
        {
            item.Material = "Wool";
            return item;
        }
    }
}