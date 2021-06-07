using System;
using System.Diagnostics;

namespace bingo
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfRows = 15;
            var numOfTries = 10000000;
            //var game = new GameOfBingo(numOfRows);
            //game.StartInConsole();
            var stopwatch = Stopwatch.StartNew();
            var stats = new BingoOddsAnalyzer(numOfRows);
            Console.WriteLine("running...");
            var count = stats.TimesWithBingoOnFirstFiveTurns(numOfTries);
            var elapsedTotalSeconds = stopwatch.Elapsed.TotalSeconds;
            var avgBoardsPerSecond = numOfTries / elapsedTotalSeconds;
            Console.WriteLine($"Times with BINGO after 5 turns:");
            Console.WriteLine($"{count} out of {numOfTries} bingoboards");
            Console.WriteLine($"Time: {elapsedTotalSeconds} s, Avg: {avgBoardsPerSecond}");
        }
    }
}
