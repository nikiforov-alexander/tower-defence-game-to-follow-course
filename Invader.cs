namespace TowerDefenceTreehouse
{
    public class Invader
    {
        // fields and properties

        private readonly Path _path;

        public int PathStep { get; private set; }

        public int Health { get; private set; }

        public MapLocation Location => _path.GetLocationAt(PathStep);

        // True if the invader reached the end of the path
        public bool HasScored
        {
            get { return PathStep >= _path.Length; }
        }

        // constructors

        public Invader(Path path) : this(path, 0, 10)
        {
        }

        public Invader(Path path, int pathStep, int health)
        {
            _path = path;
            PathStep = pathStep;
            Health = health;
        }

        // other methods

        /**
        Moves Invader one step more.
        */
        public void Move()
        {
            PathStep += 1;
        }

        /**
        Decreseas health of invader by given amount
        @param : amount - to be decreased from
        {@code Health}.
        */
        public void DecreaseHealthBy(int amount)
        {
            Health -= amount;
        }
        /**
        Decreseas {@code Health} of invader by 1
        */
        public void DecreaseHealthBy()
        {
            DecreaseHealthBy(1);
        }
    }
}