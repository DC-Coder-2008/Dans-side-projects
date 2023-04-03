using System.Numerics;

namespace Game_thing
{

    class Code
    {
        static void Main()
        {
            int screenSize = 20;
            string emptyTile = ".";

            string[,] screen = new string[screenSize, screenSize];

            for (int i = 0; i < screen.GetLength(0); i++)
            {
                for (int j = 0; j < screen.GetLength(1); j++)
                {
                    screen[i, j] = emptyTile;
                }
            }

            MainCodeLoop(screen, screenSize,emptyTile);
            
        }

        static void MainCodeLoop(string[,] screen, int screenSize, string emptyTile)
        {
            PlayerInfo player = new PlayerInfo();

            while (true)
            {
                PrintScreen(screen, player.position, emptyTile);

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

        static void PrintScreen(string[,] screen, int[] playerPosition, string emptyTile)
        {
            Console.Clear();

            for (int i = 0; i < screen.GetLength(0); i++)
            {
                for (int j = 0; j < screen.GetLength(1); j++)
                {
                    screen[i, j] = emptyTile;
                }
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
    }

    public class PlayerInfo
    {
        public int[] position = { 0, 0 };
    }

   
}