using System;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Введите число: ");
            string input=Console.ReadLine();
            int result=ParseInput(input);
            Console.WriteLine($"Вы ввели число: {result}");
        }
        catch(OverflowException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch(FormatException ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.WriteLine("Нажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
    public static int ParseInput(string input)
    {
        if (int.TryParse(input,out int number))
        {
            return number;
        }
        else
        {
            if (long.TryParse(input,out long longNumber))
            {
                if (longNumber>int.MaxValue)
                    throw new OverflowException("Введено слишком большое число");
                if (longNumber<int.MinValue)
                    throw new OverflowException("Введено слишком маленькое число");
            }
            throw new FormatException("Введено не число");
        }
    }
}