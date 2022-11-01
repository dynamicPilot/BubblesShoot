using BubblesShoot.Model.Common;
using System;
using UnityEngine;

namespace BubblesShoot.Model.Interfaces
{
    public interface ISearchGrid
    {
        Tuple<Vector2, bool> GetPosition(Vector2 hitPoint);
    }

    public interface IBubbleOnPlaceInformer
    {
        void BubbleOnPlace(Vector2 position, Bubble bubble, GameObject bubbleObject);
        void BlockRaycast();
    }

}
