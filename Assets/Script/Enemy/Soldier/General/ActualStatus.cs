using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualStatus : MonoBehaviour
{
    [Header("Identity")]
    public int iD;
    [Header("Casco Soldado Vida")]
    public GameObject cascoSoldado;
    [SerializeField] SpriteRenderer spriteCascoSoldado;
    [SerializeField] Sprite spriteCascoSoldadoGrieta;

    SoldierLife soldierLife;
    //Nota: For soldadosDetectar doesnt work, because you dont put her script
    SoldadoNormal soldadoMode;
    int oneTimeAttackMode;
    int oneTimeWarningMode;
    int onlyOne;
    private void Awake()
    {
        soldierLife = GetComponent<SoldierLife>();
        soldadoMode = GetComponent<SoldadoNormal>();
        //LoadStatus();
    }
    void Start()
    {
        //Te lo carga si esta vivo
        LoadStatus();
        SkinCabezaCasco();
        
    }
    private void Update()
    {
        CascoStatus();
        SafeModeSoldier();
        /*
        if(ListaAttackSoldado.modeSoldiers.activeAllAttackSoldiers && oneTimeAttackMode < 1 && soldierLife.vida > 0)
        {
            oneTimeAttackMode++;
        }
        if(ListaAttackSoldado.modeSoldiers.warningAllSoldiers && !ListaAttackSoldado.modeSoldiers.activeAllAttackSoldiers && oneTimeWarningMode < 1)
        {
            //ISeeCadaver();
            oneTimeWarningMode++;
        }*/

    }
    void SafeModeSoldier()
    {
        if (soldadoMode.berserker && onlyOne < 1)
        {
            SoldierActiveInScene.instancia.soldiersStatus[iD].berserkerStatus = soldadoMode.berserker;
            onlyOne++;
        }
    }
    private void OnDestroy()
    {
        SaveStatus();   
    }
    void SaveStatus()
    {
        //Necesitas algo para identificar el array

        //Cuando Aparece Cae dormido Deberia aparecer ya dormido
        //Si con transform no funciona el almacenado, almacena los vectores
        SoldierActiveInScene.instancia.soldiersStatus[iD].position_x = transform.position.x;
        SoldierActiveInScene.instancia.soldiersStatus[iD].position_y = transform.position.y;
        //Mode From soldier
        //SoldierActiveInScene.instancia.soldiersStatus[iD].berserkerStatus = soldadoMode.berserker;
        //SoldierActiveInScene.instancia.soldiersStatus[iD].modeSoldier = soldadoMode.berserker;
        SoldierActiveInScene.instancia.soldiersStatus[iD].warningSoldier = soldadoMode.seeCadaverWarning;
    }
    void LoadStatus()
    {
        soldierLife.vida = SoldierActiveInScene.instancia.soldiersStatus[iD].statusVida;
        soldadoMode.berserker = SoldierActiveInScene.instancia.soldiersStatus[iD].berserkerStatus;
        soldadoMode.seeCadaverWarning = SoldierActiveInScene.instancia.soldiersStatus[iD].warningSoldier;
        //Si detecta que el personaje a muerto, spawnea el cadaver en la zona donde ha muerto
        if(SoldierActiveInScene.instancia.soldiersStatus[iD].statusVida <=  0)
        {
            Vector3 lastPosition;
            lastPosition = new Vector3(SoldierActiveInScene.instancia.soldiersStatus[iD].position_x, SoldierActiveInScene.instancia.soldiersStatus[iD].position_y + 0.5f, 0f);

            transform.position = lastPosition;
        }
        /*
        if (Mathf.Abs(SoldierActiveInScene.instancia.soldiersStatus[iD].position_x) > 0 && Mathf.Abs(SoldierActiveInScene.instancia.soldiersStatus[iD].position_y) > 0)
        {
            //SoldierActiveInScene.instancia.soldiersStatus[0].lastPositionInScene.position = transform.position;

            Vector3 lastPosition;
            lastPosition = new Vector3(SoldierActiveInScene.instancia.soldiersStatus[iD].position_x, SoldierActiveInScene.instancia.soldiersStatus[iD].position_y + 0.5f, 0f);

            transform.position = lastPosition;

        }*/
    }

    public void ChangeModeAttackSoldier()
    {
        //COlocar update
        soldadoMode.berserker = SoldierActiveInScene.instancia.soldiersStatus[iD].berserkerStatus;
        soldadoMode.seeCadaverWarning = false;
    }
    public void ISeeCadaver()
    {
        Debug.Log("Chocolata");
        soldadoMode.seeCadaverWarning = SoldierActiveInScene.instancia.soldiersStatus[iD].warningSoldier;
    }
    /*
    void EstablishLifeBegin()
    {
        if (soldierLife.vida > 0) indexCasco = soldierLife.vida - 1;
        head.sprite = cascos[indexCasco];
    }
    void LifeConstantly()
    {
        if (indexCasco >= 0) head.sprite = cascos[indexCasco];
        else indexCasco = 0;

        if(soldierLife.vida <= 0)
        {
            head.sprite = cascos[0];
        }
    }*/
    void SkinCabezaCasco()
    {
        if(soldierLife.vida > 1)
        {
            cascoSoldado.SetActive(true);
        }
    }
    void CascoStatus()
    {
        if(soldierLife.vida == 2)
        {
            spriteCascoSoldado.sprite = spriteCascoSoldadoGrieta;
        }
        else if (soldierLife.vida == 1)
        {
            cascoSoldado.SetActive(false);
        }
    }
}
