using DesignPatterns;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine.Client;
using NewBackend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    interface IComplicatedImplementation
    {
        string GetData();
    }

    internal class User(IComplicatedImplementation implementation)
    {

        public void GetDataFromBackend()
        {
            var data = implementation.GetData();
        }
    }


    internal class Proxy : IComplicatedImplementation
    {
        //private readonly string backendUrl;
        public string GetData()
        {
            //
            // connect to backendUrl
            // e.g. with a HttpClient
            // 
            // var client = new HttpClient();
            // var response = await client.GetAsync(backendUrl);
            // var data = await response.Content.ReadAsStringAsync();
            var data = "aoifjoeifjefjoi";
            return data;
        }
    }

}

namespace NewBackend { // runs on another machine

    internal class Backend
    {
        public string GetData() // this method is exposed as a http endpoint
        {
            // Simulate a complicated implementation
            return new ComplicatedImplementation().GetData();
        }
    }


    internal class ComplicatedImplementation : IComplicatedImplementation
    {
        public string GetData()
        {
            BigComplicatedComputation();
            BigComplicatedDBQuery();
            // Simulate a complicated implementation
            return "Complicated data";
        }

        private void BigComplicatedComputation()
        {
        }

        private void BigComplicatedDBQuery()
        {
        }
    }
}

namespace Main
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            // This version goes out to the network
            var proxy = new Proxy();
            var user = new User(proxy);
            user.GetDataFromBackend();

            // this version stays inside the process
            var inprocess = new ComplicatedImplementation();
            var user2 = new User(inprocess);
            user2.GetDataFromBackend();
        }
    }

    internal class Original
    {
        public virtual string GetData()
        {
            return GetDataFromBackend();
        }
        private string GetDataFromBackend()
        {
            var backend = new Backend();
            var data = backend.GetData();
            return data;
        }
    }

    // This is a caching proxy of the Original class
    internal class Cache : Original
    {
        private string? cachedData = null;
        public override string GetData()
        {
            if (cachedData == null)
            {
                cachedData = base.GetData();
            }
            return cachedData;
        }
    }
}