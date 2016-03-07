namespace Breakout.Models
{
    using System;
    using Contracts;

    internal class Wall : IWall
    {
        public Wall(int height, int width)
        {
            this.Height = height;
            this.Width = width;
            this.FilledWall = new IBrick[height, width];
        }

        public int Height { get; }

        public int Width { get; }

        public IBrick[,] FilledWall { get; }

        public void DrawWall()
        {
            Console.SetCursorPosition(0, 1);

            for (int row = 0; row < this.Height; row++)
            {
                for (int column = 0; column < this.Width; column++)
                {
                    FilledWall[row,column] = new Brick(row, column);
                }
            }
        }

        public void UpdateWall()
        {
            Console.SetCursorPosition(0, 1);

            for (int i = 0; i < this.FilledWall.GetLength(0); i++)
            {
                for (int j = 0; j < this.FilledWall.GetLength(1); j++)
                {
                    Console.Write(this.FilledWall[i,j].getSymbol());
                }
            } 
        }
    }
}
