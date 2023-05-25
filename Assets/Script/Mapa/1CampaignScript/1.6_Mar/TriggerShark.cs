using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerShark : MonoBehaviour
{
    public List<Sharks> sharks;
    bool sharksOn;

    public int endSharks;

    private void Update()
    {
        if(endSharks < 1)
        {
            if (sharksOn)
            {
                for (int w = 0; w < sharks.Count; w++)
                {
                    Debug.Log("Cantidad de Sharks Activadas " + w);
                    sharks[w].enabled = true;
                    if (w >= sharks.Count - 1)
                    {
                        endSharks++;
                        Debug.Log("Endless Shark w");
                    }
                }
            }
            else
            {
                for (int i = 0; i < sharks.Count; i++)
                {
                    Debug.Log("Cantidad de Sharks Desactivadas " + i);
                    sharks[i].enabled = false;
                    if (i >= sharks.Count - 1)
                    {
                        endSharks++;
                        Debug.Log("Endless Shark i");
                    }
                    
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sharksOn = true;
            endSharks = 0;
        }
    }  
}
