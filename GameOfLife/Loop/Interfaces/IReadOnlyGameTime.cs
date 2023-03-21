namespace GameOfLife.Loop;

public interface IReadOnlyGameTime
{
    bool IsActive { get; }
    int DeltaTime { get; }
}