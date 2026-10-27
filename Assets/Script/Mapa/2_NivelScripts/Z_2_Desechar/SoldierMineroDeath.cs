using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMineroDeath : MonoBehaviour
{
    [Header("Soldier Info")]
    public int indexSoldier;
    [Header("Item Soldier Info")]
    public int indexItem;
    public GameObject itemSoldier;
    [Header("Ascensor Minero")]
    public GameObject ascensorMineroArriba;
    public GameObject ascensorMineroAbajo;
    [Header("Quarry")]
    [SerializeField] List<UseQuarry> quarries;
    [Header("Panel Quarry")]
    [SerializeField] List<UsePanelQuarry> panelQuarries;
    [Header("Activadores Quarry")]
    [SerializeField] List<ActivarModificador> activadorQuarries;
    void Start()
    {
        if (SoldierActiveInScene.instancia.soldiersStatus[indexSoldier].statusVida > 0)
        {
            //On quarry if soldier is alive
            for (int i = 0; i < quarries.Count; i++)
            {
                quarries[i].enabled = true;
            }
        }
        else if (SoldierActiveInScene.instancia.soldiersStatus[indexSoldier].statusVida <= 0)
        {
            //Appear elevator up and elevator normal DesAppear, because the soldier died previously
            ascensorMineroArriba.SetActive(true);
            ascensorMineroAbajo.SetActive(false);
            //Active the script that need the key
            for (int i = 0; i < panelQuarries.Count; i++)
            {
                panelQuarries[i].enabled = true;
                activadorQuarries[i].enabled = true;
                quarries[i].ascensor = ascensorMineroArriba.GetComponent<AscensorMinero>();
            }
            //Don't have the key, the key Appear
            if (!StatusGameobjectsVariables.statusGameobject.modificacion[indexItem].modificacion)
            {
                itemSoldier.SetActive(true);
            }
            //Disable the script
            this.enabled = false;
        }
    }
}
