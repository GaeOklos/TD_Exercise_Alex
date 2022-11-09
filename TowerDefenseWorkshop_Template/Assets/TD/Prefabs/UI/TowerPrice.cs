using GSGD1;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerPrice : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TowerDescription towerDescription;

    public void Update()
    {
        text.SetText(towerDescription.towerPrice + "$");
    }
}
