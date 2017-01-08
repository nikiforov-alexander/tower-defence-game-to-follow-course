namespace TowerDefenceTreehouse.MapObjects
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


        /// <summary>
        ///     Checks if <code>Point</code> is on the
        ///     <code>Map</code>, by comparing <code>Point</code>
        ///     cooridantes with <code>Map.Width</code> and
        ///     <code>Map.Height</code>.
        /// </summary>
        /// <param name="point"> Point to be checked </param>
        /// <returns>
        ///     <code>true</code> if <code>point</code>
        ///     is on the <code>Map</code>,
        ///     <code>false</code> otherwise.
        /// </returns>
        public bool OnMap(Point point)
        {
            return point.X <= Width &&
                   point.Y <= Height &&
                   point.X >= 0 &&
                   point.Y >= 0;
        }

    }
}