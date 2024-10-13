using System;
class main
{
    static void Main(string[] args)
    {
        // Пример использования класса ComplexNumber
        ComplexNumber z1 = new ComplexNumber(2, 5);
        ComplexNumber z2 = new ComplexNumber(4, -7);

        Console.WriteLine($"Комплексное число 1: {z1}");
        Console.WriteLine($"Комплексное число 2: {z2}");

        Console.WriteLine($"\nСложение: {z1 + z2}");
        Console.WriteLine($"Умножение: {z1 * z2}");
        Console.WriteLine($"Деление: {z1 / z2}");
        Console.WriteLine($"Возведение в степень 2: {z1.Pow(2)}");
        Console.WriteLine($"Корень квадратный: {z1.Sqrt()}");
        Console.WriteLine($"Модуль числа 1: {z1.Modulus()}");
        Console.WriteLine($"Угол числа 1: {z1.Angle()} радиан");

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}

class ComplexNumber
{
    public double Real {get;set;}
    public double Imaginary {get;set;}

    public ComplexNumber(double real, double imaginary)
    {
        Real=real;
        Imaginary=imaginary;
    }

    // Сложение
    public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
    {
        return new ComplexNumber(a.Real+b.Real, a.Imaginary+b.Imaginary);
    }

    // Умножение
    public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
    {
        double real=a.Real*b.Real-a.Imaginary*b.Imaginary;
        double imaginary=a.Real*b.Imaginary+a.Imaginary*b.Real;
        return new ComplexNumber(real, imaginary);
    }

    // Деление
    public static ComplexNumber operator /(ComplexNumber a, ComplexNumber b)
    {
        double denom=b.Real*b.Real+b.Imaginary*b.Imaginary;
        double real=(a.Real*b.Real+a.Imaginary*b.Imaginary)/denom;
        double imaginary=(a.Imaginary*b.Real-a.Real*b.Imaginary)/denom;
        return new ComplexNumber(real, imaginary);
    }

    // Возведение в степень
    public ComplexNumber Pow(int power)
    {
        ComplexNumber result=new ComplexNumber(1, 0);
        for (int i=0; i<power; i++)
        {
            result*=this;
        }
        return result;
    }

    // Извлечение квадратного корня
    public ComplexNumber Sqrt()
    {
        double modulus=Modulus();
        double angle=Angle()/2;
        return new ComplexNumber(
            Math.Sqrt(modulus)*Math.Cos(angle),
            Math.Sqrt(modulus)*Math.Sin(angle)
        );
    }

    // Модуль
    public double Modulus()
    {
        return Math.Sqrt(Real*Real+Imaginary*Imaginary);
    }

    // Угол комплексного числа
    public double Angle()
    {
        return Math.Atan2(Imaginary, Real);
    }

    public override string ToString()
    {
        if (Imaginary>=0)
            return $"{Real}+{Imaginary}i";
        else
            return $"{Real}-{Math.Abs(Imaginary)}i";
    }
}