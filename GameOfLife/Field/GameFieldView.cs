namespace GameOfLife.Field
{
    public sealed class GameFieldView : IGameFieldView
    {
        public GameFieldView()
            => Console.ForegroundColor = ConsoleColor.Green;

        public void Display(ICell[,] cells)
        {
            Console.Clear();

            var length = cells.GetLength(0);
            var width = cells.GetLength(1);

            for (var i = 0; i < length; i++)
            {
                for (var j = 0; j < width; j++)
                    Console.Write(cells[i, j].IsAlive ? "# " : ". ");

                Console.WriteLine();
            }
        }
    }
}