using NUnit.Framework;
using TowerDefenceTreehouse.MapObjects;

namespace TowerDefenceTreehouse.Test
{
    [TestFixture]
    public class PointTest
    {
        [Test]
        public void DistanceToOriginIsCalculatedCorrectly()
        {
            // Given Point(1,2)
            Point point = new Point(1, 2);
            // When DistanceToOrigin() is called
            // Then sqrt(1*1 + 2*2) = sqrt(5) should be returned
            Assert.AreEqual(
                    2,
                    point.DistanceToOrigin()
            );
        }

        [Test]
        public void DistanceToXyIsCalculatedCorrectly()
        {
            // Given Point(1,2)
            Point point = new Point(1, 2);
            // When DistanceTo(2, 4) is called
            // Then sqrt[(2-1)*(2-1) + (4-2)*(4-2)] = sqrt(5) should be returned
            Assert.AreEqual(
                    2,
                    point.DistanceTo(2, 4)
            );
        }

        [Test]
        public void DistanceToOtherPointIsCalculatedCorrectly()
        {
            // Given Point(1,2)
            Point point = new Point(1, 2);
            // When DistanceTo(2, 4) is called
            // Then sqrt[(2-1)*(2-1) + (4-2)*(4-2)] = sqrt(5) should be returned
            Assert.AreEqual(
                    2,
                    point.DistanceTo(
                        new Point(2,4)
                    )
            );
        }
    }
}