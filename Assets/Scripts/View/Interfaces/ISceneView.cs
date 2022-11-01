using BubblesShoot.Model.Common;
using BubblesShoot.Model.Interfaces;
using System;
using UnityEngine;

namespace BubblesShoot.View.Interfaces
{
    public interface ISceneView
    {
        void StartGame();
        void EndGame();
        void QuitGame(bool restart);
        void SpawnNewBubble(Bubble bubble, IBubbleOnPlaceInformer informer);
        void RegisterNewBubbleObject(GameObject bubbleObject, Tuple<int, int> indexes);
        void BlockRaycast();
        void ContinuePlaying();
    }
}
