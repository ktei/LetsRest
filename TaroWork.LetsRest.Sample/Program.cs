using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaroWork.LetsRest.Sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var task = Rest.For("http://jsonplaceholder.typicode.com/posts/1")
                .Get()
                .String();
            task.Wait();
            var result = task.Result;
        }
    }
}
