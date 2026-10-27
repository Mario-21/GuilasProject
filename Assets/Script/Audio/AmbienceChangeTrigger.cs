using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class AmbienceChangeTrigger : MonoBehaviour
{
    [Header("Area Ambience")]
    [SerializeField] private AmbienceArea ambienceArea;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Especificar al Player
        if (collision.gameObject.CompareTag("Player"))
        {
            if(AmbienceActual.ambienceNow != ambienceArea)
            {
                MusicAmbienceManager.instance.ChangeAmbienceManager(ambienceArea);
            }
            
        }
 
    }
}
