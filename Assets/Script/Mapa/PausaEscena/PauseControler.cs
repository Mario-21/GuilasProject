using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControler : MonoBehaviour
{
    [Header("Weapons Data")]
    [SerializeField] Stairs_Hidden stairs_Hidden;
    [SerializeField] ArmaController pistol;
    [SerializeField] ChangeWeapon changeWeapon;
    [SerializeField] B8Arma b8;
    [Header("Inventory")]
    [SerializeField] Inventory inventory;
    [Header("CreateObjeto")]
    [SerializeField] CreateObject itemCreate;

    int once;
    void Update()
    {
        TogglePause();
    }
    void TogglePause()
    {
        //Si el juego esta pausado
        if(Time.timeScale == 0)
        {
            //Desactivar Armas
            pistol.enabled = false;
            changeWeapon.enabled = false;
            b8.enabled = false;
            //Desactivar Inventario
            inventory.enabled = false;
            inventory.CloseInventory();
            //Destruir el item creado
            Destroy(itemCreate.objetoClone);

            once = 0;
        }
        else
        {
            if(once < 1)
            {
                //Activar Armas Solo si no estoy escondido
                if (!stairs_Hidden.imHidden)
                {
                    pistol.enabled = true;
                    changeWeapon.enabled = true;
                    b8.enabled = true;
                }
                
                //Activar Inventario
                inventory.enabled = true;

                once++;
            }
        }
    }
}
