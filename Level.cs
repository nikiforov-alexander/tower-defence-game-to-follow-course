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
    }
}