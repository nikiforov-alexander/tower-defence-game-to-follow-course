using System.Collections.Generic;
using NUnit.Framework;
using TowerDefenceTreehouse.MapObjects;

namespace TowerDefenceTreehouse.Test
{
    [TestFixture]
    public class LevelTest
    {
        public Map TestMap;

        [SetUp]
        public void SetUp()
        {
            TestMap = new Map(width: 5, height: 5);
        }

        [Test]
        public void NeutralizedInvadersShouldBeRemovedAfterShot()
        {
            // Given level with one neutralized invader
            Invader neutralizedInvader = new Invader(
                path: new Path(
                    new []
                    {
                        new MapLocation(x: 1, y: 1, map: TestMap),
                    }
                ),
                pathStep: 1,
                health: 0
            );
            Assert.IsTrue(
                neutralizedInvader.IsNeutralized,
                "neutralizedInvader should be neutralized"
            );
            Level level = new Level(
                    new List<Invader>{neutralizedInvader}
            );

            // When we remove neutralized invaders
            level.RemoveNeutralizedInvaders();

            CollectionAssert.DoesNotContain(
                level.Invaders,
                neutralizedInvader,
                "Then neutralizedInvader should be removed from" +
                "Invaders property"
            );
        }
    }
}