using BubblesShoot.View.Common;
using UnityEngine;

namespace BubblesShoot.View.Factories
{
    public class LocalFactory : Factory
    {
        public override GameObject CreatePrefab(PrefabToCreate prefab)
        {
            var temp = Instantiate(prefab.Prefab);
            temp.transform.parent = prefab.Parent;
            temp.transform.localPosition = prefab.Position;
            return temp;
        }
    }
}
