using System;
//Ввести сумму денег (целое число копеек до рубля включительно)
//и вывести эту сумму словами. 
//Например, если вводится число 23,
//надо вывести «двадцать три копейки».

class Program
{
    static void Main()
    {
        Console.Write("Введите сумму в копейках (0-99): ");
        int amount = int.Parse(Console.ReadLine());

        if (amount < 0 || amount > 99)
        {
            Console.WriteLine("Некорректная сумма. Введите число от 0 до 99.");
            Console.ReadLine(); 
            return;
        }

        string[] units = { "", "одна", "две", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять" };
        string[] teens = { "десять", "одиннадцать", "двенадцать", "тринадцать", "четырнадцать", "пятнадцать", "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать" };
        string[] tens = { "", "десять", "двадцать", "тридцать", "сорок", "пятьдесят", "шестьдесят", "семьдесят", "восемьдесят", "девяносто" };
        string[] endings = { "копеек", "копейка", "копейки", "копейки", "копейки", "копеек", "копеек", "копеек", "копеек", "копеек" };

        string result = "";

        if (amount >= 10 && amount < 20)
        {
            result = teens[amount - 10] + " " + endings[0];
        }
        else
        {
            int unit = amount % 10;
            int ten = amount / 10;

            if (ten > 0)
                result = tens[ten] + " ";

            if (unit > 0)
                result += units[unit] + " ";

            result += endings[unit];
        }

        Console.WriteLine(result.Trim());
        Console.ReadLine(); 
    }
}