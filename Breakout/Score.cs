namespace Breakout
{
    using System;
    using System.Collections.Generic;

    using Breakout.Contracts;

    public class Score
    {
        private const int TopGamersRanklistCount = 5;

        private readonly List<IGamer> topGamersRanklist; 

        private Gamer currentGamer;

        public Score(Gamer gamer)
        {
            this.CurrentGamer = gamer;
            this.topGamersRanklist = new List<IGamer>(TopGamersRanklistCount);
        }
        
        public Gamer CurrentGamer { get; private set; }

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
    }
}
