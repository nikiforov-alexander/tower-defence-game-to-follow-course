namespace TowerDefenceTreehouse
{
    public class Point
    {
        public readonly int X;
        public readonly int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        /**
        Returns distance from (x,y) of arguments
        to {@code this.Point}
        @param : int x
        @param : int y
        @return int : distance between (x,y) and
            (X,Y), i.e. (X-x)*(X-x) + (Y-y)*(Y-y)
        */
        public int DistanceTo(int x, int y)
        {
            return Vector.LengthSquared(X - x, Y - y);
        }

        /**
        Returns distance of {@code this.Point}
        to origin
        @return int : distance between (0,0) and
            (X,Y), i.e. (X)*(X) + (Y)*(Y)
        */
        public int DistanceToOrigin()
        {
            return Vector.LengthSquared(X, Y);
        }
    }
}