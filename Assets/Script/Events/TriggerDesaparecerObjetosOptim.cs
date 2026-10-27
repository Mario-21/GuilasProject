using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDesaparecerObjetosOptim : MonoBehaviour
{
    public List<GameObject> objetosOptimDesAp;
    bool optim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (optim)
        {
            foreach (GameObject objeto in objetosOptimDesAp)
            {
                objeto.SetActive(false);
            }
            this.enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            optim = true;
        }
    }
}
