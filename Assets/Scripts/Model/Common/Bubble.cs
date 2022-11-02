namespace BubblesShoot.Model.Common
{
    public enum COLOR { red, blue, yellow, green, none }

    public class Bubble
    {
        public COLOR Color { get; private set; }

        public Bubble(COLOR color)
        {
            Color = color;
        }
    }
}
