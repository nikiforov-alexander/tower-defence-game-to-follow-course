using System;

namespace TowerDefenceTreehouse
{
    public class Tower
    {
        // constants

        private const int Range = 1;
        private const int Power = 1;
        private const double Accuracy = .75;

        // static members

        private static readonly Random _random = new Random();

        // members with class return type

        private readonly MapLocation _location;

    }
}