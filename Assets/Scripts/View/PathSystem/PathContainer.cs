using BubblesShoot.View.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace BubblesShoot.View.PathSystem
{
    public class PathContainer : MonoBehaviour, IPathUser
    {
        [SerializeField] private List<Vector2> _path;

        public delegate void PathReady(Vector2[] path);
        public event PathReady OnPathReady;
        private bool _endWithBubble;

        private void Awake()
        {
            _path = new List<Vector2>();
        }

        public void StartPath(Vector2 point)
        {
            _path.Clear();
            _endWithBubble = false;
            _path.Add(point);
        }

        public void AddPoint(Vector2 point)
        {
            _path.Add(point);
        }

        public void StopPath(bool endWithBubble)
        {
            _endWithBubble = endWithBubble;
        }

        public void ResetPath()
        {
            if (_endWithBubble) OnPathReady?.Invoke(_path.ToArray());
            _endWithBubble = false;
        }
    }
}
