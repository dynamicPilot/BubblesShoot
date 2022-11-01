using BubblesShoot.Model.Common;
using BubblesShoot.Model.Grids;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BubblesShoot
{
    public static class GridSearcher
    {
        public static Tuple<int, int> SearchForGridCell(Vector2 hitPosition, CoordinateGrid grid, List<List<BubbleCell>> bubbles)
        {
            //Debug.Log($"Search for grid cell int grid with rows {grid.Coordinates.Count} and bubbles with rows " +
                //$"{bubbles.Count}");

            var indexes = CalculateIndexesWithPosition(hitPosition, grid);
            var row = indexes.Item1;
            var column = indexes.Item2;

            if (bubbles[row][column].IsEmpty) return indexes;


            return FindNearestEmptyCell(row, column, grid, bubbles, hitPosition);
        }

        public static Tuple<int,int> CalculateIndexesWithPosition(Vector2 hitPosition, CoordinateGrid grid)
        {
            //Debug.Log($"Hit Position: {hitPosition.x} {hitPosition.y}");
            //Debug.Log($"OriginPoint: {grid.OriginPoint.x} {grid.OriginPoint.y}");

            Vector2 correctedToOrigin = hitPosition - grid.OriginPoint;
            //Debug.Log($"CorrectedToOrigin: {correctedToOrigin.x} {correctedToOrigin.y}");
            int row = (int)Math.Floor(Mathf.Abs(correctedToOrigin.y / grid.CellSize));
            //Debug.Log($"Find row {row}. Grid Cell {grid.CellSize}");

            if (row % 2 != 0)
            {
                // correct calculation for odd rows
                correctedToOrigin.x -= grid.CellSize / 2;
            }

            int column = (int)Math.Floor(Mathf.Abs(correctedToOrigin.x / grid.CellSize));

            //Debug.Log($"Find row {row} and col {column}. Grid Rows {grid.Rows}");
            if (row >= grid.Rows) row--;
            if (column >= grid.Columns) column--;

            return new Tuple<int, int>(row, column);
        }

        private static Tuple<int, int> FindNearestEmptyCell(int row, int column, CoordinateGrid grid, List<List<BubbleCell>> bubbles, Vector2 hitPoint)
        {
            float distance = float.PositiveInfinity;
            int resultRow = -1, resultColumn = -1;

            var cellsToCheck = bubbles[row][column].Neighbors;

            for (int i = 0; i < cellsToCheck.Length; i++)
            {
                if (!bubbles[cellsToCheck[i].Item1][cellsToCheck[i].Item2].IsEmpty) continue;

                int tempRow = cellsToCheck[i].Item1;
                int tempColumn = cellsToCheck[i].Item2;
                float tempDistance = Vector2.Distance(grid.Coordinates[tempRow][tempColumn], hitPoint);
                
                if (tempDistance < distance)
                {
                    distance = tempDistance;
                    resultRow = tempRow;
                    resultColumn = tempColumn;
                }
            }

            return new Tuple<int, int>(resultRow, resultColumn);
        }
    }

}
