using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WoodStoneNumerDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    public void Update()
    {
        text.SetText("" + Stone.wood);
    }
}
