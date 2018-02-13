using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TobeConsolePractise
{
    class ThreadTest
    {
        public static int run()
        {
            Thread concreteThread = new Thread(new ThreadStart(new ConcreteObject().ConcreteMethod));
            //start the thread
            Console.WriteLine("Concrete method started!!!\r\nWill run for 10 milli-seconds with 1 milli-second intervals\r\n");
            concreteThread.Start();
            //spin for a while to initialize
            while (!concreteThread.IsAlive) { Console.WriteLine("\r\nInitialization of thread i.e. bringing it to life.\r\n"); } //hardly occurs
            //put amin thread to sleep fro 2 milli-seconds to allow concreteThread to do some work
            Thread.Sleep(10);
            // Request that concreteThread be stopped
            concreteThread.Abort();
            // Wait until concreteThread finishes ie block calling thread until thread terminates
            concreteThread.Join();
            Console.WriteLine();
            Console.WriteLine("concreteMethod has finished. concreteThread is aborted/dead");
            try
            {
                Console.WriteLine("Trying to restart the thread...");
                concreteThread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("(In the catch structure) It was unsuccessful.\r\nError: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Finally");
                Console.ReadKey();
            }
            return 0;
        }
    }

    class ConcreteObject
    {
        public void ConcreteMethod()
        {
            while (true)
            {
                Console.WriteLine("Concrete method is running");
                Thread.Sleep(1);
            }
        }
    }


    public class Worker
    {
        // This method is called when the thread is started.
        public void DoWork()
        {
            while (!_shouldStop)
            {
                Console.WriteLine("Worker thread: working...");
            }
            Console.WriteLine("Worker thread: terminating gracefully.");
        }
        public void RequestStop()
        {
            _shouldStop = true;
        }
        // Keyword volatile is used as a hint to the compiler that this data
        // member is accessed by multiple threads.
        private volatile bool _shouldStop;
    }

    public class WorkerThreadExample
    {
        public static void Run()
        {
            // Create the worker thread object. This does not start the thread.
            Worker workerObject = new Worker();
            Thread workerThread = new Thread(workerObject.DoWork);

            // Start the worker thread.
            workerThread.Start();
            Console.WriteLine("Main thread: starting worker thread...");

            // Loop until the worker thread activates.
            while (!workerThread.IsAlive) ;

            // Put the main thread to sleep for 1 millisecond to
            // allow the worker thread to do some work.
            Thread.Sleep(1);

            // Request that the worker thread stop itself.
            workerObject.RequestStop();

            // Use the Thread.Join method to block the current thread 
            // until the object's thread terminates.
            workerThread.Join();
            Console.WriteLine("Main thread: worker thread has terminated.");
        }
        // Sample output:
        // Main thread: starting worker thread...
        // Worker thread: working...
        // Worker thread: working...
        // Worker thread: working...
        // Worker thread: working...
        // Worker thread: working...
        // Worker thread: working...
        // Worker thread: terminating gracefully.
        // Main thread: worker thread has terminated.
    }
}
