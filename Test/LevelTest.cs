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

        [Test]
        public void InvadersThatScoredShouldSetWinnerToInvader()
        {
            // Given one invader that scored
            // in level
            Invader scoredInvader = new Invader(
                path: new Path(
                    new []
                    {
                        new MapLocation(x: 1, y: 1, map: TestMap),
                    }
                ),
                pathStep: 1,
                health: Invader.DefaultHealth
            );
            Assert.IsTrue(
                scoredInvader.HasScored
            );
            Level level = new Level(
                    new List<Invader>{scoredInvader}
            );

            // When CheckForWinnersAmongInvaders() is called
            level.CheckForWinnersAmongInvaders();

            Assert.AreEqual(
                level.Winner,
                WinnerType.Invader,
                "Then level winner should be invader"
            );
        }

        [Test]
        public void LevelShouldBeWonByPlayersIfThereAreNoInvaders()
        {
            // Given empty invader list
            Level level = new Level(
                new List<Invader>()
            );

            // When CheckForWinnersAmongPlayers is called
            level.CheckForWinnersAmongPlayers();

            Assert.AreEqual(
                level.Winner,
                WinnerType.Player,
                "Then Winner should be WinnerType.Player"
            );
        }

    }
}