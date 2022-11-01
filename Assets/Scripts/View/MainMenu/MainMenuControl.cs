using BubblesShoot.Root;
using BubblesShoot.View.Common;
using BubblesShoot.View.MainMenu.Interfaces;

namespace BubblesShoot.View.MainMenu
{
    public class MainMenuControl : IStartLevel
    {
        private readonly SceneLoader _sceneLoader;
        private readonly DataContainer _container;
        public MainMenuControl(SceneLoader sceneLoader, DataContainer container)
        {
            _sceneLoader = sceneLoader;
            _container = container;
        }

        public void StartLevel(LevelData data)
        {
            if (data == null) return;
            _container.Data = data;
            _sceneLoader.LoadSceneByIndex(data.SceneIndex);
        }
    }
}
