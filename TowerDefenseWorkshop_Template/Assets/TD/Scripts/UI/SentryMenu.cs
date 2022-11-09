using GSGD1;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryMenu : MonoBehaviour
{
    public GameObject selectedSentry;

    public void DestroySentry()
    {
        Destroy(selectedSentry.gameObject);
        gameObject.SetActive(false);
        MoneyBehaviour.money += selectedSentry.GetComponent<Tower>().towerDescription.towerPrice/2;
    }
}
