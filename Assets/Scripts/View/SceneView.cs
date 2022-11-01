using BubblesShoot.Model.Common;
using BubblesShoot.Model.Interfaces;
using BubblesShoot.View.GuideSystem;
using BubblesShoot.View.Interfaces;
using BubblesShoot.View.Updaters;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BubblesShoot.View
{
    public class SceneView : IBubblesObserver, ISceneView
    {
        private readonly IBubblesObservable _observable;
        private readonly BubbleRoutine _bubbleRoutine;
        private readonly ViewUpdater _viewUpdater;
        private readonly MonoBehaviour _inputControl;
        private readonly CameraUpdater _cameraUpdater;

        public SceneView(IBubblesObservable observable, BubbleRoutine bubbleRoutine, ViewUpdater viewUpdater, 
            MonoBehaviour inputControl, CameraUpdater cameraUpdater)
        {
            _observable = observable;
            _bubbleRoutine = bubbleRoutine;
            _viewUpdater = viewUpdater;
            _inputControl = inputControl;
            _cameraUpdater = cameraUpdater;
        }

        public void UpdateView(List<List<BubbleCell>> bubbles, float score)
        {
            _cameraUpdater.UpdateCameraPosition(_viewUpdater.UpdateView(bubbles));
            ContinuePlaying();
        }

        public void SpawnNewBubble(Bubble bubble, IBubbleOnPlaceInformer informer)
        {
            _bubbleRoutine.SpawnNewBubble(bubble, informer);

        }

        public void RegisterNewBubbleObject(GameObject bubbleObject, Tuple<int, int> indexes)
        {
            _viewUpdater.RegisterNewBubbleObject(bubbleObject, indexes);
        }

        public void BlockRaycast()
        {
            _inputControl.enabled = false;
        }

        public void ContinuePlaying()
        {
            _inputControl.enabled = true;
        }
    }
}
