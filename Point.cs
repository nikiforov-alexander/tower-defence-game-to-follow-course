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
            (X,Y). {@see #Vector.Length()}
        */
        public int DistanceTo(int x, int y)
        {
            return Vector.Length(X - x, Y - y);
        }

        /**
        Returns distance of {@code this.Point}
        to origin
        @return int : distance between (0,0) and
            (X,Y), {@see #Vector.Length()}
        */
        public int DistanceToOrigin()
        {
            return Vector.Length(X, Y);
        }

        /**
        Returns distance from passed {@code Point}
        to {@code this.Point}
        @param : Point point : to which distance is calculated
        @return int : distance between (point.X,point.Y) and
            (this.X,this.Y). {@see #DistanceTo()}
        */
        public int DistanceToPoint(Point point)
        {
            return DistanceTo(point.X, point.Y);
        }
    }
}