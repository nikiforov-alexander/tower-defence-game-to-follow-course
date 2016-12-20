namespace TowerDefenceTreehouse
{
    public class Invader
    {
        private readonly Path _path;
        private int _pathStep;

        public MapLocation Location => _path.GetLocationAt(_pathStep);

        public Invader(Path path)
        {
            _path = path;
            _pathStep = 0;
        }

        /**
        Moves Invader one step more.
        */
        public void Move()
        {
            _pathStep += 1;
        }
    }
}