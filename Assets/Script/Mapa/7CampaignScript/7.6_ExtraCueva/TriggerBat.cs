using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBat : MonoBehaviour
{
    [SerializeField] MoveBat movimientoMurcielago;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            movimientoMurcielago.enabled = true;
            movimientoMurcielago.move_X = true;
        }
        if (collision.gameObject.CompareTag("Antorcha"))
        {
            Debug.Log("Doremi");
        }
    }
}
