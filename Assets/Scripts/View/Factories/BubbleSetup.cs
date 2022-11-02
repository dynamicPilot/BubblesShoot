using BubblesShoot.Model.Common;
using BubblesShoot.View.Common;
using UnityEngine;

namespace BubblesShoot.View.Factories
{
    public class BubbleSetup
    {
        private readonly ColorScheme _scheme;
        public BubbleSetup(ColorScheme scheme)
        {
            _scheme = scheme;
        }
        public virtual void SetupBubble(GameObject bubbleObject, COLOR color)
        {
            // set color
            SpriteRenderer renderer = bubbleObject.GetComponent<SpriteRenderer>();
            if (renderer != null) renderer.color = _scheme.GetColor(color);
        }
    }

    public class FreeBubbleSetup : BubbleSetup
    {
        public FreeBubbleSetup(ColorScheme scheme) : base(scheme)
        {
        }

        public override void SetupBubble(GameObject bubbleObject, COLOR color)
        {
            bubbleObject.SetActive(true);
            base.SetupBubble(bubbleObject, color);
        }
    }

    public class InitialBubbleSetup : BubbleSetup
    {
        public InitialBubbleSetup(ColorScheme scheme) : base(scheme)
        {
        }

        public override void SetupBubble(GameObject bubbleObject, COLOR color)
        {
            base.SetupBubble(bubbleObject, color);

            bubbleObject.GetComponent<CircleCollider2D>().enabled = true;
            bubbleObject.layer = LayerMask.NameToLayer("Bubbles&Walls");
        }

    }
}
