using System;
using System.Collections.Generic;

// Управление стрелочками
class Game2048
{
    const int Size=4;
    static int[,] board=new int[Size, Size];
    static Random random=new Random();
    static int score=0;

    static void Main()
    {
        Console.WriteLine("Игра 2048. Используйте стрелки для управления. Нажмите ESC для выхода.");
        SpawnTile();
        SpawnTile();
        while (true)
        {
            Console.Clear();
            PrintBoard();
            Console.WriteLine($"Очки: {score}");

            var key=Console.ReadKey(true).Key;
            if (key==ConsoleKey.Escape) break;

            bool moved = false;
            switch (key)
            {
                case ConsoleKey.UpArrow: moved=MoveUp(); break;
                case ConsoleKey.DownArrow: moved=MoveDown(); break;
                case ConsoleKey.LeftArrow: moved=MoveLeft(); break;
                case ConsoleKey.RightArrow: moved=MoveRight(); break;
            }

            if (moved)
            {
                SpawnTile();
                if (GameOver())
                {
                    Console.Clear();
                    PrintBoard();
                    Console.WriteLine($"Игра окончена! Ваш счет: {score}");
                    break;
                }
            }
        }
    }

    static void SpawnTile()
    {
        var emptyCells=GetEmptyCells();
        if (emptyCells.Count>0)
        {
            var (x, y)=emptyCells[random.Next(emptyCells.Count)];
            board[x, y]=random.Next(10)==0 ? 4 : 2;
        }
    }

    static List<(int,int)> GetEmptyCells()
    {
        var emptyCells=new List<(int, int)>();
        for (int i=0; i<Size; i++)
            for (int j=0; j<Size; j++)
                if (board[i, j]==0)
                    emptyCells.Add((i,j));
        return emptyCells;
    }

    static bool MoveLeft()
    {
        bool moved=false;
        for (int i=0; i<Size; i++)
        {
            int[] row = new int[Size];
            for (int j=0; j<Size; j++) row[j] = board[i,j];
            if (ProcessLine(row))
            {
                moved=true;
                for (int j=0; j<Size; j++) board[i,j] = row[j];
            }
        }
        return moved;
    }

    static bool MoveRight()
    {
        bool moved=false;
        for (int i=0; i<Size; i++)
        {
            int[] row=new int[Size];
            for (int j=0; j<Size; j++) row[j] = board[i,Size-1-j];
            if (ProcessLine(row))
            {
                moved=true;
                for (int j=0; j<Size; j++) board[i, Size-1 -j] = row[j];
            }
        }
        return moved;
    }

    static bool MoveUp()
    {
        bool moved = false;
        for (int j=0; j<Size; j++)
        {
            int[] col=new int[Size];
            for (int i=0; i < Size; i++) col[i] = board[i, j];
            if (ProcessLine(col))
            {
                moved=true;
                for (int i=0; i<Size; i++) board[i,j] = col[i];
            }
        }
        return moved;
    }

    static bool MoveDown()
    {
        bool moved=false;
        for (int j=0; j<Size; j++)
        {
            int[] col=new int[Size];
            for (int i=0; i<Size; i++) col[i] = board[Size-1 -i, j];
            if (ProcessLine(col))
            {
                moved = true;
                for (int i=0; i<Size; i++) board[Size-1-i, j] = col[i];
            }
        }
        return moved;
    }

    static bool ProcessLine(int[] line)
    {
        bool moved=false;
        int[] merged=new int[Size];
        int position=0;

        for (int i=0; i<Size; i++)
        {
            if (line[i]==0) continue;

            if (position>0&&line[i]==merged[position-1])
            {
                merged[position-1]*=2;
                score+=merged[position - 1];
                line[i]=0;
                moved=true;
            }
            else
            {
                merged[position++]=line[i];
                if (position-1!=i) moved=true;
            }
        }

        for (int i=0; i<Size; i++) line[i] = merged[i];
        return moved;
    }

    static void PrintBoard()
    {
        Console.WriteLine(new string('-', Size * 6)); // Верхняя граница игрового поля
        for (int i=0; i<Size; i++)
        {
            for (int j=0; j<Size; j++)
            {
                Console.BackgroundColor=board[i, j] == 0 ? ConsoleColor.DarkGray : ConsoleColor.Black; // Фон для пустых и заполненных ячеек
                Console.ForegroundColor=board[i, j] == 0 ? ConsoleColor.Gray : ConsoleColor.White;    // Цвет текста
                Console.Write($"{"",4}{(board[i, j] == 0 ? " " : board[i, j].ToString()),-4}");         // Печать числа или пробела
            }
            Console.ResetColor(); // Сброс цвета
            Console.WriteLine();
        }
        Console.WriteLine(new string('-', Size * 6)); // Нижняя граница игрового поля
    }



    static bool GameOver()
    {
        if (GetEmptyCells().Count>0) return false;

        for (int i = 0; i<Size; i++)
        {
            for (int j=0; j<Size-1; j++)
            {
                if (board[i, j] == board[i, j+1] || board[j, i] == board[j+1, i])
                    return false;
            }
        }

        return true;
    }
}
