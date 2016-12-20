namespace TowerDefenceTreehouse
{
    public class Invader
    {
        // fields and properties

        private readonly Path _path;
        public int PathStep { get; private set; }

        public MapLocation Location => _path.GetLocationAt(PathStep);

        // constructors

        public Invader(Path path)
        {
            _path = path;
            PathStep = 0;
        }

        // other methods

        /**
        Moves Invader one step more.
        */
        public void Move()
        {
            PathStep += 1;
        }
    }
}