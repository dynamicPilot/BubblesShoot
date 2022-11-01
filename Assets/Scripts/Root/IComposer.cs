using BubblesShoot.ModelControllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BubblesShoot.Root.Interfaces
{
    public interface IComposer
    {
        public IStartGame GetIStartGame();
        public bool IsReady();
        public void MakeSystems();
    }
}
