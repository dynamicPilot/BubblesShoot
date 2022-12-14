using BubblesShoot.View.Factories;
using BubblesShoot.View.Input;
using BubblesShoot.View.PathSystem;
using BubblesShoot.View.StateControls;
using BubblesShoot.View.UI;
using BubblesShoot.View.Updaters;
using UnityEngine;

namespace BubblesShoot.View.Common
{
    public class SceneData : MonoBehaviour
    {
        [Header("Bubble")]
        public float BubbleSize = 0.32f;
        public GameObject BubblePrefab;        
        public Transform BubblesParent;

        [Header("Parent for objects\nthat move with Camera")]
        public Transform MoveWithCameraParent;

        [Header("Start Place")]
        public GameObject StartPlacePrefab;
        public float StartPositionDeltaFromScreenBottom = 0.28f;

        [Header("Walls")]
        public GameObject WallPrefab;
        public float WallDeltaFromCameraBorders;
        public float CeilingDeltaFromCameraBorders;

        [Header("Factories")]
        public Factory LocalFactory;
        public Factory GlobalFactory;

        [Header("UI")]
        public ScoreUI ScoreUI;
        public PauseMenuUIControl PauseUIControl;
        public GameObject Cover;

        [Header("Others")]
        public PathContainer PathContainer;
        public InputControl InputControl;
        public StaticData StaticData;
        public ObjectExternalUpdater ExternalUpdater;
    }
}
