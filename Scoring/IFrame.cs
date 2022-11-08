using System.Collections.Generic;

namespace Scoring
{
    internal interface IFrame
    {
        bool IsCompleted { get; }
        bool IsStrike { get; }
        bool IsSpare { get; }
        int RollsCount { get; }
        int Score { get; }
        List<int> Rolls { get; }

        void AddBonus(int rollScore);
        void RollTheBall(int rollScore);
    }
}