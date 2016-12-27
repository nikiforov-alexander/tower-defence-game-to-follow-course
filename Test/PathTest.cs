using NUnit.Framework;
using TowerDefenceTreehouse.MapObjects;

namespace TowerDefenceTreehouse.Test
{
    [TestFixture]
    public class PathTest
    {
        [Test]
        public void GetMapLocationShouldReturnCorrectLocation()
        {
            // Given the Path with array of MapLocation
            // with one "testMapLocation"
            // initialized in constructor
            Map map = new Map(10,10);
            MapLocation testMapLocation =
                new MapLocation(1,1, map);
            Path path = new Path(
                new [] {
                    testMapLocation
                }
            );

            // When GetLocationAt(0) is called
            MapLocation returedMapLocation =
                path.GetLocationAt(0);

            // Then correct MapLocation is returned
            Assert.AreEqual(testMapLocation, returedMapLocation);
        }

    }
}