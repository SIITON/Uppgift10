using System;

namespace bingo
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfRows = 15;
            var game = new GameOfBingo(numOfRows);
            game.Start();
        }
    }
}
