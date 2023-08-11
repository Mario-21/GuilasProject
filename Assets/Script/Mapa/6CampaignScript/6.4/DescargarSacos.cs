using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class DescargarSacos : MonoBehaviour
{
    [Header("Elevator Info")]
    [SerializeField] Polipasto_Normal platformNormal;
    [SerializeField] PlatformEnCarga platformInCharge;
    public int indexPosPlatform;

    [Header ("Soldier Info")]
    [SerializeField] SoldadoNormal descargaSoldier;
    [SerializeField] List <GameObject> itemFromSoldierD;
    [SerializeField] List <GameObject> itemInPlatformD;
    int indexItemDescarga;

    [Header ("Time realize action")]
    public float timeCargarLimite;
    public float timeDefaultWaitSoldier;
    float timeCargar;

    [Header("SFX Descargar")]
    [SerializeField] EventReference descargaSFX;
    StudioEventEmitter emissorDescarga;
    [SerializeField] GameObject itemDescarga;

    int oneAction;
    bool descargaActive;
    void Start()
    {
        emissorDescarga = AudioManager.instancia.InitializeEventEmitter(descargaSFX, itemDescarga);
        //Faltaria hacer los otros dos triggers que te ponen el saco
    }

    // Update is called once per frame
    void Update()
    {
        
        //El polipasto tiene que llegar
        if (descargaSoldier.GetComponent<SoldierLife>().vida > 0 && !descargaSoldier.berserker)
        {
            PlatformActive();
            if (oneAction < 1)
            {
                if (platformInCharge.cargo)
                {
                    DescargarBags();
                }
                else if (!descargaSoldier.berserker && platformInCharge.cargo)
                {
                    descargaSoldier.maxTiempoUbi = 90;

                }
                //Ver si cuando lo colocas pasa a 90
            }
        }

        if (descargaSoldier.berserker)
        {
            descargaSoldier.maxTiempoUbi = timeDefaultWaitSoldier;
        }
    }

    void DescargarBags()
    {
        if (descargaActive && platformNormal.transform.position == platformNormal.destinos[indexPosPlatform].position)
        {
            timeCargar += Time.deltaTime;
            //Start Descarga
            if (timeCargar >= timeCargarLimite && indexItemDescarga < itemInPlatformD.Count)
            {
                emissorDescarga.Play();
                //Put item in platform
                itemInPlatformD[indexItemDescarga].SetActive(false);
                itemFromSoldierD[indexItemDescarga].SetActive(true);
                //Time that take put one box reset
                timeCargar = 0;
                //Next box 
                indexItemDescarga++;

            }
            //Finish Descarga
            else if (indexItemDescarga >= itemInPlatformD.Count)
            {
                //Active platform when finish descarga, to transport a SoldierCarga
                platformInCharge.cargo = false;
                //I finish to descargar
                descargaActive = false;
                //The platform can move
                platformNormal.enabled = true;
                //Reset Time 
                timeCargar = 0;
                //Made only one time
                oneAction++;
                //Return her default time
                descargaSoldier.maxTiempoUbi = timeDefaultWaitSoldier;
                //Reset the index, because you don't have boxes to descargar
                indexItemDescarga = 0;
            }
        }

    }
    void PlatformActive()
    {
        //If the platform is in her position and is in charge, desactive the component to wait 
        if (platformNormal.transform.position == platformNormal.destinos[indexPosPlatform].position && platformInCharge.cargo) 
        {
            platformNormal.enabled = false;
            platformNormal.emitterAscensor.Stop();
        }
        //Make a number that change when the enemy enter and active the platform again if soldiers are life 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //I need know the state of chage if one of the enemy died 
            descargaActive = true;
            oneAction = 0;
            if(!descargaSoldier.berserker)descargaSoldier.maxTiempoUbi = 90;
            //EL cambio lo hace rapidisimo
            //platform.enabled = true;


        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //I need know the state of chage if one of the enemy died 
            descargaActive = false;
            
            //oneAction = 0;

            //platform.enabled = true;


        }
    }
}

 
