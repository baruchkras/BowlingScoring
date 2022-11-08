using System.Collections.Generic;

namespace Scoring
{
    internal interface IGame
    {
        bool IsCompleted { get; }
        IEnumerable<IFrame> Frames { get; }

        void RollTheBall(int rollScore);
    }
}