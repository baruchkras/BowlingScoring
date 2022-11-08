using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scoring
{
    internal class CLIManager
    {
        internal static void Play()
        {
            while (true)
            {
                Console.WriteLine("Game started");
                Console.WriteLine("To roll the ball enter number 0 - 10, to display score so far enter 's', to leave enter 'x'");
                IGame game = new Game();
                IGameOutputter gameOutputter = new GameCLIOutputter(game);
                while (!game.IsCompleted)
                {
                    if (game.Frames.Count() == 0 || game.Frames.Last().IsCompleted)
                    {
                        Console.Write(String.Format("Frame {0} ==>", game.Frames.Count() + 1));
                    }
                    else 
                    {
                        Console.Write(String.Format("Frame {0} ==>", game.Frames.Count()));
                    }
                    string userInput = Console.ReadLine();

                    if (userInput.Equals("s"))
                    {
                        gameOutputter.DisplayScore();
                    }
                    else if (userInput.Equals("x"))
                    {
                        return;
                    }
                    else
                    {
                        try
                        {
                            int rollScore = int.Parse(userInput);
                            game.RollTheBall(rollScore);

                        }
                        catch
                        {
                            Console.WriteLine("Illegal input, please try again");
                        }
                    }
                }
                Console.WriteLine("The game completed. The final score is:");
                gameOutputter.DisplayScore();
                Console.WriteLine("Play another? Enter 'y' or any other key to exit");
                if (Console.ReadKey().KeyChar != 'y')
                {
                    break;
                }
            }
        }
    }
}
