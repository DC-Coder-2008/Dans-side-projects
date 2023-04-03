using System.Numerics;
using System.Linq;
using System;

namespace Game_thing
{

    class Code
    {
        static void Main()
        {
            int screenSize = 25;
            int treasureAmount = (screenSize+((screenSize*screenSize)/4))/4 ;
            string emptyTile = " ";

            string[,] screen = new string[screenSize, screenSize];

            MainCodeLoop(screen, screenSize, emptyTile, treasureAmount);
            
        }

        static void MainCodeLoop(string[,] screen, int screenSize, string emptyTile, int treasureAmount)
        {
            PlayerInfo player = new PlayerInfo();
            int[,] treasureLocations = generateTreasureLocation(treasureAmount, screenSize);

            while (true)
            {

                PrintScreen(screen, player.position, emptyTile, treasureLocations);

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



            }
        }

        static void PrintScreen(string[,] screen, int[] playerPosition, string emptyTile, int[,] treasureLocations)
        {
            Console.Clear();

            for (int i = 0; i < screen.GetLength(0); i++)
            {
                for (int j = 0; j < screen.GetLength(1); j++)
                {
                    screen[i, j] = emptyTile;
                }
            }

            for (int i=0; i < treasureLocations.GetLength(0); i++)
            {
                screen[treasureLocations[i, 0], treasureLocations[i, 1]] = "$";
            }

            screen[playerPosition[1], playerPosition[0]] = "#";

            for (int i = 0; i < screen.GetLength(0); i++)
            {
                Console.WriteLine("");

                for (int j = 0; j < screen.GetLength(1); j++)
                {
                    Console.Write(screen[i, j]);
                }
                
            }
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
    }

    public class PlayerInfo
    {
        public int[] position = { 0, 0 };
    }

   
}