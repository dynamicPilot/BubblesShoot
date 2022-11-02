using BubblesShoot.Model.Common;
using System.Collections.Generic;

namespace BubblesShoot.Model.Bubbles
{
    public static class EndGameChecker
    {
        public static bool IsEndGame(List<BubbleCell> firstRow)
        {
            for (int i = 0; i < firstRow.Count; i++)
                if (!firstRow[i].IsEmpty) return false;

            return true;
        }

    }
}
