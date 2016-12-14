namespace TowerDefenceTreehouse
{
    internal class TreehouseDefenseException : System.Exception
    {
        public TreehouseDefenseException()
        {
        }

        public TreehouseDefenseException(string message) : base(message)
        {
        }
    }

    internal class OutOfBoundsException : TreehouseDefenseException
    {
        public OutOfBoundsException()
        {
        }

        public OutOfBoundsException(string message) : base(message)
        {
        }
    }
}