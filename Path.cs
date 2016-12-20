using System.Linq;

namespace TowerDefenceTreehouse
{
    public class Path
    {
        private readonly MapLocation[] _path;

        /**
        Default constructor initializing {@code path}
        field.
        */
        public Path(MapLocation[] path)
        {
            _path = path;
        }

        /**
        Gets {@code MapLocation} at given {@code pathStep}.
        @param pathStep : index of element in MapLocation array
        {@code _path} field.
        @return MapLocation
        @throws OutOfBoundsException : when {@code pathStep}
        is out of bounds from {@code _path} field.
        */
        public MapLocation GetLocationAt(int pathStep)
        {
            if (pathStep < 0 || pathStep > _path.Length - 1)
            {
                throw new OutOfBoundsException(
                    "no MapLocation with this index found"
                );
            }
            return _path[pathStep];
        }
    }
}