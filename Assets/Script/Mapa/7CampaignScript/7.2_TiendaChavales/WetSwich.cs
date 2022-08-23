using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WetSwich : MonoBehaviour
{
    public int indexMod;
    public GameObject water;
    ActivarModificador activar;
    CeiilingFan ceiiling;
    
    void Start()
    {
        activar = GetComponent<ActivarModificador>();
        ceiiling = GetComponent<CeiilingFan>();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) SwitchWet();
    }
    void Update()
    {
        if (activar.modificacion) SwitchWet();
    }
    void SwitchWet()
    {
        water.SetActive(true);
        StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        ceiiling.onCeilingFan = false;
        ceiiling.enabled = false;
    }
}
