using BubblesShoot.View.Interfaces;
using UnityEngine;


namespace BubblesShoot.View.Input
{
    public class InputControl : MonoBehaviour, IStartStopPress
    {
        private Controllers _controllers;
        private Camera _camera;

        public event IStartStopPress.StartPress OnStartPress;
        public event IStartStopPress.EndPress OnEndPress;

        private void Awake()
        {
            _controllers = new Controllers();
            _camera = Camera.main;
        }

        private void Start()
        {
            _controllers.PlayerActions.ContactAction.started += ctx => OnStartPress?.Invoke();
            _controllers.PlayerActions.ContactAction.canceled += ctx => OnEndPress?.Invoke();
        }

        private void OnEnable()
        {
            _controllers.Enable();
        }

        private void OnDisable()
        {
            _controllers.Disable();
        }

        public Vector2 GetPosition()
        {
            return _camera.ScreenToWorldPoint(_controllers.PlayerActions.PositionAction.ReadValue<Vector2>());
        }
    }
}
