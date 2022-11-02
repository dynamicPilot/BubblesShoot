using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BubblesShoot.View.Interfaces
{
    public interface IGetFreeObject
    {
        GameObject GetFreeObject();
    }

    public interface IAddObjectToFree
    {
        void AddObjectToFree(GameObject obj);
    }

    public interface IInjectUpdatedToFree
    {
        void InjectObject(GameObject objs);
    }
}
