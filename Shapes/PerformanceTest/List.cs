namespace PerformanceTest
{
    public class List : IDataInsert, IDataFind, IDataRemove
    {
        public List<long> Data { get; } = new();
        public void InsertData(long[] testdata)
        {
            var logger = new ProgressWriter("[List] Inserting", testdata.Length);
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
            var logger = new ProgressWriter("[List] Finding", testdata.Length);
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
            var logger = new ProgressWriter("[List] Removing", testdata.Length);
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
