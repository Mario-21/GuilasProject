using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashSoldier : MonoBehaviour
{
    [Header("Soldado Vida")]
    public int indexSoldierLife;
    [Header("Soldado Desaparecer Item")]
    [SerializeField] List<GameObject> aparecerItem;
    [Header("Soldado Aparecer Item")]
    [SerializeField] List<GameObject> desaparecerItem;
    void Start()
    {
        //Cuando este vivo, el soldado se intercambia con el cadaver, simulando su muerte
        if(SoldierActiveInScene.instancia.soldiersStatus[indexSoldierLife].statusVida > 0)
        {
            Show_Delete_Items itemsProperties = new Show_Delete_Items();

            itemsProperties.DeleteItems(desaparecerItem);
            itemsProperties.ShowItems(aparecerItem);
        }
    }
}
