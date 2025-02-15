namespace Collections
{
    static public class MyExtensions
    {
        public static void MyFunction(this IEnumerable<int> list) {
            // mystuff;
            }
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            var intList = new List<int>() { 1, 2, 3 };
            intList.MyFunction();
            var x = intList[2];
            intList.Add(4);
            Console.WriteLine("list");
            WriteCollection(intList);

            Console.WriteLine("*2");
            WriteCollection(intList.
                Take(2).
                Select(x => 2*x).
                Where(x => x > 1).
                OrderBy(x=>-x)
            );

            var query = intList.
                Select(x => 2 * x).
                Where(x => x > 1).
                OrderBy(x => -x);

            foreach(var y in query)
            {
                Console.WriteLine($"y: {y}");
            }

            var sum = query.Sum();
            Console.WriteLine($"sum: {sum}");

            var intSet = new HashSet<int>() { 1, 2, 3 };
            intSet.MyFunction();
            Console.WriteLine("set");
            WriteCollection(intSet);

            var intStringDictionary = new Dictionary<int, string>() { { 1, "One" }, { 2, "Two" }, { 3, "Three" } };
            Console.WriteLine("keys");
            WriteCollection(intStringDictionary.Keys);
            Console.WriteLine("values");
            WriteCollection(intStringDictionary.Values);


        }

        static void WriteCollection<T>(IEnumerable<T> list)
        {
            foreach (var  x in list)
            {
                Console.WriteLine($"{x}");
            }
        }
    }
}
