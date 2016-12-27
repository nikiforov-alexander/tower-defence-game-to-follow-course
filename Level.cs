namespace TowerDefenceTreehouse
{
    public class Level
    {

        // properties

        public WinnerType Winner { get; private set; }

        public Invader[] Invaders { get; private set; }

        public Tower[] Towers { get; set; }

        // constructors

        public Level(Invader[] invaders)
        {
            Invaders = invaders;
            Winner = WinnerType.Undefined;
        }
    }
}