using System;
class MazeGame
{
    const int Width=20; // Ширина лабиринта
    const int Height=10; // Высота лабиринта
    const char Wall='#';
    const char Path=' ';
    const char Player='@';
    const char Exit='E';
    const char Hidden='?';
    static char[,] maze;
    static char[,] visibleMaze;
    static int playerX, playerY;
    static int exitX, exitY;
    static Random random=new Random();
    static void Main()
    {
        GenerateMaze();
        InitializePlayer();
        PlayGame();
    }
    static void GenerateMaze()
    {
        maze=new char[Height, Width];
        visibleMaze=new char[Height, Width];

        // Инициализация лабиринта
        for (int y=0;y<Height;y++)
        {
            for (int x=0;x<Width;x++)
            {
                maze[y,x]=(random.Next(0,3)==0) ? Wall :Path;
                visibleMaze[y,x]=Hidden;
            }
        }

        // Создание пути для игрока и выхода
        playerX=random.Next(1,Width-1);
        playerY=random.Next(1,Height-1);
        maze[playerY,playerX]=Path;

        exitX=random.Next(1, Width - 1);
        exitY=random.Next(1, Height - 1);
        maze[exitY, exitX]=Exit;
    }

    static void InitializePlayer()
    {
        visibleMaze[playerY,playerX]=Player;
    }

    static void PlayGame()
    {
        while (true)
        {
            Console.Clear();
            DrawMaze();

            Console.WriteLine("Управление: W (вверх), A (влево), S (вниз), D (вправо)");
            char input=Console.ReadKey().KeyChar;

            int newX=playerX,newY=playerY;

            switch (input)
            {
                case 'w': newY--; break;
                case 'a': newX--; break;
                case 's': newY++; break;
                case 'd': newX++; break;
                default: continue;
            }

            if (IsValidMove(newX, newY))
            {
                visibleMaze[playerY,playerX]=maze[playerY,playerX]; // Открываем текущую ячейку
                playerX=newX;
                playerY=newY;
                visibleMaze[playerY,playerX]=Player;

                if (playerX==exitX&&playerY==exitY)
                {
                    Console.Clear();
                    DrawMaze();
                    Console.WriteLine("Поздравляем! Вы нашли выход!");
                    break;
                }
            }
        }
    }

    static bool IsValidMove(int x,int y)
    {
        return x>=0&&x<Width&&y>=0&&y<Height&&maze[y, x]!=Wall;
    }

    static void DrawMaze()
    {
        for (int y=0; y<Height; y++)
        {
            for (int x=0; x<Width; x++)
            {
                Console.Write(visibleMaze[y, x]);
            }
            Console.WriteLine();
        }
    }
}
