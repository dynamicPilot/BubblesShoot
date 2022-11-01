using BubblesShoot.Model.Common;
using System.Collections.Generic;

namespace BubblesShoot.Model.Interfaces
{
    public interface IBubblesObserver
    {
        void UpdateView(List<List<BubbleCell>> bubbles, int score);
    }

    public interface IBubblesObservable
    {
        void RegisterObserver(IBubblesObserver observer);
        void RemoveObserver(IBubblesObserver observer);
    }
}
