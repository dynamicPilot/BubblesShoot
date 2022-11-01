using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BubblesShoot.View.MainMenu
{
    public class LevelSlotUI : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private TextMeshProUGUI _text;
        private MainMenuUI _mainMenu;
        private int _levelIndex;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_mainMenu != null) _mainMenu.StartLevel(_levelIndex);
        }

        public void SetLevel(int number, int index, MainMenuUI menuUI)
        {
            _text.SetText(String.Format("{0:D2}", number));
            _levelIndex = index;
            _mainMenu = menuUI;
        }
    }
}
