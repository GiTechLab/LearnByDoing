using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncLab.ExceptionDemo
{
    /*
     * When an exception is thrown out of an async Task or async Task<T> method, that exception is captured and placed on the Task object. 
     * 
     * With async void methods, there is no Task object, 
     * so any exceptions thrown out of an async void method will be raised directly on the SynchronizationContext that was active when the async void method started.
     * 
     * 注册TaskScheduler.UnobservedTaskException事件，记录Task中未处理异常信息，方便分析及错误定位。
     * 
     * https://msdn.microsoft.com/magazine/jj991977
     */
    class Program
    {
        static void Main(string[] args)
        {
            if (Directory.Exists(@"C:\temp\") == false) Directory.CreateDirectory(@"C:\temp\");
            try
            {
                CallAsyncMethods();
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            Console.ReadKey();
        }

        static private async void CallAsyncMethods()
        {
            try
            {
                await Task.Delay(111);
                //Demo 1
                //Exceptions thrown from async void methods can’t be caught naturally.
                //ThrowExceptionInVoidAsyncCannotBeCaught();

                //Demo 2
                await ThrowExceptionInVoidAsyncCanBeCaught();
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }

        /// <summary>
        /// Except for Event handlers, avoid 'Async-Void' method, to use async Task method over async void for most cases.
        /// 
        /// Exceptions thrown from async void methods can’t be caught naturally.
        /// 
        /// Async methods returning void don’t provide an easy way to notify the calling code that they’ve completed.
        /// Async void methods will notify their SynchronizationContext when they start and finish, but a custom SynchronizationContext is a complex solution for regular application code.
        /// 
        /// These exceptions can be observed using AppDomain.UnhandledException or a similar catch-all event for GUI/ASP.NET applications, 
        /// but using those events for regular exception handling is a recipe for unmaintainability.
        /// 
        /// Async void methods are difficult to test.
        /// The MSTest asynchronous testing support only works for async methods returning Task or Task<T>. 
        /// </summary>
        static async void ThrowExceptionInVoidAsyncCannotBeCaught()
        {
            //For async void method, we should try...catch the exception inside the function block.

            await Task.Delay(1000);
            throw new System.Exception("This is an exception in Async-Void Method.");
        }

        /// <summary>
        /// Exception is captured and placed on the Task object.
        /// </summary>
        /// <returns></returns>
        static async Task ThrowExceptionInVoidAsyncCanBeCaught()
        {
            await Task.Delay(1000);
            throw new System.Exception("This is an exception in Async-Task Method.");
        }
    }
}
