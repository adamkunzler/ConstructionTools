using System.Collections.Generic;
using System.Linq;

namespace KnapsackAlgorithm
{
    public static class PieceHelpers
    {
        /// <summary>
        /// Convert CutPieces into proper data structure for knapsack algorithm
        /// </summary>
        /// <param name="pieces"></param>
        /// <returns></returns>
        public static List<Item> ConvertToKnapsackItems(this List<CutPiece> pieces)
        {
            var items = pieces.Select(x => new Item(x.Name, x.UnitLength))
                              .ToList();
            return items;
        }       

        /// <summary>
        /// Convert the contents of a knapsack to a list of cutPieces
        /// </summary>
        /// <param name="itemCollection"></param>
        /// <param name="cutPieces"></param>
        /// <returns></returns>
        public static List<CutPiece> ConvertKnapsackResults(ItemCollection itemCollection, List<CutPiece> cutPieces)
        {
            // holds the list of cutPieces from the knapsack
            var result = new List<CutPiece>();

            // temporary structure to hold known pieces to match with the results of the knapsack
            var tempPieces = new List<CutPiece>(cutPieces);

            // process each of the items in the knapsack
            foreach (var c in itemCollection.Contents)
            {
                // get the name of the part and how many of that part
                var name = c.Key;
                var qty = c.Value;

                // for each quantity, add a separate cutPiece to the result
                for (var i = 0; i < qty; i++)
                {
                    // find the cutPiece that matches the knapsack item
                    //  - add it to the return result
                    //  - remove it from our list of known pieces
                    var item = tempPieces.First(x => x.Name == name);
                    result.Add(item);
                    tempPieces.Remove(item);
                }
            }

            return result;
        }
    }
}
