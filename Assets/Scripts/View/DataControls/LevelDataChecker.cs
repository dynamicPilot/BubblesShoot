using BubblesShoot.View.Common;
using UnityEngine;

namespace BubblesShoot.View.DataControls
{
    public static class LevelDataChecker
    {
        public static bool CheckLevelData(LevelData data)
        {
            if (data == null)
            {
                Debug.LogError("Composer: null data");
                return false;
            }

            if (data.Rows == 0 || data.Columns == 0)
            {
                Debug.LogError($"Composer: zero rows or columns. Rows {data.Rows}, col {data.Columns}.");
                return false;
            }

            if (!data.IsRandomInitials)
            {
                if (data.BubblesColors == null || data.BubblesColors.Length == 0)
                {
                    Debug.Log("Composer: null or empty BubblesColors. Turn to random initials.");
                    data.IsRandomInitials = true;
                }
                else if (data.Rows > data.BubblesColors.Length)
                {
                    Debug.Log("Composer: BubblesColors length is less than Rows." +
                        "\nBubblesColors will be repeated.");
                }
            }

            if (!data.IsRandomNew)
            {
                if (data.GeneratingBubbles == null || data.GeneratingBubbles.Length == 0)
                {
                    Debug.Log("Composer: null or empty GeneratingBubbles. Turn to random new.");
                    data.IsRandomNew = true;
                }
            }

            return true;
        }
    }
}
