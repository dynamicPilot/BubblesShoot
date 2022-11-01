
using BubblesShoot.View.UI;

namespace BubblesShoot.View.Updaters
{
    public class UIUpdater
    {
        private readonly ScoreUI _scoreUI;
        public UIUpdater(ScoreUI scoreUI)
        {
            _scoreUI = scoreUI;
        }

        public void UpdateScore(int score)
        {
            _scoreUI.UpdateText(score);
        }
    }
}
