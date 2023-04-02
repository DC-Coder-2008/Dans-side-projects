namespace Game_thing
{

    class Code
    {
        static void Main()
        {
            PlayerInfo player = new PlayerInfo();
            int screenLength = 30;
            int screenHeight = 30;

            string[,] screen = new string[screenLength, screenHeight];

            for (int i = 0; i < screen.GetLength(0); i++)
            {
                for (int j = 0; j < screen.GetLength(1); j++)
                {
                    screen[i, j] = ".";
                }
            }

            while (true)
            {

                var movementInput = Console.ReadKey();
                Console.Clear();

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
                            if (player.position[1] + 1 < screenHeight)
                            {
                                player.position[1]++;
                            }
                            break;
                        }
                    case "d":
                        {
                            if (player.position[0] + 1 < screenLength)
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

                PrintScreen(screen, player.position);
            }
        }

        static void PrintScreen(string[,] screen, int[] playerPosition)
        {
            screen[playerPosition[0], playerPosition[1]] = "#";
        }
    }

    public class PlayerInfo
    {
        public int[] position = { 0, 0 };
    }

   
}