using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncLab
{
    //async的作用是异步执行，await的作用是等待执行结果（会卡住异步方法中await以下的代码，但不会卡死主线程）。

    /*
     * For client applications, such as Windows Store, Windows desktop and Windows Phone apps, the primary benefit of async is responsiveness. 
     * These types of apps use async chiefly to keep the UI responsive. 
     * For server applications, the primary benefit of async is SCALABILITY. 
     * The key to the scalability of Node.js is its inherently asynchronous nature; 
     * Open Web Interface for .NET (OWIN) was designed from the ground up to be asynchronous; and ASP.NET can also be asynchronous. 
     * 
     * Note that with synchronous handlers, the SAME thread is used for the lifetime of the request; 
     * with asynchronous handlers, in contrast, DIFFERENT threads may be assigned to the same request (at different times).
     * 
     * (Thread Pool + Async: Asynchronous code allows your application to make optimum use of the thread pool. )
     * Asynchronous code can scale further than blocking threads because it uses much less memory; 
     * every thread pool thread on a modern OS has a 1MB stack, plus an unpageable kernel stack. 
     * That doesn’t sound like a lot until you start getting a whole lot of threads on your server. 
     * In contrast, the memory overhead for an asynchronous operation is much smaller. 
     * So, a request with an asynchronous operation has much less memory pressure than a request with a blocked thread. 
     * Asynchronous code allows you to use more of your memory for other things (caching, for example).
     * 
     * Async: It’s NOT just for UI apps!
     */

    //http://www.cnblogs.com/yeagen/archive/2013/09/22/3334059.html
    //http://www.infoq.com/cn/news/2011/10/Async-Cost //Cost on Async
    //https://msdn.microsoft.com/en-us/magazine/hh456402.aspx  //Cost Detail on Async
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
            ShowMeAsync2();
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
                System.Threading.Thread.Sleep(5000);
                return "[Show me in Async Way..], I am after the main process message. In fact, I am in another thread.";
            }));
        }

        private static async void ShowMeAsync2()
        {
            Console.WriteLine(await Task.Factory.StartNew(() => {
                System.Threading.Thread.Sleep(3000);
                return "[Show me in Async Way 2..], I am after the main process message. In fact, I am in another thread.";
            }));
        }

        static async Task DoWork(string taskName)
        {
            Console.WriteLine("Hello, {0}.", taskName);
            for (var i = 0; i < 3; i++)
            {                
                Console.WriteLine("Working on Task {0} of {1}", i, taskName);
                //File.AppendAllText(@"C:\temp\" + taskName + ".txt", string.Format("Working on Task {0} of {1}" + System.Environment.NewLine, i, taskName), Encoding.UTF8);

                var fileLocation = @"C:\temp\" + taskName + ".txt";
                byte[] content = (new UnicodeEncoding()).GetBytes(string.Format("Working on Task {0} of {1} {2}", i, taskName, DateTime.Now.ToLongTimeString()) + System.Environment.NewLine);
                using (var stream = File.Open(fileLocation, FileMode.OpenOrCreate))
                {
                    stream.Seek(0, SeekOrigin.End);
                    await stream.WriteAsync(content, 0, content.Length);
                }
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
