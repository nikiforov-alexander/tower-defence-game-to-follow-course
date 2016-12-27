
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

        /**
            Checks if given {@code location} is in given
            {@code range}.
            @param : MapLocation location
            @param : int range
            @return boolean : true if distance to given {@code location}
            is less than {@code range}
        */
        public bool InRangeOf(MapLocation location, int range)
        {
            return DistanceTo(location) <= range;
        }
    }
}