using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoRecoveryList : MonoBehaviour
{
    public static AmmoRecoveryList ammoFromLevel;

    public List<bool> ammo;
    private void Awake()
    {
        if (AmmoRecoveryList.ammoFromLevel == null)
        {
            AmmoRecoveryList.ammoFromLevel = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void ResetearAmmo()
    {
        for (int i = 0; i < ammo.Count; i++)
        {
            ammo[i] = false;
        }
    }
}
