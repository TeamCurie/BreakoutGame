using System;
using System.Threading;

namespace Breakout
{
    public class BreakoutMain
    {
        private const int PlaygroundWidth = 44;
        private const int PlaygroundHeight = 35;
        private const int PaddleWidth = 7;
        private const char BallSymbol = '*';

        public static void Main()
        {
            Console.CursorVisible = false;
            Console.WindowWidth = PlaygroundWidth;
            Console.WindowHeight = PlaygroundHeight;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;

            int playerPositionX = 18; //Paddle x-coordinate starting position; y-coordinate is always PlaygroundHeight - 1
            //(i.e. bottom of the screen).
            DrawPaddle(playerPositionX);

            int ballPositionX = playerPositionX + 3; //Ball x-coordinate starting position.
            int ballPositionY = PlaygroundHeight - 1; //Ball y-coordinate starting position.
            DrawBall(ballPositionX, ballPositionY);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey();
                    playerPositionX = ChangePaddlePosition(playerPositionX, pressedKey);
                }

                Console.Clear();
                DrawPaddle(playerPositionX);
                DrawBall(ballPositionX, ballPositionY);
                Thread.Sleep(100);
            }
        }

        private static int ChangePaddlePosition(int playerPositionX, ConsoleKeyInfo pressedKey)
        {
            if (pressedKey.Key == ConsoleKey.LeftArrow)
            {
                playerPositionX = playerPositionX - 2;
                if (playerPositionX < 0)
                {
                    playerPositionX = 0;
                }
            }
            else if (pressedKey.Key == ConsoleKey.RightArrow)
            {
                playerPositionX = playerPositionX + 2;
                if (playerPositionX > PlaygroundWidth - PaddleWidth - 1)
                {
                    playerPositionX = PlaygroundWidth - PaddleWidth - 1;
                }
            }

            return playerPositionX;
        }

        private static void DrawPaddle(int playerPositionX)
        {
            for (int i = 0; i < PaddleWidth; i++)
            {
                Console.SetCursorPosition(playerPositionX + i, PlaygroundHeight - 1);
                Console.Write('_');
            }
        }

        private static void DrawBall(int ballPositionX, int ballPositionY)
        {
            Console.SetCursorPosition(ballPositionX, ballPositionY);
            Console.Write(BallSymbol);
        }
    }
}
