namespace Scoring
{
    internal class LastFrame: Frame
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
            if (rollScore < 0 || rollScore > 10 || (!IsStrike && rolls.Count == 1 && (rolls[0] + rollScore > 10)))
            {
                throw new System.ArgumentException();
            }            
        }
    }
}