using System;

class main
{
    static void Main(string[] args)
    {
        Console.Write("Введите число n: ");
        int n=int.Parse(Console.ReadLine());
        int steps=CountStepsToOne(n);
        Console.WriteLine($"Число шагов для достижения 1: {steps}");
        Console.WriteLine("Нажмите любую клавишу для выхода...");
        Console.ReadKey();
    }

    static int CountStepsToOne(int n)
    {
        int count=0;
        while (n!=1)
        {
            if (n%2==0)
            {
                n/=2;
            }
            else
            {
                n=3*n+1;
            }
            count++;
        }
        return count;
    }
}