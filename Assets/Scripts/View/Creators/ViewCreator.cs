using BubblesShoot.Model.Common;
using BubblesShoot.Model.Grids;
using BubblesShoot.Model.Interfaces;
using BubblesShoot.View.Creators;
using BubblesShoot.View.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace BubblesShoot.View
{
    public class ViewCreator
    {
        private readonly BubbleCreator _bubblesCreator;

        public ViewCreator(BubbleCreator bubbleCreator)
        {
            _bubblesCreator = bubbleCreator;
        }

        public List<List<GameObject>> CreateBubbles(CoordinateGrid coordinateGrid, List<List<BubbleCell>> bubbles)
        {
            var objects = new List<List<GameObject>>();

            for (int i = 0; i < coordinateGrid.Rows; i++)
            {
                List<GameObject> rowList = new List<GameObject>();
                for (int j = 0; j < coordinateGrid.Columns; j++)
                {
                    if (!bubbles[i][j].IsEmpty)
                        rowList.Add(_bubblesCreator.NeedNewBubble(bubbles[i][j].Bubble, coordinateGrid.Coordinates[i][j], true));
                    else rowList.Add(null);
                }
                objects.Add(rowList);
            }

            return objects;
        }

        public void CreateObject(IObjectCreator[] creators)
        {
            for (int i = 0; i < creators.Length; i++) creators[i].CreateObject();
        }
    }
}
