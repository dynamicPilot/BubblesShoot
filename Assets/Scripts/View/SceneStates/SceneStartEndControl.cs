using BubblesShoot.View.Interfaces;
using UnityEngine;

namespace BubblesShoot.View.StateControls
{
    public class SceneStartEndControl
    {
        private readonly GameObject _loadingCover;
        private readonly IEndGameMenu _endGame;
        public SceneStartEndControl(GameObject loadingCover, IEndGameMenu endGame)
        {
            _loadingCover = loadingCover;
            _endGame = endGame;
        }

        public void StartGame()
        {
            Time.timeScale = 1.0f;
            _loadingCover.SetActive(false);
        }

        public void EndGame()
        {
            _endGame.EndGameMenu();
        }  
    }
}
