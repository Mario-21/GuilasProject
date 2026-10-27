using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDirectionSoldier : MonoBehaviour
{
    [SerializeField] SoldadoNormal soldadoCode;
    [SerializeField] int indexSoldadoCode;
    void Start()
    {
        if (SoldierActiveInScene.instancia.soldiersStatus[indexSoldadoCode].statusVida > 0) 
        {
            soldadoCode.indexUbi = ClotheData.clotheInfo.numCloth;
            soldadoCode.transform.position = soldadoCode.ubicacionesDirigir[ClotheData.clotheInfo.numCloth].position;

        }
    }

}
