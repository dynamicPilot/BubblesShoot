using BubblesShoot.View.Common;
using BubblesShoot.View.Interfaces;
using UnityEngine;

namespace BubblesShoot.View.Creators
{
    public class PrefabCreator : IPrefabCreator
    {
        private readonly GameObject _prefab;
        private readonly Vector2 _position;
        private readonly Transform _parent;
        public PrefabCreator(GameObject prefab, Vector2 position, Transform parent)
        {
            _prefab = prefab;
            _position = position;
            _parent = parent;
        }

        public PrefabToCreate GetPrefabToCreate()
        {
            return new PrefabToCreate
            {
                Prefab = _prefab,
                Parent = _parent,
                Position = _position
            };
        }
    }
}
