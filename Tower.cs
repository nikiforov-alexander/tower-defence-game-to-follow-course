using System;

namespace TowerDefenceTreehouse
{
    public class Tower
    {
        // constant fields

        public const int DefaultRange = 1;
        public const int DefaultPower = 1;
        public const double DefaultAccuracy = .75;

        // properties with simple return type

        public int Range { get; }
        public int Power { get; }
        public double Accuracy { get; }

        // static fields

        private static readonly Random _random = new Random();

        // fields with class return type

        private readonly MapLocation _location;

        // boolean properties

        public bool IsSuccessfulShot()
        {
            return _random.NextDouble() < Accuracy;
        }

        // constructors

        public Tower(MapLocation location,
            int range,
            int power,
            double accuracy,
            Random random)
        {
            _location = location;
            Range = range;
            Power = power;
            Accuracy = accuracy;
            Random = random;
        }
    }
}