using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManageduPauvre : MonoBehaviour
{
    [SerializeField]
    public GameObject[] BouttonAnimation;

    private void Start()
    {
        for (int i = 0; i < BouttonAnimation.Length; i++)
            BouttonAnimation[i].GetComponent<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
    }
}
