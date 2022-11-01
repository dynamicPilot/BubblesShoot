using BubblesShoot.Model.Bubbles;
using BubblesShoot.Model.Common;
using BubblesShoot.Model.Grids;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Random = UnityEngine.Random;

namespace BubblesShoot.Model
{
    public class BubblesControl
    {
        public List<List<BubbleCell>> Bubbles { get; private set; }
        private bool _needUpdateBubbleList = false;
        public BubblesControl(List<List<BubbleCell>> bubbles)
        {
            Bubbles = bubbles;
            _needUpdateBubbleList = false;
        }

        public Bubble GetNewBubble()
        {
            int colorIndex = Random.Range(0, 4);
            return new Bubble((COLOR)colorIndex);
        }

        public Tuple<int, bool> RegisterNewBubble(Tuple<int,int> indexes, Bubble bubble)
        {
            int score = 0;

            if (Bubbles[indexes.Item1][indexes.Item2].IsEmpty)
            {
                var cell = Bubbles[indexes.Item1][indexes.Item2];
                cell.SetBubble(bubble);
                score = BubblesGraphUpdater.UpdateBubblesGraphWithNewBubble(Bubbles, cell);
                _needUpdateBubbleList = score > 0;
            }
            else Debug.LogError($"BubbleCell is not Empty: row {indexes.Item1}, col {indexes.Item2}.");

            bool needAddNewRow = indexes.Item1 == Bubbles.Count - 1;
            return new Tuple<int, bool> (score, needAddNewRow);
        }

        public Tuple<int, bool> UpdateBubbles()
        {
            if (!_needUpdateBubbleList) return new Tuple<int, bool>(0, false);

            BubblesGraphUpdater.SearchForFloaters(Bubbles);
            return new Tuple<int, bool>(BubblesGraphUpdater.UpdateBubbleGraph(Bubbles), true);
        }

        public bool IsEndGame()
        {
            return EndGameChecker.IsEndGame(Bubbles[0]);
        }

        public void AddRowToBubbles(CoordinateGrid grid)
        {
            BubblesConstructor.AddRowToBubble(grid, Bubbles);
            Debug.Log("Add row to Bubbles" + Bubbles.Count);
        }
    }
}
