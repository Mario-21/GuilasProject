using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCambiarAreaPlayer : MonoBehaviour
{
    [SerializeField] BoxCollider2D areaCambiar;
    bool onArea;
    void Update()
    {
        AreaOn();
    }
    void AreaOn()
    {
        if (onArea)
        {
            areaCambiar.enabled = true;
        }
        else
        {
            areaCambiar.enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onArea = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onArea = false;
        }
    }
}
