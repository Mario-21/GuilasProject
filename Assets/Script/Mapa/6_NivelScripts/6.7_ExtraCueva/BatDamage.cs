using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatDamage : MonoBehaviour
{
    bool damageBat;
    [SerializeField] VidaPlayer playerVida;
    float timeBetweenDamage;
    private void Update()
    {
        if (damageBat)
        {
            timeBetweenDamage += Time.deltaTime;
            if(timeBetweenDamage >= 0.4)
            {
                playerVida.Daño(10);
                timeBetweenDamage = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            damageBat = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            damageBat = false;
        }
    }

}
