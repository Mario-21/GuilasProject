using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class MovPlayerCin : MonoBehaviour
{
    //Rigibody2D y Animator del Player 
    Rigidbody2D rb;
    [HideInInspector] public Animator anim;

    [Header("Ubicación Dirigir")]
    public Transform ubiDirigirPlayer;

    [Header("Datos Movimiento")]
    public float horizontalMov;
    public float aceleracion;

    //Datos del Sonido
    EventInstance playerStepsGrass;
    DetectTypeFloor triggerFootSteps;

    [Header("Distancia Limite Ubicacion")]
    public float distanceAnularAnim;
    public bool movPlayerCin;
    private void Awake()
    {
        triggerFootSteps = GetComponentInChildren<DetectTypeFloor>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerStepsGrass = AudioManager.instancia.CreateEventInstance(triggerFootSteps.actualStepsSound);
        //DefinitionFloor();
        EstadoPlayerCin(ubiDirigirPlayer.position.x);
    }

    // Update is called once per frame
    void Update()
    {
        MovCin();
        GroundSoundSteps();
    }
    void MovCin()
    {
        Vector3 movePosition = transform.position;
        movePosition.x = Mathf.MoveTowards(transform.position.x, ubiDirigirPlayer.position.x, horizontalMov * aceleracion * Time.fixedDeltaTime);
        movePosition.y = transform.position.y;
        rb.MovePosition(movePosition);
        AnimacionCaminarPlayer(ubiDirigirPlayer.position.x);
    }
    void AnimacionCaminarPlayer(float objetivo)
    {
        if (transform.position.x < objetivo - distanceAnularAnim || transform.position.x > objetivo + distanceAnularAnim)
        {
            anim.SetBool("Player_Caminar", true);
            movPlayerCin = true;
        }
        else if (transform.position.x >= objetivo - distanceAnularAnim && transform.position.x <= objetivo + distanceAnularAnim)
        {
            anim.SetBool("Player_Caminar", false);
            movPlayerCin = false;
        }
    }
    void EstadoPlayerCin(float puntoDireccion)
    {
        if (transform.position.x < puntoDireccion - distanceAnularAnim || transform.position.x > puntoDireccion + distanceAnularAnim)
        {
            movPlayerCin = true;
        }
        else if (transform.position.x >= puntoDireccion - distanceAnularAnim && transform.position.x <= puntoDireccion + distanceAnularAnim)
        {
            movPlayerCin = false;
        }
    }
    void GroundSoundSteps()
    {
        Debug.Log("velocidad Player en cinematica es " + Mathf.Abs(rb.velocity.x));
        if (movPlayerCin)
        {
            PLAYBACK_STATE playbackState;
            playerStepsGrass.getPlaybackState(out playbackState);
            if (playbackState.Equals(PLAYBACK_STATE.STOPPED))
            {
                playerStepsGrass.start();
            }

        }
        else
        {
            playerStepsGrass.stop(STOP_MODE.ALLOWFADEOUT);
        }
    }

}
