using BubblesShoot.View.Interfaces;
using UnityEngine;

namespace BubblesShoot.View.StateControls
{
    public class PauseMenuUIControl : MonoBehaviour, IEndGameMenu
    {
        [HideInInspector] public IPauseStateControl StateControl { private get; set; }
        [SerializeField] private GameObject _panel;
        [SerializeField] private GameObject _continueButton;

        private void Awake()
        {
            _panel.SetActive(false);
        }

        public void PauseGame()
        {
            StateControl.PauseGame();
            _continueButton.SetActive(true);
            _panel.SetActive(true);
        }

        public void ContinueGame()
        {
            StateControl.ContinueGame();
            _panel.SetActive(false);
        }

        public void QuitGame(bool restart)
        {
            StateControl.QuitGame(restart);
        }

        public void EndGameMenu()
        {
            _continueButton.SetActive(false);
            _panel.SetActive(true);
        }
    }

}
