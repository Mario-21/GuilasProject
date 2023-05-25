using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePistol : MonoBehaviour
{
    public int indexMod;

    [Header("Pistol Data")]
    [SerializeField] SpriteRenderer pistolRender;
    [SerializeField] ArmaController pistola;
    [SerializeField] GameObject pistolBackPack;


    SpawnItemIcon pistolItem;
    PlayerHere player;

    private void Awake()
    {
        pistolItem = GetComponent<SpawnItemIcon>();
        player = GetComponent<PlayerHere>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.playerImHere) CatchPistol();
    }
    void CatchPistol()
    {
        if (Input.GetButtonDown("Action"))
        {
            //Habilitar y mostrar arma
            pistolRender.enabled = true;
            pistola.enabled = true;
            pistolBackPack.SetActive(false);
            //Spawnea el icono para indicar que has cogido el arma
            pistolItem.SpawnIcon();
            //La variable se activa
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        }
    }

}
