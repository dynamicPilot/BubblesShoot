using BubblesShoot.ModelControllers;
using System.Collections;
using UnityEngine;

namespace BubblesShoot.Root.Managers
{
    public class Manager : MonoBehaviour
    {
        [SerializeField] protected DataContainer _container;
        protected void SetSystems()
        {
            _container = GetDataContainer();
            StartCoroutine(GettingReady());
        }

        public virtual IEnumerator GettingReady()
        {
            yield return null;
        }

        protected void StartGame(IStartGame controller)
        {
            controller.StartGame();
        }

        DataContainer GetDataContainer()
        {
            var dataContainers = GameObject.FindGameObjectsWithTag("DataContainer");

            if (dataContainers.Length == 0)
            {
                var temp = new GameObject("DataContainer");
                temp.tag = "DataContainer";
                return temp.AddComponent<DataContainer>();
            }


            if (dataContainers.Length > 1)
            {
                Debug.Log("More then one Data Container");
                for (int i = 1; i < dataContainers.Length; i++) Destroy(dataContainers[i]);
            }

            return dataContainers[0].GetComponent<DataContainer>();
        }
    }
}
