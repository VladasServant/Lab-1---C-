using System;
using System.Threading;

namespace ThreadDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            (new Program()).Start();
        }

        void Start()
        {
            (new Thread(() => Calcuator(1))).Start();
            (new Thread(() => Calcuator(2))).Start();
            (new Thread(() => Calcuator(3))).Start();

            Thread thread1 = new Thread(() => Calcuator(4));
            thread1.Start();

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
