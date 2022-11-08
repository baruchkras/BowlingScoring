using System;

namespace Scoring
{
    internal class FrameCLIOutputter : IFrameOutputter
    {
        private IFrame frame;

        public FrameCLIOutputter(IFrame frame)
        {
            this.frame = frame;
        }

        public void DisplayRolls()
        {
            string result = "";
            int i;
            for (i = 0; i < frame.Rolls.Count; i++)
            {
                if (i == 1 && frame.IsSpare)
                {
                    result += "/ ";
                }
                else if (frame.Rolls[i] == 10)
                {
                    result += "X ";
                }
                else
                {
                    result += frame.Rolls[i].ToString() + " ";
                }
            }
            Console.Write(result);

            // Pad with spaces
            for (; i < 3; i++)
            {
                Console.Write("  ");
            }
         }
    }
}