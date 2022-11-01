using BubblesShoot.View.Common;
using BubblesShoot.View.Interfaces;
using UnityEngine;

namespace BubblesShoot.View.Factories
{
    public abstract class Factory : MonoBehaviour, IFactory
    {
        public abstract GameObject CreatePrefab(PrefabToCreate prefab);

    }
}
