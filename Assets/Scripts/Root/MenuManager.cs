using BubblesShoot.ModelControllers;
using BubblesShoot.Root;
using BubblesShoot.View.Common;
using BubblesShoot.View.MainMenu;
using System.Collections;
using UnityEngine;

namespace BubblesShoot.Root.Managers
{
    public class MenuManager : Manager
    {
        [SerializeField] private MenuSceneData _sceneData;

        private void Awake()
        {
            SetSystems();
        }

        public override IEnumerator GettingReady()
        {
            var composer = new MenuComposer(_sceneData, _container);
            composer.MakeSystems();
            yield return null;

            while (!composer.IsReady())
                yield return null;
            StartGame(composer.GetIStartGame());
            //StartGame(composer.GetIStartGame());
        }

    }
}
