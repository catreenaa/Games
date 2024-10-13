using System;
class main
{
    static bool IsPrime(int number)
    {
        if (number<2) return false;
        for (int i=2; i<=Math.Sqrt(number); i++)
        {
            if (number%i==0)
            {
                return false;
            }
        }
        return true;
    }
    static void Main()
    {
        Console.Write("Введите число: ");
        int limit=int.Parse(Console.ReadLine());

        Console.WriteLine("Простые числа, не превосходящие заданное:");
        for (int i=2; i<=limit; i++)
        {
            if (IsPrime(i))
            {
                Console.Write(i+" ");
            }
        }
        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadLine();
    }
}