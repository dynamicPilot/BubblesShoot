using UnityEngine;
using TMPro;
using System;

namespace BubblesShoot.View.UI
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        private void Awake()
        {
            UpdateText(0);
        }
        public void UpdateText(int score)
        {
            _text.SetText(String.Format("{0:D3}", score));
        }
    }
}
