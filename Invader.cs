namespace TowerDefenceTreehouse
{
    public class Invader
    {
        private readonly Path _path;
        public int PathStep { get; private set; }

        public MapLocation Location => _path.GetLocationAt(PathStep);

        public Invader(Path path)
        {
            _path = path;
            PathStep = 0;
        }

        /**
        Moves Invader one step more.
        */
        public void Move()
        {
            PathStep += 1;
        }
    }
}