using UnityEngine;

namespace BubblesShoot.View.Interfaces
{
    public interface IPathUser
    {
        void StartPath(Vector2 point);
        void AddPoint(Vector2 point);
        void StopPath(bool endWithBubble);
        void ResetPath();
    }
}
