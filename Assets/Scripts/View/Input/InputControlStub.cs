using BubblesShoot.View.Interfaces;
using UnityEngine;

namespace BubblesShoot.View.Input
{
    public class InputControlStub : MonoBehaviour, IStartStopPress
    {
        [SerializeField] private Vector2 _point = new Vector2(-0.1f, 1.6f);
        public event IStartStopPress.StartPress OnStartPress;
        public event IStartStopPress.EndPress OnEndPress;

        private void OnEnable()
        {
            OnStartPress?.Invoke();
        }

        private void OnDisable()
        {
            OnEndPress?.Invoke();
        }

        Vector2 IStartStopPress.GetPosition()
        {
            return _point;
        }
    }
}
