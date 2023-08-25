using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class RocaCollider : MonoBehaviour
{
    public string nameTag;
    [SerializeField] EventReference rocaSFX;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) Destroy(this.gameObject);

        if (collision.gameObject.tag == nameTag)
        {
            AudioManager.instancia.PlayOneShot(rocaSFX);
            Destroy(this.gameObject);
        }
    }
}
