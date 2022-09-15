using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocaCollider : MonoBehaviour
{
    public string nameTag;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) Destroy(this.gameObject);

        if (collision.gameObject.tag == nameTag)
        {
            Destroy(this.gameObject);
        }
    }
}
