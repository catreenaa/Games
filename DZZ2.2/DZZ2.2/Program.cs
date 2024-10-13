using System;
using System.Numerics;
using System.Diagnostics;

class Program
{
    // Рекурсивный метод для вычисления факториала
    static BigInteger FactorialRecursive(BigInteger n)
    {
        if (n<=1)
            return 1;
        else
            return n*FactorialRecursive(n-1);
    }

    // Итеративный метод для вычисления факториала
    static BigInteger FactorialIterative(BigInteger n)
    {
        BigInteger result=1;
        for (BigInteger i=2; i<=n; i++)
            result*=i;
        return result;
    }

    // Рекурсивный метод для вычисления чисел Фибоначчи
    static BigInteger FibonacciRecursive(BigInteger n)
    {
        if (n<=1)
            return n;
        else
            return FibonacciRecursive(n-1)+FibonacciRecursive(n-2);
    }

    // Итеративный метод для вычисления чисел Фибоначчи
    static BigInteger FibonacciIterative(BigInteger n)
    {
        if (n<=1)
            return n;

        BigInteger prev=0, curr=1;
        for (BigInteger i=2; i<=n; i++)
        {
            BigInteger next=prev+curr;
            prev=curr;
            curr=next;
        }
        return curr;
    }

    static void ComparePerformance()
    {
        Stopwatch stopwatch=new Stopwatch();
        int limit=100; // Задаем максимальный номер для вычислений

        // Сравнение факториала
        Console.WriteLine("Сравнение производительности для вычисления факториала:");
        for (int i=1; i<=limit; i++)
        {
            stopwatch.Restart();
            FactorialIterative(i);
            stopwatch.Stop();
            long iterativeTime = stopwatch.ElapsedTicks;

            stopwatch.Restart();
            FactorialRecursive(i);
            stopwatch.Stop();
            long recursiveTime = stopwatch.ElapsedTicks;

            Console.WriteLine($"Факториал {i}: Итеративный {iterativeTime} тактов, Рекурсивный {recursiveTime} тактов");

            if (recursiveTime>iterativeTime*10) // если рекурсивный метод значительно медленнее
            {
                Console.WriteLine($"Рекурсивный метод заметно медленнее итеративного на факториале {i}.\n");
                break;
            }
        }

        // Сравнение чисел Фибоначчи
        Console.WriteLine("Сравнение производительности для вычисления чисел Фибоначчи:");
        for (int i=1; i<=limit; i++)
        {
            stopwatch.Restart();
            FibonacciIterative(i);
            stopwatch.Stop();
            long iterativeTime = stopwatch.ElapsedTicks;

            stopwatch.Restart();
            FibonacciRecursive(i);
            stopwatch.Stop();
            long recursiveTime = stopwatch.ElapsedTicks;

            Console.WriteLine($"Фибоначчи {i}: Итеративный {iterativeTime} тактов, Рекурсивный {recursiveTime} тактов");

            if (recursiveTime>iterativeTime*10) // если рекурсивный метод значительно медленнее
            {
                Console.WriteLine($"Рекурсивный метод заметно медленнее итеративного на числе Фибоначчи {i}.\n");
                break;
            }
        }
    }

    static void Main()
    {
        ComparePerformance();

        Console.WriteLine("Нажмите любую клавишу для выхода...");
        Console.ReadLine();
    }
}