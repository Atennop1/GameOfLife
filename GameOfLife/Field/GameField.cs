using GameOfLife.Loop;

namespace GameOfLife.Field
{
    public sealed class GameField : IGameLoopObject
    {
        private readonly IGameFieldView _gameFieldView;
        private ICell[,] _cells;

        public GameField(IGameFieldView gameFieldView, ICell[,] cells)
        {
            _gameFieldView = gameFieldView ?? throw new ArgumentNullException(nameof(gameFieldView));
            _cells = cells ?? throw new ArgumentNullException(nameof(cells));
            _gameFieldView.Display(_cells);
        }

        public void Update(int delta)
        {
            var length = _cells.GetLength(0);
            var width = _cells.GetLength(1);
            var cellsAfterUpdate = new ICell[length, width];

            for (var i = 0; i < length; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    var currentCell = _cells[i, j];
                    var aliveNeighboursCount = GetAliveNeighboursCount(i, j);

                    if (!currentCell.IsAlive && aliveNeighboursCount == 3)
                    {
                        cellsAfterUpdate[i, j] = new Cell(true);
                        continue;
                    }

                    if (currentCell.IsAlive && aliveNeighboursCount != 2 && aliveNeighboursCount != 3)
                    {
                        cellsAfterUpdate[i, j] = new Cell(false);
                        continue;
                    }

                    cellsAfterUpdate[i, j] = _cells[i, j];
                }
            }

            _cells = cellsAfterUpdate;
            _gameFieldView.Display(_cells);
        }

        private int GetAliveNeighboursCount(int y, int x)
        {
            var length = _cells.GetLength(0);
            var width = _cells.GetLength(1);
            var count = 0;

            for (var i = -1; i < 2; i++)
            {
                for (var j = -1; j < 2; j++)
                {
                    if (i == 0 && j == 0)
                        continue;
                    
                    if ((y + i < length - 1 && y + i > 0) && (x + j < width - 1 && x + j > 0) && _cells[y + i, x + j].IsAlive)
                        count++;
                }
            }

            return count;
        }
    }
}