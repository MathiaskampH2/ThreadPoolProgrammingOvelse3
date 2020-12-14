using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolProgrammingOvelse3
{
    class Program
    {
        static void Main(string[] args)
        {
            // adds Task1 to the threadPool
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Thread pool Execution");
            sw.Start();
            ProcessWithThreadPoolMethod();
            sw.Stop();
            Console.WriteLine("Time consumed by ProcessWithThreadPoolMethod is : " + sw.ElapsedTicks.ToString());
            sw.Reset();
            Console.WriteLine("Thread Execution");
            sw.Start();
            ProcessWithThreadMethod();
            sw.Stop();
            Console.WriteLine("Time consumed by ProcessWithThreadMethod is : " + sw.ElapsedTicks.ToString());


            Console.Read();

        }


        static void ProcessWithThreadMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                Thread obj = new Thread(Process);
                // makes the thread run as background process
                obj.IsBackground = true;
                // makes the priority of the thread run with the highest.
                obj.Priority = ThreadPriority.Highest; 
                obj.Start();
                

            }
        }

        static void ProcessWithThreadPoolMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                
                // process has to take parameter (object callback) otherwise we can't add it to a threadPool
                ThreadPool.QueueUserWorkItem(Process);
                

            }
        }


        static void Process(object callback)
        {

        }
    
    }
}
