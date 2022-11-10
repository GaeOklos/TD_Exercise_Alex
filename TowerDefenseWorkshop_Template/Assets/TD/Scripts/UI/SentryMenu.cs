using GSGD1;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SentryMenu : MonoBehaviour
{
    public GameObject selectedSentry;
    public GameObject upgradeButton;

    public AProjectile projectileFire;
    public AProjectile projectileWater;
    public AProjectile projectileWood;
    public AProjectile projectileEarth;
    public AProjectile projectileMetal;

    public Image element;

    public Sprite imageFire;
    public Sprite imageWater;
    public Sprite imageWood;
    public Sprite imageEarth;
    public Sprite imageMetal;
    public Sprite imageNeutral;

    public void DestroySentry()
    {
        Destroy(selectedSentry.gameObject);
        gameObject.SetActive(false);
        MoneyBehaviour.money += selectedSentry.GetComponent<Tower>().towerDescription.towerPrice/2;
    }

    public void UpgradeSentry()
    {
        MoneyBehaviour.money -= selectedSentry.GetComponent<Tower>().towerDescription.towerPrice / 2;
        selectedSentry.GetComponent<ProjectileLauncher>().damage *= 2;
        if(selectedSentry.GetComponent<Tower>().upgradeLevel < selectedSentry.GetComponent<Tower>().maxLevel)
        {
            selectedSentry.GetComponent<Tower>().upgradeLevel++;
        }
        else
        {
            upgradeButton.SetActive(false);
            selectedSentry.GetComponent<Tower>().isMaxLevel = true;
        }
    }

    private void Update()
    {
        if(selectedSentry != null)
        {
            if(selectedSentry.GetComponent<ProjectileLauncher>()._projectile == projectileFire)
            {
                element.GetComponent<Image>().sprite = imageFire;
            }
            else if (selectedSentry.GetComponent<ProjectileLauncher>()._projectile == projectileEarth)
            {
                element.GetComponent<Image>().sprite = imageEarth;
            }
            else if (selectedSentry.GetComponent<ProjectileLauncher>()._projectile == projectileMetal)
            {
                element.GetComponent<Image>().sprite = imageMetal;
            }
            else if (selectedSentry.GetComponent<ProjectileLauncher>()._projectile == projectileWater)
            {
                element.GetComponent<Image>().sprite = imageWater;
            }
            else if (selectedSentry.GetComponent<ProjectileLauncher>()._projectile == projectileWood)
            {
                element.GetComponent<Image>().sprite = imageWood;
            }
            else
            {
                element.GetComponent<Image>().sprite = imageNeutral;
            }
        }
    }
}
