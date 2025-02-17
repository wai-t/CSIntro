namespace PerformanceTest
{
    public class LinkedList : IDataInsert, IDataFind, IDataRemove
    {
        public LinkedList<long> Data { get; } = new();
        public void InsertData(long[] testdata)
        {
            var logger = new ProgressWriter("[LinkedList] Inserting", testdata.Length);
            logger.Start();
            foreach (var d in testdata)
            {
                logger.WriteProgress(d);
                Data.AddLast(d);
                //Data.AddFirst(d);
            }
            logger.Stop();
        }

        public void FindData(long[] testdata)
        {
            var logger = new ProgressWriter("[LinkedList] Finding", testdata.Length);
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
            var logger = new ProgressWriter("[LinkedList] Removing", testdata.Length);
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
