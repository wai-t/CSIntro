namespace PerformanceTest
{
    public class SortedDictionary : IDataInsert, IDataFind, IDataRemove
    {
        // N.B. We are using the SortedDictionary<> generic collection here, so we chose
        // SortedDictionary as the name of this wrapping class to make it easier to remember
        // which collection we are dealing with.
        public System.Collections.Generic.SortedDictionary<long, string> Data { get; } = new();
        public void InsertData(long[] testdata)
        {
            var logger = new ProgressWriter("[SortedDictionary] Inserting", testdata.Length);
            logger.Start();
            foreach (var d in testdata)
            {
                logger.WriteProgress(d);
                Data.Add(d, "v"+d.ToString());
                //Data.Insert(0, d);
            }
            logger.Stop();
        }

        public void FindData(long[] testdata)
        {
            var logger = new ProgressWriter("[SortedDictionary] Finding", testdata.Length);
            logger.Start();
            foreach (var d in testdata)
            {
                logger.WriteProgress(d);
                var c = Data.TryGetValue(d, out string? v);
            }
            logger.Stop();
        }

        public void RemoveData(long[] testdata)
        {
            var logger = new ProgressWriter("[SortedDictionary] Removing", testdata.Length);
            logger.Start();
            foreach (var d in testdata)
            {
                logger.WriteProgress(d);
                Data.Remove(d);
            }
            logger.Stop();
        }
    }
}
