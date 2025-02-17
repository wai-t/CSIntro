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
            for (var i=0; i<size; i++)
            {
                yield return rand.NextInt64(size*1_000_000L);
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
            LinkedList data = new();
            //List data = new();
            //HashSet data = new();

            data.InsertData(testdata);

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
