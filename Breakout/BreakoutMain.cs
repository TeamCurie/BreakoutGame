﻿namespace Breakout
{
    using System;
    using System.Threading;
    using Enums;

    public class BreakoutMain
    {
        private const int PlaygroundWidth = 85;
        private const int PlaygroundHeight = 35;
        private const int PaddleWidth = 7;
        private const char BallSymbol = '*';

        private static int paddlePositionX = 18; //Paddle x-coordinate starting position; y-coordinate is always PlaygroundHeight - 2
                                                 //(i.e. bottom of the screen).

        private static int ballPositionX = paddlePositionX + 3; //Ball x-coordinate starting position.
        private static int ballPositionY = PlaygroundHeight - 2; //Ball y-coordinate starting position.

        private static int gameSpeed = 100;

        private static Directions ballDirection = Directions.Up;

        private static Brick[] bricks = new Brick[PlaygroundWidth * 4];

        public static void Main()
        {
            Console.CursorVisible = false;
            Console.WindowWidth = PlaygroundWidth;
            Console.WindowHeight = PlaygroundHeight;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;

            while (true)
            {
                MainMenu();
            }
        }

        private static void GameStart()
        {
            DrawPaddle();
            DrawBall();
            DrawWall();

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
                UpdateWall();
                Thread.Sleep(gameSpeed);
            }
        }

        private static void MainMenu()
        {
            int curChoiceOption = 1;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(22, 5);
                Console.WriteLine("______                _               _   ");
                Console.SetCursorPosition(22, 6);
                Console.WriteLine("| ___ \\              | |             | |  ");
                Console.SetCursorPosition(22, 7);
                Console.WriteLine("| |_/ /_ __ ___  __ _| | _____  _   _| |_ ");
                Console.SetCursorPosition(22, 8);
                Console.WriteLine("| ___ \\ '__/ _ \\/ _` | |/ / _ \\| | | | __|");
                Console.SetCursorPosition(22, 9);
                Console.WriteLine("| |_/ / | |  __/ (_| |   < (_) | |_| | |_ ");
                Console.SetCursorPosition(22, 10);
                Console.WriteLine("\\____/|_|  \\___|\\__,_|_|\\_\\___/ \\__,_|\\__|");
                Console.SetCursorPosition(22, 11);

                // all it does is coloring the current highlighted answer and printing the answers
                if (curChoiceOption == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.SetCursorPosition(35, 14);
                Console.WriteLine("Start new game ");

                if (curChoiceOption == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.SetCursorPosition(35, 15);
                Console.WriteLine("Options ");

                if (curChoiceOption == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.SetCursorPosition(35, 16);
                Console.WriteLine("Highscores ");

                if (curChoiceOption == 4)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.SetCursorPosition(35, 17);
                Console.WriteLine("Exit");

                // end of the long coloring
                var cki = Console.ReadKey(); // getting a button press
                // highlighting another desired option if an arrow is pressed
                if (cki.Key == ConsoleKey.DownArrow)
                {
                    if (curChoiceOption + 1 <= 4)
                    {
                        curChoiceOption += 1;
                    }
                    else
                    {
                        curChoiceOption = 1;
                    }
                }
                else if (cki.Key == ConsoleKey.UpArrow)
                {
                    if (curChoiceOption - 1 >= 1)
                    {
                        curChoiceOption -= 1;
                    }
                    else
                    {
                        curChoiceOption = 4;
                    }
                }
                else if (cki.Key == ConsoleKey.Enter) // breaking and leaving option validation in the outer loop
                {
                    break;
                }

                // clearing screen
                Console.Clear();
            }

            Console.Clear();

            if (curChoiceOption == 1)
            {
                GameStart();
            }
            else if (curChoiceOption == 2)
            {
                Options(); // not yet implemented
            }
            else if (curChoiceOption == 3)
            {
                Console.WriteLine("Highscores:"); // not yet implemented
            }
            else if (curChoiceOption == 4)
            {
                Environment.Exit(0);
            }
        }

        private static void Options()
        {
            int curChoiceOption = 1;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(22, 5);
                Console.WriteLine(" _____       _   _                 ");
                Console.SetCursorPosition(22, 6);
                Console.WriteLine("|  _  |     | | (_)                ");
                Console.SetCursorPosition(22, 7);
                Console.WriteLine("| | | |_ __ | |_ _  ___  _ __  ___ ");
                Console.SetCursorPosition(22, 8);
                Console.WriteLine("| | | | '_ \\| __| |/ _ \\| '_ \\/ __|");
                Console.SetCursorPosition(22, 9);
                Console.WriteLine("\\ \\_/ / |_) | |_| | (_) | | | \\__ \\");
                Console.SetCursorPosition(22, 10);
                Console.WriteLine(" \\___/| .__/ \\__|_|\\___/|_| |_|___/");
                Console.SetCursorPosition(22, 11);
                Console.WriteLine("      | |                          ");
                Console.SetCursorPosition(22, 12);
                Console.WriteLine("      |_|                          ");
                Console.SetCursorPosition(22, 13);

                // all it does is coloring the current highlighted answer and printing the answers
                Console.SetCursorPosition(35, 13);
                Console.WriteLine("Game speed: ");
                if (curChoiceOption == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.SetCursorPosition(35, 14);
                Console.WriteLine("x0.5");

                if (curChoiceOption == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.SetCursorPosition(35, 15);
                Console.WriteLine("x1");

                if (curChoiceOption == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.SetCursorPosition(35, 16);
                Console.WriteLine("x2");

                if (curChoiceOption == 4)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.SetCursorPosition(35, 17);
                Console.WriteLine("Back");

                // end of the long coloring
                var cki = Console.ReadKey(); // getting a button press
                // highlighting another desired option if an arrow is pressed
                if (cki.Key == ConsoleKey.DownArrow)
                {
                    if (curChoiceOption + 1 <= 4)
                    {
                        curChoiceOption += 1;
                    }
                    else
                    {
                        curChoiceOption = 1;
                    }
                }
                else if (cki.Key == ConsoleKey.UpArrow)
                {
                    if (curChoiceOption - 1 >= 1)
                    {
                        curChoiceOption -= 1;
                    }
                    else
                    {
                        curChoiceOption = 4;
                    }
                }
                else if (cki.Key == ConsoleKey.Enter) // breaking and leaving option validation in the outer loop
                {
                    break;
                }

                // clearing screen
                Console.Clear();
            }

            Console.Clear();

            if (curChoiceOption == 1)
            {
                gameSpeed = 200;
            }
            else if (curChoiceOption == 2)
            {
                gameSpeed = 100; // not yet implemented
            }
            else if (curChoiceOption == 3)
            {
                gameSpeed = 50; // not yet implemented
            }
            else if (curChoiceOption == 4)
            {
                return;
            }
        }

        private static void ChangeBallPosition()
        {
            switch (ballDirection)
            {
                case Directions.Up: // Up
                    ballPositionY--;
                    break;
                case Directions.UpAndLeft: // Up left
                    ballPositionX--;
                    ballPositionY--;
                    break;
                case Directions.UpAndRight: // Up right
                    ballPositionX++;
                    ballPositionY--;
                    break;
                case Directions.Down: // Down
                    ballPositionY++;
                    break;
                case Directions.DownAndRight: // Down right
                    ballPositionX++;
                    ballPositionY++;
                    break;
                case Directions.DownAndLeft: // Down left
                    ballPositionX--;
                    ballPositionY++;
                    break;
            }

            if (ballPositionY == PlaygroundHeight - 2) // When the ball hits the floor or the paddle.
            {
                if ((ballPositionX >= paddlePositionX + 2) &&
                    (ballPositionX <= paddlePositionX + 4)) // The middle 3 "_" symbols.
                {
                    ballDirection = Directions.Up; // Bouncing up.
                }
                else if ((ballPositionX >= paddlePositionX) &&
                    (ballPositionX <= paddlePositionX + 1)) // The left 2 "_" symbols.
                {
                    ballDirection = Directions.UpAndLeft; // Bouncing up and to the left.
                }
                else if ((ballPositionX >= paddlePositionX + 5) &&
                    (ballPositionX <= paddlePositionX + 6)) // The right 2 "_" symbols.
                {
                    ballDirection = Directions.UpAndRight; // Bouncing up and to the right.
                }
                else
                {
                    Console.WriteLine("Game Over!"); // The ball did not land on the paddle.
                    Environment.Exit(0); // Terminates the main thread, without any exception thrown, i.e. exits the program.
                }
            }

            if (ballPositionY == 0) // When the ball hits the ceiling.
            {
                if (ballDirection == Directions.Up)
                {
                    ballDirection = Directions.Down; // From upward direction the ball bounces off downward.
                }
                else if (ballDirection == Directions.UpAndRight)
                {
                    ballDirection = Directions.DownAndRight; // From upward right direction the ball bounces off downward right.
                }
                else if (ballDirection == Directions.UpAndLeft)
                {
                    ballDirection = Directions.DownAndLeft; // From upward left direction the ball bounces off downward left.
                }
            }

            if (ballPositionX == 0) // When the ball hits the left wall.
            {
                if (ballDirection == Directions.UpAndLeft)
                {
                    ballDirection = Directions.UpAndRight; // From upward left direction the ball bounces off upward right.
                }
                else if (ballDirection == Directions.DownAndLeft)
                {
                    ballDirection = Directions.DownAndRight; // From downward left direction the ball bounces off downward right.
                }
            }

            if (ballPositionX == PlaygroundWidth - 1) // When the ball hits the right wall.
            {
                if (ballDirection == Directions.UpAndRight)
                {
                    ballDirection = Directions.UpAndLeft; // From upward right direction the ball bounces off upward left.
                }
                else if (ballDirection == Directions.DownAndRight)
                {
                    ballDirection = Directions.DownAndLeft; // From downward right direction the ball bounces off downward left.
                }
            }
            
            // Detect collisions with the wall
            int wallHeight = 4;

            if (ballPositionY <= wallHeight)
            {
                for (int i = 0; i < bricks.Length; i++)
                {
                    if (ballPositionX == bricks[i].PositionX && ballPositionY == bricks[i].PositionY
                        && bricks[i].getVisibility())
                    {
                        bricks[i].setInvisible();

                        if (ballDirection == Directions.Up)
                        {
                            ballDirection = Directions.Down; // From upward direction the ball bounces off downward.
                        }
                        else if (ballDirection == Directions.UpAndRight)
                        {
                            ballDirection = Directions.DownAndRight; // From upward right direction the ball bounces off downward right.
                        }
                        else if (ballDirection == Directions.UpAndLeft)
                        {
                            ballDirection = Directions.DownAndLeft; // From upward left direction the ball bounces off downward left.
                        }
                    }
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
                if (paddlePositionX > PlaygroundWidth - PaddleWidth)
                {
                    paddlePositionX = PlaygroundWidth - PaddleWidth;
                }
            }
        }

        private static void DrawPaddle()
        {
            for (int i = 0; i < PaddleWidth; i++)
            {
                Console.SetCursorPosition(paddlePositionX + i, PlaygroundHeight - 2);
                Console.Write('_');
            }
        }

        private static void DrawBall()
        {
            Console.SetCursorPosition(ballPositionX, ballPositionY);
            Console.Write(BallSymbol);
        }

        private static void DrawWall()
        {
            Console.SetCursorPosition(0, 1);

            int numBricks = 0;

            // Build a wall of bricks
            numBricks = 0;
            for (int row = 1; row <= 4; row++)
            {
                for (int column = 0; column < PlaygroundWidth; column++)
                {
                    bricks[numBricks] = new Brick(row, column);
                    numBricks++;
                }
            }
        }

        private static void UpdateWall()
        {
            Console.SetCursorPosition(0, 1);

            for (int i = 0; i < bricks.Length; i++)
            {
                Console.Write(bricks[i].getSymbol());
            }
        }
    }


    internal class Brick
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
