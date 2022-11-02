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
        private readonly BubbleSetup _freeBubbleSetup;
        private readonly BubbleSetup _initialBubblesSetup;
        private readonly IGetFreeObject _getFree;

        private readonly float _startYDelta;
        private readonly Transform _startPlaceContainer;
        public BubbleCreator(Factory factory, GameObject prefab, Transform parent, 
            BubbleSetup bubbleSetup, BubbleSetup freeBubbleSetup, BubbleSetup initialBubbleSetup, 
            float positionYDelta, Transform startPoint, IGetFreeObject getFree)
        {
            _factory = factory;
            _prefab = prefab;
            _parent = parent;
            _bubbleSetup = bubbleSetup;
            _freeBubbleSetup = freeBubbleSetup;
            _initialBubblesSetup = initialBubbleSetup;
            _startYDelta = positionYDelta;
            _startPlaceContainer = startPoint;
            _getFree = getFree;
        }

        public GameObject NeedNewBubble(Bubble bubble, Vector2 position, bool initial = false)
        {
            if (initial) return CreateBubble(_factory, _initialBubblesSetup, bubble, position);
            else
            {
                position = new Vector2(_startPlaceContainer.position.x, _startYDelta + _startPlaceContainer.position.y);
                var free = TryGetFreeBubble(_freeBubbleSetup, bubble, position);
                return (free == null) ? CreateBubble(_factory, _bubbleSetup, bubble, position) : free;
            }
        }

        private GameObject TryGetFreeBubble(BubbleSetup setup, Bubble bubble, Vector2 position)
        {
            //return null;
            GameObject temp = _getFree.GetFreeObject();
            if (temp == null) return temp;
            setup.SetupBubble(temp, bubble.Color);
            temp.transform.localPosition = position;

            return temp;
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
