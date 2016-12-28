using System;
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

        // integration tests for Level.Play() method

        [Test]
        public void LevelShouldBeWonByPlayerInOneTowerOneInvaderGameWhereTowerIsAlwaysAccurate()
        {
            // Given the tower that has 100 % accuracy
            // invader that is in range of tower,
            // and has health equal to tower's power
            // on TestMap :
            // 5
            // 4
            // 3
            // 2
            // 1   t
            // 0 i i i i i i
            //   0 1 2 3 4 5
            Tower tower = new Tower(
                location: new MapLocation(x: 1, y: 1, map: TestMap),
                range: 1,
                power: 1,
                accuracy: 1.0,
                random: new Random()
            );
            Invader invader = new Invader(
                path: new Path(
                    new MapLocation[]
                    {
                        new MapLocation(x: 0, y: 0, map: TestMap),
                        new MapLocation(x: 1, y: 0, map: TestMap),
                        new MapLocation(x: 2, y: 0, map: TestMap),
                        new MapLocation(x: 3, y: 0, map: TestMap),
                        new MapLocation(x: 4, y: 0, map: TestMap),
                        new MapLocation(x: 5, y: 0, map: TestMap),
                    }
                ),
                pathStep: 0,
                health: tower.Power
            );
            Level level = new Level(
                new List<Invader> {invader}
            )
            {
                Towers = new List<Tower> {tower}
            };
            Assert.AreEqual(
                level.Winner,
                WinnerType.Undefined,
                "Before play call level.Winner should be Undefined"
            );


            // When Level.Play() is called
            level.Play();

            Assert.AreEqual(
                WinnerType.Player,
                level.Winner,
                "Level.Winner should be WinnerType.Player"
            );
        }

        [Test]
        public void LevelShouldBeWonByInvaderInOneTowerOneInvaderGameWhereInvaderIsOutOfTowerRange()
        {
            // Given the tower and
            // invader that is out range of tower,
            // on TestMap :
            // 5
            // 4
            // 3 i i i i i i
            // 2
            // 1   t
            // 0
            //   0 1 2 3 4 5
            Tower tower = new Tower(
                location: new MapLocation(x: 1, y: 1, map: TestMap),
                range: 1,
                power: 1,
                accuracy: 1.0,
                random: new Random()
            );
            Invader invader = new Invader(
                new Path(
                    new MapLocation[]
                    {
                        new MapLocation(x: 0, y: 3, map: TestMap),
                        new MapLocation(x: 1, y: 3, map: TestMap),
                        new MapLocation(x: 2, y: 3, map: TestMap),
                        new MapLocation(x: 3, y: 3, map: TestMap),
                        new MapLocation(x: 4, y: 3, map: TestMap),
                        new MapLocation(x: 5, y: 3, map: TestMap),
                    }
                )
            );
            Level level = new Level(
                new List<Invader> {invader}
            )
            {
                Towers = new List<Tower> {tower}
            };
            Assert.AreEqual(
                level.Winner,
                WinnerType.Undefined,
                "Before play call level.Winner should be Undefined"
            );


            // When Level.Play() is called
            level.Play();

            Assert.AreEqual(
                WinnerType.Invader,
                level.Winner,
                "Level.Winner should be WinnerType.Invader"
            );
        }

    }
}