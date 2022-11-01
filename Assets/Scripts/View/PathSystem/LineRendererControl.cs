using BubblesShoot.View.Interfaces;
using UnityEngine;

namespace BubblesShoot.View.PathSystem
{
    [RequireComponent(typeof(LineRenderer))]
    public class LineRendererControl : MonoBehaviour, IPathUser
    {
        private LineRenderer _lineRenderer;
        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();
        }

        public void StartPath(Vector2 originPoint)
        {
            ResetPath();
            AddPoint(originPoint);
        }

        public void AddPoint(Vector2 point)
        {
            _lineRenderer.positionCount += 1;
            _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, point);
        }

        public void StopPath(bool endWithBubble)
        {
            
        }

        public void ResetPath()
        {
            _lineRenderer.positionCount = 0;
        }
    }
}
