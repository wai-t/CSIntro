namespace PerformanceTest
{
    public class HashSet : IDataInsert, IDataFind, IDataRemove
    {
        public HashSet<long> Data { get; } = new();
        public void InsertData(long[] testdata)
        {
            var logger = new ProgressWriter("[HashSet] Inserting", testdata.Length);
            logger.Start();
            foreach (var d in testdata)
            {
                logger.WriteProgress(d);
                Data.Add(d);
            }
            logger.Stop();
        }

        public void FindData(long[] testdata)
        {
            var logger = new ProgressWriter("[HashSet] Finding", testdata.Length);
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
            var logger = new ProgressWriter("[HashSet] Removing", testdata.Length);
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
