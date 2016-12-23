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

        [Test]
        public void InvaderThatReachedEndOfThePathShouldHaveScoredAndBecomeInactive()
        {
            // Given inactive and not-scored TestInvader
            // with path.Length of 1
            // on some Map
            Assert.IsFalse(TestInvader.HasScored);
            Assert.IsTrue(TestInvader.IsActive);

            // When we move invader
            TestInvader.Move();

            // Then Invader.HasScored should be true
            Assert.IsTrue(TestInvader.HasScored);

            // Then Invader should be inactive
            Assert.IsFalse(TestInvader.IsActive);
        }

        [Test]
        public void InvaderThatLostHisHealthBecomesInactiveAndNeutralized()
        {
            // Given active and not-neutralized TestInvader
            // initialized with DefaultHealth
            // with path.Length of 1 on some Map
            Assert.False(TestInvader.IsNeutralized);
            Assert.True(TestInvader.IsActive);

            // When we decrease health by DefaultHealth
            TestInvader.DecreaseHealthBy(Invader.DefaultHealth);

            // Then Invader should be inactive and neutralized
            Assert.True(TestInvader.IsNeutralized);
            Assert.False(TestInvader.IsActive);
        }

    }
}