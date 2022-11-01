using BubblesShoot.View.Factories;
using BubblesShoot.View.Input;
using BubblesShoot.View.PathSystem;
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

        [Header("Others")]
        public PathContainer PathContainer;
        public InputControl InputControl;
        public StaticData StaticData;
    }
}
