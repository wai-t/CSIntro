namespace PerformanceTest
{
    public class LinkedList : IDataInsert, IDataFind, IDataRemove
    {
        // N.B. We are using the LinkedList<> generic collection here, so we chose
        // LinkedList as the name of this wrapping class to make it easier to remember
        // which collection we are dealing with.
        public System.Collections.Generic.LinkedList<long> Data { get; } = new();
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
