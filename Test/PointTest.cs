using NUnit.Framework;

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
            // Then 1*1 + 2*2 = 5 should be returned
            Assert.AreEqual(
                    point.DistanceToOrigin(),
                    5
            );
        }

        [Test]
        public void DistanceToOtherPointIsCalculatedCorrectly()
        {
            // Given Point(1,2)
            Point point = new Point(1, 2);
            // When DistanceTo(2, 4) is called
            // Then (2-1)*(2-1) + (4-2)*(4-2) = 5 should be returned
            Assert.AreEqual(
                    point.DistanceTo(2, 4),
                    5
            );
        }
    }
}