namespace PerformanceTest
{
    public class SortedSet : IDataInsert, IDataFind, IDataRemove
    {
        // N.B. We are using the SortedSet<> generic collection here, so we chose
        // SortedSet as the name of this wrapping class to make it easier to remember
        // which collection we are dealing with.
        public System.Collections.Generic.SortedSet<long> Data { get; } = new();
        public void InsertData(long[] testdata)
        {
            var logger = new ProgressWriter("[SortedSet] Inserting", testdata.Length);
            logger.Start();
            foreach (var d in testdata)
            {
                logger.WriteProgress(d);
                Data.Add(d);
                //Data.Insert(0, d);
            }
            logger.Stop();
        }

        public void FindData(long[] testdata)
        {
            var logger = new ProgressWriter("[SortedSet] Finding", testdata.Length);
            logger.Start();
            foreach (var d in testdata)
            {
                logger.WriteProgress(d);
                var c = Data.Contains(d);
            }
            logger.Stop();
        }

        public void RemoveData(long[] testdata)
        {
            var logger = new ProgressWriter("[SortedSet] Removing", testdata.Length);
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
