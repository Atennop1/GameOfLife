namespace GameOfLife.Field
{
    public sealed class GameFieldView : IGameFieldView
    {
        public GameFieldView()
            => Console.ForegroundColor = ConsoleColor.Green;

        public void Display(ICell[,] cells)
        {
            var length = cells.GetLength(0);
            var width = cells.GetLength(1);

            for (var i = 0; i < length; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.Write(cells[i, j].IsAlive ? "# " : ". ");
                }
            }
        }
    }
}