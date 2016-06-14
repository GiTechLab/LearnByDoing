using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AttributeLab.AOP;

namespace AttributeLab
{
    //http://www.cnblogs.com/dudu/articles/4449.html
    //https://msdn.microsoft.com/en-us/library/aa288454(v=vs.71).aspx

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start Attribute Lab...");

            Console.WriteLine("Completed");
            Console.ReadKey();
        }

        [CareException]
        static void TestException()
        {
            throw new Exception("This is a Test Exception for attribute CareException.");
        }
    }
}
