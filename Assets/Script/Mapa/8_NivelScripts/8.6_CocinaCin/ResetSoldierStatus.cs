using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSoldierStatus : MonoBehaviour
{
    [SerializeField] List<SoldadoNormal> soldadosDefault;
    void Start()
    {
        for (int i = 0; i < soldadosDefault.Count; i++)
        {
            soldadosDefault[i].berserker = false;
        }
        
    }
}
