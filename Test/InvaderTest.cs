using NUnit.Framework;

namespace TowerDefenceTreehouse.Test
{
    [TestFixture]
    public class InvaderTest
    {
        // test invader used in tests,
        // set up in [setUp] method
        public Invader TestInvader
        {
            get;
            set;
        }

        [SetUp]
        public void SetUp()
        {
            Map map = new Map(10,10);
            Path path = new Path(
                new []
                {
                    new MapLocation(1,1, map),
                }
            );
            TestInvader = new Invader(path);
        }

        [Test]
        public void MoveMethodShouldChangePathStep()
        {
            // Given TestInvader with some Path
            // on some Map with some MapLocation

            // When Move() method is called
            TestInvader.Move();

            // Then PathStep should change to 1
            Assert.AreEqual(1, TestInvader.PathStep);
        }

    }
}