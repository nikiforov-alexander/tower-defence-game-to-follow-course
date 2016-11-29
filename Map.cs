using System;

namespace TowerDefenceTreehouse
{
    public class Map
    {
        public readonly int Width;
        public readonly int Height;

        public Map(int width, int height)
        {
            Width = width;
            Height = height;
        }


        /**
        Checks if {@code Point} is on the {@literal Map}.
        @param : {@literal Point} that is checked for this
                {@literal Map}
        @return : true if {@code point} is in [0,Map.Width],
        [0, Map.Height]
        */
        public bool OnMap(Point point)
        {
            return point.X <= Width &&
                   point.Y <= Height &&
                   point.X >= 0 &&
                   point.Y >= 0;
        }

    }
}