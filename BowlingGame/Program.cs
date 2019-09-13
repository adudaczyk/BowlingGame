using System;

namespace BowlingGameSDET
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bowling game.");

            BowlingGame bowlingGame = new BowlingGame();
            bowlingGame.Roll(1);
            bowlingGame.Roll(4);
            bowlingGame.Roll(4);
            bowlingGame.Roll(5);
            bowlingGame.Roll(6);
            bowlingGame.Roll(4);
            bowlingGame.Roll(5);
            bowlingGame.Roll(5);
            bowlingGame.Roll(10);
            bowlingGame.Roll(0);
            bowlingGame.Roll(1);
            bowlingGame.Roll(7);
            bowlingGame.Roll(3);
            bowlingGame.Roll(6);
            bowlingGame.Roll(4);
            bowlingGame.Roll(10);
            bowlingGame.Roll(2);
            bowlingGame.Roll(8);
            bowlingGame.Roll(6);

            Console.WriteLine("Total score: " + bowlingGame.Score());
            Console.ReadKey();
        }
    }
}