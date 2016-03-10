namespace Breakout.Models.Patterns
{
    using System;
    using Contracts;

    class ZigZagPattern : IFillingPattern
    {
        public void FillWall(IWall wall)
        {
            Console.SetCursorPosition(0, 1);
            int counter = 0;

            for (int row = 0; row < wall.Height; row++)
            {
                for (int column = 0; column < wall.Width; column++)
                {
                    wall.FilledWall[row, column] = new Brick(row, column, false);

                    if (counter % 2 == 0)
                    {
                        wall.FilledWall[row, column].setInvisible();
                    }

                    counter++;
                }
            }
        }
    }
}
