using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActivarSoldado : MonoBehaviour
{
    public int indexMod;
    [SerializeField] SoldadoNormal soldadoPractica;
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            soldadoPractica.enabled = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            soldadoPractica.enabled = true;
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        }
    }
}
