using UnityEngine;

namespace BubblesShoot.View.Common
{
    [CreateAssetMenu(menuName = "Config/StaticData", fileName = "StaticData", order = 0)]
    public class StaticData : ScriptableObject
    {
        [Header("Colors")]
        public Color RedColor;
        public Color BlueColor;       
        public Color YellowColor;
        public Color GreenColor;

        [Header("Others")]
        public int EmptyRows = 1;
        public int MenuIndex = 0;
        public float BubbleSpeed = 2;

    }
}
