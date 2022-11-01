using BubblesShoot.Model.Common;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BubblesShoot.View.Updaters
{
    public class SceneUpdater
    {
        private readonly CameraUpdater _cameraUpdater;
        private readonly ViewUpdater _viewUpdater;
        private readonly UIUpdater _uiUpdater;
        public SceneUpdater(CameraUpdater cameraUpdater, ViewUpdater viewUpdater, UIUpdater uIUpdater)
        {
            _cameraUpdater = cameraUpdater;
            _viewUpdater = viewUpdater;
            _uiUpdater = uIUpdater;
        }

        public void UpdateView(List<List<BubbleCell>> bubbles, int score)
        {
            _cameraUpdater.UpdateCameraPosition(_viewUpdater.UpdateView(bubbles));
            _uiUpdater.UpdateScore(score);
        }

        public void RegisterNewBubbleObject(GameObject bubbleObject, Tuple<int, int> indexes)
        {
            _viewUpdater.RegisterNewBubbleObject(bubbleObject, indexes);
        }
    }
}
