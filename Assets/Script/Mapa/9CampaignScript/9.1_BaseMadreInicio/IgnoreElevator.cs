using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreElevator : MonoBehaviour
{
    BoxCollider2D caja;
    private void Start()
    {
        caja = GetComponent<BoxCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Physics2D.IgnoreCollision(collision.collider, caja);
        }
    }
}
