using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmaActive : MonoBehaviour
{
    public int indexMod;
    [SerializeField] Animator alarma;
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            alarma.SetBool("Alarm", true);
        }
    }
}
