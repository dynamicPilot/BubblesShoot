using BubblesShoot.Model.Interfaces;
using System;

namespace BubblesShoot.Model.Common
{
    public class BubbleCell
    {
        public Bubble Bubble { get; private set; }
        public bool IsEmpty { get; private set; }
        public Tuple<int, int>[] Neighbors { get; set; }
        public bool IsVisited { get; set; }
        public BubbleCell(Bubble bubble, Tuple<int,int>[] neighbors)
        {
            Bubble = bubble;
            IsEmpty = bubble == null;
            Neighbors = neighbors;
            IsVisited = false;
        }

        public void SetBubble(Bubble bubble)
        {
            Bubble = bubble;
            IsEmpty = Bubble == null;
        }
    }
}
