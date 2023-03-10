using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageWaterEnemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SoldierLife vidaEnemy = collision.gameObject.GetComponentInParent<SoldierLife>();
            vidaEnemy.vida = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SoldierLife enemyVida = collision.GetComponentInParent<SoldierLife>();
            enemyVida.vida = 0;
        }
    }
}
