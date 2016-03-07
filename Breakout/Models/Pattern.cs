namespace Breakout.Models
{
    using System;
    using Contracts;

    internal class Pattern
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
