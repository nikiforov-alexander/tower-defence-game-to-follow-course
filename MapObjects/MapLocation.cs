
namespace TowerDefenceTreehouse.MapObjects
{
    public class MapLocation : Point
    {
        public MapLocation(int x, int y, MapObjects.Map map) : base(x, y)
        {
            if (!map.OnMap(this))
            {
                throw new OutOfBoundsException(x + ","
                                               + y +
                                               " is outside the boundaries of the map.");
            }
        }

        /// <summary>
        ///     Checks if given <c>location</c> is in
        ///     given <c>range</c>
        /// </summary>
        /// <param name="location">
        ///     Location, distance to which is
        ///     calculated
        /// </param>
        /// <param name="range"></param>
        /// <returns>
        ///     <c>true</c> if location is less than
        ///     given <code>range</code>
        /// </returns>
        public bool InRangeOf(MapLocation location, int range)
        {
            return DistanceTo(location) <= range;
        }
    }
}