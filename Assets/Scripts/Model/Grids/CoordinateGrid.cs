using System;
using System.Collections.Generic;
using UnityEngine;

namespace BubblesShoot.Model.Grids
{
    public class CoordinateGrid
    {
        public List<List<Vector2>> Coordinates {  get; private set; }
        public int Columns { get; private set; }
        public int Rows { get; private set; }
        public float Height {  get; private set; }
        public float Width { get; private set; }
        public float CellSize { get; private set; }
        public Vector2 OriginPoint { get; private set; }

        private Tuple<int, int>[] evenRool;
        private Tuple<int, int>[] oddRool;
        public CoordinateGrid(List<List<Vector2>> gridArray, int columns, int rows, float cellSize, float width, float height, Vector2 originPoint)
        {
            Coordinates = gridArray;
            Columns = columns;
            Rows = rows;
            CellSize = cellSize;
            Width = width;
            Height = height;

            OriginPoint = originPoint;
        }

        public void AddRow(List<Vector2> rowList)
        {
            Coordinates.Add(rowList);
            Rows++;
            Height += CellSize;
        }

        public Tuple<int, int>[] GetNearestCells(int row, int col)
        {
            List<Tuple<int,int>> result = new List<Tuple<int,int>>();
            var additionsRool = GetAdditionsRool(row % 2 == 0);

            for (int i = 0; i < additionsRool.Length; i++)
            {
                int newRow = row + additionsRool[i].Item1;
                int newCol = col + additionsRool[i].Item2;
                if (newRow > -1 && newRow < Coordinates.Count && newCol >= 0 &&
                    newCol < Coordinates[0].Count)
                    result.Add(Tuple.Create(newRow, newCol));
            }

            return result.ToArray();
        }

        private Tuple<int, int>[] GetAdditionsRool(bool evenRow)
        {
            if (evenRow)
            {
                if (evenRool == null) CreateRools(evenRow);
                return evenRool;
            }
            else
            {
                if (oddRool == null) CreateRools(false);
                return oddRool;
            }
        }

        private void CreateRools(bool evenRow)
        {
            List<Tuple<int, int>> result = new List<Tuple<int, int>>();
            result.Add(new Tuple<int, int>(-1, 0));
            result.Add(new Tuple<int, int>(1, 0));
            result.Add(new Tuple<int, int>(0, -1));
            result.Add(new Tuple<int, int>(0, 1));

            result.Add(new Tuple<int, int>(-1, evenRow ? -1 : 1));
            result.Add(new Tuple<int, int>(1, evenRow ? -1 : 1));

            if (evenRow) evenRool = result.ToArray();
            else oddRool = result.ToArray();
        }
    }
}
