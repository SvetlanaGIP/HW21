using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HW21
{
    class Program
    {
        //Имеется пустой участок земли (двумерный массив) и план сада,
        //который необходимо реализовать.
        //Эту задачу выполняют два садовника,
        //которые не хотят встречаться друг с другом.
        //Первый садовник начинает работу с верхнего левого угла сада и
        //перемещается слева направо, сделав ряд, он спускается вниз.
        //Второй садовник начинает работу с нижнего правого угла сада и
        //перемещается снизу вверх, сделав ряд, он перемещается влево.
        //Если садовник видит, что участок сада уже выполнен другим садовником,
        //он идет дальше. Садовники должны работать параллельно.
        //Создать многопоточное приложение,
        //моделирующее работу садовников.

        const int m = 4;
        const int l = 5;
        static int[,] path = { { 3, 2, 6, 5, 2 }, { 0, 1, 2, 6, 10 }, { 0, 2, 10, 5, 5 }, { 0, 1, 2, 6, 10 } };
        static void Main(string[] args)
        {
            ThreadStart threadStart = new ThreadStart(Gardner1);
            Thread thread = new Thread(threadStart);
            thread.Start();

            Gardner2();

            for (int i = 0; i < m; i++)
            {
                for (int k = 0; k < l; k++)
                {
                    Console.Write($"{path[i, k]} ");
                }
                Console.Write("\n");
            }
            Console.ReadKey();
        }

        static void Gardner1()
        {
            for (int i = 0; i < m; i++)
            {
                for (int k = 0; k < l; k++)
                {
                    if (path[i, k] >= 0)
                    {
                        int delay = path[i, k];
                        path[i, k] = -1; // обработал первый садовник
                        Thread.Sleep(delay);
                    }
                }
            }
        }


        static void Gardner2()
        {
            for (int k = l - 1; k >= 0; k--)
            {
                for (int i = m - 1; i >= 0; i--)
                {
                    if (path[i, k] >= 0)
                    {
                        int delay = path[i, k];
                        path[i, k] = -2; // обработал второй садовник
                        Thread.Sleep(delay);
                    }
                }
            }
        }
    }
}