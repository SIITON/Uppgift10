using System;

namespace bingo
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new GameOfBingo(15);
            game.ConsolePrintBingoBoard();
            while (true)
            {
                Console.ReadKey();
                var numberDrawn = game.DrawNumber();
                Console.WriteLine($"Number drawn: {numberDrawn}");
                Console.ReadKey();

                game.MarkNumberIfDrawn(numberDrawn);
                Console.Clear();
                game.ConsolePrintBingoBoard();
            }
            

        }
    }
}
