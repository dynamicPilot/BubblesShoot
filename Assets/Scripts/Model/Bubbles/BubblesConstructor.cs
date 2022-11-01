using BubblesShoot.Model.Common;
using BubblesShoot.Model.Grids;
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BubblesShoot.Model.Bubbles
{
    public static class BubblesConstructor
    {
        public static List<List<BubbleCell>> GetRandomBubbles(CoordinateGrid grid, int emptyRows = 1)
        {
            var bubbles = new List<List<BubbleCell>>();
            var rows = grid.Rows - emptyRows;
            var columns = grid.Columns;

            bool hasAtLeastOneBubble = false;

            for(int i = 0; i < rows; i++)
            {
                var rowList = new List<BubbleCell>();
                hasAtLeastOneBubble = false;

                for (int j = 0; j < columns; j++)
                {
                    int colorIndex = Random.Range(0, 7);

                    if (colorIndex > 3) rowList.Add(new BubbleCell(null, grid.GetNearestCells(i, j)));
                    else
                    {
                        rowList.Add(new BubbleCell(new Bubble((COLOR)colorIndex), grid.GetNearestCells(i, j)));
                        hasAtLeastOneBubble = true;
                    }
                }

                if (!hasAtLeastOneBubble) i--;
                else bubbles.Add(rowList);
            }

            for(int i = 0; i < emptyRows; i++)
            {
                bubbles.Add(GetEmptyRow(rows + i, columns, grid));
            }
            //Printer(bubbles);
            return bubbles;
        }

        private static List<BubbleCell> GetEmptyRow(int row, int columns, CoordinateGrid grid)
        {
            var rowList = new List<BubbleCell>();
            for (int j = 0; j < columns; j++)
            {
                rowList.Add(new BubbleCell(null, grid.GetNearestCells(row, j)));
            }

            return rowList;
        }

        public static void AddRowToBubble(CoordinateGrid grid, List<List<BubbleCell>> bubbles)
        {
            bubbles.Add(GetEmptyRow(bubbles.Count, bubbles[0].Count, grid));

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
