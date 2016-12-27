using NUnit.Framework;
using TowerDefenceTreehouse.MapObjects;

namespace TowerDefenceTreehouse.Test
{
    [TestFixture]
    public class MapTest
    {
        [Test]
        public void PointsOnTheMapShouldGiveTrueUsingOnMapMethod()
        {
            // Given Map with Width = 2, and Height = 2
            Map map = new Map(2, 2);
            // and validPoints:
            // (0,0)
            // (1,1)
            // (2,2) : edge case
            Point[] validPoints = new Point[3];
            validPoints[0] = new Point(0,0);
            validPoints[1] = new Point(1,1);
            validPoints[2] = new Point(2,2);

            // When we check whether points:
            // using onMap()
            // Then method should return "true"
            foreach (var point in validPoints)
            {
                Assert.True(map.OnMap(
                    point
                ));
            }
        }
        [Test]
        public void PointsOffTheMapShouldGiveFalseUsingOnMapMethod()
        {
            // Given Map with Width = 2, and Height = 2
            Map map = new Map(2, 2);
            // and invalidPoints:
            // (-1,-1) : both X and Y are bad
            // (-1, 0) : only X is bad
            // ( 0,-1) : only Y is bad
            // ( 2, 3) : only Y is bad
            // ( 3, 2) : only X is bad
            var invalidPoints = new Point[5];
            invalidPoints[0] = new Point(-1,-1);
            invalidPoints[1] = new Point(-1, 0);
            invalidPoints[2] = new Point( 0,-1);
            invalidPoints[3] = new Point( 2, 3);
            invalidPoints[4] = new Point( 3, 2);

            // When we check whether points:
            // using onMap()
            // Then method should return "false"
            foreach (var point in invalidPoints)
            {
                Assert.False(map.OnMap(
                    point
                ));
            }
        }

    }
}