/*
 * Created by SharpDevelop.
 * User: bizbe
 * Date: 2016/11/9
 * Time: 0:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Messaging;

namespace LearnMSMQManager
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello MSMQ!");
			
			// TODO: Implement Functionality Here
			
			//In fact, application does NOT have the Administrative privilege to create a message queue in most cases.
			//Usually, queues are created by installation programs.
			using(var queue = MessageQueue.Create(""))
			{
			
			}
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}