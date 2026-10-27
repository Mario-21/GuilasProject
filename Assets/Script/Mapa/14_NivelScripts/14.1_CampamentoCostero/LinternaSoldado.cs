using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class LinternaSoldado : MonoBehaviour
{
    SoldierLife vidaSoldado;
    ActualStatus statusSoldado;

    [SerializeField] GameObject luzLinterna;
    [SerializeField] EventReference luzRota;
    private void Awake()
    {
        vidaSoldado = GetComponent<SoldierLife>();
        statusSoldado = GetComponent<ActualStatus>();
    }
    void Start()
    {
        if(SoldierActiveInScene.instancia.soldiersStatus[statusSoldado.iD].statusVida <= 0)
        {
            luzLinterna.SetActive(false);
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(vidaSoldado.vida <= 0)
        {
            luzLinterna.SetActive(false);
            AudioManager.instancia.PlayOneShot(luzRota);
            this.enabled = false;
        }
    }
}
