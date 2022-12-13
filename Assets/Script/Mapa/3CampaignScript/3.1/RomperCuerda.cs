using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RomperCuerda : MonoBehaviour
{
    [SerializeField]Rigidbody2D rbChild;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BalaPlayer") || collision.gameObject.CompareTag("B8")) rbChild.bodyType = RigidbodyType2D.Dynamic;
    }
}
