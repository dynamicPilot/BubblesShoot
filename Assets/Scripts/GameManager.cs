using BubblesShoot.ModelControllers;
using UnityEngine;
using BubblesShoot.Root;
using BubblesShoot.View.Common;
using System.Collections;

namespace BubblesShoot
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private SceneData _sceneData;

        private void Awake()
        {
            SetSystems();
        }

        private void SetSystems()
        {
            StartCoroutine(GettingReady());
        }

        IEnumerator GettingReady()
        {
            var composer = new Composer(_sceneData);
            composer.MakeSystems();
            yield return null;

            while (!composer.IsReady())
                yield return null;
            StartGame(composer.GetIStartGame());
        }

        private void StartGame(IStartGame controller)
        {
            controller.StartGame();
        }

    }
}
