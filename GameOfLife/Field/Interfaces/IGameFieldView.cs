namespace GameOfLife.Field
{
    public interface IGameFieldView
    {
        void Display(ICell[,] cells);
    }
}