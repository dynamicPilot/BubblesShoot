using BubblesShoot.ModelControllers;
using BubblesShoot.View.Interfaces;
using UnityEngine;

namespace BubblesShoot.View.StateControls
{
    public class SceneStartControl : IStartGame
    {
        private readonly GameObject _loadingCover;
        public SceneStartControl (GameObject loadingCover)
        {
            _loadingCover = loadingCover;
        }

        public virtual void StartGame()
        {
            Time.timeScale = 1.0f;
            _loadingCover.SetActive(false);
        }
    }

    public class SceneStartEndControl : SceneStartControl
    {
        private readonly IEndGameMenu _endGame;
        public SceneStartEndControl(GameObject loadingCover, IEndGameMenu endGame) :
            base(loadingCover)
        {
            _endGame = endGame;
        }

        public override void StartGame()
        {
            Time.timeScale = 1.0f;
            base.StartGame();
        }

        public void EndGame()
        {
            _endGame.EndGameMenu();
        }  
    }
}
