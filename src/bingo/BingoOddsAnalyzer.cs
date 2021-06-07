using System;
using System.Collections.Generic;
using System.Text;

namespace bingo
{
    public class BingoOddsAnalyzer
    {
        private readonly GameOfBingo _game;
        private readonly int _numOfRows;

        public BingoOddsAnalyzer(int numOfRows)
        {
            _numOfRows = numOfRows;
            _game = new GameOfBingo(_numOfRows);
        }

        public int TimesWithBingoOnFirstFiveTurns(int numOfTries)
        {
            int count = 0;
            for (int tries = 0; tries < numOfTries; tries++)
            {
                PlayFiveRoundsOfBingo();
                count += (_game.IsBingoHorizontally()) ? 1 : 0;
                if (tries % (numOfTries/20) == 0)
                {
                    Console.Clear();
                    Console.Write($"Tries: {tries}");
                    Console.Write($" | {100*Math.Round((double)tries/numOfTries, 2)} %");
                    Console.WriteLine($"| Counts: {count}");
                }
            }

            return count;

        }

        private void PlayFiveRoundsOfBingo()
        {
            _game.InitNewBingoBoard(_numOfRows);
            do
            {
                var numberDrawn = _game.DrawNumber();
                _game.MarkNumberIfDrawn(numberDrawn);
            } while (_game.Turn! > 5);
        }
    }
}
