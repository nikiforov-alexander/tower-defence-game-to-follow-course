using System;
using System.Collections.Generic;
using TowerDefenceTreehouse.Invaders;
using TowerDefenceTreehouse.MapObjects;

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

        /// <summary>
        /// Checks if <c>Tower</c> is in range of
        /// <c>Invader</c> passed as argument.
        ///
        /// Method <c>InRangeOf</c> defined in
        /// <c>MapLocation</c> is used upon
        /// <c>_location</c> field with <c>Tower.Range</c>
        /// </summary>
        /// <param name="invader"></param>
        /// <returns>
        ///     <c>true</c> if invader is
        ///     in <c>Tower.Range</c>
        /// </returns>
        public bool IsInRangeOf(Invader invader) => _location.InRangeOf(invader.Location, Range);

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

        // methods

        /// <summary>
        ///     This method checks if list of invaders
        ///     passed as argument are active and in tower
        ///     range and fires at only one of them.
        ///
        ///     Miss, Hit and/or Killed messages will be printed.
        ///
        /// </summary>
        /// <param name="invaders">
        ///     list of invaders to be fired upon
        /// </param>
        public void FireOnInvaders(List<Invader> invaders)
        {
            foreach (Invader invader in invaders)
            {
                if (invader.IsActive && this.IsInRangeOf(invader))
                {
                    if (IsSuccessfulShot())
                    {
                        invader.DecreaseHealthBy(Power);
                        Console.WriteLine(invader + " is hit!");
                    }
                    else
                    {
                        Console.WriteLine(invader + " is missed!");
                    }

                    if (invader.IsNeutralized)
                    {
                        Console.WriteLine(invader + " is killed!");
                    }
                }
                else
                {
                    Console.WriteLine(invader + " is missed!");
                }
                break;
            }
        }
    }
}