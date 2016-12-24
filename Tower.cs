﻿using System;

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

        // fields with class return type

        private readonly MapLocation _location;

        private readonly Random _random;

        // boolean properties

        /// <summary>
        /// <c>_random.NextDouble()</c> gives number
        /// from 0 to 1.
        ///
        /// If <c>Accuracy</c> is for example 0.75, that
        /// means that we will have numbers from
        /// [0, 0.75] with high probability when
        /// we say that condition is <c>randomDouble &amp;lt; Accuracy</c>
        ///
        /// That also means when <c>_random.NextDouble</c> will give
        /// a number from 0 to <c>Accuracy</c> we will have a successful
        /// shot
        /// </summary>
        /// <returns></returns>
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
            _random = random;
        }

        // Default constructor, used in actual Game

        public Tower(MapLocation location) :
            this(location,
                DefaultRange,
                DefaultPower,
                DefaultAccuracy,
                new Random())
        {
        }
    }
}