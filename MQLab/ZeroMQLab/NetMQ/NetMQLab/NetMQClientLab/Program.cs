using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NetMQ;
using NetMQ.Sockets;

namespace NetMQClientLab
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new RequestSocket())
            {
                /*
                 With Connect, ZeroMQ knows that there's going to be at least a single peer and thus it can create a single queue immediately. 
                 This applies to all socket types except ROUTER, where queues are only created after the peer we connect to has acknowledge our connection.
                 */
                context.Connect("tcp://127.0.0.1:5555");
                for (var i = 0; i < 10; i++)
                {
                    //context.TrySendFrame("My Message. " + i);
                    context.SendFrame(("My Message. " + i));
                    var messageFromServer = "";
                    context.TryReceiveFrameString(out messageFromServer);
                    Console.WriteLine(messageFromServer);
                }
            }
            Console.WriteLine("Test Completed.");
            Console.ReadKey();
        }
    }
}
