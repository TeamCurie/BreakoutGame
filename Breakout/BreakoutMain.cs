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

        private static int paddlePositionX = 18; //Paddle x-coordinate starting position; y-coordinate is always PlaygroundHeight - 1
        //(i.e. bottom of the screen).
        
        private static int ballPositionX = paddlePositionX + 3; //Ball x-coordinate starting position.
        private static int ballPositionY = PlaygroundHeight - 1; //Ball y-coordinate starting position.

        //Valid predefined ball directions: 0 - up, 1 - up left, 2 - up right, 3 - down, 4 - down right, 5 - down left.
        private static int ballDirection = 0;

        public static void Main()
        {
            Console.CursorVisible = false;
            Console.WindowWidth = PlaygroundWidth;
            Console.WindowHeight = PlaygroundHeight;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;

            DrawPaddle();
            DrawBall();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey();
                    ChangePaddlePosition(pressedKey);
                }

                ChangeBallPosition();
                Console.Clear();
                DrawPaddle();
                DrawBall();
                Thread.Sleep(100);
            }
        }

        private static void ChangeBallPosition()
        {
            switch (ballDirection)
            {
                case 0: //Up
                    ballPositionY--;
                    break;
                case 1: //Up left
                    ballPositionX--;
                    ballPositionY--;
                    break;
                case 2: //Up right
                    ballPositionX++;
                    ballPositionY--;
                    break;
                case 3: //Down
                    ballPositionY++;
                    break;
                case 4: //Down right
                    ballPositionX++;
                    ballPositionY++;
                    break;
                case 5: //Down left
                    ballPositionX--;
                    ballPositionY++;
                    break;
            }

            if (ballPositionY == PlaygroundHeight - 1) //When the ball hits the floor or the paddle.
            {
                if ((ballPositionX >= paddlePositionX + 2) &&
                    (ballPositionX <= paddlePositionX + 4)) // The middle 3 "_" symbols.
                {
                    ballDirection = 0; //Bouncing up.
                }
                else if ((ballPositionX >= paddlePositionX) &&
                    (ballPositionX <= paddlePositionX + 1)) // The left 2 "_" symbols.
                {
                    ballDirection = 1; //Bouncing up and to the left.
                }
                else if ((ballPositionX >= paddlePositionX + 5) &&
                    (ballPositionX <= paddlePositionX + 6)) // The right 2 "_" symbols.
                {
                    ballDirection = 2; //Bouncing up and to the right.
                }
                else
                {
                    Console.WriteLine("Game Over!"); //The ball did not land on the paddle.
                    Environment.Exit(0); //Terminates the main thread, without any exception thrown, i.e. exits the program.
                }
            }

            if (ballPositionY == 0) //When the ball hits the ceiling.
            {
                if (ballDirection == 0)
                {
                    ballDirection = 3; //From upward direction the ball bounces off downward.
                }
                else if (ballDirection == 2)
                {
                    ballDirection = 4; //From upward right direction the ball bounces off downward right.
                }
                else if (ballDirection == 1)
                {
                    ballDirection = 5; //From upward right direction the ball bounces off downward right.
                }
            }

            if (ballPositionX == 0) //When the ball hits the left wall.
            {
                if (ballDirection == 1)
                {
                    ballDirection = 2; //From upward left direction the ball bounces off upward right.
                }
                else if (ballDirection == 5)
                {
                    ballDirection = 4; //From downward left direction the ball bounces off downward right.
                }
            }

            if (ballPositionX == PlaygroundWidth - 1) //When the ball hits the right wall.
            {
                if (ballDirection == 2)
                {
                    ballDirection = 1; //From upward right direction the ball bounces off upward left.
                }
                else if (ballDirection == 4)
                {
                    ballDirection = 5; //From downward right direction the ball bounces off downward left.
                }
            }
        }
        
        private static void ChangePaddlePosition(ConsoleKeyInfo pressedKey)
        {
            if (pressedKey.Key == ConsoleKey.LeftArrow)
            {
                paddlePositionX = paddlePositionX - 2;
                if (paddlePositionX < 0)
                {
                    paddlePositionX = 0;
                }
            }
            else if (pressedKey.Key == ConsoleKey.RightArrow)
            {
                paddlePositionX = paddlePositionX + 2;
                if (paddlePositionX > PlaygroundWidth - PaddleWidth - 1)
                {
                    paddlePositionX = PlaygroundWidth - PaddleWidth - 1;
                }
            }
        }

        private static void DrawPaddle()
        {
            for (int i = 0; i < PaddleWidth; i++)
            {
                Console.SetCursorPosition(paddlePositionX + i, PlaygroundHeight - 1);
                Console.Write('_');
            }
        }

        private static void DrawBall()
        {
            Console.SetCursorPosition(ballPositionX, ballPositionY);
            Console.Write(BallSymbol);
        }
    }
}
