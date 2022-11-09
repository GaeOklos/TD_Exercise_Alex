using GSGD1;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryMenu : MonoBehaviour
{
    public GameObject selectedSentry;
    public GameObject upgradeButton;

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
}
