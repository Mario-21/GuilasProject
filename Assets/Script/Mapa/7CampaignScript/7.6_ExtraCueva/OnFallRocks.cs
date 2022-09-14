using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFallRocks : MonoBehaviour
{
    [SerializeField] RocksFall desprendimiento;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            desprendimiento.enabled = true;
        } 
    }
}
