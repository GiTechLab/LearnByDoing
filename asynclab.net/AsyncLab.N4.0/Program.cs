using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncLab.N4
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowMeAsync();

            //http://www.nuget.org/packages/Microsoft.Bcl.Async
            //http://blog.csdn.net/qiujuer/article/details/38511821
            //Nuget: Microsoft.Bcl.Async
            Console.WriteLine(@"Demo to use async\await feature in .NET 4.0");
            Console.WriteLine("See, the main process is not blocked by the async method ShowMeAsync..");
            Console.WriteLine("Main Process Ends.");
            Console.ReadKey();
        }

        /// <summary>
        /// See, the main process is not blocked by the async method
        /// </summary>
        private static async void ShowMeAsync()
        {
            Console.WriteLine(await Task.Factory.StartNew(() => {
                System.Threading.Thread.Sleep(3000);
                return "[Show me in Async Way..], I am after the main process message.";
            }));
        }
    }
}
