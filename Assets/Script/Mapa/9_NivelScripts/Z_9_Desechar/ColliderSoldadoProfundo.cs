using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderSoldadoProfundo : MonoBehaviour
{
    [SerializeField] CapsuleCollider2D colliderSoldado;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeepEnemy")) 
        {
            colliderSoldado.enabled = true;
            Debug.Log("Deep True;");
        } 
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeepEnemy")) 
        {
            colliderSoldado.enabled = false;
            Debug.Log("Deep False;");
        } 
    }
}
