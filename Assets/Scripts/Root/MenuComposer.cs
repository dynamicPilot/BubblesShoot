using BubblesShoot.ModelControllers;
using BubblesShoot.Root.Interfaces;
using BubblesShoot.View;
using BubblesShoot.View.Creators;
using BubblesShoot.View.MainMenu;
using BubblesShoot.View.StateControls;
using UnityEngine;

namespace BubblesShoot.Root
{
    public class MenuComposer : IComposer
    {
        private readonly MenuSceneData _sceneData;
        private readonly DataContainer _dataContainer;
        private IStartGame _startGame;

        public MenuComposer(MenuSceneData sceneData, DataContainer dataContainer)
        {
            _sceneData = sceneData;
            _startGame = null;
            _dataContainer = dataContainer;
        }
        public IStartGame GetIStartGame()
        {
            return _startGame;
        }

        public bool IsReady()
        {
            return _startGame != null;
        }

        public void MakeSystems()
        {
            _startGame = null;
            var menuControl = new MainMenuControl(new SceneLoader(0), _dataContainer);
            
            var slotCreator = new LevelSlotsCreator(_sceneData.MenuUI, _sceneData.Factory,
                new PrefabCreator(_sceneData.LevelSlotPrefab, Vector2.one, _sceneData.LevelSlotParent).GetPrefabToCreate());

            _sceneData.MenuUI.StartLevelControl = menuControl;
            _sceneData.MenuUI.SetChooseLevelButtonState(slotCreator.CreateSlots(_sceneData.Storage.Levels));

            _startGame = new SceneStartControl(_sceneData.LoadingPanel);

        }
    }
}
