using BubblesShoot.Model.Interfaces;
using System;
using UnityEngine;

namespace BubblesShoot.View.PathSystem
{
    public class ModelHelper : MonoBehaviour, ISearchGrid
    {
        public ISearchGrid SearchGrid { private get; set; }
        public float BubbleSize { get; set; }
        public Tuple<Vector2, bool> GetPosition(Vector2 hitPoint)
        {
            return SearchGrid.GetPosition(hitPoint);
        }
    }
}
