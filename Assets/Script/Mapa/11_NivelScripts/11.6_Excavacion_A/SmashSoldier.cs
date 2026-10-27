using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashSoldier : MonoBehaviour
{
    [Header("Soldado Vida")]
    public int indexSoldierLife;
    [Header("Estado Soldado")]
    [Tooltip("En que estado quieres que desparezcan los items")]
    public bool vivo;
    [Header("Soldado Aparecer Item")]
    [SerializeField] List<GameObject> aparecerItem;
    [Header("Soldado Desaparecer Item")]
    [SerializeField] List<GameObject> desaparecerItem;
    void Start()
    {
        Show_Delete_Items itemsProperties = new Show_Delete_Items();
        //Cuando este vivo, el soldado se intercambia con el cadaver, simulando su muerte
        if (SoldierActiveInScene.instancia.soldiersStatus[indexSoldierLife].statusVida > 0 && vivo)
        {
            Debug.Log("Soldado Asignado " + indexSoldierLife + " esta vivo");

            itemsProperties.DeleteItems(desaparecerItem);
            itemsProperties.ShowItems(aparecerItem);
        }
        //Si estoy muerto, 
        else if(SoldierActiveInScene.instancia.soldiersStatus[indexSoldierLife].statusVida <= 0 && !vivo)
        {
            Debug.Log("Soldado Asignado " + indexSoldierLife + " esta muerto");

            itemsProperties.DeleteItems(desaparecerItem);
            itemsProperties.ShowItems(aparecerItem);
        }
    }
}
