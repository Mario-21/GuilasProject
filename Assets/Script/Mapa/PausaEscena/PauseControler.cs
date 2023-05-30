using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControler : MonoBehaviour
{
    [Header("Weapons Data")]
    [SerializeField] ArmaController pistol;
    [SerializeField] ChangeWeapon changeWeapon;
    [SerializeField] B8Arma b8;

    void Update()
    {
        TogglePause();
    }
    void TogglePause()
    {
        //Si el juego esta pausado
        if(Time.timeScale == 0)
        {
            pistol.enabled = false;
            changeWeapon.enabled = false;
            b8.enabled = false;
        }
        else
        {
            pistol.enabled = true;
            changeWeapon.enabled = true;
            b8.enabled = true;
            Debug.Log("Continue");
        }
    }
}
