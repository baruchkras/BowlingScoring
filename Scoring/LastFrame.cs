using System.Linq;

namespace Scoring
{
    public class LastFrame: Frame
    {
        public override bool IsCompleted
        {
            get
            {
                return ((IsStrike || IsSpare) && rolls.Count == 3) || (!(IsStrike || IsSpare) && rolls.Count == 2);
            }
        }

        protected override void Validate(int rollScore)
        {
            if (rollScore < 0)
            {
                throw new System.ArgumentException(ErrorMessages.RollScoreIsLessThan0);
            }
            else if (rollScore > 10)
            {
                throw new System.ArgumentException(ErrorMessages.RollScoreIsMoreThan10);
            }
            else if (!IsStrike && Rolls.Count == 1 && (rolls.Sum() + rollScore > 10))
            {
                throw new System.ArgumentException(ErrorMessages.SumOfRollScoresIsMoreThan10);
            }
        }
    }
}