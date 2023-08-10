using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarAttackMode : MonoBehaviour
{
    SoldadoNormal soldado;
    SoldierLife lifeSoldado;
    ActualStatus actualStatus;

    public int vidaNowSoldier;
    private void Awake()
    {
        actualStatus = GetComponentInParent<ActualStatus>();
        soldado = GetComponentInParent<SoldadoNormal>();
        lifeSoldado = GetComponentInParent<SoldierLife>();
    }
    private void Start()
    {
        vidaNowSoldier = SoldierActiveInScene.instancia.soldiersStatus[actualStatus.iD].statusVida;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (soldado.berserker) { Debug.Log("Player esta Dentro"); soldado.seePlayer = true; }
            
        }
        if (collision.gameObject.CompareTag("BalaPlayer"))
        {
            soldado.seePlayer = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (soldado.berserker) { Debug.Log("Player esta Dentro"); soldado.seePlayer = true; }

        }
        if (collision.gameObject.CompareTag("BalaPlayer"))
        {
            soldado.seePlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BalaPlayer"))
        {
            Debug.Log("Bala salida");

            //Dos vertientes
            //1 La bala a entrado y no a producido cambios en la vida.
            //2 La bala si ha modificado la vida

            //Si al salir la bala esta NO me ha restado vida reproduce "Hey"
            if (vidaNowSoldier == lifeSoldado.vida)
            {
                AudioManager.instancia.PlayOneShot(FMODEvent.instancia.attackMode);
            }
        }
    }
}
