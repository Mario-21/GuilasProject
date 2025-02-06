using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class LostAllVida : MonoBehaviour
{
    [Header("Datos Player")]
    [SerializeField] VidaPlayer playerVida;
    [SerializeField] BloquearMovimientoPlayer playerBlock;
    [Header("Datos Daño")]
    public float damage;
    public EventReference soundDamage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerVida.Daño(damage);
            AudioManager.instancia.PlayOneShot(soundDamage);
        }
    }
}
