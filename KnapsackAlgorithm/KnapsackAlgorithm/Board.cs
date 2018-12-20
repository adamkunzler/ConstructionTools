using System;
using System.Collections.Generic;
using System.Linq;

namespace KnapsackAlgorithm
{
    public class Board
    {        
        public List<Piece> Pieces { get; set; }

        public int BoardLength { get; private set; }
        public int BoardLengthInches => BoardLength * 12;

        public Board(int boardLength)
        {
            BoardLength = boardLength;
            Pieces = new List<Piece>();
        }

        public void Display()
        {
            Console.WriteLine("Board");

            var uncutInches = BoardLengthInches;
            var cutInches = Pieces.Sum(x => x.Length);
            var diffInches = uncutInches - cutInches;
            
            Console.WriteLine($"\tUncut Inches: {uncutInches}");
            Console.WriteLine($"\tCut Inches: {cutInches}");
            Console.WriteLine($"\tUncut/Cut Diff: {diffInches}");
            Console.WriteLine($"\tPercentage Used: {(cutInches/uncutInches) * 100}");
            Console.WriteLine("\t---------------------");

            foreach (var p in Pieces)
            {
                Console.WriteLine($"\t{p.Name} - {p.Length}\"");
            }
        }
    }
}
