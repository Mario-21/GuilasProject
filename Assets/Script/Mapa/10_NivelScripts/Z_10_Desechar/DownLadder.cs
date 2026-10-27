using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class DownLadder : MonoBehaviour
{
    PlayerHere player;
    public int indexMod;

    [Header("Escaleras")]
    public GameObject escalerasClose;
    public BoxCollider2D escalerasCloseColl;
    public GameObject escalerasDown;
    [Header("SFX Ladder")]
    [SerializeField] EventReference sfxLadderDown;
    [Header("Event Transition")]
    [SerializeField] Events evento;

    bool down;
    int soundLadder;
    void Start()
    {
        player = GetComponent<PlayerHere>();
        if (StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion)
        {
            //Bajas las escaleras 
            escalerasClose.SetActive(false);
            escalerasDown.SetActive(true);
            //Desactivas el collider para no volver activar las escaleras
            escalerasCloseColl.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ExecuteDownEscaleras();
        if (player.playerImHere)
        {
            evento.actionOnCinematic += DownEscaleras;
            if (Input.GetButtonDown("Action"))
            {
                down = true;
            }
        }
    }
    void ExecuteDownEscaleras()
    {
        if (down)
        {
            evento.Cinematic(ref down);
        }
    }
    void DownEscaleras()
    {
        //Bajas las escaleras 
        escalerasClose.SetActive(false);
        escalerasDown.SetActive(true);
        //Desactivas el collider para no volver activar las escaleras
        escalerasCloseColl.enabled = false;
        //Variable
        StatusGameobjectsVariables.statusGameobject.modificacion[indexMod].modificacion = true;
        //Bajar sound
        if(soundLadder < 1)
        {
            AudioManager.instancia.PlayOneShot(sfxLadderDown);
            soundLadder++;
        }
       
    }
}
