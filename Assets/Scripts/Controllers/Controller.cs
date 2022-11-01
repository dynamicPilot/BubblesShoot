using BubblesShoot.Model.Common;
using BubblesShoot.Model.Interfaces;
using BubblesShoot.View;
using BubblesShoot.View.Interfaces;
using BubblesShoot.View.StateControls;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BubblesShoot.ModelControllers
{
    public class Controller : ISearchGrid, IBubbleOnPlaceInformer, IStartGame, IQuitControl
    {
        private readonly IGameModel _gameModel;
        private readonly ISceneView _sceneView;
        public Controller(IGameModel gameModel, ISceneView sceneView)
        {
            _gameModel = gameModel;
            _sceneView = sceneView;
        }

        public void StartGame()
        {
            Debug.Log("Start Game!");
            _sceneView.StartGame();
            _sceneView.SpawnNewBubble(GetNewBubble(), this);
        }

        public void EndGame()
        {
            Debug.Log("End Game!");           
            _sceneView.EndGame();
        }

        public void QuitGame(bool restart)
        {
            _gameModel.QuitGame();
            _sceneView.QuitGame(restart);
        }

        public Tuple<Vector2, bool> GetPosition(Vector2 hitPoint)
        {
            return _gameModel.GetPosition(hitPoint);
        }

        private Bubble GetNewBubble()
        {
            return _gameModel.GetNewBubble();
            //return new Bubble(COLOR.red);
        }

        public void BubbleOnPlace(Vector2 position, Bubble bubble, GameObject bubbleObject)
        {
            Tuple<int,int> indexes = _gameModel.RegisterNewBubble(position, bubble);
            _sceneView.RegisterNewBubbleObject(bubbleObject, indexes);
            _gameModel.UpdateModel();
            CheckForEndGame();
        }

        private void CheckForEndGame()
        {
            bool isEndGame = _gameModel.CheckForEndGame();
            if (isEndGame) EndGame();
            else
            {
                _sceneView.ContinuePlaying();
                _sceneView.SpawnNewBubble(GetNewBubble(), this);
            }
        }

        public void BlockRaycast()
        {
            _sceneView.BlockRaycast();
        }
    }
}
