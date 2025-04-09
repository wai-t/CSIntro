using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DesignPatterns
{
    public interface IDataSource
    {
        Task<string> GetDataAsync();
    }

    internal class DataSource : IDataSource
    {
        private readonly HttpClient httpClient = new();
        const string url = "https://www.google.com/";
        public static int CallCount = 0; // for testing purposes
        public async Task<string> GetDataAsync()
        {
            CallCount++;
            return await httpClient.GetStringAsync(url);
        }
    }

    internal class CachingDataSource() : IDataSource
    {
        // use an async style SemaphoreSlim to allow async methods to be called in a thread-safe manner
        // otherwise can use lock
        private readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
        private string? cachedData = null;
        private readonly IDataSource dataSource = new DataSource(); // use a real data source

        public async Task<string> GetDataAsync()
        {
            await semaphore.WaitAsync(); // if the semaphore is in use, task will wait until it is free
            try {
                cachedData ??= await dataSource.GetDataAsync(); // ??= only calls GetDataS
                return cachedData;
            }
            finally
            {
                // always called before returning from the method
                semaphore.Release(); 
            }
        }
    }

    internal class LazyCacheDataSource : IDataSource
    {
        private Lazy<string> cachedData = new Lazy<string>(() =>
        {
            // Lazy<T> will only call the function once, and will cache the result
            var dataSource = new DataSource(); // use a real data source
            return dataSource.GetDataAsync().Result; // blocking call to get the data
        }, isThreadSafe: true);

        public async Task<string> GetDataAsync()
        {
            return cachedData.Value; 
        }

        private static int count = 10;
        public void Counter()
        {
            lock(this)
            {
                count++; // don't know that the CPU might switch to another thread in the middle of this operation
            }
        }
    }

    public class Tester
    {
        [Fact]
        public async Task TestCaching()
        {
            var cachingDataSource = new CachingDataSource();
            // Call the GetDataAsync method multiple times
            var task1 = await cachingDataSource.GetDataAsync();
            var task2 = await cachingDataSource.GetDataAsync();
            var task3 = await cachingDataSource.GetDataAsync();
            // Assert that all tasks return the same result
            Assert.Equal(task1, task2);
            Assert.Equal(task1, task3);
            Assert.Equal(1, DataSource.CallCount);
        }

        [Fact]
        public async Task TestLazyCaching()
        {
            var cachingDataSource = new LazyCacheDataSource();
            // Call the GetDataAsync method multiple times
            var task1 = await cachingDataSource.GetDataAsync();
            var task2 = await cachingDataSource.GetDataAsync();
            var task3 = await cachingDataSource.GetDataAsync();
            // Assert that all tasks return the same result
            Assert.Equal(task1, task2);
            Assert.Equal(task1, task3);
            Assert.Equal(1, DataSource.CallCount);
        }
    }
}
