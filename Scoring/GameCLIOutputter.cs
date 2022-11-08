using System;

namespace Scoring
{
    internal class GameCLIOutputter : IGameOutputter
    {
        private IGame game;

        public GameCLIOutputter(IGame game)
        {
            this.game = game;
        }

        public void DisplayScore()
        {
            if (game.IsCompleted)
            {
                Console.WriteLine("Game final score");
            }
            else
            {
                Console.WriteLine("Game score so far");
            }

            Console.WriteLine("Frame       Score");
            Console.WriteLine("-----------------");

            int frameCount = 1;
            int score = 0;
            foreach(IFrame frame in game.Frames)
            {
                score += frame.Score;
                IFrameOutputter frameOutputter = new FrameCLIOutputter(frame);
                Console.Write(string.Format("{0,3}   ", frameCount++));
                frameOutputter.DisplayRolls();
                Console.WriteLine(string.Format("{0,3}   ", score));
            }
            Console.WriteLine("-----------------");
        }
    }
}