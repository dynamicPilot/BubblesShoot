using BubblesShoot.View.Interfaces;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BubblesShoot.View.Updaters
{
    public class ObjectExternalUpdater : MonoBehaviour
    {
        private List<Tuple<GameObject, IUpdaterMethod>> _toUpdate;
        private List<IInjectUpdatedToFree> _toInjectScripts;
        private void Awake()
        {
            _toUpdate = new List<Tuple<GameObject, IUpdaterMethod>>();
            _toInjectScripts = new List<IInjectUpdatedToFree>();
        }

        private void Update()
        {
            if (_toUpdate.Count == 0) return;

            for(int i = 0; i < _toUpdate.Count; i++)
            {
                var element = _toUpdate[i];
                element.Item2.Updater(element.Item1);
            }

            InjectUpdated();
        }

        public void AddToUpdate(GameObject gameObject, IUpdaterMethod updaterMethod, IInjectUpdatedToFree toInject)
        {
            _toInjectScripts.Add (toInject);
            _toUpdate.Add(new Tuple<GameObject, IUpdaterMethod>(gameObject, updaterMethod));
        }

        private void InjectUpdated()
        {
            for (int i = 0; i< _toInjectScripts.Count; i++)
            {
                _toInjectScripts[i].InjectObject(_toUpdate[i].Item1);
            }

            _toUpdate.Clear();
            _toInjectScripts.Clear();
        }

    }
}
