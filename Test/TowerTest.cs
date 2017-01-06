using System;
using System.Collections.Generic;
using System.IO;
using Moq;
using NUnit.Framework;
using TowerDefenceTreehouse.Invaders;
using TowerDefenceTreehouse.MapObjects;
using TowerDefenceTreehouse.Towers;
using Path = TowerDefenceTreehouse.MapObjects.Path;

namespace TowerDefenceTreehouse.Test
{
    [TestFixture]
    public class TowerTest
    {
        public Map TestMap;
        public Tower TestTower;
        public Mock<Random> RandomMock;
        public Invader TestInvaderInTowerRange;
        public Invader TestInvaderOutOfTowerRange;

        /// <summary>
        /// here we set up only <c>TestMap</c>
        /// 5
        /// 4
        /// 3
        /// 2
        /// 1   t
        /// 0
        ///   0 1 2 3 4 5
        ///
        /// Quoting from https://blogs.msdn.microsoft.com/ploeh/2006/10/21/console-unit-testing/
        /// Since test case redirects the standard output for System.Console
        /// it’s important to reset it when the test is done,
        /// since all test cases should be independent,
        /// and you may have other tests where
        /// you don’t want the console output to be redirected.
        /// Usually, I use a test initialization method for this task
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            TestMap = new Map(5, 5);
            StreamWriter standardOut =
                new StreamWriter(Console.OpenStandardOutput()) {AutoFlush = true};
            Console.SetOut(standardOut);
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
        /// <param name="health">TestInvader's health</param>
        private void SetUpTestInvaderInTowerRangeWithHealth(int health)
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
                health: health
            );
        }

        /// <summary>
        /// Sets up the <c>TestInvader</c> that is OUT of <c>TestTower.Range</c>
        /// with <c>Invader.DefaultHealth</c> and 0 as <c>pathStep</c>
        /// Here is how <c>invaderPath</c> looks like
        /// 5
        /// 4
        /// 3 i i i i i i
        /// 2
        /// 1   t
        /// 0
        ///   0 1 2 3 4 5
        /// </summary>
        /// <param name="health">TestInvader's health</param>
        private void SetUpTestInvaderOutOfTowerRangeWithHealth(int health)
        {
            Path invaderPath = new Path(
                new []
                {
                    new MapLocation(x:0, y:3, map: TestMap),
                    new MapLocation(x:1, y:3, map: TestMap),
                    new MapLocation(x:2, y:3, map: TestMap),
                    new MapLocation(x:3, y:3, map: TestMap),
                    new MapLocation(x:4, y:3, map: TestMap),
                    new MapLocation(x:5, y:3, map: TestMap),
                }
            );
            TestInvaderOutOfTowerRange = new Invader(
                path: invaderPath,
                pathStep: 0,
                health: health
            );
        }

        /// <summary>
        ///     Creates <code>Invader</code> with <c>Path</c>
        ///     from one <c>MapLocation</c>, that is constructed from
        ///     passed arguments <c>x</c> and <c>y</c> on the
        ///     <c>TestMap</c>.
        /// </summary>
        ///
        /// <param name="x">
        ///     X coordinate of <c>MapLocation</c>
        /// </param>
        /// <param name="y">
        ///     Y coordinate of <c>MapLocation</c>
        /// </param>
        /// <returns>
        ///     <c>Invader</c> with <c>Path</c> from only one
        ///     <c>MapLocation</c>
        /// </returns>
        private Invader CreateInvaderWithPathOfOneMapLocation(int x, int y)
        {
            return new Invader(
                new Path(
                    new []
                    {
                        new MapLocation(x, y, TestMap),
                    }
                )
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
        public void IsInRangeOfShouldReturnTrueWhenInvaderIsClose()
        {
            // Given TestTower on (1,1) TestMap location
            SetUpTowerLocationWithRandomDoubleValue(0.0);
            // Given 8 Invaders that are in range of 1
            // 5
            // 4
            // 3
            // 2 i6 i7 i8
            // 1 i4  t i5
            // 0 i1 i2 i3
            //    0  1  2  3  4  5
            Invader i1 = CreateInvaderWithPathOfOneMapLocation(x: 0, y: 0);
            Invader i2 = CreateInvaderWithPathOfOneMapLocation(x: 1, y: 0);
            Invader i3 = CreateInvaderWithPathOfOneMapLocation(x: 2, y: 0);

            Invader i4 = CreateInvaderWithPathOfOneMapLocation(x: 0, y: 1);
            // at (1,1) stays TestTower
            Invader i5 = CreateInvaderWithPathOfOneMapLocation(x: 2, y: 1);

            Invader i6 = CreateInvaderWithPathOfOneMapLocation(x: 0, y: 2);
            Invader i7 = CreateInvaderWithPathOfOneMapLocation(x: 1, y: 2);
            Invader i8 = CreateInvaderWithPathOfOneMapLocation(x: 2, y: 2);

            // When IsInRangeOf() is called with invaders
            // Then true should be returned
            foreach (var invader in new []{i1, i2, i3, i4, i5, i6, i7, i8})
            {
                Assert.IsTrue(
                    TestTower.IsInRangeOf(invader)
                );
            }
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
                // with DefaultHealth
                SetUpTestInvaderInTowerRangeWithHealth(Invader.DefaultHealth);
                Assert.IsTrue(TestInvaderInTowerRange.IsActive);
                Assert.IsTrue(
                    TestTower.IsInRangeOf(
                        TestInvaderInTowerRange
                    )
                );
                int testInvaderInitialHealth = TestInvaderInTowerRange.Health;


                // When Tower fires on invaders
                // with TestInvader as only Invader
                TestTower.FireOnInvaders(
                    new List<Invader>{TestInvaderInTowerRange}
                );

                // Then invader's health should decrease
                Assert.AreEqual(
                    TestInvaderInTowerRange.Health,
                    testInvaderInitialHealth - 1
                );
                // Then hit message should be printed
                Assert.IsTrue(sw.ToString().Contains("is hit"));
            }
        }

        [Test]
        public void SuccessfulShotOnInvaderWithLastBitOfHealthNeutralizesInvader()
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
                // With health equal to power of tower
                SetUpTestInvaderInTowerRangeWithHealth(TestTower.Power);
                Assert.IsTrue(TestInvaderInTowerRange.IsActive);
                Assert.IsTrue(
                    TestTower.IsInRangeOf(
                        TestInvaderInTowerRange
                    )
                );
                Assert.AreEqual(
                    TestInvaderInTowerRange.Health,
                    TestTower.Power,
                    "Tower.Power should be equal to Invader.Health to kill him"
                );


                // When Tower fires on invaders
                // with TestInvader as only Invader
                TestTower.FireOnInvaders(
                    new List<Invader>{TestInvaderInTowerRange}
                );

                // Then hit message should be printed
                Assert.IsTrue(sw.ToString().Contains("is hit"));
                Assert.IsTrue(sw.ToString().Contains("is killed"));

                // Then TestInvader should be neutralized
                Assert.IsTrue(
                    TestInvaderInTowerRange.IsNeutralized
                );
            }
        }

        [Test]
        public void MissedShotOnInvaderBecauseOfNotSuccessfulShotDoesNotHitInvader()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                // Given TestTower with Miss Shot
                SetUpTowerLocationWithRandomDoubleValue(1.0);
                // Given Invader that is in range of TestTower
                // 5
                // 4
                // 3
                // 2
                // 1   t
                // 0 i i i i i i
                //   0 1 2 3 4 5
                // With default invader health
                SetUpTestInvaderInTowerRangeWithHealth(Invader.DefaultHealth);
                Assert.IsTrue(TestInvaderInTowerRange.IsActive);
                Assert.IsTrue(
                    TestTower.IsInRangeOf(
                        TestInvaderInTowerRange
                    )
                );


                // When Tower fires on invaders
                // with TestInvader as only Invader
                TestTower.FireOnInvaders(
                    new List<Invader>{TestInvaderInTowerRange}
                );

                Assert.IsTrue(sw.ToString().Contains("missed"),
                    "Then miss message should be printed"
                );

                Assert.IsFalse(
                    TestInvaderInTowerRange.IsHit,
                    "Then TestInvader should not be hit"
                );
            }
        }

        [Test]
        public void ShotOnInvaderOffRangeShouldNotHitInvaderAndShouldBeMiss()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                // Given TestTower with Hit Shot
                SetUpTowerLocationWithRandomDoubleValue(0.0);
                // Given Invader that is OUT of range of TestTower
                // 5
                // 4
                // 3 i i i i i i
                // 2
                // 1   t
                // 0
                //   0 1 2 3 4 5
                // With default invader health
                SetUpTestInvaderOutOfTowerRangeWithHealth(Invader.DefaultHealth);
                Assert.IsTrue(TestInvaderOutOfTowerRange.IsActive);
                Assert.IsFalse(
                    TestTower.IsInRangeOf(
                        TestInvaderOutOfTowerRange
                    )
                );

                // When Tower fires on invaders
                // with TestInvader as only Invader
                TestTower.FireOnInvaders(
                    new List<Invader>{TestInvaderOutOfTowerRange}
                );

                Assert.IsTrue(sw.ToString().Contains("missed"),
                    "Then miss message should be printed"
                );

                Assert.IsFalse(
                    TestInvaderOutOfTowerRange.IsHit,
                    "Then TestInvader should not be hit"
                );
            }
        }

        [Test]
        public void ShotOnTwoInvadersInTowerRangeHitsOnlyOneInvader()
        {
            // Given TestTower with Hit Shot
            SetUpTowerLocationWithRandomDoubleValue(0.0);
            // Given two Invaders that are in range of TestTower
            // 5
            // 4
            // 3
            // 2
            // 1   t
            // 0 i i
            //   0 1 2 3 4 5
            // With default invader health
            Path firstInvaderPath = new Path(
                new[]
                {
                    new MapLocation(x: 1, y: 0, map: TestMap),
                }
            );
            Invader firstInvaderInTowerRange = new Invader(
                path: firstInvaderPath,
                pathStep: 0,
                health: Invader.DefaultHealth
            );
            Path secondInvaderPath = new Path(
                new[]
                {
                    new MapLocation(x: 1, y: 0, map: TestMap),
                }
            );
            Invader secondInvaderInTowerRange = new Invader(
                path: secondInvaderPath,
                pathStep: 0,
                health: Invader.DefaultHealth
            );
            Assert.IsTrue(TestTower.IsInRangeOf(firstInvaderInTowerRange));
            Assert.IsTrue(TestTower.IsInRangeOf(secondInvaderInTowerRange));

            // When Tower fires on two invaders
            TestTower.FireOnInvaders(
                new List<Invader> {
                    firstInvaderInTowerRange,
                    secondInvaderInTowerRange
                }
            );

            Assert.IsFalse(
                firstInvaderInTowerRange.IsHit && secondInvaderInTowerRange.IsHit,
                "Then only one invader should be hit"
            );
        }
    }
}