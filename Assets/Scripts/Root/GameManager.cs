using BubblesShoot.ModelControllers;
using UnityEngine;
using BubblesShoot.Root;
using BubblesShoot.View.Common;
using System.Collections;

namespace BubblesShoot.Root.Managers
{
    public class GameManager : Manager
    {
        [SerializeField] private SceneData _sceneData;

        private void Awake()
        {
            SetSystems();
        }

        public override IEnumerator GettingReady()
        {
            var composer = new Composer(_sceneData);
            composer.MakeSystems();
            yield return null;

            while (!composer.IsReady())
                yield return null;
            StartGame(composer.GetIStartGame());
        }
    }
}
