using BubblesShoot.View.Common;
using BubblesShoot.View.Factories;

namespace BubblesShoot.View.MainMenu
{
    public class LevelSlotsCreator
    {
        private readonly MainMenuUI _menuUI;
        private readonly Factory _factory;
        private PrefabToCreate _prefabToCreate;
        public LevelSlotsCreator(MainMenuUI menuUI, Factory factory,PrefabToCreate prefabToCreate)
        {
            _menuUI = menuUI;
            _factory = factory;
            _prefabToCreate = prefabToCreate;
        }

        public bool CreateSlots(LevelData[] levels)
        {
            if (levels == null || levels.Length < 2) return false;

            for (int i = 1; i < levels.Length; i++)
            {
                var levelSlot = _factory.CreatePrefab(_prefabToCreate).GetComponent<LevelSlotUI>();
                if (levelSlot == null) i--;
                else levelSlot.SetLevel(levels[i].Number, i, _menuUI);
            }

            return true;
        }
    }
}
