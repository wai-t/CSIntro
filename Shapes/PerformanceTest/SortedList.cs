namespace PerformanceTest
{
    public class SortedList : IDataInsert, IDataFind, IDataRemove
    {
        // N.B. We are using the SortedList<> generic collection here, so we chose
        // SortedList as the name of this wrapping class to make it easier to remember
        // which collection we are dealing with.
        public System.Collections.Generic.SortedList<long, string> Data { get; } = new();
        public void InsertData(long[] testdata)
        {
            var logger = new ProgressWriter("[SortedList] Inserting", testdata.Length);
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
            var logger = new ProgressWriter("[SortedList] Finding", testdata.Length);
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
            var logger = new ProgressWriter("[SortedList] Removing", testdata.Length);
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
