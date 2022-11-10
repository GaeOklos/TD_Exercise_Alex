namespace GSGD1
{
	using UnityEngine;

	[System.Serializable]
	public class WaveEntityDescription
	{
		[SerializeField]
		private EntityType _entityType = EntityType.None;

		[SerializeField]
		private float _extraDurationAfterSpawned = 0;

        [SerializeField]
        private EntityStone _entityStone = EntityStone.None;


        public EntityType EntityType
		{
			get
			{
				return _entityType;
			}
		}

        public EntityStone EntityStone
        {
            get
            {
                return _entityStone;
            }
        }

        public float ExtraDurationAfterSpawned
		{
			get
			{
				return _extraDurationAfterSpawned;
			}
		}
	}
}