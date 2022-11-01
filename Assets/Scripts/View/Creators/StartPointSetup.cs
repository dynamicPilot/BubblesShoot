using BubblesShoot.Model.Interfaces;
using BubblesShoot.View.Interfaces;
using BubblesShoot.View.PathSystem;
using UnityEngine;

namespace BubblesShoot.View.Creators
{
    public class StartPointSetup : ISetupObject
    {
        private readonly ISearchGrid _searchGrid;
        private readonly float _bubbleSize;
        public StartPointSetup(ISearchGrid searchGrid, float bubbleSize)
        {
            _searchGrid = searchGrid;
            _bubbleSize = bubbleSize;
        }
        public void SetupObject(GameObject gameObject)
        {
            var helper = gameObject.GetComponent<ModelHelper>();
            helper.SearchGrid = _searchGrid;
            helper.BubbleSize = _bubbleSize;
        }
    }
}
