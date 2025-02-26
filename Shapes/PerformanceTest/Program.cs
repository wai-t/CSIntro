namespace PerformanceTest
{
    public interface IDataInsert
    {
        void InsertData(long[] testdata);
    }

    public interface IDataFind
    {
        void FindData(long[] testdata);
    }

    public interface IDataRemove
    {
        void RemoveData(long[] testdata);
    }

    public class ProgressWriter(string message, int size)
    {
        readonly int repeat = size / 100;
        int count;
        int pct;
        DateTime started;
        DateTime stopped;

        public void Start()
        {
            count = 0;
            pct = 0;
            started = DateTime.Now;
            Console.WriteLine($"{message} started at {started}");
        }
        public void WriteProgress(long d)
        {
            count += 1;
            if (count%repeat == 0)
            {
                Console.Write($"{message}: {++pct}%, {d}");
                Console.SetCursorPosition(0, Console.CursorTop);
            }
        }

        public void Stop()
        {
            Console.WriteLine();
            stopped = DateTime.Now;
            var elapsed = stopped - started;
            Console.WriteLine($"{message} stopped at {stopped}, elapsed time = {elapsed}");
        }
    }
    internal class Program
    {
        static IEnumerable<long> MakeTestData(long size)
        {
            var rand = new Random();

            // This version creates the memory for the whole dataset first before
            // returning it. Disadvantage is that the caller may only be interested
            // in the first few items, or may have a way of processing the items one
            // at a time so that a large amount of memory doesn't need to be used
            //long[] arr = new long[size];
            //for (var i = 0; i < size; i++)
            //{
            //    arr[i] =  rand.NextInt64(size * 1_000_000L);
            //}
            //return arr;

            for (var i = 0; i < size; i++)
            {
                yield return rand.NextInt64(size * 1_000_000L);
            }
        }

        /**
         * Change the data to a random order, so that the search is not in the same order
         * that the insert was done
         */
        public static void Shuffle(long[] testdata)
        {
            var rng = new Random();
            int n = testdata.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                (testdata[n], testdata[k]) = (testdata[k], testdata[n]);
            }
        }

        static void Main(string[] args)
        {
            const int datasize = 100_000;
            var testdata = MakeTestData(datasize).ToArray();

            // Uncomment to choose the required type of collection
            // System.Collections.Generic
            //LinkedList data = new();
            //List data = new();
            //HashSet data = new();
            //SortedSet data = new();
            //SortedList data = new();
            SortedDictionary data = new();

            data.InsertData(testdata);

            var collection = data.Data;

            // Example of calling an "aggregate" function (many items in -> one number out)
            //var total = collection.Keys.Sum();

            // Example of filtering a Dictionary, then selecting only the string value part of the item,
            // then reverse ordering by the string value, and finally outputing to an array.
            //var middle_numbers = collection.Where(kvp => kvp.Key > 500 && kvp.Key < 5_000_000_000)
            //                        .Select(kvp => kvp.Value)
            //                        .OrderByDescending(value => value)
            //                        .ToArray();

            // The same example as before, but using LINQ, and this time outputting to a List.
            //var middle_numbers = (from kvp in collection
            //                     where kvp.Key > 500 && kvp.Key < 5_000_000_000
            //                     orderby kvp.Key descending
            //                     select kvp.Value).ToList()
            //                     ;

            Console.WriteLine();
            Console.WriteLine($"data contains {data.Data.Count} items");

            Shuffle(testdata);

            data.FindData(testdata);

            Console.WriteLine();

            data.RemoveData(testdata);

            Console.WriteLine();
            Console.WriteLine($"data contains {data.Data.Count} items");
        }
    }
}
