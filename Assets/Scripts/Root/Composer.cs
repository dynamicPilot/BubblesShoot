using BubblesShoot.Model;
using BubblesShoot.Model.Bubbles;
using BubblesShoot.Model.Grids;
using BubblesShoot.Model.Interfaces;
using BubblesShoot.ModelControllers;
using BubblesShoot.Root.Interfaces;
using BubblesShoot.View;
using BubblesShoot.View.Common;
using BubblesShoot.View.Creators;
using BubblesShoot.View.DataControls;
using BubblesShoot.View.Factories;
using BubblesShoot.View.GuideSystem;
using BubblesShoot.View.Interfaces;
using BubblesShoot.View.StateControls;
using BubblesShoot.View.Updaters;
using UnityEngine;

namespace BubblesShoot.Root
{
    public class Composer : IComposer
    {
        private readonly SceneData _sceneData;
        private readonly StaticData _staticData;
        private IStartGame _iStartGame;
        private LevelData _levelData;
        public Composer(SceneData sceneData, LevelData levelData)
        {
            _sceneData = sceneData;
            _staticData = _sceneData.StaticData;
            _iStartGame = null;
            _levelData = levelData;
        }

        public IStartGame GetIStartGame()
        {
            return _iStartGame;
        }

        public bool IsReady()
        {
            return _iStartGame != null;
        }

        public void MakeSystems()
        {
            _iStartGame = null;

            // check level data
            if (!CheckLevelData(_levelData))
            {
                _iStartGame = new SceneLevelDataError(new SceneLoader(_staticData.MenuIndex));
                return;
            }
            
            int emptyRow = _staticData.EmptyRows;

            CoordinateGrid grid = GridConstructor.GetGrid(_levelData.Rows, _levelData.Columns, _sceneData.BubbleSize, emptyRow);

            // get bubbles
            //List<List<BubbleCell>> bubbles = BubblesConstructor.GetRandomBubbles(grid, emptyRow);
            var bubbles = BubblesConstructor.GetBubbles(grid, emptyRow, _levelData.IsRandomInitials, _levelData.BubblesColors);
            
            // check for floaters and update
            BubblesGraphUpdater.SearchForFloaters(bubbles);
            BubblesGraphUpdater.UpdateBubbleGraph(bubbles);

            IGenerateNewBubble generator = _levelData.IsRandomNew ? new RandomBubbleGenerator() : 
                new SpecificBubbleGenerator(_levelData.GeneratingBubbles);
            // game model
            GameModel model = new GameModel(new BubblesControl(bubbles, generator), new GridControl(grid));

            // camera
            var cameraUpdater = new CameraUpdater(new Transform[2] { Camera.main.transform, _sceneData.MoveWithCameraParent });
            var cameraSize = cameraUpdater.SetCameraAndGetSize(grid, Camera.main);
            Vector2 startPoint = new Vector2(0, - cameraSize.y / 2 + _sceneData.StartPositionDeltaFromScreenBottom);

            // bubble objects creator
            var scheme = new ColorScheme(_staticData);
            var getAndAddFree = new FreeBubblesContainer(_sceneData.ExternalUpdater, new BubbleUpdaterMethod());

            var bubbleCreator = new BubbleCreator(_sceneData.LocalFactory,_sceneData.BubblePrefab, _sceneData.BubblesParent,
                new BubbleSetup(scheme), new FreeBubbleSetup(scheme) , new InitialBubbleSetup(scheme),
                startPoint.y, _sceneData.MoveWithCameraParent, getAndAddFree);

            // view creator
            var viewCreator = new ViewCreator(bubbleCreator);

            // bubbles objects
            var objects = viewCreator.CreateBubbles(grid, bubbles);

            var sceneUpdater = new SceneUpdater(cameraUpdater,
                new ViewUpdater(objects, getAndAddFree), new UIUpdater(_sceneData.ScoreUI));

            var startEndControl = new SceneStartEndControl(_sceneData.Cover, _sceneData.PauseUIControl);
            var inputState = new InputStateControl(_sceneData.InputControl);
            //scene view
            var sceneView = new SceneView(new BubbleRoutine(_sceneData.PathContainer, bubbleCreator, _staticData.BubbleSpeed),
                sceneUpdater, startEndControl,
                inputState);

            // controller
            Controller controller = new Controller(model, sceneView);

            var pauseState = new PauseStateControl(controller, 
                new SceneLoader(_staticData.MenuIndex),
                inputState);

            _sceneData.PauseUIControl.StateControl = pauseState;

            var creators = GetCreators(startPoint, cameraSize, controller);
            
            // start
            viewCreator.CreateObject(creators);
            model.RegisterObserver(sceneView);

            _iStartGame = controller;
        }

        private bool CheckLevelData(LevelData data)
        {
            return LevelDataChecker.CheckLevelData(data);
        }

        private IObjectCreator[] GetCreators(Vector2 startPoint, Vector2 cameraSize, ISearchGrid searchGrid)
        {
            // start point
            var startPointCreator = new ObjectsCreator(_sceneData.LocalFactory,
                new PrefabCreator(_sceneData.StartPlacePrefab, startPoint, _sceneData.MoveWithCameraParent),
                new StartPointSetup(searchGrid, _sceneData.BubbleSize));

            float sideWallsAbsXPosition = cameraSize.x / 2 + _sceneData.WallDeltaFromCameraBorders;
            // left wall
            var leftWallCreator = new ObjectsCreator(_sceneData.LocalFactory,
                new PrefabCreator(_sceneData.WallPrefab, new Vector2(- sideWallsAbsXPosition, 0f), _sceneData.MoveWithCameraParent),
                null);
            
            // right wall
            var rightWallCreator = new ObjectsCreator(_sceneData.LocalFactory,
                new PrefabCreator(_sceneData.WallPrefab, new Vector2(sideWallsAbsXPosition, 0f), _sceneData.MoveWithCameraParent),
                null);

            float ceilingYPosition = cameraSize.y / 2 + _sceneData.CeilingDeltaFromCameraBorders;
            // ceiling
            var ceilingCreator = new ObjectsCreator(_sceneData.LocalFactory,
                new PrefabCreator(_sceneData.WallPrefab, new Vector2(0f, ceilingYPosition), _sceneData.MoveWithCameraParent),
                new CeilingSetup());

            IObjectCreator[] creators = new IObjectCreator[] { startPointCreator, leftWallCreator, rightWallCreator, ceilingCreator };

            return creators;
        }
    }
}
