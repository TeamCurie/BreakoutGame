namespace Breakout.Models.Patterns
{
    using System;
    using System.Diagnostics;
    using Contracts;

    internal class BasicPattern : IFillingPattern
    {
        /*
        public static int[,] fillColor = new int[4, 40]
        {
            {0, 1, 0, 0, 0, 1, 1, 1, 0, 1, 1, 1, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 1, 0, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 1, 0, 1, 0, 1, 1, 0, 0, 1, 0, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 1, 1, 1, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        };
        */

        public void FillWall(IWall wall)
        {
            Console.SetCursorPosition(0, 1);

            for (int row = 0; row < wall.Height; row++)
            {
                for (int column = 0; column < wall.Width; column++)
                {
                    wall.FilledWall[row, column] = new Brick(row, column, false);
                }
            }
        }
    }
}
