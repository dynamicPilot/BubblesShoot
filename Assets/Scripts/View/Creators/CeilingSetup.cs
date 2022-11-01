using BubblesShoot.View.Interfaces;
using UnityEngine;

namespace BubblesShoot.View.Creators
{
    public class CeilingSetup : ISetupObject
    {
        public void SetupObject(GameObject gameObject)
        {
            gameObject.transform.Rotate(0f, 0f, 90f);
        }
    }
}
