namespace Breakout
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Breakout.Contracts;

    public class Score
    {
        private const int TopGamersRanklistCount = 5;

        private readonly SortedDictionary<int, IGamer> topGamersRanklist; 

        private Gamer currentGamer;

        private int points;

        public Score(IGamer gamer)
        {
            this.points = 0;
            this.CurrentGamer = gamer;
            this.topGamersRanklist = new SortedDictionary<int, IGamer>();
        }
        
        public IGamer CurrentGamer { get; private set; }
        // TODO : List -> Dictionary
        private static void PrintHighScores(List<IGamer> gamerRatingList)
        {
            Console.WriteLine("Score: ");
            if (gamerRatingList.Count > 0)
            {
                for (int i = 0; i < gamerRatingList.Count; i++)
                {
                    Console.WriteLine(
                        $"{i + 1}.{gamerRatingList[i].GamerName} -> {gamerRatingList[i].GamerPoints} points");
                }
            }
            else
            {
                Console.WriteLine("Empty ranklist!");
            }
        }

        public void SaveScore()
        {
            Console.Clear();
            Console.WriteLine("Game Over!"); // The ball did not land on the paddle.
            Console.WriteLine("Your score: {0}", this.points);
            Console.Write("Enter you nickname to save the score: ");
            this.CurrentGamer.GamerName = Console.ReadLine();
            Console.Clear();
        }

        public void UpdateCurrentScore()
        {
            this.points++;
        }
    }
}
