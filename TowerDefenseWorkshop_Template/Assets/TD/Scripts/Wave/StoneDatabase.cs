namespace GSGD1
{
    using UnityEngine;

    [System.Serializable]
    public class StoneDatabase
    {
        [SerializeField]
        private Stone _waveEntityStone = null;

        [SerializeField]
        private EntityStone _entityStone = EntityStone.None;

        public Stone Stone => _waveEntityStone;
        public EntityStone EntityStone => _entityStone;
    }
}
