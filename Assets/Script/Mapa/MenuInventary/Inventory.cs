using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //NOTA: Esto es un inventario, no el menu de pausa (quiza colocar)
    public static bool gameIsPause = false;

    public GameObject inventory;
    public ArmaController pistol;
    public B8Arma b8;
    ChangeWeapon change;
    private void Awake()
    {
        pistol = FindObjectOfType<ArmaController>();
        change = FindObjectOfType<ChangeWeapon>();
    }
    void Start()
    {
        //pistol = FindObjectOfType<ArmaController>();
        //change = FindObjectOfType<ChangeWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (change.changeWeapon)
        {
            if (Input.GetButtonDown("Inventory") && !b8.activarB8)
            {
                gameIsPause = !gameIsPause;
            }
        }
        else
        {
            if (Input.GetButtonDown("Inventory") && !pistol.activarDisparo)
            {
                gameIsPause = !gameIsPause;
            }
        }
        if (Input.GetButtonDown("Draw_Weapon"))
        {
            gameIsPause = false;
        }
        if (gameIsPause)
        {
            OpenInventory();
        }
        else CloseInventory();
    }
    void OpenInventory()
    {
        inventory.SetActive(true);
    }
    public void CloseInventory()
    {
        inventory.SetActive(false);
    }
}
