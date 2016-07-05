using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048_Console
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.Title = "2048 Console";
            Console.CursorVisible = false;
            Console.SetWindowSize(29, 17);
            Console.SetBufferSize(29, 17);

            string StoredScoreStrng = System.IO.File.ReadAllText(@"Score.txt");
            int StoredScore = Int32.Parse(StoredScoreStrng);

            int Score = 0;
            int HighScore = StoredScore;

            //INITIALIZE MATRIX
            int[,] coor = new int[5, 5];
            int[,] coorcopy = new int[5, 5];

            for (int x = 1; x < 5; x++)
            {
                for (int y = 1; y < 5; y++)
                {
                    coor[x, y] = 0;
                }
            }

            bool Possible = true;

            while (Possible)
            {
                //RANDOM NUM ( 2 OR 4 )
                Random RNG = new Random();

                int num = RNG.Next(2, 5);

                while (num == 3)
                {
                    num = RNG.Next(2, 5);
                }

                //SPAWN LOCATION
                bool TemZeros = false;

                for (int x = 1; x < 5; x++)
                {
                    for (int y = 1; y < 5; y++)
                    {
                        if (coor[x, y] == 0)
                        {
                            TemZeros = true;
                            x = 5;
                            break;
                        }
                    }
                }

                if (TemZeros)
                {
                    int X = RNG.Next(1, 5);
                    int Y = RNG.Next(1, 5);

                    while (coor[X, Y] != 0)
                    {
                        X = RNG.Next(1, 5);
                        Y = RNG.Next(1, 5);
                    }

                    coor[X, Y] = num;
                }

                //PRINT
                Console.Clear();

                Console.SetCursorPosition(5, 1);
                Console.WriteLine("-------------------");
                Console.SetCursorPosition(4, 2);
                Console.WriteLine("|    |    |    |    |");
                Console.SetCursorPosition(5, 3);
                Console.WriteLine("-------------------");
                Console.SetCursorPosition(4, 4);
                Console.WriteLine("|    |    |    |    |");
                Console.SetCursorPosition(5, 5);
                Console.WriteLine("-------------------");
                Console.SetCursorPosition(4, 6);
                Console.WriteLine("|    |    |    |    |");
                Console.SetCursorPosition(5, 7);
                Console.WriteLine("-------------------");
                Console.SetCursorPosition(4, 8);
                Console.WriteLine("|    |    |    |    |");
                Console.SetCursorPosition(5, 9);
                Console.WriteLine("-------------------");

                Console.SetCursorPosition(5, 12);
                Console.Write("Score: " + Score);

                Console.SetCursorPosition(5, 14);
                Console.Write("HighScore: " + HighScore);

                for (int x = 1; x < 5; x++)
                {
                    for (int y = 1; y < 5; y++)
                    {
                        if (coor[x, y] != 0)
                        {
                            Console.SetCursorPosition((5 * x), (2 * y));
                            Console.Write(coor[x, y]);
                        }
                        coorcopy[x, y] = coor[x, y];
                    }
                }

                //CONTROLS
                bool change = false;

                while (change == false)
                {
                    switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.RightArrow:
                        for (int x = 3; x > 0; x--)
                        {
                            for (int y = 0; y < 5; y++)
                            {
                                if (coor[x+1, y] == coor[x, y])
                                {
                                    coor[x, y] = 0;
                                    coor[x + 1, y] = coor[x + 1, y] * 2;
                                    Score = Score + coor[x + 1, y];
                                }
                                else
                                {
                                    while (coor[x + 1, y] == 0)
                                    {
                                        coor[x + 1, y] = coor[x, y];
                                        coor[x, y] = 0;
                                        if (x != 3)
                                        {
                                            x = x+1;
                                        }
                                    }
                                    if (coor[x + 1, y] == coor[x, y])
                                    {
                                        coor[x, y] = 0;
                                        coor[x + 1, y] = coor[x + 1, y] * 2;
                                        Score = Score + coor[x + 1, y];
                                    }
                                }
                            }
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        for (int x = 0; x < 5; x++)
                        {
                            for (int y = 2; y < 5; y++)
                            {
                                if (coor[x, y - 1] == coor[x, y])
                                {
                                    coor[x, y] = 0;
                                    coor[x, y - 1] = coor[x, y - 1] * 2;
                                    Score = Score + coor[x, y - 1];
                                }
                                else
                                {
                                    while (coor[x, y - 1] == 0)
                                    {
                                        coor[x, y - 1] = coor[x, y];
                                        coor[x, y] = 0;
                                        if (y != 2)
                                        {
                                            y = y - 1;
                                        }
                                    }
                                    if (coor[x, y - 1] == coor[x, y])
                                    {
                                        coor[x, y] = 0;
                                        coor[x, y - 1] = coor[x, y - 1] * 2;
                                        Score = Score + coor[x, y - 1];
                                    }
                                }
                            }
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        for (int x = 2; x <5; x++)
                        {
                            for (int y = 0; y < 5; y++)
                            {
                                if (coor[x - 1, y] == coor[x, y])
                                {
                                    coor[x, y] = 0;
                                    coor[x - 1, y] = coor[x - 1, y] * 2;
                                    Score = Score + coor[x - 1, y];
                                }
                                else
                                {
                                    while (coor[x - 1, y] == 0)
                                    {
                                        coor[x - 1, y] = coor[x, y];
                                        coor[x, y] = 0;
                                        if (x != 2)
                                        {
                                            x = x - 1;
                                        }
                                    }
                                    if (coor[x - 1, y] == coor[x, y])
                                    {
                                        coor[x, y] = 0;
                                        coor[x - 1, y] = coor[x - 1, y] * 2;
                                        Score = Score + coor[x - 1, y];
                                    }
                                }
                            }
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        for (int x = 0; x < 5; x++)
                        {
                            for (int y = 3; y > 0; y--)
                            {
                                if (coor[x, y + 1] == coor[x, y])
                                {
                                    coor[x, y] = 0;
                                    coor[x, y + 1] = coor[x, y + 1] * 2;
                                    Score = Score + coor[x, y + 1];
                                }
                                else
                                {
                                    while (coor[x, y + 1] == 0)
                                    {
                                        coor[x, y + 1] = coor[x, y];
                                        coor[x, y] = 0;
                                        if (y != 3)
                                        {
                                            y = y + 1;
                                        }
                                    }
                                    if (coor[x, y + 1] == coor[x, y])
                                    {
                                        coor[x, y] = 0;
                                        coor[x, y + 1] = coor[x, y + 1] * 2;
                                        Score = Score + coor[x, y + 1];
                                    }
                                }
                            }
                        }
                        break;

                        case ConsoleKey.Escape:                            
                            if (Score > HighScore)
                            {
                                System.IO.File.WriteAllText(@"Score.txt", Score.ToString());
                            }
                            System.Environment.Exit(1);
                            break;

                    }

                for (int x = 0; x < 5; x++)
                {
                    for (int y = 0; y < 5; y++)
                    {
                        if (coorcopy[x,y] != coor[x,y])
                        {
                            change = true;
                        }
                    }
                }

                    Console.Clear();

                    Console.SetCursorPosition(5, 1);
                    Console.WriteLine("-------------------");
                    Console.SetCursorPosition(4, 2);
                    Console.WriteLine("|    |    |    |    |");
                    Console.SetCursorPosition(5, 3);
                    Console.WriteLine("-------------------");
                    Console.SetCursorPosition(4, 4);
                    Console.WriteLine("|    |    |    |    |");
                    Console.SetCursorPosition(5, 5);
                    Console.WriteLine("-------------------");
                    Console.SetCursorPosition(4, 6);
                    Console.WriteLine("|    |    |    |    |");
                    Console.SetCursorPosition(5, 7);
                    Console.WriteLine("-------------------");
                    Console.SetCursorPosition(4, 8);
                    Console.WriteLine("|    |    |    |    |");
                    Console.SetCursorPosition(5, 9);
                    Console.WriteLine("-------------------");

                    Console.SetCursorPosition(5, 12);
                    Console.Write("Score: " + Score);

                    Console.SetCursorPosition(5, 14);
                    Console.Write("HighScore: " + HighScore);

                    for (int x = 1; x < 5; x++)
                    {
                        for (int y = 1; y < 5; y++)
                        {
                            if (coor[x, y] != 0)
                            {
                                Console.SetCursorPosition((5 * x), (2 * y));
                                Console.Write(coor[x, y]);
                            }
                            coorcopy[x, y] = coor[x, y];
                        }
                    }

                }          

            }            

        }
    }
}
