namespace TowerDefenceTreehouse
{
    public class Invader
    {
        private readonly Path _path;
        private int _pathStep;

        public Invader(Path path)
        {
            _path = path;
            _pathStep = 0;
        }
    }
}