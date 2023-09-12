using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class GoterasSound : MonoBehaviour
{
    [SerializeField] EventReference typeGoteo; 
    private void OnParticleCollision(GameObject other)
    {
        if(other.gameObject.layer == 9)
        {
            AudioManager.instancia.PlayOneShot(typeGoteo);
            Debug.Log("Gota Gota No mi");
        }
    }
}
