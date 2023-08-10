using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargarSacos : MonoBehaviour
{
    [Header("Elevator Info")]
    [SerializeField] Polipasto_Normal platformNormal;
    [SerializeField] PlatformEnCarga platformInCharge;
    public int indexPosPlatform;

    [Header("Soldier Info")]
    [SerializeField] SoldadoNormal cargaSoldier;
    [SerializeField] List<GameObject> itemFromSoldierC;
    [SerializeField] List<GameObject> itemInPlatformC;
    int indexItemCargar;

    [Header("Time realize action")]
    public float timeCargarLimite;
    public float timeDefaultWaitSoldier;
    public float timeCargar;

    int oneAction;
    public bool cargaAcive;
    void Start()
    {
        //Faltaria hacer los otros dos triggers que te ponen el saco
    }

    void Update()
    {
        
        //El polipasto tiene que llegar
        if(cargaSoldier.GetComponent<SoldierLife>().vida > 0)
        {
            PlatformActive();
            if (oneAction < 1)
            {
                //If soldier is not berserker and the platform is offload
                if (!platformInCharge.cargo)
                {
                    CargarBags();

                }
                else if (!cargaSoldier.berserker && platformInCharge.cargo)
                {
                    cargaSoldier.maxTiempoUbi = 90;

                }
            }
            
            if (cargaSoldier.berserker)
            {
                cargaSoldier.maxTiempoUbi = timeDefaultWaitSoldier;
            }
        }
    }
    void CargarBags()
    {
        if(cargaAcive && platformNormal.transform.position == platformNormal.destinos[indexPosPlatform].position)
        {
            timeCargar += Time.deltaTime;
            if(timeCargar >= timeCargarLimite && indexItemCargar < itemInPlatformC.Count)
            {
                //Put item in platform
                itemInPlatformC[indexItemCargar].SetActive(true);
                itemFromSoldierC[indexItemCargar].SetActive(false);
                //Reset Time 
                timeCargar = 0;
                //Next box
                indexItemCargar++;
                
            }
            else if(indexItemCargar >= itemInPlatformC.Count)
            {
                //Active platform when finish carga, to transport a SoldierDescarga
                platformInCharge.cargo = true;
                //I finish to cargar
                cargaAcive = false;
                //the platform can move
                platformNormal.enabled = true;
                //Reset Time 
                timeCargar = 0;
                //Made only one time
                oneAction++;
                //Return her default time
                cargaSoldier.maxTiempoUbi = timeDefaultWaitSoldier;
                //Reset the index, because you don't have boxes to cargar
                indexItemCargar = 0;
            }
        }
        
    }
    void PlatformActive()
    {
        //if The platform reaches the destiny and is descargada, disable the platform to the soldier can cargar
        if (platformNormal.transform.position == platformNormal.destinos[indexPosPlatform].position && !platformInCharge.cargo) 
        {
            platformNormal.enabled = false;
            platformNormal.emitterAscensor.Stop();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //I need know the state of chage if one of the enemy died 
            cargaAcive = true;
            oneAction = 0;

            if(!cargaSoldier.berserker)cargaSoldier.maxTiempoUbi = 90;


        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            cargaSoldier.maxTiempoUbi = timeDefaultWaitSoldier;
            cargaAcive = false;
        }
    }
}
