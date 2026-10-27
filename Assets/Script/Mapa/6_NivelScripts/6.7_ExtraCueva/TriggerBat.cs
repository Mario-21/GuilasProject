using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBat : MonoBehaviour
{
    [SerializeField] MoveBat movimientoMurcielago;
    [SerializeField] GameObject conjuntoBat;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            conjuntoBat.SetActive(true);
            movimientoMurcielago.enabled = true;
            this.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Antorcha"))
        {
            Debug.Log("Doremi");
        }
    }
}
