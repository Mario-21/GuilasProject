using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestWeapon : MonoBehaviour
{
    [SerializeField] GameObject bestWeapon;
    [SerializeField] ArmaController weaponPlayer;

    private void Start()
    {
        Invoke("SpawnBestWeapon", 1.0f);
    }
    void SpawnBestWeapon()
    {
        if (weaponPlayer.municion <= 0 && !SpecialWeapons.specialW.b8)
        {
            bestWeapon.SetActive(true);
            //TAmbien podría hacerlo como en el foco que tarde unos segundos en el start invoke
        }
    }
}
