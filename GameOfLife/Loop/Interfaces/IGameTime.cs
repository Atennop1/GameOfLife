namespace GameOfLife.Loop
{
    public interface IGameTime : IReadOnlyGameTime
    {
        void Start();
        void Stop();
    }
}