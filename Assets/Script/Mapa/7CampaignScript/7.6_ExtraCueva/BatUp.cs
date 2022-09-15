using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatUp : MonoBehaviour
{
    [SerializeField] MoveBat batUp;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Antorcha"))
        {
            batUp.move_X = false;
        }
    }
}
