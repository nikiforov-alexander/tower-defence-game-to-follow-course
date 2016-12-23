using System;

namespace TowerDefenceTreehouse
{
    public class Tower
    {
        // constant fields

        private const int _range = 1;
        private const int _power = 1;
        private const double _accuracy = .75;

        // static fields

        private static readonly Random _random = new Random();

        // fields with class return type

        private readonly MapLocation _location;

        // boolean properties

        public bool IsSuccessfulShot()
        {
            return _random.NextDouble() < _accuracy;
        }

    }
}