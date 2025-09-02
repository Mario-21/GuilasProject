using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class SewerSystem : MonoBehaviour
{
    public int indexMod;

    [Header("Boton Generador")]
    [SerializeField] SpriteRenderer boton_Generador;
    [SerializeField] Color color_Gen_On;
     
    [Header("Pozo Data")]
    [SerializeField] GameObject aqua;
    [SerializeField] Camino_CambiarZona pozoArea;
    [SerializeField] Events evento;

    [Header("Zona Sound Effect")]
    [SerializeField] EventReference soundDrain;
    //[SerializeField] ZonaChangeSound zonaSound;
    int reproduceAudio;

    PlayerHere player;
    bool activeEvent;
    //No puedes tomar como referencia el ActivarModificador dado que si sales de la escena, el script no
    //podrá volver a ejecutarse a no ser que el objeto tenga más de un uso, y aun así, el nivel ya estaría roto.
    //[SerializeField] ActivarModificador activar;
    private void Awake()
    {
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
        if (player.playerImHere)
        {
            evento.actionOnCinematic += Drain;
            if (Input.GetButtonDown("Action"))
            {
                activeEvent = true;
                if(reproduceAudio < 1)
                {
                    boton_Generador.color = color_Gen_On;
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
        boton_Generador.color = color_Gen_On;
        pozoArea.enabled = true;
        //zonaSound.enabled = true;
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
