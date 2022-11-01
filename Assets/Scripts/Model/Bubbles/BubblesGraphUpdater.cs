using BubblesShoot.Model.Common;
using System;
using System.Collections.Generic;

namespace BubblesShoot.Model.Bubbles
{
    public static class BubblesGraphUpdater
    {
        public static int UpdateBubblesGraphWithNewBubble(List<List<BubbleCell>> bubbles, BubbleCell rootBubble)
        {
            int score = -1;
            COLOR targetColor = rootBubble.Bubble.Color;

            Queue<BubbleCell> queue = new Queue<BubbleCell>();
            queue.Enqueue(rootBubble);

            while (queue.Count > 0)
            {
                BubbleCell cell = queue.Dequeue();
                if (cell.IsVisited) continue;

                cell.IsVisited = true;
                score++;
                if (cell != rootBubble) cell.SetBubble(null);

                for (int i= 0; i < cell.Neighbors.Length; i++)
                {
                    Tuple<int, int> indexes = cell.Neighbors[i];
                    BubbleCell neighbor = bubbles[indexes.Item1][indexes.Item2];

                    if (neighbor.IsEmpty || neighbor.IsVisited || neighbor.Bubble.Color != targetColor) continue;

                    queue.Enqueue(bubbles[indexes.Item1][indexes.Item2]);
                }
            }

            if (score > 0)
            {
                rootBubble.SetBubble(null);
                score++;
            }
            else rootBubble.IsVisited = false;

            return score;
        }

       

        public static int UpdateBubbleGraph(List<List<BubbleCell>> bubbles)
        {
            int score = 0;

            for (int i = 0; i < bubbles.Count; i++)
            {
                for (int j = 0; j < bubbles[i].Count; j++)
                {
                    if (bubbles[i][j].IsVisited || bubbles[i][j].IsEmpty) continue;
                    score++;
                    bubbles[i][j].SetBubble(null);
                }
            }

            ResetIsVisited(bubbles);
            return score;
        }

        public static void SearchForFloaters(List<List<BubbleCell>> bubbles)
        {
            ResetIsVisited(bubbles);

            for (int j = 0; j < bubbles[0].Count; j++)
            {
                if (bubbles[0][j].IsEmpty || bubbles[0][j].IsVisited) continue;
                DFS(bubbles, bubbles[0][j]);
            }
        }

        private static void DFS(List<List<BubbleCell>> bubbles, BubbleCell root)
        {
            Stack<BubbleCell> stack = new Stack<BubbleCell>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                BubbleCell cell = stack.Pop();

                if (cell.IsVisited) continue;

                cell.IsVisited = true;
                for (int i = 0; i < cell.Neighbors.Length; i++)
                {
                    Tuple<int, int> indexes = cell.Neighbors[i];
                    BubbleCell neighbor = bubbles[indexes.Item1][indexes.Item2];

                    if (neighbor.IsVisited || neighbor.IsEmpty) continue;
                    
                    stack.Push(neighbor);
                }
            }
        }

        private static void ResetIsVisited(List<List<BubbleCell>> bubbles)
        {
            for (int i = 0; i < bubbles.Count; i++)
            {
                for (int j = 0; j < bubbles[i].Count; j++)
                {
                    bubbles[i][j].IsVisited = false;
                }
            }
        }
    }
}
