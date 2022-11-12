using System.Collections.Generic;
using System.Linq;

namespace Scoring
{
    public class Frame : IFrame
    {
        public virtual bool IsCompleted 
        { 
            get
            {
                return IsStrike || rolls.Count == 2;
            }
        }

        public bool IsStrike 
        { 
            get
            {
                return rolls.Count > 0 && rolls[0] == 10;
            }
        }

        public bool IsSpare
        {
            get
            {
                return rolls.Count > 1 && rolls[0] + rolls[1] == 10;
            }
        }

        public int Score
        {
            get
            {
                return rolls.Sum() + bonus;
            }
        }

        public int RollsCount
        {
            get { return rolls.Count; }
        }

        protected List<int> rolls = new List<int>();
        public List<int> Rolls 
        { 
            get
            {
                return rolls;
            }
        }

        protected int bonus;

        public void AddBonus(int rollScore)
        {
            bonus += rollScore;
        }

        public void RollTheBall(int rollScore)
        {
            Validate(rollScore);

            if (!IsCompleted)
            {
                rolls.Add(rollScore);
            }
        }

        protected virtual void Validate(int rollScore)
        {
            if (rollScore < 0)
            {
                throw new System.ArgumentException(ErrorMessages.RollScoreIsLessThan0);
            }
            else if (rollScore > 10)
            {
                throw new System.ArgumentException(ErrorMessages.RollScoreIsMoreThan10);
            }
            else if (Rolls.Count == 1 && (rolls.Sum() + rollScore > 10))
            {
                throw new System.ArgumentException(ErrorMessages.SumOfRollScoresIsMoreThan10);
            }
        }
    }
}