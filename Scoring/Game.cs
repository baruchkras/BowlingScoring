using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Scoring
{
    internal class Game : IGame
    {
        public bool IsCompleted { get
            {
                return frames.Count == 10 && frames.Last().IsCompleted;
            }          
        }

        public IEnumerable<IFrame> Frames
        {
            get { return frames; }
        }

        private List<IFrame> frames = new List<IFrame>();

        public void RollTheBall(int rollScore)
        {
            if (frames.Count == 0 || frames.Last().IsCompleted)
            {
                if (frames.Count == 9)
                {
                    frames.Add(new LastFrame());
                }
                else
                {
                    frames.Add(new Frame());
                }

                frames.Last().RollTheBall(rollScore);

            }
            else
            {
                frames.Last().RollTheBall(rollScore);
            }
            AddBonuses(rollScore);
        }
        private void AddBonuses(int rollScore)
        {
            switch (frames.Last().RollsCount)
            {
                case 1:
                    if (frames.Count > 1 && (frames[frames.Count - 2].IsStrike || frames[frames.Count - 2].IsSpare))
                    {
                        frames[frames.Count - 2].AddBonus(rollScore);
                        if (frames.Count > 2 && frames[frames.Count - 2].IsStrike && frames[frames.Count - 3].IsStrike)
                        {
                            frames[frames.Count - 3].AddBonus(rollScore);
                        }
                    }
                    break;
                case 2:
                    if (frames.Count > 1 && frames[frames.Count - 2].IsStrike)
                    {
                        frames[frames.Count - 2].AddBonus(rollScore);
                    }
                    break;
            }
        } 
    }
}