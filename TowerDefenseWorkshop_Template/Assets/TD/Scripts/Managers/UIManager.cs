namespace GSGD1
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;
	using TMPro;

	public class UIManager : Singleton<UIManager>
	{
		[SerializeField] private TextMeshProUGUI _textSpeedOfLevel;
		private float _speedOfLevel = 1f;

		public void ChangeSpeedOfLevel()
		{
			
			if (_speedOfLevel < 8)
				_speedOfLevel *= 2;
			else
				_speedOfLevel = 0.5f;
			Time.timeScale = _speedOfLevel;
            _textSpeedOfLevel.SetText("x" + _speedOfLevel);
		}
	}
}