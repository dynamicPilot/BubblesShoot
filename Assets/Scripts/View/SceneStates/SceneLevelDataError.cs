using BubblesShoot.ModelControllers;

namespace BubblesShoot.View.StateControls
{
    public class SceneLevelDataError : IStartGame
    {
        private readonly SceneLoader _loader;

        public SceneLevelDataError(SceneLoader loader)
        {
            _loader = loader;
        }

        public void StartGame()
        {
            _loader.LoadMainMenu();
        }
    }
}
