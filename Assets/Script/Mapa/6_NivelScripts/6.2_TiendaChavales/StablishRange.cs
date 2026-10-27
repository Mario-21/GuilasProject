using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StablishRange : MonoBehaviour
{
    [Header("Conditions To Change Range")]
    [SerializeField] SoldierLife soldadoSwitch;
    [Header("Apply Range")]
    [SerializeField] SoldadoNormal soldadoNormal;
    [Header("Range")]
    public float outChange;
    public float insideChange;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if(soldadoSwitch.vida < 1)
            {
                soldadoNormal.outRange = outChange;
                soldadoNormal.insideRange = insideChange;
            }
        }
    }
}
