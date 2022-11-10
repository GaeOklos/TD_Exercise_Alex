using GSGD1;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradePrice : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject sentryMenu;

    public void Update()
    {
        text.SetText("" + sentryMenu.GetComponent<SentryMenu>().selectedSentry.GetComponent<Tower>().towerDescription.towerPrice + "$");
    }
}
