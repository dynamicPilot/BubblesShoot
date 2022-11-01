using BubblesShoot.Model.Common;
using System;
using UnityEngine;

namespace BubblesShoot.Model.Interfaces
{
    public interface IGameModel
    {
        Tuple<Vector2, bool> GetPosition(Vector2 hitPoint);

        Bubble GetNewBubble();

        Tuple<int,int> RegisterNewBubble(Vector2 position, Bubble bubble);

        void UpdateModel();

        bool CheckForEndGame();
    }
}
