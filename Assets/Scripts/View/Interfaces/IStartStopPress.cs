using UnityEngine;

namespace BubblesShoot.View.Interfaces
{
    public interface IStartStopPress
    {
        delegate void StartPress();
        event StartPress OnStartPress;
        delegate void EndPress();
        event EndPress OnEndPress;
        Vector2 GetPosition();

    }

}
