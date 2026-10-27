using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCinematic : MonoBehaviour
{
    PlayerHere player;
    [SerializeField] Stairs_Hidden playerHiddenComp;

    public int sceneCatching;
    bool enabledEscaleraMano;
    public bool segundosTriggersPlayer;
    float timeEnabled;
    private void Awake()
    {
        player = GetComponent<PlayerHere>();
    }
    void Update()
    {
        BeginScene();
    }
    void BeginScene()
    {
        if (player.playerImHere || segundosTriggersPlayer)
        {
            Debug.Log("He entrado ha rango de la caja cinematica");
            if (playerHiddenComp.imHidden)
            {
                enabledEscaleraMano = true;
                AnimationHud.detectar_echar.SetTrigger("Detectar_Echar");
                EstructuraNiveles.nivel = sceneCatching;
            }
        }
        if (enabledEscaleraMano)
        {
            timeEnabled += Time.deltaTime;
            if(timeEnabled >= 0.2)
            {
                playerHiddenComp.enabled = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ropa"))
        {
            segundosTriggersPlayer = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ropa"))
        {
            segundosTriggersPlayer = false;
        }
    }
}
