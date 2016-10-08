using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace TaroWork.LetsRest.Sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var task = Lets.Call("http://jsonplaceholder.typicode.com/posts/1")
                .Then().Get().ReceiveString();
            task.Wait();
            var result = task.Result;
        }
    }
}
