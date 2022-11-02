using BubblesShoot.Model.Common;
using BubblesShoot.Model.Grids;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BubblesShoot.Model.Bubbles
{
    public static class BubblesConstructor
    {
        public static List<List<BubbleCell>> GetBubbles(CoordinateGrid grid, int emptyRows, bool isRandom, BubblesColorRow[] colorRows)
        {
            var bubbles = new List<List<BubbleCell>>();
            var rows = grid.Rows - emptyRows;
            var columns = grid.Columns;

            int i = 0, index = 0;

            while (i < rows)
            {
                if (isRandom)
                {
                    bubbles.Add(GetRow(i++, columns, grid, GenerateColorRow(columns)));
                }
                else
                {
                    bubbles.Add(GetRow(i++, columns, grid, colorRows[index++].Colors));
                    index %= colorRows.Length;
                }   
            }

            for (i = 0; i < emptyRows; i++)
            {
                bubbles.Add(GetEmptyRow(rows + i, columns, grid));
            }

            return bubbles;
        }

        private static COLOR[] GenerateColorRow(int columns)
        {
            var rowList = new List<COLOR>();
            bool hasAtLeastOneBubble = false;

            while(!hasAtLeastOneBubble)
            {
                rowList.Clear();

                for (int j = 0; j < columns; j++)
                {
                    int colorIndex = Random.Range(0, (int)COLOR.none + 2);
                    if (colorIndex > (int)COLOR.none) colorIndex = (int)COLOR.none;
                    rowList.Add((COLOR)colorIndex);
                    hasAtLeastOneBubble = (colorIndex < (int)COLOR.none);
                }
            }

            return rowList.ToArray();
        }

        private static List<BubbleCell> GetRow(int row, int columns, CoordinateGrid grid, COLOR[] colors = null)
        {
            var rowList = new List<BubbleCell>();
            bool isEmpty = colors == null || colors.Length == 0;
            int j = 0, index = 0;

            while (j < columns)
            {
                Bubble newBubble = null;
                if (!isEmpty)
                {
                    newBubble = (colors[index] != COLOR.none) ? new Bubble(colors[index]) : null;
                    index++;
                    index %= colors.Length;
                }

                rowList.Add(new BubbleCell(newBubble, grid.GetNearestCells(row, j++)));                
            }

            return rowList;
        }

        private static List<BubbleCell> GetEmptyRow(int row, int columns, CoordinateGrid grid)
        {
            return GetRow(row, columns, grid, null);
        }

        public static void AddRowToBubble(CoordinateGrid grid, List<List<BubbleCell>> bubbles)
        {
            bubbles.Add(GetRow(bubbles.Count, bubbles[0].Count, grid, null));

            int rowToUpdate = bubbles.Count - 2;
            for (int j = 0; j < bubbles[0].Count; j++)
            {
                bubbles[rowToUpdate][j].Neighbors = grid.GetNearestCells(rowToUpdate, j);
            }
        }

        public static void Printer(List<List<BubbleCell>> bubbles)
        {
            Debug.Log("----------- Print bubbles ------------");
            string div = "   ";

            for(int i = 0; i < bubbles.Count;i++)
            {
                
                string line = i.ToString() + div;
                for (int j = 0; j < bubbles[i].Count; j++)
                {
                    var cell = bubbles[i][j];

                    if (cell.IsEmpty)
                    {
                        line += "empty" + div;
                    }
                    else line += cell.Bubble.Color.ToString() + div;
                }
                Debug.Log(line);
            }
        }
    }
}
