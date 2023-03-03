using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalancaMantenimiento : MonoBehaviour
{
    public int indexMod;
    [Header("Palanca Mantenimiento On")]
    public GameObject palancaOn;
    [Header("Palanca Mantenimiento Off")]
    public GameObject palancaOff;
    void Update()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            palancaOff.SetActive(false);
            palancaOn.SetActive(true);
            this.enabled = false;
        }
    }
}
