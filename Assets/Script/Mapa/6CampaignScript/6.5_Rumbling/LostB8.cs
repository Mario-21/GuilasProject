using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostB8 : MonoBehaviour
{
    public GameObject escombrosB8;
    [SerializeField] ArmaController weaponPlayer;
    void Start()
    {
        B8Rota();
    }
    void B8Rota()
    {
        //Previously pick up the object
        //no puedes hacerlo en base al spawn dado que cuendo entres de nuevo ya no sera 1 o 2
        if(SpecialWeapons.specialW.b8 && weaponPlayer.municion > 0)
        {
            SpecialWeapons.specialW.b8 = false;
            escombrosB8.SetActive(true);
        }
    }
}
