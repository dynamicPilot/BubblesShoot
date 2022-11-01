using BubblesShoot.View.Common;
using UnityEngine;

namespace BubblesShoot.View.Factories
{
    public class UIFactory : Factory
    {
        public override GameObject CreatePrefab(PrefabToCreate prefab)
        {
            return Instantiate(prefab.Prefab, prefab.Parent);
        }
    }
}
