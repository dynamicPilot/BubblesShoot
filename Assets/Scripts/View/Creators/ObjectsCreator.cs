using BubblesShoot.View.Common;
using BubblesShoot.View.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace BubblesShoot.View.Creators
{
    public class ObjectsCreator : IObjectCreator
    {
        private readonly IFactory _factory;
        private readonly ISetupObject _setupObject;
        private readonly IPrefabCreator _prefabCreator;
        public ObjectsCreator(IFactory factory, IPrefabCreator prefabCreator, ISetupObject setupObject)
        {
            _factory = factory;
            _setupObject = setupObject;
            _prefabCreator = prefabCreator;
        }
        public void CreateObject()
        {
            GameObject gameObject = _factory.CreatePrefab(_prefabCreator.GetPrefabToCreate());
            if (_setupObject != null) _setupObject.SetupObject(gameObject);
        }
    }
}
