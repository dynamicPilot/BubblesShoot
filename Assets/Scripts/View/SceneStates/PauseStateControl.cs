using BubblesShoot.View.Interfaces;
using UnityEngine;

namespace BubblesShoot.View.StateControls
{
    public class PauseStateControl : IPauseStateControl
    {
        private readonly IQuitControl _quitControl;
        private readonly SceneLoader _loader;
        private readonly IRaycastControl _raycastControl;

        public PauseStateControl(IQuitControl quitControl, SceneLoader sceneLoader, IRaycastControl raycastControl)
        {
            _quitControl = quitControl;
            _loader = sceneLoader;
            _raycastControl = raycastControl;
        }

        public void ContinueGame()
        {
            Time.timeScale = 1f;
            _raycastControl.ContinueRaycast();
        }

        public void PauseGame()
        {
            _raycastControl.BlockRaycast();
            Time.timeScale = 0f;
        }

        public void QuitGame(bool restart)
        {
            _quitControl.QuitGame(restart);
            if (restart) _loader.RestartScene();
            else _loader.LoadMainMenu();
        }
    }
}
