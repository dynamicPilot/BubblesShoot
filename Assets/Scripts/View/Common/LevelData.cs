using BubblesShoot.Model.Common;
using System.Collections.Generic;
using UnityEngine;

namespace BubblesShoot.View.Common
{
    [CreateAssetMenu(menuName = "Config/LevelData", fileName = "LevelData", order = 1)]
    public class LevelData : ScriptableObject
    {
        public int Number;
        public int SceneIndex;

        [Header("Grid")]
        public int Rows;
        public int Columns;

        [Header("Initial Bubbles")]
        public bool IsRandomInitials;
        public BubblesColorRow[] BubblesColors;

        [Header("New Bubbles")]
        public bool IsRandomNew;
        public COLOR[] GeneratingBubbles;
    }
}
