using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salida : MonoBehaviour
{
    public int indexMod;
    [SerializeField] BoxCollider2D puertaCollider;
    private void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            puertaCollider.enabled = false;
            this.enabled = false;
        }
    }
    private void Update()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            puertaCollider.enabled = false;
        }
    }
}
