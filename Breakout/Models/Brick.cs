namespace Breakout.Models
{
    using Contracts;

    internal class Brick : IBrick
    {
        private char symbol;

        private bool isVisible;

        public Brick(int positionY, int positionX)
        {
            isVisible = true;
            symbol = '#';

            this.PositionY = positionY;
            this.PositionX = positionX;
        }

        public int PositionX { get; set; }

        public int PositionY { get; set; }

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