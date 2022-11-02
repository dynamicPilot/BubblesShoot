using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using BubblesShoot.Model.Grids;
using System;
using BubblesShoot;
using BubblesShoot.Model.Bubbles;
using BubblesShoot.Model.Interfaces;
using BubblesShoot.Model.Common;

public class BubblesTests
{
    [Test]

    public void BubblesConstructorTest()
    {
        int emptyRows = 1;
        CoordinateGrid grid = GridConstructor.GetGrid(8, 10, 0.32f, emptyRows);

        var colors = new COLOR[2][];
        colors[0] = new COLOR[] { COLOR.red, COLOR.blue, COLOR.yellow, COLOR.none };
        colors[1] = new COLOR[] { COLOR.none, COLOR.blue, COLOR.red, COLOR.none };


        var randomBubbles = BubblesConstructor.GetBubbles(grid, emptyRows, true, null);
        BubblesConstructor.Printer(randomBubbles);

        BubblesGraphUpdater.SearchForFloaters(randomBubbles);
        BubblesGraphUpdater.UpdateBubbleGraph(randomBubbles);
        for (int i = 0; i < grid.Rows; i++)
        {
            for (int j = 0;j < grid.Columns; j++)
            {
                Assert.IsTrue(randomBubbles[i][j] != null);
            }
        }

        
        BubblesColorRow[] colorRows = new BubblesColorRow[colors.Length];
        for (int i = 0; i < colors.Length; i++)
        {
            colorRows[i] = new BubblesColorRow();
            colorRows[i].Colors = colors[i];
        }

        for (int i = 0; i < colors.Length; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Assert.IsTrue(randomBubbles[i][j] != null);
            }
        }

        var bubbles = BubblesConstructor.GetBubbles(grid, emptyRows, false, colorRows);
        BubblesConstructor.Printer(bubbles);

        BubblesGraphUpdater.SearchForFloaters(bubbles);
        BubblesGraphUpdater.UpdateBubbleGraph(bubbles);

        var rowList = bubbles[0];

        for (int i = 0; i < rowList.Count; i++)
        {
            Assert.IsTrue(rowList[i] != null);
            Assert.IsTrue(rowList[i].IsEmpty == (colors[0][i % colors[0].Length] == COLOR.none));
        }
    }

    [Test]
    public void RandomGeneratorTest()
    {
        IGenerateNewBubble randomGenerator = new RandomBubbleGenerator();
        var randomBubble = randomGenerator.GenerateNewBubble();

        Assert.IsTrue(randomBubble != null);
        Assert.IsTrue(randomBubble.Color != COLOR.none);
    }

    [Test]
    public void SpecificGeneratorTest()
    {
        var colors = new COLOR[] { COLOR.red, COLOR.blue, COLOR.yellow, COLOR.none };
        var resultColors = new COLOR[] { COLOR.red, COLOR.blue, COLOR.yellow, COLOR.red };
        IGenerateNewBubble specificGenerator = new SpecificBubbleGenerator(colors);

        for(int i = 0; i < colors.Length; i++)
        {
            var bubble = specificGenerator.GenerateNewBubble();
            Assert.IsTrue(bubble != null);
            Assert.IsTrue(bubble.Color != COLOR.none);
            Assert.AreEqual(bubble.Color, resultColors[i]);
        }
    }
}
