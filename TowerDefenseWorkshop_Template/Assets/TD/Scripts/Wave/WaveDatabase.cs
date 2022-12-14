namespace GSGD1
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

#if UNITY_EDITOR
	using UnityEditor;
#endif //UNITY_EDITOR

	public enum EntityType
	{
		None,
		Neutral,
        Water,
        Fire,
        Wood, 
		Earth,
		Metal
	}
	
	public enum EntityStone
	{
		None,
        Water,
        Fire,
        Wood, 
		Earth,
		Metal
	}

    [CreateAssetMenu(menuName = "GameSup/WaveDatabase")]
	public class WaveDatabase : ScriptableObject
    {
        [SerializeField]
        private List<WaveEntityData> _waveEntityDatas = null;

        [SerializeField]
        private List<WaveSet> _waves = null;

		[SerializeField]
        private List<StoneDatabase> _stone = null;

        public List<WaveSet> Waves
		{
			get { return _waves; }
		}

		public bool GetWaveElementFromType(EntityType entityType, out WaveEntity outEntity)
		{
			WaveEntityData waveEntityData = _waveEntityDatas.Find(entity => entity.EntityType == entityType);
			if (waveEntityData != null)
			{
				outEntity = waveEntityData.WaveEntityPrefab;
				return true;
			}
			outEntity = null;
			return false;
		}
        public bool GetWaveStoneElement(EntityStone entityStone, out Stone outStone)
        {
            StoneDatabase stoneDatabase = _stone.Find(entity => entity.EntityStone == entityStone);
            if (stoneDatabase != null)
            {
                outStone = stoneDatabase.Stone;
                return true;
            }
            outStone = null;
            return false;
        }
    }

#if UNITY_EDITOR
	[CustomEditor(typeof(WaveDatabase))]
	public class WaveEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			serializedObject.Update();
			EditorGUILayout.Space(24);

			var waveDatabase = (serializedObject.targetObject as WaveDatabase);
			EditorGUILayout.TextArea(string.Format("Total Duration : {0} seconds", GetWaveDuration(waveDatabase.Waves).ToString()));
		}

		private float GetWaveDuration(List<WaveSet> waves)
		{
			float duration = 0;
			for (int i = 0, length = waves.Count; i < length; i++)
			{
				duration += waves[i].GetWaveDuration();
			}
			return duration;
		}
	}
#endif //UNITY_EDITOR

}