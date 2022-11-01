using BubblesShoot.Model.Common;
using System.Collections.Generic;
using UnityEngine;


namespace BubblesShoot.Model.Grids
{
    public static class GridConstructor
    {
        public static CoordinateGrid GetGrid(int rows, int columns, float cellSize = 0.32f, int emptyRows = 2)
        {
            var totalRows = rows + emptyRows;
            var width = cellSize * (columns + 0.5f);
            var height = cellSize * totalRows;
            var gridArray = new List<List<Vector2>>();
            var originPoint = new Vector2 (-width / 2, height - emptyRows * cellSize);

            for (int i = 0; i < totalRows; i++)
                gridArray.Add(ConstructRow(i, columns, cellSize, originPoint));              
            
            return new CoordinateGrid(gridArray, columns, totalRows, cellSize, width, height, originPoint);
        }

        public static List<Vector2> GetRowForGrid(CoordinateGrid grid)
        {
            return ConstructRow(grid.Rows, grid.Columns, grid.CellSize, grid.OriginPoint);
        }

        private static List<Vector2> ConstructRow(int row, int columns, float cellSize, Vector2 originPoint)
        {
            var rowList = new List<Vector2>();
            var shift = (row % 2 == 0) ? 0 : cellSize / 2;
            var x = originPoint.x + cellSize / 2 + shift;
            var y = originPoint.y - cellSize / 2 - cellSize * row;

            for (int j = 0; j < columns; j++)
            {
                rowList.Add(new Vector2(x, y));
                x += cellSize;
            }
            return rowList;
        }

        public static void Printer(CoordinateGrid grid)
        {
            Debug.Log("----------- Print grid ------------");
            string div = "   ";

            for (int i = 0; i < grid.Coordinates.Count; i++)
            {

                string line = i.ToString() + div;
                for (int j = 0; j < grid.Coordinates[i].Count; j++)
                {
                    var cell = grid.Coordinates[i][j];
                    line += cell.x + " "+ cell.y + div;
                }
                Debug.Log(line);
            }
        }
    }
}

