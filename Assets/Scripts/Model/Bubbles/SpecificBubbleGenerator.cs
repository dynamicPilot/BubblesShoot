using BubblesShoot.Model.Common;
using BubblesShoot.Model.Interfaces;

namespace BubblesShoot.Model.Bubbles
{
    public class SpecificBubbleGenerator : IGenerateNewBubble
    {
        private readonly COLOR[] _colors;
        int _index;
        public SpecificBubbleGenerator(COLOR[] colors)
        {
            _colors = colors;
            _index = 0;
        }

        public Bubble GenerateNewBubble()
        {
            UpdateIndex();
            return new Bubble(_colors[_index++]);
            
        }

        private void UpdateIndex()
        {
            if (_index >= _colors.Length) _index %= _colors.Length;

            while (_colors[_index] == COLOR.none)
            {
                _index++;
                _index %= _colors.Length;
            }
        }
    }
}
