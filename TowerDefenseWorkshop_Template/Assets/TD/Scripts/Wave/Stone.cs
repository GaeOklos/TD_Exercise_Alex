using GSGD1;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public string type;

    public static int fire;
    public static int water;
    public static int wood;
    public static int earth;
    public static int metal;

    public static bool isPeackinFire;
    public static bool isPeackinWater;
    public static bool isPeackinWood;
    public static bool isPeackinEarth;
    public static bool isPeackinMetal;

    public void Cancel()
    {
        isPeackinFire = false;
        isPeackinWater = false;
        isPeackinWood = false;
        isPeackinEarth = false;
        isPeackinMetal = false;
    }

    public void PickFire()
    {
        if (fire >= 1)
        {
            isPeackinFire = true;
        }
    }
    public void PickWater()
    {
        if (water >= 1)
        {
            isPeackinWater = true;
        }
    }
    public void PickWood()
    {
        if (wood >= 1)
        {
            isPeackinWood = true;
        }
    }
    public void PickEarth()
    {
        if (earth >= 1)
        {
            isPeackinEarth = true;
        }
    }
    public void PickMetal()
    {
        if (metal >= 1)
        {
            isPeackinMetal = true;
        }
    }

}
