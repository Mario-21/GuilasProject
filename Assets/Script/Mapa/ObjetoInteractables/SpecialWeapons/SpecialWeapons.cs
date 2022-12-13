using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialWeapons : MonoBehaviour
{
    public static SpecialWeapons specialW;
    public bool b8;
    void Start()
    {
        if (SpecialWeapons.specialW == null)
        {
            SpecialWeapons.specialW = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
