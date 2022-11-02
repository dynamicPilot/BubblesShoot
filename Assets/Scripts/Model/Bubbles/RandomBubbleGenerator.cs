using BubblesShoot.Model.Common;
using BubblesShoot.Model.Interfaces;
using UnityEngine;

namespace BubblesShoot
{
    public class RandomBubbleGenerator : IGenerateNewBubble
    {
        public Bubble GenerateNewBubble()
        {
            int colorIndex = Random.Range(0, (int) COLOR.none);
            return new Bubble((COLOR)colorIndex);
        }
    }
}
