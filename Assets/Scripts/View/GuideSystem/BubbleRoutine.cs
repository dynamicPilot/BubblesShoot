using BubblesShoot.Model.Common;
using BubblesShoot.Model.Interfaces;
using BubblesShoot.View.Creators;
using BubblesShoot.View.PathSystem;
using System;
using UnityEngine;

namespace BubblesShoot.View.GuideSystem
{
    public class BubbleRoutine
    {
        private readonly PathContainer _container;
        private readonly BubbleCreator _creator;
        private IBubbleOnPlaceInformer _informer;

        private GameObject _newBubbleObject;
        private Bubble _newBubble;
        private bool _isSubscribe = false;
        private readonly float _bubbleSpeed;

        public BubbleRoutine(PathContainer container, BubbleCreator creator, float bubbleSpeed)
        {
            _container = container;
            _creator = creator;
            _isSubscribe = false;
            _bubbleSpeed = bubbleSpeed;
        }

        public void SpawnNewBubble(Bubble bubble, IBubbleOnPlaceInformer informer)
        {
            _newBubbleObject = _creator.NeedNewBubble(bubble, Vector2.one);
            _newBubble = bubble;
            _informer = informer;
            _container.OnPathReady += StartBubble;
            _isSubscribe = true;
        }

        public void StartBubble(Vector2[] path)
        {            
            if (path == null || path.Length < 2 || _newBubbleObject == null) return;

            _informer.BlockRaycast();
            _container.OnPathReady -= StartBubble;
            _isSubscribe = false;
            var guide = _newBubbleObject.AddComponent<BubbleGuide>();
            guide.StartBubble(path, _newBubble, _informer, _bubbleSpeed);
        }

        public void QuitGame()
        {
            if (_isSubscribe) _container.OnPathReady -= StartBubble;
            _isSubscribe = false;
        }
    }
}
