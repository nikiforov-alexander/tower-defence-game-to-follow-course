namespace TowerDefenceTreehouse.MapObjects
{
    public class Point
    {
        public readonly int X;
        public readonly int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        ///     Calculates distance from
        ///     <code>Point</code> to
        ///     passed <code>x</code> and <code>y</code>
        ///     arguments
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>
        ///     <code>Vector.Length</code> of
        ///     difference between coordinates
        ///     of <code>this</code> Point and
        ///     given coordinates.
        /// </returns>
        public int DistanceTo(int x, int y)
        {
            return Vector.Length(X - x, Y - y);
        }

        /// <summary>
        /// Calculates distance from <code>this</code>
        /// Point to origin (0,0) Point
        /// </summary>
        /// <returns>int : distance to origin </returns>
        public int DistanceToOrigin()
        {
            return Vector.Length(X, Y);
        }

        /// <summary>
        ///     Calculates distance from passed <code>point</code>
        ///     to <code>this</code> Point.
        /// </summary>
        /// <param name="point">Point</param>
        /// <returns>
        ///     DistanceTo() method defined above with
        ///     <code>point.x</code>
        ///     <code>point.y</code>
        /// </returns>
        public int DistanceTo(Point point)
        {
            return DistanceTo(point.X, point.Y);
        }
    }
}