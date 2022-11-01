using BubblesShoot.View.Factories;
using UnityEngine;

namespace BubblesShoot.View.MainMenu
{
    public class MenuSceneData : MonoBehaviour
    {
        public MainMenuUI MenuUI;
        public LevelDataStorage Storage;
        public Factory Factory;

        [Header("UI")]
        public GameObject LevelSlotPrefab;
        public Transform LevelSlotParent;
        public GameObject LoadingPanel;
    }
}
