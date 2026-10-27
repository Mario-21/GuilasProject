using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTime : MonoBehaviour
{
    public int indexModStopTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) StatusGameobjectsVariables.statusGameobject.modificacion[indexModStopTime].modificacion = true;
    }

}
