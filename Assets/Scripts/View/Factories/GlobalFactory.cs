using BubblesShoot.View.Common;
using UnityEngine;

namespace BubblesShoot.View.Factories
{
    public class GlobalFactory : Factory
    {
        public override GameObject CreatePrefab(PrefabToCreate prefab)
        {
            return Instantiate(prefab.Prefab, prefab.Position, Quaternion.identity, prefab.Parent);
        }
    }
}
