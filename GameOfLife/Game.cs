using GameOfLife.Field;
using GameOfLife.Loop;

namespace GameOfLife
{
    public sealed class Game
    {
        public void Play()
        {
            var gameTime = new GameTime();

            var gameFieldView = new GameFieldView();
            var gameField = new GameField(gameFieldView, CreateCells());

            var gameLoop = new GameLoop(new List<IGameLoopObject> { gameField }, gameTime);
            gameLoop.Activate();
        }

        private ICell[,] CreateCells()
        {
            var length = 18;
            var width = 11;
            var cells = new ICell[length, width];

            for (var i = 0; i < length; i++)
                for (var j = 0; j < width; j++)
                    cells[i, j] = new Cell(false);

            var aliveCellsCoordinates = new List<List<int>>
            {
                new() {4, 5}, new() {5, 5}, new() {6, 4}, new() {6, 6}, 
                new() {7, 5}, new() {8, 5}, new() {9, 5}, new() {10, 5}, 
                new() {11, 4}, new() {11, 6}, new() {12, 5}, new() {13, 5}
            };

            foreach (var aliveCellCoordinates in aliveCellsCoordinates)
                cells[aliveCellCoordinates[0], aliveCellCoordinates[1]] = new Cell(true);

            return cells;
        }
    }
}