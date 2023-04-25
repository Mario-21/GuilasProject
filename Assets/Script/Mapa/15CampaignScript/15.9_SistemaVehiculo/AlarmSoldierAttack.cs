using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmSoldierAttack : MonoBehaviour
{
    public int indexMod;
    public List<SoldadoNormal> soldadosScene;
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            for(int e = 0; e < soldadosScene.Count; e++)
            {
                soldadosScene[e].berserker = true;
            }
        }
    }
}
