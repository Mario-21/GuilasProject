using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDirectionSoldier : MonoBehaviour
{
    [SerializeField] SoldadoNormal soldadoCode;
    void Start()
    {
        soldadoCode.indexUbi = ClotheData.clotheInfo.numCloth;
        soldadoCode.transform.position = soldadoCode.ubicacionesDirigir[ClotheData.clotheInfo.numCloth].position;
    }

}
