using BubblesShoot.View.Interfaces;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace BubblesShoot.View.PathSystem
{
    [RequireComponent(typeof(LineRendererControl))]
    [RequireComponent(typeof(ModelHelper))]
    public class PathDetection : MonoBehaviour
    {       
        [SerializeField] private float _maxLength = 10f;
        [SerializeField] private int _maxReflectionsNumber = 3;

        private IStartStopPress _inputControl;
        private ModelHelper _modelHelper;
        private List<IPathUser> _users;

        private RaycastHit2D _hit;
        private Ray2D _ray;

        private float _bubbleSize;

        private bool _pauseUpdate = true;
        private bool _hitBubble = false;
        private void Awake()
        {            
            _modelHelper = GetComponent<ModelHelper>();
            _users = new List<IPathUser>();
            _users.AddRange(GetComponents<IPathUser>());

            var pathContainer = GameObject.FindGameObjectWithTag("SceneData").GetComponent<PathContainer>();
            if (pathContainer == null) Debug.LogError("PathDetection : No PathContainer Object");
            _users.Add(pathContainer);
            _inputControl = pathContainer.GetComponent<IStartStopPress>();
        }
        private void Start()
        {
            _bubbleSize = _modelHelper.BubbleSize;
        }

        private void OnEnable()
        {
            _pauseUpdate = true;
            _inputControl.OnStartPress += StartDetection;
            _inputControl.OnEndPress += StopDetection;
        }

        private void OnDisable()
        {
            _inputControl.OnStartPress -= StartDetection;
            _inputControl.OnEndPress -= StopDetection;
        }

        private void StartDetection()
        {
            _pauseUpdate = false;
        }

        private void StopDetection()
        {
            _pauseUpdate = true;
            UsersStopPath();
        }

        private void Update()
        {
            if (_pauseUpdate) return;
            DrawPath();
        }

        private void DrawPath()
        {
            Vector2 origin = gameObject.transform.position;
            Vector2 position = _inputControl.GetPosition();
            Vector2 direction = (position - origin).normalized;
            float lengthRemain = _maxLength;

            UsersAddPoint(origin, true);

            for (int i = 0; i < _maxReflectionsNumber; i++)
            {
                _ray = new Ray2D(origin, direction);
                //_hit = Physics2D.Raycast(_ray.origin, _ray.direction, lengthRemain);
                _hit = Physics2D.CircleCast(_ray.origin, _bubbleSize / 2, _ray.direction,lengthRemain);

                if (_hit.collider)
                {
                    bool hitWall = _hit.collider.gameObject.CompareTag("Wall");
                    _hitBubble = _hit.collider.gameObject.CompareTag("Bubble");

                    direction = Vector2.Reflect(_ray.direction, _hit.normal);

                    origin = hitWall ? CorrectHitPointWhenHitWall(_hit.point, _hit.normal) : 
                        _hitBubble ? CorrectHitPointWhenHitBubble(_hit.point) : _hit.point;

                    lengthRemain -= Vector2.Distance(_ray.origin, origin);

                    UsersAddPoint(origin);
                    //Debug.DrawLine(_ray.origin, origin, Color.magenta);

                    if (!hitWall || lengthRemain <= 0)
                    {
                        UsersStopPath(_hitBubble, true);
                        break;
                    }

                }
                else
                {
                    UsersAddPoint(_ray.origin + _ray.direction * lengthRemain);
                    break;
                }
            }
        }

        private Vector2 CorrectHitPointWhenHitBubble(Vector2 hitPoint)
        {
            var result = _modelHelper.GetPosition(hitPoint);
            if (result.Item2) return result.Item1;
            else
            {
                _hitBubble = false;
                return hitPoint;
            }
        }

        private Vector2 CorrectHitPointWhenHitWall(Vector2 hitPoint, Vector2 hitNormal)
        {
            float sideV = Vector2.Dot(Vector2.down, hitNormal); // 1 - bottom, -1 - top
            float sideH = Vector2.Dot(Vector2.right, hitNormal); // 1 - left wall, -1 - right wall

            return new Vector2(hitPoint.x + sideH * _bubbleSize / 2, hitPoint.y + sideV * _bubbleSize / 2);
        }

        private void UsersAddPoint(Vector2 point, bool start = false)
        {
            for (int i = 0; i < _users.Count; i++)
            {
                if (start) _users[i].StartPath(point);
                else _users[i].AddPoint(point);
            }
        }

        private void UsersStopPath(bool endWithBubble = false, bool stop = false)
        {
            for (int i = 0; i < _users.Count; i++)
            {
                if (stop) _users[i].StopPath(endWithBubble);
                else _users[i].ResetPath();
            }
                
        }

    }

}
