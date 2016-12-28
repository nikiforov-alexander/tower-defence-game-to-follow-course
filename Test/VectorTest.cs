using NUnit.Framework;
using TowerDefenceTreehouse.MapObjects;

namespace TowerDefenceTreehouse.Test
{
    [TestFixture]
    public class VectorTest
    {
        [Test]
        public void VectorLengthSquaredShouldReturnCorrectValue()
        {
            // Given vector with coordinates (2, 1)
            // When Vector.LengthSquared(2,1) is called
            // Then 2*2 + 1*1 = 5 should be returned
            Assert.AreEqual(
                5,
                Vector.LengthSquared(2, 1)
            );
        }

        [Test]
        public void VectorLengthShouldReturnCorrectValue()
        {
            // Given vector with coordinates (2, 1)
            // When Vector.LengthSquared(2,1) is called
            // Then sqrt(2*2 + 1*1) = sqrt(5) = 2
            // should be returned
            Assert.AreEqual(
                2,
                Vector.Length(2, 1)
            );
        }

    }
}