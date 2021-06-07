using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace bingo
{
    public class GameOfBingo
    {
        public List<BingoRow> Rows;
        private List<int> _numbersGenerated;
        private readonly Random r = new Random();
        private int _numPerRow = 5;
        private List<int> _drawnNumbers;
        private int _turn;

        public GameOfBingo(int numOfRows)
        {
            InitNewBingoBoard(numOfRows);
            
        }

        private void InitNewBingoBoard(int numOfRows)
        {
            var countOfNumbersToGenerate = _numPerRow * numOfRows;
            //_numbersGenerated = new List<int>();
            _numbersGenerated = GenerateUniqueRandomOrderedNumbers(countOfNumbersToGenerate, 100);

            Rows = new List<BingoRow>();
            for (int i = 0; i < numOfRows; i++)
            {
                var row = _numbersGenerated.Skip(i * _numPerRow).Take(_numPerRow).ToArray();
                Rows.Add(new BingoRow
                {
                    IsMarked = new bool[5]{false, false, false, false, false},
                    Values = row
                });
            }

            _drawnNumbers = new List<int>();
            _turn = 0;
        }
        private List<int> GenerateUniqueRandomOrderedNumbers(int maxCount, int maxValue)
        {
            maxValue = (maxCount > maxValue) ? maxCount : maxValue;
            var numbersGenerated = new List<int>();
            while (numbersGenerated.Count < maxCount)
            {
                var randNum = r.Next(1, maxValue);
                if (!numbersGenerated.Contains(randNum))
                {
                    numbersGenerated.Add(randNum);
                }
            }
            return numbersGenerated;
        }

        public void ConsolePrintBingoBoard()
        {
            int i = 0;
            foreach (var row in Rows)
            {
                for (int j = 0; j < _numPerRow; j++)
                {
                    if (!row.IsMarked[j])
                    {
                        Console.Write(" {0,2} ", row.Values[j]);
                    }
                    else
                    {
                        Console.Write("  X ");
                    }
                    
                }
                Console.WriteLine();
                //i++;
                //if (i % 5 == 0)
                //{
                //    Console.WriteLine();
                //}
            }
        }

        public int DrawNumber()
        {
            while (true)
            {
                var newRandomNumber = r.Next(1, 100);
                if (!_drawnNumbers.Contains(newRandomNumber))
                {
                    _drawnNumbers.Add(newRandomNumber);
                    return newRandomNumber;
                }
            }
        }

        public void MarkNumberIfDrawn(int number)
        {
            _turn++;
            if (_numbersGenerated.Contains(number))
            {
                foreach (var row in Rows)
                {
                    for (int i = 0; i < _numPerRow; i++)
                    {
                        if (!row.IsMarked[i])
                        {
                            row.IsMarked[i] = row.Values[i] == number;
                        }
                    }
                }
            }
        }
    }
}