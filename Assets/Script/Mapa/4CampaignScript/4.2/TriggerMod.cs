using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMod : MonoBehaviour
{
    public int indexMod;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
    }
}
