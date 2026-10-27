using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChef : MonoBehaviour
{
    [SerializeField] BoxCollider2D triggerActDetectorOut;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            triggerActDetectorOut.enabled = true;
        }
    }
}
