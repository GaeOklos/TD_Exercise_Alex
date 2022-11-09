using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    public static int money = 60;

    public void Update()
    {
        text.SetText("Money : " + money + "$");
    }
}
