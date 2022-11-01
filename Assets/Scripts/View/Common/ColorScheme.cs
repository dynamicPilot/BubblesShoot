using BubblesShoot.Model.Common;
using System.Collections.Generic;
using UnityEngine;

namespace BubblesShoot.View.Common
{
    public class ColorScheme 
    {
        private IDictionary<COLOR, Color> _colors;

        public ColorScheme(StaticData staticData)
        {
            _colors = new Dictionary<COLOR, Color>();

            _colors.Add(COLOR.red, staticData.RedColor);
            _colors.Add(COLOR.blue, staticData.BlueColor);
            _colors.Add(COLOR.green, staticData.GreenColor);
            _colors.Add(COLOR.yellow, staticData.YellowColor);
        }

        public Color GetColor(COLOR color)
        {
            return _colors.ContainsKey(color) ? _colors[color] : Color.clear;
        }


    }
}
