namespace Breakout.Contracts
{
    public interface IWall
    {
        int Height { get; }

        int Width { get; }

        IBrick[,] FilledWall { get; }

        void DrawWall();

        void UpdateWall();
    }
}
