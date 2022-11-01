using BubblesShoot.Model.Common;
using BubblesShoot.View.Common;
using UnityEngine;

namespace BubblesShoot.View.Interfaces
{
    public interface IFactory
    {
        GameObject CreatePrefab(PrefabToCreate prefab);
    }

    public interface IObjectCreator
    {
        void CreateObject();
    }

    public interface IPrefabCreator
    {
        PrefabToCreate GetPrefabToCreate();
    }

    public interface ISetupObject
    {
        void SetupObject(GameObject gameObject);
    
    }

}
