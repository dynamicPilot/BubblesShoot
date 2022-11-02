using BubblesShoot.Model.Common;
using BubblesShoot.View.Interfaces;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BubblesShoot.View.Updaters
{
    public class ViewUpdater
    {
        private readonly IAddObjectToFree _addToFree;
        private List<List<GameObject>> _bubblesObjects;

        public ViewUpdater(List<List<GameObject>> bubbles, IAddObjectToFree addToFree)
        {
            _bubblesObjects = bubbles;
            _addToFree = addToFree;
        }

        public void RegisterNewBubbleObject(GameObject bubbleObject, Tuple<int,int> indexes)
        {
            if (_bubblesObjects[indexes.Item1][indexes.Item2] == null)
                _bubblesObjects[indexes.Item1][indexes.Item2] = bubbleObject;
            else
                Debug.LogError($"BubbleObject array place is not Empty: row {indexes.Item1}, col {indexes.Item2}.");
        }

        public float UpdateView(List<List<BubbleCell>> bubbles)
        {
            float bottomObjectY = 1000;

            if (bubbles.Count > _bubblesObjects.Count) AddEmptyRow();

            for (int i = 0; i < _bubblesObjects.Count; i++)
            {
                for (int j = 0; j < _bubblesObjects[0].Count; j++)
                {
                    if (_bubblesObjects[i][j] == null) continue;

                    bool isActive = !bubbles[i][j].IsEmpty;
                    _bubblesObjects[i][j].SetActive(isActive);

                    if (!isActive)
                    {                       
                        GameObject temp = _bubblesObjects[i][j];
                        _bubblesObjects[i][j] = null;
                        _addToFree.AddObjectToFree(temp);
                    }                   
                    else
                    {
                        if (_bubblesObjects[i][j].transform.position.y < bottomObjectY)
                            bottomObjectY = _bubblesObjects[i][j].transform.position.y;
                    }
                }
            }
            //Debug.Log($"Update View. Bottom position is {bottomObjectY}.");
            return bottomObjectY;
        }

        private void AddEmptyRow()
        {           
            List<GameObject> rowList = new List<GameObject>();
            int row = _bubblesObjects.Count;

            for (int j = 0; j < _bubblesObjects[0].Count; j++)
                rowList.Add(null);

            _bubblesObjects.Add(rowList);
            //Debug.Log("Add row to Objects" + _bubblesObjects.Count);
        }
    }
}
