using System;

namespace KnapsackAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new BoardPieceOptimizerConfiguration
            {
                BoardLengthFeet = 8,
                Scale = 8
            };

            var boards = BoardPieceOptimizer.OptimizePieces(config);
            BoardPieceOptimizer.DisplaySummary(boards);

            Console.ReadLine();
        }        
    }
}
