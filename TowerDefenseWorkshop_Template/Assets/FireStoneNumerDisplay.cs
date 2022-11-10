using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FireStoneNumerDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    public void Update()
    {
        text.SetText("" + Stone.fire);
    }
}
