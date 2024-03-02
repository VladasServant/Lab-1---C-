using System;
using System.Threading;

namespace ThreadDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            (new Program()).Start(6);
        }

        void Start(int processCount)
        {
            Thread[] threads = new Thread[processCount];

            for (int i = 0; i < processCount; i++)
            {
                int id = i + 1;
                threads[i] = new Thread(() => Calcuator(id));
                threads[i].Start();
            }

            (new Thread(Stoper)).Start();
        }

        void Calcuator(int id)
        {

            int step = 1;
            long sum = 0;
            long elements = 0;

            while (!canStop)
            {
                sum += elements * step;
                elements++;
                // Console.WriteLine("Thread: " + id + " Sum: " + sum + " Elements: " + elements);
            }
            Console.WriteLine("Thread: " + id + " Sum: " + sum + " Elements: " + elements);
        }

        private bool canStop = false;

        public bool CanStop { get => canStop; }

        public void Stoper()
        {
            Thread.Sleep(5 * 1000);
            canStop = true;
        }
    }
}
