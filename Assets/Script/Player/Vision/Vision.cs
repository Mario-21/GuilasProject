using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    [Header("Vida Player")]
    [SerializeField] VidaPlayer vida;
    public GameObject visionShadder;
    [HideInInspector] public bool visiOn;
    void Start()
    {
        visionShadder = GameObject.FindGameObjectWithTag("Respawn");
        visiOn = false;
    }
    void Update()
    {
        if(vida.vidaActual > 0)
        {
            ActiveVision();
            OnVision();
        }
        else if (vida.vidaActual <= 0)
        {
            //comprobar si al morir y resetear la escena funciona.
            //Si mueres teniendo la Vision activa,quiere decir que la vision existe, por tanto, hay que desactivar la
            if(visionShadder.activeInHierarchy)
            {
                visiOn = false;
                Debug.Log("Esta activo, por tanto, desactiva lo");
                AudioManager.instancia.PlayOneShot(FMODEvent.instancia.visionModeOff);
                visionShadder.SetActive(false);
            }
        }
    }
    void ActiveVision()
    {
        if (Input.GetButtonDown("Vision"))
        {
            visiOn = !visiOn;


            if (visiOn) AudioManager.instancia.PlayOneShot(FMODEvent.instancia.visionModeOn);
            else AudioManager.instancia.PlayOneShot(FMODEvent.instancia.visionModeOff);
            //AudioManager.instancia.PlayOneShot(visionSFX);
        }
    }
    void OnVision()
    {
        if (visiOn)
        {
            visionShadder.SetActive(true);
        }
        else
        {
            visionShadder.SetActive(false);
        }
    }
}
