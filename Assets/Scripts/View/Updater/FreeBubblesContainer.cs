using BubblesShoot.View.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace BubblesShoot.View.Updaters
{
    public class FreeBubblesContainer : IAddObjectToFree, IGetFreeObject, IInjectUpdatedToFree
    {
        private Stack<GameObject> _freeObjects;
        private ObjectExternalUpdater _externalUpdater;
        private IUpdaterMethod _updaterMethod;
        public FreeBubblesContainer(ObjectExternalUpdater externalUpdater, IUpdaterMethod updaterMethod)
        {
            _freeObjects = new Stack<GameObject>();
            _externalUpdater = externalUpdater;
            _updaterMethod = updaterMethod;
        }

        public void AddObjectToFree(GameObject bubbleObject)
        {
            if (bubbleObject == null) return;
            if (_freeObjects.Contains(bubbleObject)) return;
            _externalUpdater.AddToUpdate(bubbleObject, _updaterMethod, this);
        }

        public void InjectObject(GameObject objs)
        {
            _freeObjects.Push(objs);
        }

        public GameObject GetFreeObject()
        {
            if (_freeObjects.Count == 0) return null;
            return _freeObjects.Pop();
        }


    }
}
