using System.Collections.Generic;

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
        /// For now all towers simply shot on all
        /// invaders in foreach loop
        ///
        /// Used in <see cref="Play"/>
        /// </summary>
        private void MakeTowerStep()
        {
            foreach (var tower in Towers)
            {
                tower.FireOnInvaders(Invaders.ToArray());
            }
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
    }
}