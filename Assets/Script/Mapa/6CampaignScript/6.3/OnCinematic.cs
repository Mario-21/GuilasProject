using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCinematic : MonoBehaviour
{
    PlayerHere player;
    [SerializeField] Stairs_Hidden playerHiddenComp;

    public int sceneCatching;
    bool enabledEscaleraMano;
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
        if (player.playerImHere)
        {
            if (Input.GetButtonDown("Fire2"))
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
}
