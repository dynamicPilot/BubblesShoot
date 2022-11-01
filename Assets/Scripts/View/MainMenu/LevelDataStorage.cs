using BubblesShoot.View.Common;
using UnityEngine;

namespace BubblesShoot.View.MainMenu
{
    public class LevelDataStorage : MonoBehaviour
    {
        public LevelData[] Levels;

        public LevelData GetLevelByIndex(int index)
        {
            if (index >= Levels.Length) return null;
            else return Levels[index];
        }
    }
}
