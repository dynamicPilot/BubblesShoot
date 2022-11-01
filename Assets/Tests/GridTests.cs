using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using BubblesShoot.Model.Grids;
using System;
using BubblesShoot;

public class GridTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void GridSimpleTest()
    {
        // Use the Assert class to test conditions
        CoordinateGrid grid = GridConstructor.GetGrid(10, 10, 0.32f, 2);

        Assert.AreEqual(grid.CellSize, 0.32f);
        Assert.AreEqual(grid.GetNearestCells(0, 0).Length, 2);
        Assert.AreEqual(grid.GetNearestCells(1, 0).Length, 5);
        Assert.AreEqual(grid.GetNearestCells(1, 1).Length, 6);
        Assert.AreEqual(grid.GetNearestCells(1, 1).Length, 6);
    }

    [Test]
    public void GridIndexesTest()
    {
        CoordinateGrid grid = GridConstructor.GetGrid(10, 10, 0.32f, 2);

        // test single
        int row = 1;
        int col = 0;
        Vector2 singlePosition = grid.Coordinates[row][col];
        Assert.AreEqual(GridSearcher.CalculateIndexesWithPosition(singlePosition, grid), new Tuple<int, int>(row, col));


        // test all
        for (int i = 0; i < grid.Rows; i++)
        {
            for (int j = 0; j < grid.Columns; j++)
            {
                Vector2 position = grid.Coordinates[i][j];
                Assert.AreEqual(GridSearcher.CalculateIndexesWithPosition(position, grid), new Tuple<int, int>(i, j));
            }
        }
    }

    [Test]
    public void GridCellNeighborsTest()
    {
        CoordinateGrid grid = GridConstructor.GetGrid(10, 10, 0.32f, 2);
        // test single
        int row = 10;
        int col = 3;
        var neighbors = grid.GetNearestCells(row, col);
        Debug.Log($"Neighbors for {row} col {col}");

        for (int i =0; i < neighbors.Length; i++)
        {
            Debug.Log($"   Neighbor: row {neighbors[i].Item1} col {neighbors[i].Item2}");   
        }

        Assert.AreEqual(grid.GetNearestCells(row, col).Length, 6);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    //[UnityTest]
    //public IEnumerator GridTestWithEnumeratorPasses()
    //{
    //    // Use the Assert class to test conditions.
    //    // Use yield to skip a frame.
    //    yield return null;
    //}
}
