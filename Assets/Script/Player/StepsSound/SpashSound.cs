using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpashSound : MonoBehaviour
{
    public bool onWet;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            onWet = true;
            AudioManager.instancia.PlayOneShot(FMODEvent.instancia.splashWater);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            onWet = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            onWet = false;
        }
    }
}
