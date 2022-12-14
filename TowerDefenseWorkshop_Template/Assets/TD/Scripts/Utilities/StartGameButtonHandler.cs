namespace GSGD1
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class StartGameButtonHandler : MonoBehaviour
    {
        [SerializeField]
        private Button _button = null;

        public AProjectile projectileFire;
        public AProjectile projectileWater;
        public AProjectile projectileWood;
        public AProjectile projectileEarth;
        public AProjectile projectileMetal;

        private void OnEnable()
        {
            _button.onClick.RemoveListener(StartGameClicked);
            _button.onClick.AddListener(StartGameClicked);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(StartGameClicked);
        }

        private void OnDestroy()
        {
            if (LevelReferences.HasInstance == true)
            {
                SpawnerManager spawnerManager = LevelReferences.Instance.SpawnerManager;
                spawnerManager.WaveStatusChanged -= OnWaveStatusChanged;
            }
        }

        private void StartGameClicked()
        {
            SpawnerManager spawnerManager = LevelReferences.Instance.SpawnerManager;
            spawnerManager.WaveStatusChanged -= OnWaveStatusChanged;
            spawnerManager.WaveStatusChanged += OnWaveStatusChanged;
            spawnerManager.StartWaves();
            //StartCoroutine(CoroutineDestroyButton());
        }
        //public IEnumerator CoroutineDestroyButton()
        //{
        //    yield return new WaitForSeconds(1f);
        //}

        private void OnWaveStatusChanged(SpawnerManager sender, SpawnerStatus status, int currentWaveRunning)
        {
            switch (status)
            {
                case SpawnerStatus.Inactive:
                    {
                        if (currentWaveRunning <= 0)
                        {
                            gameObject.SetActive(true);
                        }
                    }
                    break;
                case SpawnerStatus.WaveRunning:
                    {
                        gameObject.SetActive(false);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}