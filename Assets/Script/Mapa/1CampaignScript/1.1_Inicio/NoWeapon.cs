using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoWeapon : MonoBehaviour
{
    public int indexNoWeapon;

    [Header("Weapons Data")]
    [SerializeField] ArmaController pistol;
    [SerializeField] ChangeWeapon changeWeapon;
    [SerializeField] B8Arma b8;
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexNoWeapon].modificacion)
        {
            pistol.enabled = true;
            changeWeapon.enabled = true;
            b8.enabled = true;
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexNoWeapon].modificacion)
        {
            pistol.enabled = true;
            changeWeapon.enabled = true;
            b8.enabled = true;
            this.enabled = false;
        }
        else
        {
            pistol.enabled = false;
            changeWeapon.enabled = false;
            b8.enabled = false;

            Debug.Log("No tengo arma");
        }
    }
}
