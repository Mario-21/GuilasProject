using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Establecer_Checkpoint : MonoBehaviour
{
    public int checkpoint;
    bool checkpointOn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (checkpointOn)
        {
            CheckPointController.numeroCheckPoint = checkpoint;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            checkpointOn = true;
            Debug.Log("El checkpoint ha sido activado");
        }
    }
}
