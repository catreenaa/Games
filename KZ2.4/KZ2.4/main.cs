using System;

class main
{
    static void Main(string[] args)
    {
        Console.Write("Введите количество элементов в массиве: ");
        int n=int.Parse(Console.ReadLine());

        int[] array=new int[n];
        Console.WriteLine("Введите элементы массива:");
        for (int i=0; i < n; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("Массив до сортировки:");
        PrintArray(array);

        BubbleSort(array);

        Console.WriteLine("Массив после сортировки:");
        PrintArray(array);

        Console.WriteLine("Нажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
    static void BubbleSort(int[] array)
    {
        int n=array.Length;
        for (int i=0; i<n-1; i++)
        {
            for (int j=0; j<n-i-1; j++)
            {
                if (array[j]>array[j+1])
                {                    
                    int temp = array[j]; // Меняем элементы местами
                    array[j] = array[j+1];
                    array[j+1] = temp;
                }
            }
        }
    }
    static void PrintArray(int[] array)
    {
        foreach (int element in array)
        {
            Console.Write(element+" ");
        }
        Console.WriteLine();
    }
}