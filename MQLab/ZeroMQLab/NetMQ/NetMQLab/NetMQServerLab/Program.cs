using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//http://netmq.readthedocs.io/en/latest/introduction/
using NetMQ;
using NetMQ.Sockets;

namespace NetMQServerLab
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ResponseSocket())
            {
                /*
                 When should I use bind and when connect?
                 As a general rule 
                 use Bind from the most stable points in your architecture, and 
                 use Connect from dynamic components with volatile endpoints. 
                  
                 With Bind, you allow peers to connect to you, thus you don't know how many peers there will be in the future and you cannot create the queues in advance. 
                 Instead, queues are created as individual peers connect to the bound socket.
                 */
                context.Bind("tcp://127.0.0.1:5555");
                var flag = true;
                while (true)
                {
                    var message = "";
                    flag = context.TryReceiveFrameString(out message);
                    if (!flag)
                    {
                        message = "Failed to receive message: " + message;
                    }
                    Console.WriteLine(message);
                    System.Threading.Thread.Sleep(100);
                    flag = flag && context.TrySendFrame("Server send back.");
                    if (!flag)
                    {
                        Console.WriteLine("Failed to send message from the server");
                    }
                }
            }

            Console.WriteLine("Test Completed.");
            Console.ReadKey();
        }
    }
}
