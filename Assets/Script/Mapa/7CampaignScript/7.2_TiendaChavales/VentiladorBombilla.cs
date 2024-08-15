using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class VentiladorBombilla : MonoBehaviour
{
    public int indexMod;
    [Header("Usar Ventilador")]
    public SpriteRenderer cabezaVentilador;
    public Sprite ventiladorOn;
    public Sprite ventiladorOff;
    public GameObject luzFake;
    public bool onCeilingFan;
    [Header("Soldier Switch")]
    [SerializeField] SoldierLife soldierSwitchLife;
    public float timeOnCeilingLimit = 1.5f;
    public float timeOnCeiling;
    public bool enemyHere;

    PlayerHere player;
    void Start()
    {
        player = GetComponent<PlayerHere>();
        //if (!StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion);
    }
    void Update()
    {
        if (!StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            ActiveCeilingFan();
            CeilingFan();
            SoldierOnCeiling();
            /*
            else
            {
                cabezaVentilador.sprite = ventiladorOff;
                luzFake.SetActive(false);
            }
            */
        }
        void ActiveCeilingFan()
        {
            if (player.playerImHere)
            {
                if (Input.GetButtonDown("Action"))
                {
                    onCeilingFan = !onCeilingFan;
                }
            }

        }
        void CeilingFan()
        {
            if (onCeilingFan)
            {
                cabezaVentilador.sprite = ventiladorOn;
                luzFake.SetActive(true);
            }
            else
            {
                cabezaVentilador.sprite = ventiladorOff;
                luzFake.SetActive(false);
            }
        }
        void SoldierOnCeiling()
        {
            //Encender la bombilla ventilador
            if (enemyHere && soldierSwitchLife.vida > 0)
            {
                timeOnCeiling += Time.deltaTime;
                if (timeOnCeiling >= timeOnCeilingLimit)
                {
                    AudioManager.instancia.PlayOneShot(FMODEvent.instancia.botonGeneral);
                    onCeilingFan = true;
                    timeOnCeiling = 0;
                    enemyHere = false;
                }
            }
            else
            {
                timeOnCeiling = 0;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) enemyHere = true;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyHere = false;
            timeOnCeiling = 0;
        }
    }

}
