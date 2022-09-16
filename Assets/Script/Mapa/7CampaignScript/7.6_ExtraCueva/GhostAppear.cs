using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAppear : MonoBehaviour
{
    public int indexMod;
    [Header("Ghost Info")]
    public GameObject ghost;
    [SerializeField] Ghost ghostComp;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Si todavia no ha aparecido
            if (!StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
            {
                ghost.SetActive(true);
                ghostComp.enabled = true;
            }
            
        }
    }
}
