using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidFall : MonoBehaviour
{
    [SerializeField] VidaPlayer playerVida;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) playerVida.Daño(150);
    }

}
