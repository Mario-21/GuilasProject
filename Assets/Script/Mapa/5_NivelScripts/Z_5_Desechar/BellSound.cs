using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class BellSound : MonoBehaviour
{
    public int indexMod;
    public EventReference sound;
    bool bellSound;


    int soundOnlyOne;
    void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) this.enabled = false;
    }
    void Update()
    {
        if(!StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) BellRest();
    }
    void BellRest()
    {
        if (bellSound)
        {
            if(soundOnlyOne < 1)
            {
                //Reproduce the audioCLip BellSound only once 
                AudioManager.instancia.PlayOneShot(sound);
                soundOnlyOne++;
            }
            StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) bellSound = true;
    }
}
