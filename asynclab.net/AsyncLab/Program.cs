using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncLab
{
    //async的作用是异步执行，await的作用是等待执行结果（会卡住异步方法中await以下的代码，但不会卡死主线程）。

    //http://www.cnblogs.com/yeagen/archive/2013/09/22/3334059.html
    //http://www.cnblogs.com/x-xk/archive/2013/06/05/3118005.html
    //http://www.dozer.cc/2012/03/async-and-await-in-web-application.html
    //https://msdn.microsoft.com/magazine/jj991977 Async Best Practice
    //https://msdn.microsoft.com/magazine/dn802603.aspx  Async in ASP.NET
    //https://msdn.microsoft.com/zh-cn/magazine/mt149362?author=Stephen%20Cleary

    class Program
    {
        static void Main(string[] args)
        {
            if (Directory.Exists(@"C:\temp\") == false) Directory.CreateDirectory(@"C:\temp\");

            Task t1 = Example1();

            //For showing the thread output
            //t1.Wait();
            //System.Threading.Thread.Sleep(2000);

            Example2();

            //For showing the thread output
            //Option 1: result in all
            //t1.Wait();
            //Option 2: result in depends on the sleep time
            //System.Threading.Thread.Sleep(2000);//Adjust the sleep time can affect the output range...

            ShowMeAsync();
            Console.WriteLine("See, the main process is not blocked by the async method ShowMeAsync..");
            Console.WriteLine("Main Process Ends.");
            //注：是否注释掉ReadKey对显示结果有一定的影响，因为不注释的话，所有线程结果都会显示出来(因为主线程一直没有结束)
            //这个例子说明在Windows Form 类型的程序中，通常UI 主线程不会马上结束，所以这个控制台程序发生的例子不容易在UI程序中遇到
            Console.ReadKey();
        }

        /// <summary>
        /// See, the main process is not blocked by the async method
        /// </summary>
        private static async void ShowMeAsync()
        {
            Console.WriteLine(await Task.Factory.StartNew(() => {
                System.Threading.Thread.Sleep(3000);
                return "[Show me in Async Way..], I am after the main process message. In fact, I am in another thread.";
            }));
        }

        static async Task DoWork(string taskName)
        {
            Console.WriteLine("Hello, {0}.", taskName);
            for (var i = 0; i < 3; i++)
            {                
                await Task.Delay(1000);
                File.AppendAllText(@"C:\temp\" + taskName + ".txt", string.Format("Working on Task {0} of {1}" + System.Environment.NewLine, i, taskName), Encoding.UTF8);
                Console.WriteLine("Working on Task {0} of {1}", i, taskName);
            }
        }

        static async Task Example1()
        {
            var taskName = "Example1";
            await DoWork(taskName);
            Console.WriteLine("{0} Async Run End", taskName);
        }

        static async void Example2()
        {
            var taskName = "Example2";
            await DoWork(taskName);
            Console.WriteLine("{0} Async Run End", taskName);
        }
    }
}
