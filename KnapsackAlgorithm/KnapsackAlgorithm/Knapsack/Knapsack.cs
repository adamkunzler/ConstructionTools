using System;
using System.Collections.Generic;

namespace KnapsackAlgorithm
{
    public static class Knapsack
    {                
        /// <summary>
        /// Core knapsack algorithm. Builds out the results in an array of ItemCollection objects.
        /// By the end of the algorithm, the most optimized solution is the last element of the
        /// array. That is what is returned and processed.
        /// </summary>
        /// <param name="capacity"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public static ItemCollection Calculate(int capacity, List<Item> items)
        {
            // create and initialize an array to hold the various solutions
            var ic = new ItemCollection[capacity + 1];
            for (var i = 0; i <= capacity; i++) ic[i] = new ItemCollection();

            // foreach item...
            for (var i = 0; i < items.Count; i++)
            {
                // loop from highest capacity to lowest capacity
                for (var j = capacity; j >= 0; j--)
                {
                    // does the current item fit in the current capacity?
                    if (j >= items[i].Weight)
                    {
                        // calculate the ratio of capacity to item weight
                        var quantity = Math.Min(1, j / items[i].Weight);
                        for (var k = 1; k <= quantity; k++)
                        {
                            // calculate the "score" of the result
                            var lighterCollection = ic[j - k * items[i].Weight];
                            var testValue = lighterCollection.TotalValue + k * items[i].Value;

                            // if the score of this solution is better than the previous one
                            // then we'll push this solution onto the end of the solutions array
                            if (testValue > ic[j].TotalValue)
                            {
                                (ic[j] = lighterCollection.Copy()).AddItem(items[i], k);
                            }
                        }
                    }
                }
            }

            return ic[capacity];
        }
    }
}