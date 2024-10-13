using System;
class main
{
    static void Main()
    {
        Console.Write("Введите коэффициент a: ");
        double a=double.Parse(Console.ReadLine());

        Console.Write("Введите коэффициент b: ");
        double b=double.Parse(Console.ReadLine());

        Console.Write("Введите коэффициент c: ");
        double c = double.Parse(Console.ReadLine());

        if (a==0)
        {
            // Если a==0, уравнение становится линейным
            if (b==0)
            {
                if (c==0)
                {
                    Console.WriteLine("Бесконечное количество решений");
                }
                else
                {
                    Console.WriteLine("Решений нет");
                }
            }
            else
            {
                // Линейное уравнение вида bx + c = 0
                double x=-c / b;
                Console.WriteLine($"Уравнение линейное. Единственное решение: x = {x}");
            }
        }
        else
        {
            // Стандартное решение квадратного уравнения
            double discriminant=b*b-4*a*c;

            if (discriminant > 0)
            {
                double x1 = (-b+Math.Sqrt(discriminant))/(2 * a);
                double x2 = (-b-Math.Sqrt(discriminant))/(2 * a);
                Console.WriteLine($"Два корня: x1 = {x1}, x2 = {x2}");
            }
            else if (discriminant==0)
            {
                double x=-b/(2*a);
                Console.WriteLine($"Один корень: x = {x}");
            }
            else
            {
                Console.WriteLine("Корней нет (дискриминант отрицательный).");
            }
        }

        Console.WriteLine("Нажмите любую клавишу для выхода...");
        Console.ReadLine();
    }
}