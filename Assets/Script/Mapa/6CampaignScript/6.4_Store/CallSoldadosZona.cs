using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallSoldadosZona : MonoBehaviour
{
    public List<SoldadoNormal> soldados;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BalaPlayer"))
        {
            for (int i = 0; i < soldados.Count; i++)
            {
                soldados[i].berserker = true;
            }
        }

    }
}
