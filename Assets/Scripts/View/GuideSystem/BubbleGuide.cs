using BubblesShoot.Model.Common;
using BubblesShoot.Model.Interfaces;
using UnityEngine;

namespace BubblesShoot.View.GuideSystem
{
    public class BubbleGuide : MonoBehaviour
    {
        private Rigidbody2D _rb;
        private Vector2[] _path;
        private float _positionDelta = 0.01f;
        private float _speed = 1.5f;
        private IBubbleOnPlaceInformer _informer;
        private Bubble _bubble;

        private int _pathIndex = -1;
        private Vector2 _currentTarget;
        private bool _pauseUpdate = true;

        public void StartBubble(Vector2[] path, Bubble bubble,IBubbleOnPlaceInformer informer, float speed = 1.5f)
        {
            _path = path;
            _bubble = bubble;
            _speed = speed;
            _rb = GetComponent<Rigidbody2D>();
            _informer = informer;
            _pauseUpdate = true;
            SetNextTarget();
        }

        private void SetNextTarget()
        {
            _pathIndex++;
            if (_pathIndex >= _path.Length)
            {
                EndPath();
                return;
            }

            _currentTarget = _path[_pathIndex];
            Vector2 velocity = (_currentTarget - _rb.position).normalized;
            _rb.velocity = velocity;
            _pauseUpdate = false;
        }

        private void OnDestroy()
        {
            GetComponent<CircleCollider2D>().enabled = true;
        }

        private void FixedUpdate()
        {
            if (_pauseUpdate) return;

            if (Mathf.Abs(Vector2.Distance(_rb.position, _currentTarget)) <= _positionDelta)
            {
                _rb.velocity = Vector2.zero;
                _rb.position = _currentTarget;
                SetNextTarget();
            }
        }

        private void EndPath()
        {
            _pauseUpdate = true;
            _informer.BubbleOnPlace(_currentTarget, _bubble, gameObject);
            Destroy(this);
        }


    }
}
