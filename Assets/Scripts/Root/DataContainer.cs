using BubblesShoot.View.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BubblesShoot.Root
{
    public class DataContainer : MonoBehaviour
    {
        public LevelData Data;
        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
