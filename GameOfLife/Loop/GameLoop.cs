namespace GameOfLife.Loop
{
    public sealed class GameLoop : IGameLoop
    {
        private readonly List<IGameLoopObject> _gameLoopObjects;
        private readonly IGameTime _gameTime;

        public GameLoop(List<IGameLoopObject> gameLoopObjects, IGameTime gameTime)
        {
            _gameLoopObjects = gameLoopObjects ?? throw new ArgumentNullException(nameof(gameLoopObjects));
            _gameTime = gameTime ?? throw new ArgumentNullException(nameof(gameTime));
        }

        public void Activate()
        {
            _gameTime.Start();

            var loopThread = new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(_gameTime.DeltaTime);
                    
                    if (!_gameTime.IsActive)
                        continue;
                    
                    _gameLoopObjects.ForEach(gameLoopObject => gameLoopObject.Update(_gameTime.DeltaTime));
                }
            });
            
            loopThread.Start();
        }
    }
}