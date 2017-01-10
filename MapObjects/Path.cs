namespace TowerDefenceTreehouse.MapObjects
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

        public int Length => _path.Length;

        /// <summary>
        /// Gets <code>MapLocation</code> at given
        /// <code>pathStep</code> : index of element in
        /// <code>MapLocation</code> array <code>_path</code> field.
        /// </summary>
        /// <param name="pathStep"></param>
        /// <returns>
        ///     MapLocation object at <code>pathStep</code>
        ///     index of <code>_path</code>
        /// </returns>
        /// <exception cref="OutOfBoundsException">
        ///     if <code>pathStep</code> is out of bounds of
        ///     <code>_path</code> array.
        /// </exception>
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