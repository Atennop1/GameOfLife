namespace GameOfLife.Loop
{
    public sealed class GameTime : IGameTime
    {
        public bool IsActive { get; private set; }
        public int DeltaTime => 300;
        
        public void Start() 
            => IsActive = true;

        public void Stop() 
            => IsActive = false;
    }
}