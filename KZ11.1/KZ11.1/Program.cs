using System;
using System.IO;
class Program
{
    static void Main()
    {
        using (StreamWriter writer=new StreamWriter("f.txt")) //создание файла
        {   
            writer.WriteLine("x sin(x)"); //Запись заголовка
            for (double x=0;x<=1;x+=0.1) //запись значений
            {               
                writer.WriteLine($"{x:F1} {Math.Sin(x):F4}"); //форматирование строки и запись в файл
            }
        }
        Console.WriteLine("Таблица записана в файл f.txt");
        Console.ReadLine(); //Ожидание нажатия клавиши для завершения программы
    }
}