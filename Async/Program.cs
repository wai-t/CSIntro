using Async;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xunit;

//Assert.True(ThreadPool.SetMinThreads(1, 1));
//Assert.True(ThreadPool.SetMaxThreads(2, 1));

AsyncDemo.RunAsync(args).Wait();

//ThreadDemo.RunThread(args);


namespace Async
{
    class AsyncDemo()
    {
        // async qualifier is required to use await keyword
        public static async Task RunAsync(string[] args)
        {
            Console.WriteLine("Start Async Tasks");

            List<Task> tasks = [];
            for (int  taskNo = 0;  taskNo < 5;  taskNo++)
            {
                await FetchDataAsync(taskNo);
                // Without await, the tasks will run in parallel
                //tasks.Add(FetchDataAsync(taskNo));
            }

            // To wait for all tasks to complete, use Task.WhenAll
            //await Task.WhenAll(tasks);

            Console.WriteLine($"All tasks completed");
        }

        // async qualifier is required to use await keyword
        static async Task FetchDataAsync(int taskNo)
        {
            Console.WriteLine($"Thread for task {taskNo} is {Thread.CurrentThread.ManagedThreadId}");
            var rand = new Random();
            for (var i = 0; i < 100_000; i++)
            {
                if (i % 10_000 == 0)
                {
                    Console.WriteLine($"Task {taskNo}: waiting");
                    // using await causes the method to pause here and
                    // give another task a chance to run
                    await Task.Delay(rand.Next(10));
                }
                if (i%1_000 == 0)
                {
                    Console.WriteLine($"Task {taskNo}: i={i}");
                }
            }
            Console.WriteLine($"Task {taskNo} completed");
        }

    }

    class ThreadDemo()
    {
        public static void RunThread(string[] args)
        {
            Console.WriteLine("Start Threads");

            var threads = Enumerable.Range(0, 5)
                .Select(threadNo => new Thread(() => FetchData(threadNo)))
                .ToList();

            foreach (var thread in threads)
            {
                thread.Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }
            Console.WriteLine($"Threads Completed");

        }

        static void FetchData(int threadNo)
        {

            Console.WriteLine($"Thread for thead {threadNo} is {Thread.CurrentThread.ManagedThreadId}");
            var rand = new Random();
            for (var i = 0; i < 100_000; i++)
            {
                if (i % 10_000 == 0)
                {
                    Console.WriteLine($"Thread {threadNo}: waiting");
                    Thread.Sleep(rand.Next(10));
                }
                if (i % 1_000 == 0)
                {
                    Console.WriteLine($"Thread {threadNo}: i={i}");
                }
            }
            Console.WriteLine( $"Thread {threadNo} completed");
        }

    }
}
