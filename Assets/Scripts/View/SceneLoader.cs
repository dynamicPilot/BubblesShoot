using BubblesShoot.View.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BubblesShoot.View
{
    public class SceneLoader
    {
        private readonly int _menuSceneIndex = 0;       

        public SceneLoader(int menuSceneIndex)
        {
            _menuSceneIndex = menuSceneIndex;
        }

        public void LoadMainMenu()
        {
            LoadSceneByIndexAsync(_menuSceneIndex);
        }

        public void RestartScene()
        {
            LoadSceneByIndexAsync(SceneManager.GetActiveScene().buildIndex);
        }

        public void LoadSceneByIndex(int index)
        {
            LoadSceneByIndexAsync(index);
        }

        private void LoadSceneByIndexAsync(int index)
        {
            SceneManager.LoadSceneAsync(index, LoadSceneMode.Single);
        }
    }
}
