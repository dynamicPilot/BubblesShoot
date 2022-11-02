using BubblesShoot.View.Interfaces;
using UnityEngine;

namespace BubblesShoot.View.Updaters
{
    public class BubbleUpdaterMethod : IUpdaterMethod
    {
        public void Updater(GameObject gameObject)
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            gameObject.layer = LayerMask.NameToLayer("TranspBubbles");
        }
    }
}
