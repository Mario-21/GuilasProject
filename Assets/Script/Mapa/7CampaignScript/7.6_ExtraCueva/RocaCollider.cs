using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocaCollider : MonoBehaviour
{
    public string tagname;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) Destroy(this.gameObject);

        if (collision.gameObject.tag == tagname)
        {
            Destroy(this.gameObject);
        }
    }
}
