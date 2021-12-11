using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lab_22
{
    class Program
    {
        static int n;
        static int m;
        static int [,]t;
      public  static void Method1()
        {
            Console.WriteLine("Введите n");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите m");
            m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Массив:");
            t = new int[n, m];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    t[i, j] = random.Next(0, 100);
                    Console.WriteLine("{0} ", t[i, j]);
                }
                Console.WriteLine();
            }

        }
        public static void Method2(Task task)
        {
            int s = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    s += t[i, j];

                }
            }
            Console.WriteLine("Сумма чисел массива: {0}",s);

        }
        public static void Method3(Task task)
        {
            int max = t[0,0];
            foreach (int a in t)
            {
                if (a > max)
                    max = a;
            }
            Console.WriteLine("Максимальное число в массиве: {0}", max);

        }
        static void Main(string[] args)
        {
            Task met1 = new Task(Method1);
            Task met2 = met1.ContinueWith(Method3);
            Task met3 = met1.ContinueWith(Method2);
            met1.Start();
            met1.Wait();

            Console.ReadKey();
        }
    }
}
