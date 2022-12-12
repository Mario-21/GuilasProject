using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDirectionSoldier : MonoBehaviour
{
    [SerializeField] SoldadoNormal soldadoCode;
    void Start()
    {
        soldadoCode.indexUbi = ExtraVariable.extras.ubiSave;
    }
    private void OnDestroy()
    {
        ExtraVariable.extras.ubiSave = soldadoCode.indexUbi;
    }
}
