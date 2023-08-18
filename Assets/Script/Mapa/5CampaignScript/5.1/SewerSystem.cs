using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class SewerSystem : MonoBehaviour
{
    public int indexMod;

    [Header("Pozo Data")]
    [SerializeField] GameObject aqua;
    [SerializeField] Camino_CambiarZona pozoArea;
    [SerializeField] Events evento;

    [Header("Zona Sound Effect")]
    [SerializeField] EventReference soundDrain;
    [SerializeField] ZonaChangeSound zonaSound;
    int reproduceAudio;

    PlayerHere player;
    bool activeEvent;
    ActivarModificador activar;
    private void Awake()
    {
        activar = GetComponent<ActivarModificador>();
        player = GetComponent<PlayerHere>();
    }
    private void Start()
    {
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) Drain();
    }

    // Update is called once per frame
    void Update()
    {
        //This active the event one time, no more
        if (!StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion) ActionDrain();
        ExecuteDrain();
    }

    void ActionDrain()
    {
        //When you are here Drain() suscribe to events and on the switch
        if (player.playerImHere && activar.modificacion)
        {
            evento.actionOnCinematic += Drain;
            if (Input.GetButtonDown("Action"))
            {
                activeEvent = true;
                if(reproduceAudio < 1)
                {
                    AudioManager.instancia.PlayOneShot(soundDrain);
                    reproduceAudio++;
                }
            }
        }
        else evento.actionOnCinematic -= Drain;
    }

    void Drain()
    {
        //Make the action of event
        aqua.SetActive(false);
        pozoArea.enabled = true;
        zonaSound.enabled = true;
        StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        
    }
    void ExecuteDrain()
    {
        
        if (activeEvent)
        {
            evento.Cinematic(ref activeEvent);
        }
    }
}
