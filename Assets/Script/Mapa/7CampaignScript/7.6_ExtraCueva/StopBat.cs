using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBat : MonoBehaviour
{
    public int indexMod;
    [SerializeField] ParticleSystem bats;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Antorcha")) 
        {
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
            bats.Stop();
        }
    }
}
