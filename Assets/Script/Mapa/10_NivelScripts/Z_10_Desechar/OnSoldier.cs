using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSoldier : MonoBehaviour
{
    public int indexMod;
    [SerializeField] SoldadoNormal soldadoCode;
    [SerializeField] GameObject soldadoTrigger;

    private void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            soldadoCode.gameObject.SetActive(true);
            soldadoTrigger.SetActive(true);
        }
        else
        {
            soldadoCode.gameObject.SetActive(false);
            soldadoTrigger.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            soldadoCode.enabled = true;
        }
    }
}
