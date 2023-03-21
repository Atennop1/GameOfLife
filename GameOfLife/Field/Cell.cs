namespace GameOfLife.Field
{
    public sealed class Cell : ICell
    {
        public bool IsAlive { get; }

        public Cell(bool isAlive) 
            => IsAlive = isAlive;
    }
}