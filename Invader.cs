namespace TowerDefenceTreehouse
{
    public class Invader
    {
        // fields and properties

        // constants

        public const int DefaultHealth = 10;

        // class properties

        private readonly Path _path;

        public MapLocation Location => _path.GetLocationAt(PathStep);

        // int properties

        public int PathStep { get; private set; }

        public int Health { get; private set; }

        // boolean properties

        // True if the invader reached the end of the path
        public bool HasScored
        {
            get { return PathStep >= _path.Length; }
        }

        public bool IsNeutralized => Health <= 0;

        public bool IsActive => !IsNeutralized && !HasScored;

        public bool IsHit { get; private set; }

        // constructors

        public Invader(Path path) : this(path, 0, DefaultHealth)
        {
        }

        public Invader(Path path, int pathStep, int health)
        {
            _path = path;
            PathStep = pathStep;
            Health = health;
            IsHit = false;
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
            IsHit = true;
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