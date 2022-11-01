using BubblesShoot.Model.Common;
using BubblesShoot.Model.Interfaces;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BubblesShoot.Model
{

    public class GameModel: IBubblesObservable, IGameModel
    {
        private BubblesControl _bubblesControl;
        private GridControl _gridControl;
        private List<IBubblesObserver> _observers;
        private int _score = 0;
        private bool _needUpdateObservers = false;
        public GameModel(BubblesControl bubbles, GridControl grid)
        {
            _bubblesControl = bubbles;
            _gridControl = grid;
            _observers = new List<IBubblesObserver>();
        }

        public Tuple<Vector2, bool> GetPosition(Vector2 hitPoint)
        {
            return _gridControl.GetPosition(hitPoint, _bubblesControl.Bubbles);
        }

        public Tuple<int,int> RegisterNewBubble(Vector2 position, Bubble bubble)
        {
            Tuple<int, int> indexes = _gridControl.GetIndexes(position);
            var result =_bubblesControl.RegisterNewBubble(indexes, bubble);
            Debug.Log("Score " + result.Item1);
            _score += result.Item1;

            _needUpdateObservers = result.Item2;
            if (_needUpdateObservers) _bubblesControl.AddRowToBubbles(_gridControl.AddRow());
            return indexes;            
        }

        public void UpdateModel()
        {
            var result = _bubblesControl.UpdateBubbles();
            _score += result.Item1;
            _needUpdateObservers |= result.Item2;            
        }

        public bool CheckForEndGame()
        {
            if (_needUpdateObservers) NotifyObservers();
            return _bubblesControl.IsEndGame();
        }

        private void NotifyObservers()
        {
            for (int i = 0; i < _observers.Count; i++)
            {
                _observers[i].UpdateView(_bubblesControl.Bubbles, _score);
            }
            _needUpdateObservers = false;
        }

        public void RegisterObserver(IBubblesObserver observer)
        {
            if (observer != null && !_observers.Contains(observer)) _observers.Add(observer);
        }

        public void RemoveObserver(IBubblesObserver observer)
        {
            if (_observers.Contains(observer)) _observers.Remove(observer);
        }

        public Bubble GetNewBubble()
        {
            return _bubblesControl.GetNewBubble();
        }
    }
}
