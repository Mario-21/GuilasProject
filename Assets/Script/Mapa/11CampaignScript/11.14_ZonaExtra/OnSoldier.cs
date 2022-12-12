using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSoldier : MonoBehaviour
{
    [SerializeField] SoldadoNormal soldadoCode;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            soldadoCode.enabled = true;
        }
    }
}
