using System;
using System.Collections.Generic;
using System.Linq;

namespace KnapsackAlgorithm
{
    /// <summary>
    /// BoardLength defaults to 8 feet. Scale default to 1/8" (8)
    /// </summary>
    public class BoardPieceOptimizerConfiguration
    {
        public int BoardLengthFeet { get; set; } = 8;
        public int BoardLengthInches => BoardLengthFeet * 12;
        public int Scale { get; set; } = 8;
    }

    public static class BoardPieceOptimizer
    {        
        public static List<Board> OptimizePieces(BoardPieceOptimizerConfiguration config)
        {            
            var thresholdScaled = config.BoardLengthInches * config.Scale;

            // get the pieces and convert to cutPieces
            var pieces = GetPieces();            
            var cutPieces = pieces.Select(x => x.ToCutPiece(config.Scale)).ToList();

            // boards will hold our optimized pieces
            var boards = new List<Board>();

            // optimize the cutPieces
            while (cutPieces.Any())
            {                
                // Run the knapsack algorithm
                var knapsackItems = PieceHelpers.ConvertToKnapsackItems(cutPieces);
                var knapsackContents = Knapsack.Calculate(thresholdScaled, knapsackItems);
                var optimizedPieces = PieceHelpers.ConvertKnapsackResults(knapsackContents, cutPieces);
                
                // put pieces in board
                var board = new Board(config.BoardLengthFeet);
                board.Pieces = optimizedPieces.Select(x => x.ToPiece()).ToList();
                boards.Add(board);

                // remove optimized pieces
                foreach (var r in optimizedPieces)
                    cutPieces.Remove(r);
            }

            return boards;
        }

        public static void DisplaySummary(List<Board> boards)
        {
            if (!boards.Any())
            {
                Console.WriteLine("No boards!");
                return;
            }
            
            var totalUncut = boards.Count() * boards[0].BoardLengthInches;
            var totalCut = boards.Sum(x => x.Pieces.Sum(y => y.Length));
            Console.WriteLine($"Number of Boards: {boards.Count()}");
            Console.WriteLine($"Total Uncut Board Feet: {totalUncut}");
            Console.WriteLine($"Total Cut Board Feet: {totalCut}");
            Console.WriteLine($"Uncut/Cut Diff: {totalUncut - totalCut}");
            Console.WriteLine();

            foreach (var b in boards) b.Display();
        }

        private static List<Piece> GetPieces()
        {
            var pieces = new List<Piece>();

            for (var i = 0; i < 6; i++)
                pieces.Add(new Piece
                {
                    Name = "Long",
                    Length = 60
                });

            for (var i = 0; i < 5; i++)
                pieces.Add(new Piece
                {
                    Name = "Vert",
                    Length = 47
                });

            for (var i = 0; i < 5; i++)
                pieces.Add(new Piece
                {
                    Name = "Vert Filler Top",
                    Length = 26.5f
                });

            for (var i = 0; i < 5; i++)
                pieces.Add(new Piece
                {
                    Name = "Vert Filler Bottom",
                    Length = 11
                });

            for (var i = 0; i < 15; i++)
                pieces.Add(new Piece
                {
                    Name = "Braces",
                    Length = 15
                });

            for (var i = 0; i < 4; i++)
                pieces.Add(new Piece
                {
                    Name = "Support",
                    Length = 18
                });

            for (var i = 0; i < 4; i++)
                pieces.Add(new Piece
                {
                    Name = "Support Filler",
                    Length = 11
                });

            return pieces;
        }
    }
}
