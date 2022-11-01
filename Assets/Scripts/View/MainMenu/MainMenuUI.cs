using BubblesShoot.View.MainMenu.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace BubblesShoot.View.MainMenu
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private LevelDataStorage _storage;
        [SerializeField] private Button _levelChooseButton;
        public IStartLevel StartLevelControl { private get; set; }
        public void StartLevel(int index)
        {
            StartLevelControl.StartLevel(_storage.GetLevelByIndex(index));
        }

        public void SetChooseLevelButtonState(bool state)
        {
            _levelChooseButton.interactable = state;
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }

}
