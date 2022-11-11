using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Pause_Menu : MonoBehaviour
{
		[SerializeField]
		private GameObject _pauseMenuPanel = null;
		private bool _isPause = false;
    	public GameObject PauseMenuUI;
		public Button buttonPlay;
		public Button buttonPause;
		public Button buttonSpeed;
		private bool _isDead = false;
		string sceneName;
		[SerializeField] private TextMeshProUGUI _textSpeedOfLevel;

		public void Pause()
		{
			if (_isDead == false) {
				PauseMenuUI.SetActive(true);
				_pauseMenuPanel.SetActive(true);
				buttonPause.gameObject.SetActive(false);
				buttonSpeed.gameObject.SetActive(false);
				buttonPlay.gameObject.SetActive(true);
				_isPause = true;
				Time.timeScale = 0;
			}
		}
		public void Resume()
		{
			if (_isDead == false) {
           		_textSpeedOfLevel.SetText("x1");
				_pauseMenuPanel.SetActive(false);
				PauseMenuUI.SetActive(false);
				buttonPause.gameObject.SetActive(true);
				buttonSpeed.gameObject.SetActive(true);
				buttonPlay.gameObject.SetActive(false);
				_isPause = false;
				Time.timeScale = 1;
			}
		}

		public void CurLoadScene()
    	{
			if (_isPause) {
				Resume();
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
			else
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
		public void LoadScene(string sceneName)
		{
			if (_isPause) {
				Resume();
				SceneManager.LoadScene(sceneName);
			}
			else
				SceneManager.LoadScene(sceneName);
    	}

		private void Update()
		{
			if ((Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) && _isDead == false)
			{
				if (_isPause) {
					Resume();
				}
				else {
					Pause();
				}
			}
		}
}
