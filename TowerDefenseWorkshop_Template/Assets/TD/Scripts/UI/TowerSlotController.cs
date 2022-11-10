namespace GSGD1
{
	using System.Collections;
	using System.Collections.Generic;
	using TMPro;
	using UnityEngine;
	using UnityEngine.UI;

	public enum State
	{
		Available = 0,
		GhostVisible
	}

	public class TowerSlotController : MonoBehaviour
	{
		[SerializeField]
		private TowerSlot[] _towerSlots = null;

		[System.NonSerialized]
		private State _state = State.Available;

		[System.NonSerialized]
		private TowerDescription _currentTowerDescription = null;

        [SerializeField]
        private LayerMask _layerMask;

        [SerializeField] private LayerMask stoneLayer;

        [SerializeField]
        private GameObject sentryScreen;

        public AProjectile projectileFire;
        public AProjectile projectileWater;
        public AProjectile projectileWood;
        public AProjectile projectileEarth;
        public AProjectile projectileMetal;

        public PlayerPickerController PlayerPickerController
		{
			get
			{
				return LevelReferences.Instance.PlayerPickerController;
			}
		}

		private void OnEnable()
		{
			for (int i = 0, length = _towerSlots.Length; i < length; i++)
			{
				_towerSlots[i].OnTowerSlotClicked -= TowerSlotController_OnTowerSlotClicked;
				_towerSlots[i].OnTowerSlotClicked += TowerSlotController_OnTowerSlotClicked;
			}
		}

		private void OnDisable()
		{
			for (int i = 0, length = _towerSlots.Length; i < length; i++)
			{
				_towerSlots[i].OnTowerSlotClicked -= TowerSlotController_OnTowerSlotClicked;
			}
		}

		private void TowerSlotController_OnTowerSlotClicked(TowerSlot sender)
		{
			if (_state == State.Available)
			{
				_currentTowerDescription = sender.TowerDescription;
				ChangeState(State.GhostVisible);
			}
		}

		private void Update()
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, float.MaxValue, stoneLayer))
            {
                //Recupere Stone
                if (hit.transform.parent.gameObject.GetComponent<Stone>().type == "fire")
                {
                    Stone.fire++;
                }
                if (hit.transform.parent.gameObject.GetComponent<Stone>().type == "water")
                {
					Stone.water++;
                }
                if (hit.transform.parent.gameObject.GetComponent<Stone>().type == "wood")
                {
					Stone.wood++;
                }
                if (hit.transform.parent.gameObject.GetComponent<Stone>().type == "earth")
                {
					Stone.earth++;
                }
                if (hit.transform.parent.gameObject.GetComponent<Stone>().type == "metal")
                {
					Stone.metal++;
                }
				Destroy(hit.transform.parent.gameObject);
            }

			if (Input.GetMouseButtonDown(0) == true)
			{
				if (_state == State.GhostVisible)
				{
					if (PlayerPickerController.TrySetGhostAsCellChild() == true)
					{
						sentryScreen.SetActive(false);
						MoneyBehaviour.money -= _currentTowerDescription.towerPrice;
						ChangeState(State.Available);
					}
				}
				else
				{
					if (Physics.Raycast(ray, out hit, float.MaxValue, _layerMask))
                    {
                        sentryScreen.GetComponent<SentryMenu>().selectedSentry = hit.transform.gameObject;
                        if (Stone.isPeackinWater == true)
						{
							Stone.isPeackinWater = false;
                            sentryScreen.GetComponent<SentryMenu>().selectedSentry.GetComponent<ProjectileLauncher>()._projectile = projectileWater;
							Stone.water--;
                        }
                        if (Stone.isPeackinFire == true)
                        {
                            Stone.isPeackinFire = false;
                            sentryScreen.GetComponent<SentryMenu>().selectedSentry.GetComponent<ProjectileLauncher>()._projectile = projectileFire;
                            Stone.fire--;
                        }
                        if (Stone.isPeackinMetal == true)
                        {
                            Stone.isPeackinMetal = false;
                            sentryScreen.GetComponent<SentryMenu>().selectedSentry.GetComponent<ProjectileLauncher>()._projectile = projectileMetal;
                            Stone.metal--;
                        }
                        if (Stone.isPeackinWood == true)
                        {
                            Stone.isPeackinWood = false;
                            sentryScreen.GetComponent<SentryMenu>().selectedSentry.GetComponent<ProjectileLauncher>()._projectile = projectileWood;
                            Stone.wood--;
                        }
                        if (Stone.isPeackinEarth == true)
                        {
                            Stone.isPeackinEarth = false;
                            sentryScreen.GetComponent<SentryMenu>().selectedSentry.GetComponent<ProjectileLauncher>()._projectile = projectileEarth;
                            Stone.earth--;
                        }
                        sentryScreen.SetActive(true);

                        if (sentryScreen.GetComponent<SentryMenu>().selectedSentry.GetComponent<Tower>().isMaxLevel == true)
						{
							sentryScreen.GetComponent<SentryMenu>().upgradeButton.SetActive(false);
                        }
						else
						{
                            sentryScreen.GetComponent<SentryMenu>().upgradeButton.SetActive(true);
                        }
					}
				}
			}
            if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Escape) == true)
			{
				Stone.isPeackinEarth = false;
				Stone.isPeackinFire = false;
				Stone.isPeackinMetal = false;
				Stone.isPeackinWater = false;
				Stone.isPeackinWood = false;
				ChangeState(State.Available);
                sentryScreen.SetActive(false);
            }
		}

		public void ChangeState(State newState)
		{
			switch (newState)
			{
				case State.Available:
				{
					PlayerPickerController.DestroyGhost();
					PlayerPickerController.Activate(false);
					_currentTowerDescription = null;
				}
				break;
				case State.GhostVisible:
				{
					PlayerPickerController.ActivateWithGhost(_currentTowerDescription.Instantiate());
				}
					break;
				default:
					break;
			}
			_state = newState;
		}
	}
}
