using BubblesShoot.Model.Common;
using BubblesShoot.Model.Interfaces;
using BubblesShoot.View.GuideSystem;
using BubblesShoot.View.Interfaces;
using BubblesShoot.View.StateControls;
using BubblesShoot.View.Updaters;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BubblesShoot.View
{
    public class SceneView : IBubblesObserver, ISceneView
    {
        private readonly BubbleRoutine _bubbleRoutine;
        private readonly SceneStartEndControl _stateControl;
        private readonly SceneUpdater _sceneUpdater;
        private readonly IRaycastControl _raycastControl;
        

        public SceneView(BubbleRoutine bubbleRoutine, SceneUpdater sceneUpdater,
            SceneStartEndControl stateControl, IRaycastControl raycastControl)
        {
            _bubbleRoutine = bubbleRoutine;
            _sceneUpdater = sceneUpdater;
            _stateControl = stateControl;
            _raycastControl = raycastControl;
        }

        public void UpdateView(List<List<BubbleCell>> bubbles, int score)
        {
            _sceneUpdater.UpdateView(bubbles, score);
            ContinuePlaying();
        }

        public void SpawnNewBubble(Bubble bubble, IBubbleOnPlaceInformer informer)
        {
            _bubbleRoutine.SpawnNewBubble(bubble, informer);

        }

        public void RegisterNewBubbleObject(GameObject bubbleObject, Tuple<int, int> indexes)
        {
            _sceneUpdater.RegisterNewBubbleObject(bubbleObject, indexes);
        }

        public void BlockRaycast()
        {
            _raycastControl.BlockRaycast();
        }

        public void ContinuePlaying()
        {
            _raycastControl.ContinueRaycast();
        }

        public void StartGame()
        {
            _stateControl.StartGame();
            ContinuePlaying();
        }

        public void EndGame()
        {
            _stateControl.EndGame();
            BlockRaycast();
        }

        public void QuitGame(bool restart)
        {
            _bubbleRoutine.QuitGame();
        }
    }
}
