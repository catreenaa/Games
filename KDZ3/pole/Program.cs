using System;

class Program
{
    const int FieldSize=10;
    char[,] field=new char[FieldSize, FieldSize];
    int playerX, playerY;
    int currentLevel=0;

    string[][] levels=new string[][]
    {
        // Уровень 1
        new string[]
        {
            "##########",
            "#   O    #",
            "#   R    #",
            "#  RO    #",
            "#   T    #",
            "#    O   #",
            "#   O T  #",
            "#   R C  #",
            "#        #",
            "##########"
        },
        // Уровень 2
        new string[]
        {
            "##########",
            "#O O R  T#",
            "#     R  #",
            "# O R R T#",
            "#  T     #",
            "#  R  O  #",
            "#   R O T#",
            "#  C  R  #",
            "#  R     #",
            "##########"
        },
        // Уровень 3
        new string[]
        {
            "##########",
            "#O O   R #",
            "#  T     #",
            "#   O R  #",
            "#   RO T #",
            "# R  C   #",
            "# O O O  #",
            "#  TR R  #",
            "#        #",
            "##########"
        }
    };

    public Program()
    {
        LoadLevel(currentLevel);
    }

    void LoadLevel(int levelIndex)
    {
        var level=levels[levelIndex];
        for (int i=0; i<FieldSize; i++)
        {
            for (int j=0; j<FieldSize; j++)
            {
                field[i, j]=level[i][j];
                if (field[i, j]=='C') // Позиция игрока
                {
                    playerX=i;
                    playerY=j;
                }
            }
        }
    }

    void DrawField()
    {
        Console.Clear();
        for (int i=0; i<FieldSize; i++)
        {
            for (int j=0; j<FieldSize; j++)
            {
                switch (field[i, j])
                {
                    case '#': Console.ForegroundColor = ConsoleColor.Green; break; // Трава
                    case 'R': Console.ForegroundColor = ConsoleColor.Gray; break; // Камень
                    case 'T': Console.ForegroundColor = ConsoleColor.DarkGreen; break; // Дерево
                    case 'O': Console.ForegroundColor = ConsoleColor.Yellow; break; // Неактивированная плита
                    case 'Ⓡ': Console.ForegroundColor = ConsoleColor.Red; break; // Активированная камнем плита
                    case 'Ⓒ': Console.ForegroundColor = ConsoleColor.Cyan; break; // Активированная персонажем плита
                    case 'C': Console.ForegroundColor = ConsoleColor.Blue; break; // Персонаж
                    default: Console.ResetColor(); break;
                }
                Console.Write(field[i, j]);
            }
            Console.WriteLine();
        }
        Console.ResetColor();
    }

    void MovePlayer(int dx, int dy)
    {
        int newX=playerX + dx;
        int newY=playerY + dy;

        // Препятствия: стены и деревья
        if (field[newX, newY]=='#'||field[newX, newY]=='T')
            return;

        // Если на пути камень
        if (field[newX, newY]=='R'||field[newX, newY]=='Ⓡ')
        {
            int stoneNewX=newX+dx;
            int stoneNewY=newY+dy;

            // Камень можно сдвинуть только на пустое место или плиту
            if (field[stoneNewX, stoneNewY]==' '||field[stoneNewX, stoneNewY]=='O')
            {
                field[stoneNewX, stoneNewY]=(field[stoneNewX, stoneNewY]=='O') ? 'Ⓡ' : 'R';
                field[newX, newY]=(field[newX, newY]=='Ⓡ') ? 'O' : ' ';
            }
            else
            {
                return; // Камень не может быть сдвинут
            }
        }

        // Перемещение игрока
        if (field[newX, newY]=='O')
        {
            field[newX, newY]='Ⓒ'; // Игрок активирует плиту
        }
        else
        {
            field[newX, newY]='C';
        }

        field[playerX, playerY]=(field[playerX, playerY] == 'Ⓒ') ? 'O' : ' ';
        playerX=newX;
        playerY=newY;
    }
    bool IsGameWon()
    {
        for (int i=0; i<FieldSize; i++)
        {
            for (int j=0; j<FieldSize; j++)
            {
                if (field[i, j]=='O') // Если остались неактивированные плиты
                    return false;
            }
        }
        return true;
    }

    void NextLevel()
    {
        currentLevel++;
        if (currentLevel<levels.Length)
        {
            LoadLevel(currentLevel);
        }
        else
        {
            Console.Clear();
            Environment.Exit(0);
        }
    }

    void GameLoop()
    {
        while (true)
        {
            DrawField();

            if (IsGameWon())
            {
                Console.WriteLine("Уровень пройден! Нажмите Enter");
                Console.ReadKey();
                NextLevel();
            }

            Console.WriteLine("Управление: W/A/S/D для перемещения, Q для выхода");
            var key=Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.W: MovePlayer(-1, 0); break;
                case ConsoleKey.S: MovePlayer(1, 0); break;
                case ConsoleKey.A: MovePlayer(0, -1); break;
                case ConsoleKey.D: MovePlayer(0, 1); break;
                case ConsoleKey.Q: return;
            }
        }
    }

    static void Main()
    {
        Program game=new Program();
        game.GameLoop();
    }
}