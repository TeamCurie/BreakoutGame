namespace Breakout.Models
{
    using System;
    using Contracts;

    internal class Brick : IBrick
    {
        private char symbol;

        private bool isVisible;

        public Brick(int positionY, int positionX, bool isColored)
        {
            isVisible = true;
            symbol = '#';

            this.PositionY = positionY;
            this.PositionX = positionX;
            this.IsColored = isColored;
        }

        public int PositionX { get; set; }

        public int PositionY { get; set; }

        public bool IsColored { get; set; }

        public char getSymbol()
        {
            return this.symbol;
        }

        public void setInvisible()
        {
            isVisible = false;
            this.symbol = ' ';
        }

        public bool getVisibility()
        {
            return isVisible;
        }
    }
}