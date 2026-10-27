using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class TakePistol : MonoBehaviour
{
    public int indexMod;

    [Header("Pistol Data")]
    [SerializeField] SpriteRenderer pistolRender;
    [SerializeField] ArmaController pistola;
    [SerializeField] GameObject pistolMochila;

    [SerializeField] EventReference sonidoRecogerArma;

    SpawnItemIcon pistolItem;
    PlayerHere player;
    BoxCollider2D boxCollider2D;
    

    private void Awake()
    {
        pistolItem = GetComponent<SpawnItemIcon>();
        player = GetComponent<PlayerHere>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.playerImHere) CatchPistol();
    }
    void CatchPistol()
    {
        if (Input.GetButtonDown("Take"))
        {
            //Habilitar arma, mostrar arma
            pistolRender.enabled = true;
            pistola.enabled = true;
            pistolMochila.SetActive(false);
            //Audio Recoger Arma
            AudioManager.instancia.PlayOneShot(sonidoRecogerArma);
            //Spawnea el icono para indicar que has cogido el arma
            pistolItem.SpawnIcon();
            //La variable se activa
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
            //Desactiva el collider
            boxCollider2D.enabled = false;
        }
    }

}
