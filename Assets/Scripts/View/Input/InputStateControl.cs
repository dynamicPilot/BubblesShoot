using BubblesShoot.View.Interfaces;
using UnityEngine;

namespace BubblesShoot.View.StateControls
{
    public class InputStateControl : IRaycastControl
    {
        private readonly MonoBehaviour _inputControl;

        public InputStateControl(MonoBehaviour inputControl)
        {
            _inputControl = inputControl;
        }

        public void BlockRaycast()
        {
            _inputControl.enabled = false;
        }

        public void ContinueRaycast()
        {
            _inputControl.enabled = true;
        }
    }
}
