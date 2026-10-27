using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

[RequireComponent(typeof(PlayerHere))]
public class Duct : MonoBehaviour
{
    PlayerHere playerHere;
    [Header("Block Player")]
    [SerializeField] BloquearMovimientoPlayer player;
    [Header("Position Info")]
    [SerializeField] Transform playerPos;
    [SerializeField] Transform ductPos;
    [Header("Time Secuence")]
    public float timeLimitBetweenScene;
    float timeBetweenScene;
    [Header("Icon")]
    [SerializeField] GameObject iconZone;
    [SerializeField] SpriteRenderer iconZoneSprite;
    [SerializeField] Sprite iconLeft;
    [SerializeField] Sprite iconRight;
    [Header("SFX")]
    [SerializeField] EventReference sfxSound;

    bool startDuct;
    enum Secuence
    {
        first,
        second,
        third
    }
    Secuence startSecuence;
    //Icon
    void Start()
    {
        playerHere = GetComponent<PlayerHere>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startDuct)
        {
            DuctAction();
        }
        else
        {
            UseDuct();
            timeBetweenScene = 0;
        }
    }
    void UseDuct()
    {
        if (playerHere.playerImHere)
        {
            DirectionIcon();
            iconZone.SetActive(true);
            if (Input.GetButtonDown("Action"))
            {
                AudioManager.instancia.PlayOneShot(sfxSound);
                startDuct = true;
                startSecuence =  Secuence.first;
            }
        }
    }
    void DuctAction()
    {
        switch (startSecuence)
        {
            case Secuence.first:
                iconZone.SetActive(false);
                AnimationHud.detectar_echar.SetBool("Transicion",true);
                player.BloquearMovPlayer();
                timeBetweenScene += Time.deltaTime;
                if(timeBetweenScene >= timeLimitBetweenScene)
                {
                    startSecuence = Secuence.second;
                }
                break;
            case Secuence.second:
                AnimationHud.detectar_echar.SetBool("Transicion", false);
                playerPos.position = ductPos.position;
                player.HabilitarMovPlayer();
                startDuct = false;
                startSecuence = Secuence.third;
                break;
            case Secuence.third:
                Debug.Log("End Duct");
                break;
        }
    }
    void DirectionIcon()
    {
        if(playerPos.localScale.x == -1)
        {
            iconZoneSprite.sprite = iconRight;
        }
        else if (playerPos.localScale.x == 1)
        {
            iconZoneSprite.sprite = iconLeft;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        iconZone.SetActive(false);
    }
}
