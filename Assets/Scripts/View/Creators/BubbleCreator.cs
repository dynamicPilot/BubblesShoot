using BubblesShoot.Model.Common;
using BubblesShoot.View.Common;
using BubblesShoot.View.Factories;
using BubblesShoot.View.Interfaces;
using UnityEngine;

namespace BubblesShoot.View.Creators
{
    public class BubbleCreator
    {
        private readonly Factory _factory;
        private readonly GameObject _prefab;
        private readonly Transform _parent;
        private readonly BubbleSetup _bubbleSetup;
        private readonly BubbleSetup _initialBubblesSetup;

        private readonly float _startYDelta;
        private readonly Transform _startPlaceContainer;
        public BubbleCreator(Factory factory, GameObject prefab, Transform parent, 
            BubbleSetup bubbleSetup, BubbleSetup initialBubbleSetup, float positionYDelta, Transform startPoint)
        {
            _factory = factory;
            _prefab = prefab;
            _parent = parent;
            _bubbleSetup = bubbleSetup;
            _initialBubblesSetup = initialBubbleSetup;
            _startYDelta = positionYDelta;
            _startPlaceContainer = startPoint;
        }

        public GameObject NeedNewBubble(Bubble bubble, Vector2 position, bool initial = false)
        {
            if (initial) return CreateBubble(_factory, _initialBubblesSetup, bubble, position);
            else
            {
                position = new Vector2(_startPlaceContainer.position.x, _startYDelta + _startPlaceContainer.position.y);
                return CreateBubble(_factory, _bubbleSetup, bubble, position);
            }
        }

        private GameObject CreateBubble(IFactory factory, BubbleSetup setup, Bubble bubble, Vector2 position)
        {           
            GameObject temp = factory.CreatePrefab(new PrefabToCreate
            {
                Prefab = _prefab,
                Parent = _parent,
                Position = position
            });

            setup.SetupBubble(temp, bubble.Color);

            return temp;
        }
    }
}
