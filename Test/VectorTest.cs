using NUnit.Framework;

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
                Vector.LengthSquared(2, 1),
                5
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
                Vector.LengthSquared(2, 1),
                2
            );
        }

    }
}