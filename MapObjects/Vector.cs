using System;

namespace TowerDefenceTreehouse.MapObjects
{
    public class Vector
    {
        /**
        Simple method that calculates sum of
        squares of two passed arguments
        @param x : int
        @param y : int
        @return int : because in our game we don't care
        about decimal value
        */
        public static int LengthSquared(int x, int y)
        {
            return x * x + y * y;
        }
        /**
        Simple method where Math.Sqrt()
        is used with {@see #LengthSquared(x,y)}.
        @param x : int
        @param y : int
        @return int : because in our game we don't care
        about decimal value
        */
        public static int Length(int x, int y)
        {
            return (int) Math.Sqrt(LengthSquared(x, y));
        }
    }
}