namespace Breakout.Models.Patterns
{
    using System;
    using Contracts;

    internal class BasicPattern : IFillingPattern
    {
        public void FillWall(IWall wall)
        {
            Console.SetCursorPosition(0, 1);

            for (int row = 0; row < wall.Height; row++)
            {
                for (int column = 0; column < wall.Width; column++)
                {
                    wall.FilledWall[row, column] = new Brick(row, column);
                }
            }
        }
    }
}
