using System;
using System.IO;
using Moq;
using NUnit.Framework;

namespace TowerDefenceTreehouse.Test
{
    [TestFixture]
    public class TowerTest
    {
        public Map TestMap;
        public Tower TestTower;
        public Mock<Random> RandomMock;
        public Invader TestInvaderInTowerRange;

        /// <summary>
        /// here we set up only <c>TestMap</c>
        /// 5
        /// 4
        /// 3
        /// 2
        /// 1   t
        /// 0
        ///   0 1 2 3 4 5
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            TestMap = new Map(5, 5);
        }

        /// <summary>
        /// This method sets up <code>TestTower</code>
        /// to be located at (1,1) position,
        /// <see cref="TowerTest.SetUp"/>.
        ///
        /// It also mocks using Moq framework the <c>Random</c>
        /// class that is passed to constructor of
        /// <c>TestTower</c>
        ///
        /// </summary>
        /// <param name="randomDoubleValue">
        ///     This value is used to be compared with <c>Accuracy</c>
        ///     in <c>Tower</c> class, <see cref="Tower.IsSuccessfulShot"/>
        ///     for more.
        /// </param>
        private void SetUpTowerLocationWithRandomDoubleValue(double randomDoubleValue)
        {
            RandomMock = new Mock<Random>();

            RandomMock.Setup(
                rand => rand.NextDouble()
            ).Returns(randomDoubleValue);

            MapLocation towerLocation = new MapLocation(x: 1, y: 1, map: TestMap);

            TestTower = new Tower(
                location: towerLocation,
                range: Tower.DefaultRange,
                power: Tower.DefaultPower,
                accuracy: Tower.DefaultAccuracy,
                random: RandomMock.Object
            );
        }

        /// <summary>
        /// Sets up the <c>TestInvader</c> that is in <c>TestTower.Range</c>
        /// with <c>Invader.DefaultHealth</c> and 0 as <c>pathStep</c>
        /// Here is how <c>invaderPath</c> looks like
        /// 5
        /// 4
        /// 3
        /// 2
        /// 1   t
        /// 0 i i i i i i
        ///   0 1 2 3 4 5
        /// </summary>
        private void SetUpTestInvaderInTowerRange()
        {
            Path invaderPath = new Path(
                new []
                {
                    new MapLocation(x:0, y:0, map: TestMap),
                    new MapLocation(x:1, y:0, map: TestMap),
                    new MapLocation(x:2, y:0, map: TestMap),
                    new MapLocation(x:3, y:0, map: TestMap),
                    new MapLocation(x:4, y:0, map: TestMap),
                    new MapLocation(x:5, y:0, map: TestMap),
                }
            );
            TestInvaderInTowerRange = new Invader(
                path: invaderPath,
                pathStep: 0,
                health: Invader.DefaultHealth
            );
        }

        [Test]
        public void ShotOnInvaderIsSuccessfulWhenRandomGivesValueLessThanAccuracy()
        {
            // Given TestTower with HundredPercentShot,
            // i.e. when Random gives value LESS than Accuracy
            SetUpTowerLocationWithRandomDoubleValue(0.0);
            Assert.Less(0.0, TestTower.Accuracy);

            // When TestTower.isSuccesfulShot() is called

            // Then true should be returned
            Assert.True(TestTower.IsSuccessfulShot());

            // Then _random.nextDouble should be called
            RandomMock.Verify(random => random.NextDouble());
        }

        [Test]
        public void ShotOnInvaderIsUnSuccessfulWhenRandomGivesValueMoreThanAccuracy()
        {
            // Given TestTower with Miss Shot
            // i.e. when Random gives value MORE than accuracy
            SetUpTowerLocationWithRandomDoubleValue(1.0);
            Assert.Greater(1.0, TestTower.Accuracy);

            // When TestTower.isSuccesfulShot() is called

            // Then False should be returned
            Assert.False(TestTower.IsSuccessfulShot());

            // Then _random.nextDouble should be called
            RandomMock.Verify(random => random.NextDouble());
        }


        [Test]
        public void ShotOnActiveInvaderInTowerRangeShouldHitAndDecreaseHealth()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                // Given TestTower with Hit Shot
                SetUpTowerLocationWithRandomDoubleValue(0.0);
                // Given Invader that is in range of TestTower
                // 5
                // 4
                // 3
                // 2
                // 1   t
                // 0 i i i i i i
                //   0 1 2 3 4 5
                SetUpTestInvaderInTowerRange();
                Assert.IsTrue(TestInvaderInTowerRange.IsActive);
                Assert.IsTrue(
                    TestTower.IsInRangeOf(
                        TestInvaderInTowerRange
                    )
                );
                int testInvaderInitialHealth = TestInvaderInTowerRange.Health;


                // When Tower fires on invaders
                // with TestInvader as only Invader
                TestTower.FireOnInvaders(new []{TestInvaderInTowerRange});

                // Then invader's health should decrease
                Assert.AreEqual(
                    TestInvaderInTowerRange.Health,
                    testInvaderInitialHealth - 1
                );
                // Then hit message should be printed
                Assert.IsTrue(sw.ToString().Contains("is hit"));
            }
        }
    }
}