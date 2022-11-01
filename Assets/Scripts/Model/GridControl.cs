using BubblesShoot.Model.Bubbles;
using BubblesShoot.Model.Common;
using BubblesShoot.Model.Grids;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BubblesShoot.Model
{
    public class GridControl
    {
        private CoordinateGrid _grid;
        private Tuple<int, int> _cacheIndexes;
        public GridControl(CoordinateGrid grid)
        {
            _grid = grid;
        }

        public Tuple<Vector2, bool> GetPosition(Vector2 hitPoint, List<List<BubbleCell>> bubbles)
        {
            Tuple<int, int> indexes = GridSearcher.SearchForGridCell(hitPoint, _grid, bubbles);

            try
            {
                _cacheIndexes = indexes;
                return new Tuple <Vector2, bool> (_grid.Coordinates[indexes.Item1][indexes.Item2], true);
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }

            _cacheIndexes = null;
            return new Tuple<Vector2, bool>(Vector2.zero, false);
        }

        public Tuple<int, int> GetIndexes(Vector2 position, bool useCache = true)
        {
            if (!useCache || _cacheIndexes == null)
                return GridSearcher.CalculateIndexesWithPosition(position, _grid);

            Vector2 cachePosition = _grid.Coordinates[_cacheIndexes.Item1][_cacheIndexes.Item2];
            float delta = Mathf.Abs(Vector2.Distance(cachePosition, position));

            if (delta <= 0.01f)
            {
                Debug.Log($"Use cache indexes {_cacheIndexes.Item1} {_cacheIndexes.Item2}");
                return _cacheIndexes;
            }
            else return GridSearcher.CalculateIndexesWithPosition(position, _grid);
        }

        public CoordinateGrid AddRow()
        {
            _grid.AddRow(GridConstructor.GetRowForGrid(_grid));
            //GridConstructor.Printer(_grid);
            return _grid;
        }
    }
}
