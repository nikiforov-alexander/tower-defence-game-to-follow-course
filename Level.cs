using System.Collections.Generic;
using System.Linq;

namespace TowerDefenceTreehouse
{
    public class Level
    {

        // properties

        public WinnerType Winner { get; private set; }

        public List<Invader> Invaders { get; private set; }

        public List<Tower> Towers { get; set; }

        // constructors

        public Level(List<Invader> invaders)
        {
            Invaders = invaders;
            Winner = WinnerType.Undefined;
        }

        // methods

        /// <summary>
        /// Method that encapsulates Tower's step in
        /// this game.
        ///
        /// Uses <c>List.ForEach</c> method in
        /// combination with LINQ for each tower to
        /// fire on invader
        ///
        /// Used in <see cref="Play"/>
        /// </summary>
        private void MakeTowerStep()
        {
            Towers.ForEach(
                t => t.FireOnInvaders(Invaders)
            );
        }

        /// <summary>
        /// Removes all Invaders that were
        /// neutralized after Towers step
        /// using LINQ with <c>List.RemoveAll</c> method
        /// with filter for <c>IsNeutralized</c>
        /// property
        /// </summary>
        internal void RemoveNeutralizedInvaders()
        {
            Invaders.RemoveAll(
                i => i.IsNeutralized
            );
        }

        /// <summary>
        /// For now we simply move all invaders
        /// by calling <c>Move</c> method on each
        /// of them using LINQ and <c>List.ForEach</c>
        /// </summary>
        private void MakeInvadersStep()
        {
            Invaders.ForEach(
                i => i.Move()
            );
        }

        /// <summary>
        /// For now checks simply if <c>Invaders</c>
        /// is empty list, and sets <c>Winner</c>
        /// property to <c>WinnerType.Player</c>.
        ///
        /// Later additional logic
        /// can be added
        /// </summary>
        internal void CheckForWinnersAmongPlayers()
        {
            if (Invaders.Count == 0)
            {
                Winner = WinnerType.Player;
            }
        }

        /// <summary>
        /// Check for winners among invaders.
        ///
        /// For now simply counts number of
        /// invaders that <c>HasScored</c>.
        ///
        /// And if more than 0, then
        /// <c>Winner</c> is set to
        /// <c>WinnerType.Invader</c>
        ///
        /// </summary>
        internal void CheckForWinnersAmongInvaders()
        {
            int numberOfScoredInvaders = Invaders.Count(
                i => i.HasScored
            );

            if (numberOfScoredInvaders > 0)
            {
                Winner = WinnerType.Invader;
            }
        }


    }
}