using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlayerFall : MonoBehaviour
{
    [SerializeField] VidaPlayer vida;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            vida.Daño(150);
        }
    }
}
