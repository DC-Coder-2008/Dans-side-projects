using System.Numerics;
using System.Linq;
using System;

namespace Game_thing
{

    class Code
    {
        static void Main()
        {
            int screenSize = 10;
            int treasureAmount = (int)Math.Pow((screenSize / 2.5),2) ;
            string emptyTile = " ";
            int count = 0;

            string[,] screen = new string[screenSize, screenSize];

            MainCodeLoop(screen, screenSize, emptyTile, treasureAmount, count);
            
        }

        static void MainCodeLoop(string[,] screen, int screenSize, string emptyTile, int treasureAmount, int count)
        {
            PlayerInfo player = new PlayerInfo();
            int[,] treasureLocations = generateTreasureLocation(treasureAmount, screenSize);

            RunGameLoop(screen, player.position, emptyTile, treasureLocations, count);

            while (true)
            {

                var movementInput = Console.ReadKey();
                switch (movementInput.KeyChar.ToString())
                {
                    case "w":
                        {
                            if (player.position[1] > 0)
                            {
                                player.position[1]--;
                            }
                            break;
                        }

                    case "a":
                        {
                            if (player.position[0] > 0)
                            {
                                player.position[0]--;
                            }
                            break;
                        }

                    case "s":
                        {
                            if (player.position[1] + 1 < screenSize)
                            {
                                player.position[1]++;
                            }
                            break;
                        }
                    case "d":
                        {
                            if (player.position[0] + 1 < screenSize)
                            {
                                player.position[0]++;
                            }
                            break;
                        }
                    default:
                        {

                            break;
                        }
                }//movement logic

                RunGameLoop(screen, player.position, emptyTile, treasureLocations, count);
                count++;

            }
        }

        static void RunGameLoop(string[,] screen, int[] playerPosition, string emptyTile, int[,] treasureLocations, int count)
        {
            

            for (int i = 0; i < screen.GetLength(0); i++)
            {
                for (int j = 0; j < screen.GetLength(1); j++)
                {
                    screen[i, j] = emptyTile;
                }
            }

            treasureLocations = CheckForTreasureCollection(treasureLocations, playerPosition);

            for (int i=0; i < treasureLocations.GetLength(0); i++)
            {
                screen[treasureLocations[i, 0], treasureLocations[i, 1]] = "$";
            }

            screen[playerPosition[1], playerPosition[0]] = "#";

            

            CheckForWin(treasureLocations, count);

            Console.Clear();
            PrintScreen(screen);

        }

        static int[,] generateTreasureLocation(int treasureAmount, int screenSize)
        {
            int[,] treasureLocations = new int[treasureAmount, 2];

            Random rnd = new Random();

            for (int i = 0; i < treasureAmount; i++)
            {
                treasureLocations[i, 0] = rnd.Next(0, screenSize);
                treasureLocations[i, 1] = rnd.Next(0, screenSize);
            }
            return treasureLocations;
        }

        static void PrintScreen(string[,] screen)
        {
            for (int i = 0; i < screen.GetLength(0); i++)
            {
                Console.WriteLine("");

                for (int j = 0; j < screen.GetLength(1); j++)
                {
                    Console.Write(screen[i, j]);
                }

            }
        }

        static int[,] CheckForTreasureCollection(int[,] treasureLocations, int[] playerPosition)
       {
            for (int i = 0; i < treasureLocations.GetLength(0); i++)
            {
               if (treasureLocations[i,0] == playerPosition[1] && treasureLocations[i,1] == playerPosition[0])
                {
                    treasureLocations[i, 0] = 0;
                    treasureLocations[i, 1] = 0;
                }
            }

            return treasureLocations;
        }

        static void CheckForWin(int[,] treasureLocations, int count)
        {
            bool win = true;

            for(int i = 0; i < treasureLocations.GetLength(0); i++)
            {
                for(int j = 0; j < treasureLocations.GetLength(1); j++)
                {
                    if (treasureLocations[i,j] != 0)
                    {
                        win = false;
                    }
                }
            }

           if(win == true)
            {
                Console.Clear();

                Console.WriteLine("You collected the treasure in " + (count+1) + " moves.");
                Thread.Sleep(1000);
                Environment.Exit(12345);
            }
            
            
        }
    }

    public class PlayerInfo
    {
        public int[] position = { 0, 0 };
    }

   
}