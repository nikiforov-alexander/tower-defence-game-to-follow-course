using NUnit.Framework;

namespace TowerDefenceTreehouse.Test
{
    [TestFixture]
    public class InvaderTest
    {
        [Test]
        public void MoveMethodShouldChangePathStep()
        {
            // Given Invader with some Path
            Map map = new Map(10,10);
            Path path = new Path(
                new []
                {
                    new MapLocation(1,1, map),
                }
            );
            Invader invader = new Invader(path);

            // When Move() method is called
            invader.Move();

            // Then _pathStep should change to 1
            Assert.AreEqual(1, invader.PathStep);
        }

    }
}